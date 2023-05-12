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

public partial class Bidding_PDUSupervisorItems : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "41";
    private int areaID;
    SendMail mailer = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadOfficers(); LoadProcMethod();

                if (Session["AccessLevelID"].ToString() == "3")//Proc Manager
                {
                    
                    ddllStatus.Items.Insert(0, new ListItem("Draft EOI submitted", "34"));
                    ddllStatus.Items.Insert(1, new ListItem("EOI evaluation submitted", "39"));
                    ddllStatus.Items.Insert(2, new ListItem("Draft RFP/Docs, Firms submitted by LPM/SPM", "41"));
                    ddllStatus.Items.Insert(3, new ListItem("Procurement approved for commencement by MD", "45"));
                    ddllStatus.Items.Insert(4, new ListItem("Technical evaluation submitted", "56"));
                    ddllStatus.Items.Insert(5, new ListItem("Technical & Financial evaluation submitted", "63"));
                    ddllStatus.Items.Insert(6, new ListItem("Draft contract submitted", "64"));

                }
                else {
                    ddllStatus.Items.Insert(0, new ListItem("Draft RFP/Docs, Firms submitted by LPO/SPO", "26"));
                    ddllStatus.Items.Insert(1, new ListItem("Draft EOI submitted", "33"));
                    ddllStatus.Items.Insert(2, new ListItem("EOI evaluation submitted", "38"));
                    ddllStatus.Items.Insert(3, new ListItem("Draft RFP submitted by L/SPO", "49"));
                    ddllStatus.Items.Insert(4, new ListItem("Docs & Firms submitted by L/SPO", "41"));
                    ddllStatus.Items.Insert(5, new ListItem("Procurement approved for commencement by PM", "47"));
                    ddllStatus.Items.Insert(6, new ListItem("Technical evaluation submitted", "55"));
                    ddllStatus.Items.Insert(7, new ListItem("Technical & Financial evaluation submitted", "60"));
                    ddllStatus.Items.Insert(8, new ListItem("Draft contract submitted", "62"));
                }

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
            }else
            {


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
        Status = ddllStatus.SelectedValue;
        datatable = Process.GetProcurementsForSupervisorSubmission(RecordID, PrNumber, ProcOfficer, ProcMethod, Status, AreaCode, CostCenterCode, true);
        
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
            Session["officerId"] = int.Parse(datatable.Rows[0]["AssiginedTo"].ToString());
            Session["createdby"] = int.Parse(datatable.Rows[0]["CreatedBy"].ToString());
            txtBidStart.Text = datatable.Rows[0]["BidInvitationDate"].ToString();
            txtBidCloseDate.Text = datatable.Rows[0]["BidSubmissionDate"].ToString();
            string status = datatable.Rows[0]["StatusID"].ToString();
            if (status == "26")// Docs submitted by L/SPO to L/SPM
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve docs, method and bidders", "41"));
                rbnApproval.Items.Insert(1, new ListItem("Reject docs, method and bidders", "28"));


            }
            else if (status == "33") //Draft EOI submitted by L/SPO to L/SPM
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve draft EO1", "34"));
                rbnApproval.Items.Insert(1, new ListItem("Reject draft EOI", "28"));
            }
            else if (status == "41")// Docs submitted to PM by L/SPM
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve docs, method and bidders", "43"));
                rbnApproval.Items.Insert(1, new ListItem("Reject docs, method and bidders", "42"));
            }
            else if (status == "34")// Draft EOI submitted to PM
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve draft EO1", "35"));
                rbnApproval.Items.Insert(1, new ListItem("Reject draft EOI", "28"));
            }
            else if (status == "43")// Docs submitted to MD
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve docs, method and bidders", "45"));
                rbnApproval.Items.Insert(1, new ListItem("Reject docs, method and bidders", "46"));
            }
            else if (status == "35")// Draft EOI submitted to MD
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve draft EO1", "36"));
                rbnApproval.Items.Insert(1, new ListItem("Reject draft EOI", "28"));
            }
            else if (status == "45")// Docs, bidders approved by MD
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Assign procurement to department for commencements", "47"));
                rbnApproval.Items.Insert(1, new ListItem("Reject procurement", "28"));
            }
            else if (status == "47")// Proc assigned to dept for commencement
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Commence procurement and send out IFB(s)", "50"));
                rbnApproval.Items.Insert(1, new ListItem("Reject procurement", "28"));
            }
            else if (status == "55" )// S/LPM Approve Technical evaluation
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve Technical evaluation", "56"));
                rbnApproval.Items.Insert(1, new ListItem("Reject Technical evaluation", "28"));
            }
            else if (status == "56")// PM Approve Technical evaluation
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve Technical evaluation", "57"));
                rbnApproval.Items.Insert(1, new ListItem("Reject Technical evaluation", "28"));
            }
            else if (status == "60" )// L/SPM Approve Financial & Technical Evaluation
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve Financial & Technical Evaluation", "63"));
                rbnApproval.Items.Insert(1, new ListItem("Reject Financial & Technical Evaluation", "28"));
            }
            else if (status == "63")// PM Approve Financial & Technical Evaluation
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve Financial & Technical Evaluation", "66"));
                rbnApproval.Items.Insert(1, new ListItem("Reject Financial & Technical Evaluation", "65"));
            }
            else if (status == "62")// L/SPM Approve Draft contract
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve Draft contract", "64"));
                rbnApproval.Items.Insert(1, new ListItem("Reject Draft contract", "28"));
            }
            else if (status == "64")// PM Approves draft contract
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve Draft contract and send contract to Firm", "77"));
                rbnApproval.Items.Insert(1, new ListItem("Reject Draft contract", "76"));
            }




            if (string.IsNullOrEmpty(datatable.Rows[0]["ContractNumber"].ToString()))
            {
                txtContractNumber.Text = datatable.Rows[0]["PD_EntityCode"].ToString();
                string entityCode = datatable.Rows[0]["PD_EntityCode"].ToString(); ;
                string[] parts = entityCode.Split('/');
                string conNum = parts[0] + "/2NUWSRP/"+parts[2]+"/" + parts[4];
                txtContractNumber.Text = conNum;
            }
            else
            {
                txtContractNumber.Text = datatable.Rows[0]["ContractNumber"].ToString();
            }
           
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
            lblHeading.Text = Subject;
            lblProcMethod.Text = ProcMethodCode.ToString();
            lblRefNo.Text = PRNumber;
            lblpreviousstatus.Text = e.Item.Cells[8].Text;
            if (e.CommandName == "btnViewDetails")
            {

                MultiView1.ActiveViewIndex = 2;
                MultiView2.ActiveViewIndex = 0;
                if(e.Item.Cells[8].Text == "69")
                {
                    rbnApproval.Visible = false;
                    btnSubmit.Visible = false;
                    btnEval.Visible = true;
                    lblContractNumber.Visible = true;
                    txtContractNumber.Visible = true;
                }else if (e.Item.Cells[8].Text == "48")
                {
                    btnEval.Visible = false;
                    lblContractNumber.Visible = false;
                    txtContractNumber.Visible = false;
                }
                else if (e.Item.Cells[8].Text == "63")
                {
                    btnEval.Visible = true;
                    lblContractNumber.Visible = true;
                    txtContractNumber.Visible = true;
                }
                if ((ProcMethodCode == 11) || (ProcMethodCode == 1)) {
                    btnViewEC.Visible = false;
                    btnFormDetails.Visible = false;
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
        
        datatable.DefaultView.Sort = "Code asc";
        dgvQuestions.DataSource = datatable;
        dgvQuestions.DataBind();
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
                else {

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

    public void loadreports(string ReportName,string refno,int areaid,string section)
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
        ////doc.Database.Tables[1].SetDataSource(dtSectionAnswers);
        //doc.Subreports[0].SetDataSource(dtSectionAnswers);

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
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Shortlist of Bidders");
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
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Evaluation Committee");
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
            btnPrint.Enabled = false;
        }
        else {
            btnPrint.Enabled = false;
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
        if (rbnApproval.SelectedIndex == -1)
            ShowMessage("Please Select Approve / Reject");
        else if (rbnApproval.SelectedIndex == 1 && txtComment.Text.Trim() == "")
            ShowMessage("Please Enter Comment/Remark For Rejection of Procurement");
        else
        {

            if (rbnApproval.SelectedIndex == 0)
            {
                string previousstatus = lblpreviousstatus.Text;

                int StatusID = Convert.ToInt32(rbnApproval.SelectedValue);
                string Accesslevel = Session["AccessLevelID"].ToString();

                Double estcost = Convert.ToDouble(txtEstimatedCost.Text.ToString());

               
                /// updateContractNumber();
                StatusID = Convert.ToInt32(rbnApproval.SelectedValue);


                Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), StatusID, txtComment.Text.Trim());
   
                //// Notify Requisitioner, Proc. Officer and CC Members
                string ReferenceNo = txtReferenceNo.Text.Trim();
                string PDUSupervisor = HttpContext.Current.Session["FullName"].ToString();

                DataTable dtAlert = Process.GetBiddingDetailsForNotification(ReferenceNo);

                /*/*/
                string ContractsCommittee = "Supervisor";
                if (StatusID == 43 || StatusID == 35 || StatusID == 40 || StatusID == 57 || StatusID == 66)
                {
                    ContractsCommittee = "Managing Director";
                }else
                {
                    ContractsCommittee = "Procurement Manager";
                }
               
                
                //long CCID = Convert.ToInt64(dtAlert.Rows[0]["CCID"].ToString()); 
                string CostCenterName = txtBudgetCostCenter.Text;
                string Subject = "Procurement " + txtProcSubject.Text+ " Has Been Submitted To " + ContractsCommittee;

                string OfficerID = Session["officerId"].ToString();
                string Requisitioner = Session["createdby"].ToString();


                if (StatusID == 50)
                {
                    String Subject2 = "";
                    String Message2 = "";
                    String Message3 = "";
                    datatable = Process.GetShortlistedBidderDetails(ReferenceNo);
                    if (datatable.Rows.Count > 0)
                        foreach (DataRow row in datatable.Rows)
                        {
                            int supplierid = int.Parse(row["BidderID"].ToString());
                            Process.generateIFB(ReferenceNo, supplierid);

                            string biddername = row["BidderName"].ToString();
                            string email = row["EmailAddress"].ToString();
                            string entityCode = row["PD_EntityCode"].ToString();

                            Subject2 = "Lagos Water Corporation Sourcing platform - " + entityCode;
                            //Notify supplier

                            Message2 = "<p>You have been shorlisted a bidder for procurement  ( " + entityCode + " ) by Lagos Water Corporation</p>";

                            Message2 += "<p>For more details, please access the link: <a href='https://lagoswater.org/sourcing/'>https://lagoswater.org/sourcing</a> to respond to IFB.</p>";
                            mailer.SendEmail("Lagos Water Corporation", "ivansoyeko@gmail.com", Subject2, Message2);
                        }

                    Message3 = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> from " + CostCenterName + " has been approved for sourcing of bids by Procurement </p>";

                    Message3 += "<p>Comment: " + txtComment.Text.Trim() + "</p>";
                    Message3 += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";
                    ShowMessage("Procurement Has Been Successfully Approved and IFB sent out");

                    ProcessReq.NotifyOfficer(PDUSupervisor, Subject, OfficerID, Message3);
                    ProcessPlan.NotifyPlanner(PDUSupervisor, Subject, Requisitioner, Message3);



                    ShowMessage("Procurement Has Been Successfully Approved and IFB sent out");
                }else if(StatusID==77)
                {
                    ShowMessage("Procurement successfully approved");

                    String Subject2 = "";
                    String Message2 = "";
                    // Send Letter of award
                    datatable = Process.GetBEBDetails(ReferenceNo);
                    if (datatable.Rows.Count > 0)
                        foreach (DataRow row in datatable.Rows)
                        {
                            int supplierid = int.Parse(row["BidderID"].ToString());
                            string biddername = row["CompanyName"].ToString();
                            string email = row["EmailAddress"].ToString();
                            string entityCode = row["PD_EntityCode"].ToString();
                            string title = row["Subject"].ToString();
                            Subject2 = "Lagos Water Corporation Sourcing platform - " + entityCode;
                            //Notify supplier
                            Message2 = "<p>" + biddername + ", following your emergence as the Lowest, Evaluated Subtantially Responsive and Qualified firm in the ";
                            Message2 += "bidding process for ( " + entityCode + ": " + title + " ). The Lagos Water Corporation, Management has approved the award of Contract to your firm accordingly.</p>";

                            Message2 += "<p>For more details, please access the link: <a href='https://lagoswater.org/sourcing/'>https://lagoswater.org/sourcing</a>.</p>";
                            string path = generateLetter();
                            mailer.SendEmail2("Lagos Water Corporation", email, Subject2, Message2, path);
                        }
                }


                string Message = "";

                if (StatusID == 43)
                    Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> from " + CostCenterName + " has been submitted to " + ContractsCommittee + " for Approval by " + PDUSupervisor + " </p>";
                else if (StatusID == 42)
                    Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> from " + CostCenterName + " has been rejected by " + PDUSupervisor + " </p>";
                else if (StatusID == 37)
                    Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> from " + CostCenterName + " has been submitted to " + "ProcurementManager" + " for Approval " + " </p>";
                else if (StatusID == 47)
                    Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> from " + CostCenterName + " has been assigned to Procurement department for commencement " + " </p>";
                else if (StatusID == 57)
                    Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> from " + CostCenterName + " has been submitted to Managing Director for Approval " + " </p>";

                Message += "<p>Comment: " + txtComment.Text.Trim() + "</p>";
                Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

          
                //    // Notify Contracts Committee
                //    //Process.NotifyContractsCommittee(PDUSupervisor, Subject, Message, CCID);
                
                // Notify Requisitioner
                    ProcessPlan.NotifyPlanner(PDUSupervisor, Subject, Requisitioner, Message);
                    ShowMessage("Procurement Has Been Successfully Submitted To " + ContractsCommittee);
                // Notify Procurement Officer
                ProcessReq.NotifyOfficer(PDUSupervisor, Subject, OfficerID, Message);

               
                LoadItems();
                MultiView1.ActiveViewIndex = 0;
            }else
            {
                int StatusID = Convert.ToInt32(rbnApproval.SelectedValue);
                ShowMessage("Procurement successfully rejected");
                Process.LogandCommitBiddingDetails(txtReferenceNo.Text.Trim(), StatusID, txtComment.Text.Trim());
                LoadItems();
                MultiView1.ActiveViewIndex = 0;
            }
        }
    }

    private string generateLetter()
    {
        string path = "";
        try
        {
            string ReferenceNo = lblRefNo.Text.Trim();
            int ProcMethod = Convert.ToInt32(lblProcMethod.Text.Trim());
            ShowMessage("" + ProcMethod.ToString());
            string biddername = "";
            string contractnumber = "";
            string subject = "";
            string amount = "";
            string address = "";

            DataTable report = new DataTable();
            report.Columns.Add("biddername", typeof(string));
            report.Columns.Add("contractNumber", typeof(string));
            report.Columns.Add("subject", typeof(string));
            report.Columns.Add("amount", typeof(string));
            report.Columns.Add("amountWords", typeof(string));
            report.Columns.Add("address", typeof(string));

            DataRow _row = report.NewRow();



            string appPath = HttpContext.Current.Request.ApplicationPath;
            string physicalPath = HttpContext.Current.Request.MapPath(appPath);
            string ReportName = physicalPath + "\\Bin\\Reports\\Bidding\\ContractAward.rpt";
            datatable = Process.GetBEBRequisitionDetails(ReferenceNo);
            if (datatable.Rows.Count > 0)
            {
                _row["subject"] = datatable.Rows[0]["Subject"].ToString();
                _row["biddername"] = datatable.Rows[0]["CompanyName"].ToString();
                _row["amount"] = datatable.Rows[0]["RequisitionedAmount"].ToString();
                _row["address"] = datatable.Rows[0]["PhysicalAddress"].ToString();
                _row["contractNumber"] = datatable.Rows[0]["PD_EntityCode"].ToString();
                _row["amountWords"] = datatable.Rows[0]["RequisitionedAmount"].ToString();


                report.Rows.Add(_row);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();


                //doc.Load(ReportName);
                //doc.SetDataSource(report);

                // doc.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "Letter of Award of Contract");
                // Process.LogandCommitBiddingDetails(ReferenceNo, 69, "");
                //s ShowMessage(".");
                string dPath = "D:\\Reports\\ProcurementAttachments\\";
                path = dPath + "" + ReferenceNo + "_ContractLetter.pdf";
                //doc.ExportToDisk(ExportFormatType.PortableDocFormat, path);

            }
            else
            {
                ShowMessage("No Data To Load For Report Form Selected ...");
            }

            return path;
        }
        catch (Exception ex)
        {

            ShowMessage(ex.Message);
            return path;
        }

    }

    private void updateContractNumber()
    {
        if (txtContractNumber.Text!="")
        {
            string refno = txtReferenceNo.Text;
            string contractnum = txtContractNumber.Text;
            Process.updateContractNumber(refno, contractnum);
        }else
        {
            ShowMessage("Enter contract number");
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
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods -- ", "0"));
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
        datatable = Process.GetBiddingDocuments(RefNo, 0);
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

            // Email Assigned Officer about Form Details Editing
            string PDUSupervisor = HttpContext.Current.Session["FullName"].ToString();
            DataTable dtAlert = Process.GetBiddingDetailsForNotification(ReferenceNo);
            string Subject = "Procurement Supervisor Edited " + dtAlert.Rows[0]["Subject"].ToString();
            string OfficerID = dtAlert.Rows[0]["POID"].ToString(); string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString(); 
            string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();

            /// Notify Procurement Officer
            string Message = "<p>Submission Form of Procurement ( " + ReferenceNo + " ) from " + CostCenterName + " has been edited by Procurement Supervisor " + PDUSupervisor + " </p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

            ProcessReq.NotifyOfficer(PDUSupervisor, Subject, OfficerID, Message);

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    public bool DisableAction(object dataItem)
    {

        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "48") && Session["AccessLevelID"].ToString().Equals("3"))
            return true;
        else if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "41"))
            return true;
        else
            return false;
    }



    protected void btnEval_Click(object sender, EventArgs e)
    {
        MultiView2.ActiveViewIndex = 6;
        datatable= Process.GetBidderEvaluations(lblRefNo.Text);
        dgvEval.DataSource = datatable;
        dgvEval.DataBind();
    }
}
