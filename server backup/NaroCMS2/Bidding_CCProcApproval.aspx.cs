using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;

public partial class Bidding_PendingProcurements : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "33";
    private int areaID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadOfficers(); LoadProcMethod();
                MultiView1.ActiveViewIndex = 0;
                DisableBtnsOnClick();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        btnSubmit.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnSubmit, "").ToString());
    }
    private void LoadOfficers()
    {
        cboProcurementOfficer.DataSource = ProcessReq.GetPDUMembers();
        cboProcurementOfficer.DataValueField = "UserID";
        cboProcurementOfficer.DataTextField = "Name";
        cboProcurementOfficer.DataBind();
    }
    private void LoadProcMethod()
    {
        datatable = ProcessPlan.GetProcurementMethods();
        cboProcMethod.DataSource = datatable;
        cboProcMethod.DataValueField = "MethodCode";
        cboProcMethod.DataTextField = "Method";
        cboProcMethod.DataBind();
    }
    private void LoadAreas()
    {
        datatable = data.GetAreas();
        cboAreas.DataSource = datatable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();

        LoadCostCenters(cboAreas.SelectedIndex);
    }
    private void ToggleCenter()
    {
        int AccessLevelID = Convert.ToInt32(Session["AccessLevelID"].ToString());
        string AreaID = Session["AreaCode"].ToString();
        cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(AreaID));
    }
    private void LoadCostCenters(int AreaID)
    {
        string AreaCode = AreaID.ToString();
        datatable = ProcessPlan.GetCostCentersByName("", AreaCode);
        cboCostCenters.DataSource = datatable;
        cboCostCenters.DataValueField = "CostCenterID";
        cboCostCenters.DataTextField = "CostCenterDesc";
        cboCostCenters.DataBind();
    }
    private void LoadItems()
    {
        string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim();
        string ProcMethod = cboProcMethod.SelectedValue.ToString(); string ProcOfficer = cboProcurementOfficer.SelectedValue.ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();
        
        datatable = Process.GetCCProcurements(RecordID, PrNumber, ProcOfficer, ProcMethod, Status, AreaCode, CostCenterCode);
        
        if (datatable.Rows.Count > 0)
        {
            lblCC.Text = datatable.Rows[0]["CCDescription"].ToString();
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind(); DataGrid1.Visible = true;
            lblEmpty.Text = ".";
        }
        else
        {
            MultiView1.ActiveViewIndex = 0; DataGrid1.Visible = false;
            string EmptyMessage = "No Procurement(s) For CC Approval in the system From Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
            lblEmpty.Text = EmptyMessage;
        }
    }
    private void ShowMessage(string Message)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        if (Message == ".")
        {
            msg.Text = ".";
        }
        else
        {
            msg.Text = "MESSAGE: " + Message;
        }
    }
    private void LoadControls(string PRNumber)
    {
        datatable = Process.GetCCProcurements("0", PRNumber, "0", "0", "", "", "");
        if (datatable.Rows.Count > 0)
        {
            txtReferenceNo.Text = datatable.Rows[0]["ScalaPRNumber"].ToString();
            txtEstimatedCost.Text = Convert.ToDouble(datatable.Rows[0]["EstimatedCost"]).ToString("#,##0");
            txtProcSubject.Text = datatable.Rows[0]["Subject"].ToString();
            txtProcType.Text = datatable.Rows[0]["ProcurementType"].ToString();
            txtProcMethod.Text = datatable.Rows[0]["Method"].ToString();
            txtDateRequisitioned.Text = datatable.Rows[0]["CreationDate"].ToString();
            txtRequisitioner.Text = datatable.Rows[0]["Requisitioner"].ToString();
            txtDateRequired.Text = datatable.Rows[0]["DateRequired"].ToString();
            txtBudgetCostCenter.Text = datatable.Rows[0]["CostCenterName"].ToString();
            lblStatus.Text = datatable.Rows[0]["StatusID"].ToString();
            lblECPreviousStatus.Text = datatable.Rows[0]["ECPreviousStatusID"].ToString();
            areaID = int.Parse(datatable.Rows[0]["CreatedBy"].ToString());
        }
        ClearApprovalControls();
    }
    private void LoadApprovalOptions(int StatusID)
    {
        datatable = Process.GetCCApprovalOptions(StatusID);
        if (datatable.Rows.Count > 0)
        {
            rbnSubmission.DataSource = datatable;
            rbnSubmission.DataValueField = "OptionID";
            rbnSubmission.DataTextField = "ApprovalOption";
            rbnSubmission.DataBind();
        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            LoadControls(PRNumber);       
            string Subject = e.Item.Cells[3].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            string Form = Process.GetForm(ProcMethodCode);
            lblHeading.Text = Subject + " - [" + Form + "]";
            lblProcMethod.Text = ProcMethodCode.ToString();
            lblRefNo.Text = PRNumber;

            if (e.CommandName == "btnViewDetails")
            {
                
                MultiView1.ActiveViewIndex = 2;
                MultiView2.ActiveViewIndex = 0;
                if (lblStatus.Text.ToString().Equals("120")) {

                    btnViewBidders.Visible = false;
                    btnViewEC.Visible = false;
                    btnViewBidders.Text = "No bids Received";
                    Label1.Visible = true;
                    btnSubmit.Text = "REJECT/ CANCELTHIS PROCUREMENT";
                    rbnApproval.SelectedIndex = 2;
                    rbnApproval.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void ClearApprovalControls()
    {
        txtCCRefNo.Text = ""; txtComment.Text = ""; lblApprovals.Visible = false; rbnSubmission.Visible = false;
        rbnSubmission.SelectedIndex = -1; rbnApproval.SelectedIndex = -1;
    }
    private void LoadAnsweredFormGrid()
    {
        dgvFormDetails.DataSource = datatable;
        dgvFormDetails.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboCostCenter_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("- - All Cost Centers - -", "0"));
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int AreaID = Convert.ToInt32(cboAreas.SelectedValue.ToString());
        LoadCostCenters(AreaID);
    }
    protected void cboAreas_DataBound1(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem(" -- All Areas -- ", "0"));
    }
    private void LoadGrid(string ReferenceNo, string ProcMethod, string Section)
    {   
        datatable = Process.GetGridAnswers(ReferenceNo, ProcMethod, Section);
        dgvQuestions.DataSource = datatable;
        dgvQuestions.DataBind();
        if (datatable.Rows.Count > 0)
            btnPrint.Enabled = true;
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            if (dgvQuestions.Rows.Count == 0)
            {
                ShowMessage("There is no data for the report ...");
            }
            else
            {
                if (txtProcMethod.Text.Contains("Micro"))
                {


                    string ReferenceNo = lblRefNo.Text.Trim();
                    int ProcMethod = Convert.ToInt32(lblProcMethod.Text.Trim());
                    ShowMessage("" + ProcMethod.ToString());
                    datatable = Process.GetFormNumberByProcMethod(ProcMethod, 1);

                    string FormNumber = datatable.Rows[0]["FormNumber"].ToString();
                    string Section = lblSection.Text.Trim();
                    int NewProcMethod = ReturnProcMethod(ProcMethod);
                    string ReportName = Process.GetReportName(NewProcMethod, FormNumber, Section, true);

                    //   ShowMessage(ReportName);
                    datatable = Process.GetForm1ForReport(ReferenceNo, FormNumber, Section);
                    int rowcount = datatable.Rows.Count;

                    if (rowcount != 0)
                    {
                        btnPrint.Enabled = true;
                        loadreport(ReportName);

                        Response.Buffer = false;
                        Response.ClearContent();
                        Response.ClearHeaders();
                        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, ReportName);
                    }
                    else
                    {
                        ShowMessage("No Data To Load For Report Form Selected ...");
                    }
                }
                else
                {

                    string ReferenceNo = lblRefNo.Text.Trim();

                    string ReportName = "";
                    string section = "";
                    if (txtProcType.Text.Equals("CONSULTATIONAL SERVICES"))
                    {
                        ReportName = "form18";
                        section = "H";
                    }
                    else
                    {
                        ReportName = "form5";
                        section = "G";

                    }
                    btnPrint.Enabled = true;

                    loadreports(ReportName, ReferenceNo, areaID, section);
                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, ReportName);


                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private int ReturnProcMethod(int ProcurementMethod)
    {
        int NewMthd = 0;
        switch (ProcurementMethod)
        {
            case 3:
                NewMthd = 2;
                break;
            case 6:
                NewMthd = 5;
                break;
            default:
                NewMthd = ProcurementMethod;
                break;
        }
        return NewMthd;
    }
    public void loadreport(string ReportName)
    {
        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\Bidding\\" + ReportName + ".rpt";

        //doc.Load(rptName);
        //doc.SetDataSource(datatable);

        Hidetoolbar();
        //CrystalReportViewer1.ReportSource = doc;
    }

    public void loadreports(string ReportName, string refno, int areaid, string section)
    {
        DataTable dtFormDetails = new DataTable();
        DataTable dtSectionAnswers = new DataTable();

        dtFormDetails = Process.GetFormDetails(refno, areaid);

        dtSectionAnswers = Process.GetSectionAnswers(section, refno);


        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\Bidding\\newreports\\" + ReportName + ".rpt";
        //doc.Load(rptName);
        //doc.Database.Tables[0].SetDataSource(dtFormDetails);
        //doc.Database.Tables[1].SetDataSource(dtSectionAnswers);
        //doc.Subreports[0].SetDataSource(dtSectionAnswers);

        Hidetoolbar();
        //CrystalReportViewer1.ReportSource = doc;
    }
    private void Hidetoolbar()
    {
        //CrystalReportViewer1.HasPrintButton = false;
        //CrystalReportViewer1.HasCrystalLogo = false;
        //CrystalReportViewer1.HasDrillUpButton = false;
        //CrystalReportViewer1.HasExportButton = false;
        //CrystalReportViewer1.HasRefreshButton = false;
        //CrystalReportViewer1.HasViewList = false;
        //CrystalReportViewer1.HasZoomFactorList = false;
    }
    protected void btnFiles_Click(object sender, EventArgs e)
    {

    }
    protected void dgvQuestions_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void Page_Unload(object sender, EventArgs e)
    {
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //    GC.Collect();
        //}
    }
    protected void dgvFormDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnView")
        {
            int intIndex = Convert.ToInt32(e.CommandArgument);
            string Section = Convert.ToString(dgvFormDetails.DataKeys[intIndex].Value);
            lblSection.Text = Section;
            LoadGrid(lblRefNo.Text.Trim(), lblProcMethod.Text.Trim(), Section);
        }
    }
    protected void cboPDUSupervisors_DataBound(object sender, EventArgs e)
    {

    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        MultiView2.ActiveViewIndex = 0;
    }
    protected void btnPrintBidders_Click(object sender, EventArgs e)
    {
        try
        {
            string ReportName = "BidderShortlist32";
            string ReferenceNo = txtReferenceNo.Text.Trim();
            datatable = Process.GetReportForShortlistedBidders(ReferenceNo);
            int rowcount = datatable.Rows.Count;

            if (rowcount != 0)
            {
                loadreport(ReportName);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Shortlist of Bidders F32");
            }
            else
            {
                ShowMessage("No Data To Load For Report ... ");
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnPrintEC_Click(object sender, EventArgs e)
    {
        try
        {
            string ReportName = "ECMembers40";
            string ReferenceNo = txtReferenceNo.Text.Trim();
            datatable = Process.GetReportForECMembers(ReferenceNo);
            int rowcount = datatable.Rows.Count;

            if (rowcount != 0)
            {
                loadreport(ReportName);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Shortlist of Bidders F32");
            }
            else
            {
                ShowMessage("No Data To Load For Report ... ");
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnFormDetails_Click(object sender, EventArgs e)
    {
        datatable = Process.GetAnsweredFormDetails(txtReferenceNo.Text.Trim());
        if (datatable.Rows.Count > 0)
            LoadAnsweredFormGrid();
        MultiView2.ActiveViewIndex = 1;
    }
    protected void btnViewBidders_Click(object sender, EventArgs e)
    {
        datatable = Process.GetShortlistedBidderDetails(txtReferenceNo.Text.Trim());
        if (datatable.Rows.Count > 0)
        {
            gvBidders.DataSource = datatable;
            gvBidders.DataBind();
            btnPrintBidders.Enabled = true;
        }
        MultiView2.ActiveViewIndex = 2;
    }
    protected void btnViewEC_Click(object sender, EventArgs e)
    {
        datatable = Process.GetECMemberDetails(txtReferenceNo.Text.Trim());
        if (datatable.Rows.Count > 0)
        {
            gvEC.DataSource = datatable;
            gvEC.DataBind();
            btnPrintEC.Enabled = true;
        }
        MultiView2.ActiveViewIndex = 3;
    }
    private void UploadFiles(string ReferenceNo)
    {
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        int countfiles = 0;
        for (int i = 0; i <= (uploads.Count - 1); i++)
        {
            if (uploads[i].ContentLength > 0)
            {
                string c = System.IO.Path.GetFileName(uploads[i].FileName);
                string cNoSpace = c.Replace(" ", "-");
                string c1 = ReferenceNo + "_" + (countfiles + i + 1) + "_" + cNoSpace;
                string Path = Process.GetDocPath();
                FileField.PostedFile.SaveAs(Path + "" + c1);
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 3);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        if (txtCCRefNo.Text.Trim() == "")
            ShowMessage("Please Enter CC Meeting Reference No.");
        else if ((rbnApproval.SelectedValue == "46" || rbnApproval.SelectedValue == "47") && txtComment.Text.Trim() == "")
            ShowMessage("Please Enter Comment/Remark For Deferring OR Rejection of Procurement");
        //else if (rbnApproval.SelectedValue == "45" && rbnSubmission.SelectedIndex == -1)
        //   ShowMessage("Please Select The Contracts Committee Approval Option");
        else
        {
            string procmethod = txtProcMethod.Text.ToString();
            string CCMeetingRefNo = Regex.Replace(txtCCRefNo.Text.Trim(), "[^A-Za-z0-9]", "");
            UploadFiles(CCMeetingRefNo);

            int StatusID = Convert.ToInt32(rbnApproval.SelectedValue);
            int CCDecisionID = 0;
            if (StatusID == 45)
                CCDecisionID = 1;
            else if (StatusID == 47)
                CCDecisionID = 2;
            else if (StatusID == 46)
                CCDecisionID = 3;

            // Notify Requisitioner, Proc. Officer and CC Members
            string ReferenceNo = txtReferenceNo.Text.Trim(); string CCMember = HttpContext.Current.Session["FullName"].ToString();
            DataTable dtAlert = Process.GetBiddingDetailsForNotification(ReferenceNo);
            string Subject = "Procurement " + dtAlert.Rows[0]["Subject"].ToString() + " Submission To Contracts Committee";
            string OfficerID = dtAlert.Rows[0]["POID"].ToString(); string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
            string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString(); string ContractsCommittee = dtAlert.Rows[0]["CCDescription"].ToString();
            long CCID = Convert.ToInt64(dtAlert.Rows[0]["CCID"].ToString());


            int CCAprovaloption = 1;
            int prmthd = int.Parse(lblProcMethod.Text.ToString());
            //**********************
            if ((prmthd == 2) || (prmthd == 3) || (prmthd == 12))
            {
                CCAprovaloption = 4;
            }
            else if ((prmthd == 4) || (prmthd == 7) || (prmthd == 14))
            {
                CCAprovaloption = 2;
            }
            else if ((prmthd == 5) || (prmthd == 6) || (prmthd == 13))
            {
                CCAprovaloption = 1;
            }
            else if ((prmthd == 10) || (prmthd == 15))
            {
                CCAprovaloption = 3;
            }

            Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCID, CCDecisionID, CCAprovaloption.ToString(), txtComment.Text.Trim(), 1);
            // Submitted for Evaluation Committee Approval
            if (StatusID == 44)
            {
                int PreviousStatus = Convert.ToInt32(lblECPreviousStatus.Text);
               
              

                    Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 79, "Procurement Successfully Approved");
               
            }
            else
            {
                if (procmethod.Equals("Request For Proposal")&& !(lblStatus.Text.ToString().Equals("120")))
                {
                    Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 76, txtComment.Text.Trim());
                }
                else
                {

                    Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), StatusID, txtComment.Text.Trim());
                }
            }
            string Message = "", DisplayMessage = "";
            if (StatusID == 45)
            {
                Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + "</strong> from " + CostCenterName + " has been successfully approved by " + ContractsCommittee + " ( " + CCMember + " ) </p>";
                DisplayMessage = "Procurement Has Been Successfully Approved ...";
            }
            else if (StatusID == 47)
            {
                Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + "</strong> from " + CostCenterName + " has been deferred by " + ContractsCommittee + " ( " + CCMember + " ) </p>";
                DisplayMessage = "Procurement Has Been Deferred ...";
            }
            else if (StatusID == 46)
            {
                Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + "</strong> from " + CostCenterName + " has been rejected / cancelled by " + ContractsCommittee + " ( " + CCMember + " ) </p>";
                DisplayMessage = "Procurement Has Been Rejected ...";
            }
            Message += "<p>Comment: " + txtComment.Text.Trim() + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

            // PP Forms BackUp For Cross Reference 
            BackUpSubmittedForms(ReferenceNo);

            // Notify Requisitioner
            ProcessPlan.NotifyPlanner(CCMember, Subject, Requisitioner, Message);
            // Notify Procurement Officer
            ProcessReq.NotifyOfficer(CCMember, Subject, OfficerID, Message);
            ShowMessage(DisplayMessage +" Reference Number: "+ txtReferenceNo.Text.Trim());
            MultiView1.ActiveViewIndex = 0;
            LoadItems();
        }
    }
    private void BackUpSubmittedForms(string ReferenceNo)
    {
        string BackUpPath = Process.GetBiddingFormDocPath();
        string ActualPath = String.Format("{0}\\{1}\\", BackUpPath, ReferenceNo);
        Process.CheckPath(ActualPath);
        datatable = Process.GetReportForECMembers(ReferenceNo);
        if (datatable.Rows.Count > 0)
        {
            loadreport("ECMembers40");
            //doc.ExportToDisk(ExportFormatType.PortableDocFormat, ActualPath + "PPForm40_" + Regex.Replace(txtCCRefNo.Text.Trim(), "[^A-Za-z0-9]", "") +  "_" + Regex.Replace(DateTime.Now.ToString(), "[^A-Za-z0-9]", "") + ".pdf");
        }
        datatable = Process.GetReportForShortlistedBidders(ReferenceNo);
        if (datatable.Rows.Count > 0)
        {
            loadreport("BidderShortlist32");
            //doc.ExportToDisk(ExportFormatType.PortableDocFormat, ActualPath + "PPForm32_" + Regex.Replace(txtCCRefNo.Text.Trim(), "[^A-Za-z0-9]", "") +  "_" + Regex.Replace(DateTime.Now.ToString(), "[^A-Za-z0-9]", "") + ".pdf");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnViewSolDocs_Click(object sender, EventArgs e)
    {
        MultiView2.ActiveViewIndex = 4;
        lblAttachRefNo.Text = txtReferenceNo.Text;
        lblHeaderMsg.Text = txtProcSubject.Text;
        LoadDocuments();
    }
    protected void cboProcurementOfficer_DataBound(object sender, EventArgs e)
    {
        cboProcurementOfficer.Items.Insert(0, new ListItem(" -- All Proc. Officers -- ", "0"));
    }
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods --", "0"));
    }
    protected void rbnApproval_SelectedIndexChanged(object sender, EventArgs e)
    {
        int StatusID = Convert.ToInt32(rbnApproval.SelectedValue);
        if (StatusID == 45)
        {
            rbnSubmission.Visible = true;
            lblApprovals.Visible = true;
           // LoadApprovalOptions(45);
        }
        else
        {
            lblApprovals.Visible = false; rbnSubmission.Visible = false;
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView2.ActiveViewIndex = 0;
    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                Process.RemoveDocument(FileCode);
                LoadDocuments();
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                string Path = Process.GetDocumentPath(FileCode);
                Process.DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadDocuments()
    {
        MultiView2.ActiveViewIndex = 4;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments(RefNo, 1);
        if (datatable.Rows.Count > 0)
        {
            GridAttachments.DataSource = datatable;
            GridAttachments.DataBind();
            GridAttachments.Visible = true;
            lblNoAttachments.Visible = false;
        }
        else
        {
            lblNoAttachments.Visible = true;
            GridAttachments.Visible = false;
        }
    }
}
