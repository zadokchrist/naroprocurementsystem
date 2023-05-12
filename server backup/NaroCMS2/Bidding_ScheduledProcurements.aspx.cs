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
public partial class Bidding_ScheduledProcurements : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "33";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadOfficers(); LoadProcMethod();
                if (Request.QueryString["transferid"] != null)
                {
                    txtPrNumber.Text = Session["PRNumber"].ToString();
                    cboProcMethod.SelectedIndex = cboProcMethod.Items.IndexOf(cboProcMethod.Items.FindByValue(Session["ProcMethod"].ToString()));
                    cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(Session["Area"].ToString()));
                    cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(Session["CostCenter"].ToString()));
                    LoadItems(); MultiView1.ActiveViewIndex = 2;
                    ClearApprovalControls();
                    LoadControls(Session["PRNumber"].ToString());
                    int ProcMethodCode = Convert.ToInt32(Session["ProcMethod"].ToString());
                    string Form = Process.GetForm(ProcMethodCode);
                    lblHeading.Text = txtProcSubject.Text + " - [" + Form + "]";
                    lblProcMethod.Text = ProcMethodCode.ToString();
                    lblRefNo.Text = txtReferenceNo.Text;

                    if (Session["PreviousPage"].ToString() == "Bidding_ShortlistBidders.aspx")
                        btnViewBidders_Click(this, e);
                    else if (Session["PreviousPage"].ToString() == "Bidding_NewEvaluationCommittee.aspx")
                        LoadControls(Session["PRNumber"].ToString()); btnViewEC_Click(this, e);
                }
                else
                    MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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

        datatable = Process.GetCCScheduledProcurements(RecordID, PrNumber, ProcOfficer, ProcMethod, Status, AreaCode, CostCenterCode);
        
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind(); DataGrid1.Visible = true;
            lblEmpty.Text = ".";
        }
        else
        {
            MultiView1.ActiveViewIndex = 0; DataGrid1.Visible = false;
            string EmptyMessage = "No Procurement(s) Ready For Submission To Contracts Committee in the system From Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
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
        datatable = Process.GetLevelProcurements("0", PRNumber, "0", "0", "", "", "");
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
        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            ClearApprovalControls();
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
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void ClearApprovalControls()
    {
        ShowMessage(".");
        rbnApproval.SelectedIndex = -1; txtComment.Text = "";
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
            ShowMessage(".");
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
                string ReferenceNo = lblRefNo.Text.Trim();
                int ProcMethod = Convert.ToInt32(lblProcMethod.Text.Trim());
                datatable = Process.GetFormNumberByProcMethod(ProcMethod, 1);

                string FormNumber = datatable.Rows[0]["FormNumber"].ToString();
                string Section = lblSection.Text.Trim();
                int NewProcMethod = ReturnProcMethod(ProcMethod);
                string ReportName = Process.GetReportName(NewProcMethod, FormNumber, Section, true);

                datatable = Process.GetForm1ForReport(ReferenceNo, FormNumber, Section);
                int rowcount = datatable.Rows.Count;

                if (rowcount != 0)
                {
                    btnPrint.Enabled = true;
                    loadreport(ReportName);

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "PPForm");
                }
                else
                {
                    ShowMessage("No Data To Load For Report Form Selected ...");
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

        //Hidetoolbar();
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
    protected void btnDone_Click(object sender, EventArgs e)
    {
        DataTable dtcancel = new DataTable();
        dgvFormDetails.DataSource = dtcancel;
        dgvFormDetails.DataBind();
        DataTable dtcancel2 = new DataTable();
        dgvQuestions.DataSource = dtcancel2;
        dgvQuestions.DataBind();
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
        {
            LoadAnsweredFormGrid();
        }
        else {

            DataTable dtcancel = new DataTable();
            dgvFormDetails.DataSource = dtcancel;
            dgvFormDetails.DataBind();
            DataTable dtcancel2 = new DataTable();
            dgvQuestions.DataSource = dtcancel2;
            dgvQuestions.DataBind();
        }
        MultiView2.ActiveViewIndex = 1;
    }
    protected void btnViewBidders_Click(object sender, EventArgs e)
    {
        datatable = Process.GetShortlistedBidderDetails(txtReferenceNo.Text.Trim());
        if (datatable.Rows.Count > 0)
        {
            gvBidders.DataSource = datatable;
            gvBidders.DataBind();
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
        }
        MultiView2.ActiveViewIndex = 3;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (rbnApproval.SelectedValue == "32" && txtComment.Text.Trim() == "")
            ShowMessage("Please Enter Comment/Remark For Rejection of Procurement");
        else
        {
            int StatusID = Convert.ToInt32(rbnApproval.SelectedValue);
            Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), StatusID, txtComment.Text.Trim());
            //TODO: Notify Requisitioner and CC Members
            ShowMessage("Procurement Has Been Successfully Submitted To Contracts Committee");
            LoadItems(); MultiView1.ActiveViewIndex = 0;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void cboProcurementOfficer_DataBound(object sender, EventArgs e)
    {
        cboProcurementOfficer.Items.Insert(0, new ListItem(" -- All Procurement Officers -- ", "0"));
    }
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- Select Procurement Method --", "0"));
    }
    private void GetPreviousSelectedValues()
    {
        Session["PreviousPage"] = "Bidding_PDUSupervisorItems.aspx";
        Session["PRNumber"] = txtPrNumber.Text.Trim();
        Session["ProcMethod"] = cboProcMethod.SelectedValue;
        Session["Area"] = cboAreas.SelectedValue; Session["CostCenter"] = cboCostCenters.SelectedValue;
        Session["ProcMethod"] = lblProcMethod.Text;
    }
    protected void btnEditBidders_Click(object sender, EventArgs e)
    {
        GetPreviousSelectedValues();
        Response.Redirect("Bidding_ShortlistBidders.aspx?PR=" + txtReferenceNo.Text, true);
    }
    protected void btnEditEC_Click(object sender, EventArgs e)
    {
        GetPreviousSelectedValues();
        Response.Redirect("Bidding_NewEvaluationCommittee.aspx?PR=" + txtReferenceNo.Text, true);
    }
    protected void btnEditFormDetails_Click(object sender, EventArgs e)
    {
        datatable = Process.GetSectionAnswers(lblSection.Text, txtReferenceNo.Text);

        if (datatable.Rows.Count > 0)
        {
            lblCreatedBy.Text = datatable.Rows[0]["CreatedBy"].ToString();
            DataGrid3.DataSource = datatable;
            DataGrid3.DataBind();
        }

        MultiView2.ActiveViewIndex = 4;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        MultiView2.ActiveViewIndex = 0;
    }
    protected void btnViewSolDocs_Click(object sender, EventArgs e)
    {
        MultiView2.ActiveViewIndex = 5;
        lblAttachRefNo.Text = txtReferenceNo.Text;
        lblHeaderMsg.Text = txtProcSubject.Text;
        LoadDocuments();
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
        MultiView2.ActiveViewIndex = 5;
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
    protected void btnEditForm_Click(object sender, EventArgs e)
    {
        try
        {
            int QuestionID; string Answer; string ReferenceNo = lblRefNo.Text.Trim();
            int UserID = Convert.ToInt32(lblCreatedBy.Text);

            foreach (DataGridItem Record in DataGrid3.Items)
            {
                QuestionID = Convert.ToInt32(Record.Cells[0].Text);
                TextBox txtAnswer = ((TextBox)(Record.FindControl("txtAnswer")));
                Answer = txtAnswer.Text.Trim();

                Process.SaveEditQuestions(ReferenceNo, QuestionID, Answer, UserID);
            }
            ShowMessage("Form Section Has Been Successfully Saved...");
            LoadGrid(lblRefNo.Text.Trim(), lblProcMethod.Text.Trim(), lblSection.Text);
            MultiView2.ActiveViewIndex = 1;

            //TODO: Email Assigned Officer about Form Details
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
}
