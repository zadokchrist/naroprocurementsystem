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

public partial class Bidding_CCEvaluationReportApproval : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    BusinessBidding bllBidding = new BusinessBidding();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadOfficers(); LoadProcMethod();
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
    public string EnableFindStatus(object dataItem)
    {



        int status = Convert.ToInt32(DataBinder.Eval(dataItem, "StatusID").ToString());
        string statusString = "pending";
        if (status == 80)
        {

            statusString = "Approve Technical Evaluation";
        }
        else if (status == 83)
        {
            statusString = "Approve Financial Opening";
        }
        else if (status == 86)
        {

            statusString = "Approve Financial Evaluation";
        }
        else if (status == 103) {

            statusString = "Approve Financial & Technical Evaluation";
        
        }else if (status == 66 || status == 54 ){

            statusString = "Award of contract";
        }


        return statusString;
    }
    private void LoadItems()
    {
        string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim();
        string ProcMethod = cboProcMethod.SelectedValue.ToString(); string ProcOfficer = cboProcurementOfficer.SelectedValue.ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();

        datatable = Process.GetCCEvaluationProcurements(RecordID, PrNumber, ProcOfficer, ProcMethod, AreaCode, CostCenterCode);
        
        if (datatable.Rows.Count > 0)
        {
            lblCC.Text = datatable.Rows[0]["CCDescription"].ToString();
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind(); DataGrid1.Visible = true;
            lblEmpty.Text = ".";
        }
        else
        {
            DataGrid1.Visible = false;
            string EmptyMessage = "No Procurement(s) found in the system From Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
            lblEmpty.Text = EmptyMessage;
        }
        MultiView1.ActiveViewIndex = 0;
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
        datatable = Process.GetCCEvaluationProcurements("0", PRNumber, "0", "0", "", "");
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
            lblStatusID.Text = datatable.Rows[0]["StatusID"].ToString();

            if (lblStatusID.Text == "54" || lblStatusID.Text == "66" || lblStatusID.Text == "103" )
            {
                rbnApproval.Items.Clear();
                rbnApproval.Items.Add(new ListItem("Approve Procurement For Award of Contract", "1"));
                rbnApproval.Items.Add(new ListItem("Defer Procurement", "72"));
                rbnApproval.Items.Add(new ListItem("Reject/Cancel Procurement", "74"));

            }
            else if (lblStatusID.Text == "80") {
                rbnApproval.Items.Clear();
                rbnApproval.Items.Add(new ListItem("Approve Technical Evaluation Report", "1"));
                rbnApproval.Items.Add(new ListItem("Defer   Technical Evaluation", "118"));
                rbnApproval.Items.Add(new ListItem("Reject  /Cancel Procurement", "74"));

            }else if( lblStatusID.Text == "86" )
            {
                rbnApproval.Items.Clear();
                rbnApproval.Items.Add(new ListItem("Approve Procurement For Award of Contract", "1"));
                rbnApproval.Items.Add(new ListItem("Defer Procurement", "87"));
                rbnApproval.Items.Add(new ListItem("Reject/Cancel Procurement", "74"));
            
            }

        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        ShowMessage(".");
        try
        {
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            
            string Subject = e.Item.Cells[3].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            string Form = Process.GetForm(ProcMethodCode);
            Session["currentstatus"]  =       e.Item.Cells[9].Text;
            lblHeading.Text = Subject + " - [" + Form + "]";
            lblProcMethod.Text = ProcMethodCode.ToString();
            lblRefNo.Text = PRNumber;

            if (e.CommandName == "btnViewDetails")
            {
                
                LoadControls(PRNumber);
                LoadEvaluations(PRNumber);

                MultiView1.ActiveViewIndex = 2;
                MultiView2.ActiveViewIndex = 0;

            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadEvaluations(string PRNumber)
    {
        datatable = Process.GetBidderEvaluations(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            if (datatable.Rows[0]["LottID"].ToString() != "")
                LoadLottedBEBS(PRNumber);
            else
            {
                DataGrid7.DataSource = datatable; DataGrid8.Visible = false;
                DataGrid7.DataBind(); DataGrid7.Visible = true;
                lblNoRecords.Visible = false;
            }
        }
        else
        {
            DataGrid7.DataSource = null; DataGrid7.Visible = false;
            lblNoRecords.Visible = true;
        }
    }
    private void LoadLottedBEBS(string ReferenceNo)
    {
        datatable = Process.GetLottedBidderEvaluations(ReferenceNo);
        if (datatable.Rows.Count > 0)
        {
            DataGrid8.DataSource = datatable; DataGrid8.DataBind();
            DataGrid8.Visible = true; DataGrid7.Visible = false;
        }
    }
    private void ClearApprovalControls()
    {
        txtCCRefNo.Text = ""; txtComment.Text = ""; lblApprovals.Visible = false; 
        rbnSubmission.Visible = false; rbnSubmission.SelectedIndex = -1;
    }
    private void LoadApprovalOptions(int StatusID)
    {
       // datatable = Process.GetCCApprovalOptions(StatusID);
       /* if (datatable.Rows.Count > 0)
        {
            rbnSubmission.DataSource = datatable;
            rbnSubmission.DataValueField = "OptionID";
            rbnSubmission.DataTextField = "ApprovalOption";
            rbnSubmission.DataBind();

            rbnSubmission.Visible = true;
            lblApprovals.Visible = true;
        }
        else
        {*/
            lblApprovals.Visible = false; rbnSubmission.Visible = false;
       // }
    }
    private void LoadAnsweredFormGrid()
    {
        dgvFormDetails.DataSource = datatable;
        dgvFormDetails.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
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
    protected void btnFormDetails_Click(object sender, EventArgs e)
    {
        datatable = Process.GetAnsweredFormDetails(txtReferenceNo.Text.Trim());
        if (datatable.Rows.Count > 0)
            LoadAnsweredFormGrid();
        MultiView2.ActiveViewIndex = 1;
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
        if (txtCCRefNo.Text.Trim() == "")
            ShowMessage("Please Enter CC Meeting Reference Number");
        else if (((rbnApproval.SelectedValue == "72") || (rbnApproval.SelectedValue == "3") || (rbnApproval.SelectedValue == "118") || (rbnApproval.SelectedValue == "74") || (rbnApproval.SelectedValue == "87")) && txtComment.Text.Trim() == "")
            ShowMessage("Please Enter Comment or Remark For Rejection/Deferment of Procurement");
        else if (rbnApproval.SelectedValue == "54" && rbnSubmission.SelectedIndex == -1)
            ShowMessage("Please Select The Contracts Committee Approval Option");
        else
        {
            string RefNo = txtReferenceNo.Text.Trim();
            UploadFiles(RefNo);
            int ApprovalStatus = Convert.ToInt32(rbnApproval.SelectedValue);

            // Notify Requisitioner and Proc. Officer
            string ReferenceNo = txtReferenceNo.Text.Trim(); string By = HttpContext.Current.Session["FullName"].ToString();
            DataTable dtAlert = Process.GetBiddingDetailsForNotification(ReferenceNo);
            string Subject = "Contracts Committee Decision on Procurement " + dtAlert.Rows[0]["Subject"].ToString();
            string OfficerID = dtAlert.Rows[0]["POID"].ToString(); string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
            string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString(); string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
            long CCEvaluationID = Convert.ToInt64(dtAlert.Rows[0]["CCEvaluationID"].ToString());
            string ContractsCommittee = dtAlert.Rows[0]["CCEvaluationDescription"].ToString();
            string Message = ""; bool SendToPDUSupervisors = false;

            int currentstatus = Convert.ToInt32(Session["currentstatus"].ToString());
            int status = 0;
            if (currentstatus == 80)
            {
                status = 82;
            }
            else if (currentstatus == 83)
            {
                status = 85;
            }
            else if (currentstatus == 86)
            {
                status = 88;
            }
            else if (currentstatus == 103) {
                status = 104;
            }

            /*    if (!bllBidding.IsProcurementApprovedByAreaCC(txtReferenceNo.Text.Trim()) && bllBidding.IsProcurementFromArea(txtReferenceNo.Text.Trim()))
                {
                    // Rejected / Cancelled By Area CC
                    if (ApprovalStatus == 3)
                    {
                        Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 3, rbnSubmission.SelectedValue, txtComment.Text, 3);
                        Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 60, txtComment.Text.Trim());
                        Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                        + RequisitionerName + "</strong> from " + CostCenterName + " has been rejected / cancelled by " + ContractsCommittee
                                        + "  By " + By + " </p>";
                    }
                    // Deferred By Area CC
                    else if (ApprovalStatus == 72)
                    {
                        Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 2, rbnSubmission.SelectedValue, txtComment.Text, 3);
                        string OptionComment = "";
                        // If Option is Re-Tender
                        if (rbnSubmission.SelectedValue == "7")
                        {
                            Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 59, "Defered Procurement For Re-Tender With Comment " + txtComment.Text.Trim());
                            OptionComment = "For Re-Tender";
                        }
                        // If Option is Re-Evaluation
                        else if (rbnSubmission.SelectedValue == "8")
                        {
                            Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 58, "Defered Procurement For Re-Evaluation With Comment " + txtComment.Text.Trim());
                            OptionComment = "For Re-Evaluation";
                        }
                        Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                        + RequisitionerName + "</strong> from " + CostCenterName + " has been defered by " + ContractsCommittee
                                        + "  By " + By + " " + OptionComment + " </p>";
                    }
                    // Approved By Area CC 
                    else
                    {


                        if (currentstatus == 54 || status == 88 || status == 104)
                        {


                            Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 1, rbnSubmission.SelectedValue, txtComment.Text, 3);

                            Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 56, txtComment.Text.Trim());
                            Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                    + RequisitionerName + "</strong> from " + CostCenterName + " has been approved by " + ContractsCommittee
                                    + "  By " + By + " For Award of Contract";
                        }
                        else {

                            Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 1, rbnSubmission.SelectedValue, txtComment.Text, 3);

                            Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), status, txtComment.Text.Trim());
                            Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                    + RequisitionerName + "</strong> from " + CostCenterName + " has been approved by " + ContractsCommittee
                                    + "  By " + By + " For POST QUALIFICATION";

                    
                        }
                    }
                    ShowMessage(Message);
                }
                else
                {*/
            if (ApprovalStatus == 1)
                {

                    if ((currentstatus == 66) || (currentstatus == 86) )
                    {



                        Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 1, rbnSubmission.SelectedValue, txtComment.Text, 3);
                        Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 69, txtComment.Text.Trim());
                        Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                        + RequisitionerName + "</strong> from " + CostCenterName + " has been approved by " + ContractsCommittee
                                        + "  By " + By + " For Award of Contract";

                    }
                    else if (currentstatus == 80)
                    {
                        Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 1, rbnSubmission.SelectedValue, txtComment.Text, 3);
                        Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 117, txtComment.Text.Trim());
                        Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                        + RequisitionerName + "</strong> from " + CostCenterName + " has been approved by " + ContractsCommittee
                                        + "  By " + By + " For Finacial Bid Opening";
                    
                    }
             
                }
                else if (ApprovalStatus == 72)
                {
                   
                    Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 2, "8", txtComment.Text, 3);
                    string OptionComment = "";
                  
                    Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 72, txtComment.Text.Trim());
                    OptionComment = "For  Re-Evaluation";
                  
                    Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                    + RequisitionerName + "</strong> from " + CostCenterName + " has been defered by " + ContractsCommittee
                                    + "  By " + By + " " + OptionComment + " </p>";
               }
                else if (ApprovalStatus == 87)
                {

                    Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 2, "8", txtComment.Text, 3);
                    string OptionComment = "";

                    Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 87, txtComment.Text.Trim());
                    OptionComment = "For Financial Re-Evaluation";

                    Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                    + RequisitionerName + "</strong> from " + CostCenterName + " has been Defered by " + ContractsCommittee
                                    + "  By " + By + " " + OptionComment + " </p>";
                }
               else if(ApprovalStatus == 118)
               {
                   Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 2, "8", txtComment.Text, 3);
                   string OptionComment = "";

                   Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 118, txtComment.Text.Trim());
                   OptionComment = "For Re-Evaluation";

                   Message = "<p> Technical Evaluation for Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                   + RequisitionerName + "</strong> from " + CostCenterName + " has been defered by " + ContractsCommittee
                                   + "  By " + By + " " + OptionComment + " </p>";
              
               }
                else if (ApprovalStatus == 74)
                {
                    Process.LogCCApprovalDetails(txtCCRefNo.Text.Trim(), txtReferenceNo.Text.Trim(), CCEvaluationID, 3, rbnSubmission.SelectedValue, txtComment.Text, 3);
                    Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), 74, txtComment.Text.Trim());
                    Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                    + RequisitionerName + "</strong> from " + CostCenterName + " has been rejected / cancelled by " + ContractsCommittee
                                    + "  By " + By + " </p>";
                }
                ShowMessage(Message);
         //  }

            Message += "<p>Comment: " + txtComment.Text.Trim() + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

            if (SendToPDUSupervisors)
                Process.NotifyPDUSupervisors(By, Subject, Message);
            // Notify Requisitioner
            ProcessPlan.NotifyPlanner(By, Subject, Requisitioner, Message);
            // Notify Procurement Officer
            ProcessReq.NotifyOfficer(By, Subject, OfficerID, Message);

            MultiView1.ActiveViewIndex = 0;
            LoadItems();
        }
    } 
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
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
       // int StatusID = Convert.ToInt32(rbnApproval.SelectedValue);
        //ClearApprovalControls();
        //LoadApprovalOptions(StatusID);
    }
    protected void btnAttReturn_Click(object sender, EventArgs e)
    {
        MultiView2.ActiveViewIndex = 0;
    }
    protected void btnViewEvalReport_Click(object sender, EventArgs e)
    {
        lblAttachRefNo.Text = txtReferenceNo.Text;
        MultiView2.ActiveViewIndex = 2;
        LoadDocuments();
    }
    private void LoadDocuments()
    {
        MultiView2.ActiveViewIndex = 2;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments(RefNo, 5);
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
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                //ConfirmRemoveDocument(FileCode);
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
    protected void btnDone_Click(object sender, EventArgs e)
    {
        MultiView2.ActiveViewIndex = 0;
    }
}
