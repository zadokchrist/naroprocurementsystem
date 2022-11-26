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
public partial class Bidding_PDUEvaluation : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    BusinessBidding bllBidding = new BusinessBidding();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "53";
    DataTable dtUpdate = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadProcMethod(); LoadProcurementOfficers();
                MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadProcurementOfficers()
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
    private void CreateBidderEvaluationsDataTable()
    {
        DataTable dtEvaluation = new DataTable("Evaluation");

        dtEvaluation.Columns.Add(new DataColumn("RecordID", typeof(long)));
        dtEvaluation.Columns.Add(new DataColumn("BidderID", typeof(long)));
        dtEvaluation.Columns.Add(new DataColumn("BidderName", typeof(string)));
        dtEvaluation.Columns.Add(new DataColumn("IsBEB", typeof(bool)));
        dtEvaluation.Columns.Add(new DataColumn("BidUnitID", typeof(long)));
        dtEvaluation.Columns.Add(new DataColumn("Unit", typeof(string)));
        dtEvaluation.Columns.Add(new DataColumn("BidValue", typeof(double)));
        dtEvaluation.Columns.Add(new DataColumn("Reason", typeof(string)));

        Session["dtEvaluation"] = dtEvaluation;
        dtUpdate = dtEvaluation; 
    }
    private void CreateLottedBidderEvaluationsDataTable()
    {
        DataTable dtLottedEvaluation = new DataTable("LottedEvaluation");

        dtLottedEvaluation.Columns.Add(new DataColumn("RecordID", typeof(long)));
        dtLottedEvaluation.Columns.Add(new DataColumn("BidderID", typeof(long)));
        dtLottedEvaluation.Columns.Add(new DataColumn("BidderName", typeof(string)));
        dtLottedEvaluation.Columns.Add(new DataColumn("IsBEB", typeof(bool)));
        dtLottedEvaluation.Columns.Add(new DataColumn("LottID", typeof(long)));
        dtLottedEvaluation.Columns.Add(new DataColumn("LottNumber", typeof(int)));
        dtLottedEvaluation.Columns.Add(new DataColumn("LottDescription", typeof(string)));
        dtLottedEvaluation.Columns.Add(new DataColumn("BidUnitID", typeof(long)));
        dtLottedEvaluation.Columns.Add(new DataColumn("Unit", typeof(string)));
        dtLottedEvaluation.Columns.Add(new DataColumn("BidValue", typeof(double)));
        dtLottedEvaluation.Columns.Add(new DataColumn("Reason", typeof(string)));

        Session["dtLottedEvaluation"] = dtLottedEvaluation;
        dtUpdate = dtLottedEvaluation;
    }
    private void CreateNegotiationPlanDataTable()
    {
        DataTable dtNegotiationPlan = new DataTable("NegotiationPlan");

        dtNegotiationPlan.Columns.Add(new DataColumn("NegotiationPlanID", typeof(long)));
        dtNegotiationPlan.Columns.Add(new DataColumn("ProviderID", typeof(long)));
        dtNegotiationPlan.Columns.Add(new DataColumn("ProviderName", typeof(string)));
        dtNegotiationPlan.Columns.Add(new DataColumn("ProposedByID", typeof(long)));
        dtNegotiationPlan.Columns.Add(new DataColumn("ProposedBy", typeof(string)));
        dtNegotiationPlan.Rows.Clear();

        Session["dtNegotiationPlan"] = dtNegotiationPlan;
        dtUpdate = dtNegotiationPlan;
        ClearItemControls(); ClearNegotiationPlanControls();
    }
    private void CreateNegPlanDetailsDataTable()
    {
        DataTable dtNegPlanDetails = new DataTable("NegPlanDetails");

        dtNegPlanDetails.Columns.Add(new DataColumn("NegotiationPlanDetailID", typeof(long)));
        dtNegPlanDetails.Columns.Add(new DataColumn("Issue", typeof(string)));
        dtNegPlanDetails.Columns.Add(new DataColumn("Objective", typeof(string)));
        dtNegPlanDetails.Columns.Add(new DataColumn("NegotiationParameters", typeof(string)));

        dtNegPlanDetails.Rows.Clear();

        Session["dtNegPlanDetails"] = dtNegPlanDetails;
        dtUpdate = dtNegPlanDetails;
        ClearItemControls(); ClearNegPlanDetailControls();
    }
    private void CreateNegPlanMembersDataTable()
    {
        DataTable dtMembers = new DataTable("Members");

        dtMembers.Columns.Add(new DataColumn("MemberID", typeof(long)));
        dtMembers.Columns.Add(new DataColumn("UserID", typeof(long)));
        dtMembers.Columns.Add(new DataColumn("Member", typeof(string)));
        dtMembers.Columns.Add(new DataColumn("Position", typeof(string)));
        dtMembers.Columns.Add(new DataColumn("ReasonID", typeof(int)));
        dtMembers.Columns.Add(new DataColumn("Reason", typeof(string)));
        dtMembers.Columns.Add(new DataColumn("OtherReason", typeof(string)));
        dtMembers.Rows.Clear();

        Session["dtMembers"] = dtMembers;
        dtUpdate = dtMembers;
    }
    private void ClearItemControls()
    {
        ClearNegotiationPlanControls();
        ClearNegPlanDetailControls();
        ClearNegPlanMemberControls();
    }
    private void ClearNegotiationPlanControls()
    {
       /// cboBidder.SelectedIndex = cboBidder.Items.IndexOf(cboBidder.Items.FindByValue("0"));
        txtProposedBy.Text = "";
        btnAdd.Text = "Add Negotiation Plan";
    }
    private void ClearNegPlanDetailControls()
    {
        txtIssue.Text = ""; txtObjective.Text = ""; txtParameter.Text = "";
        btnAddDetails.Text = "Add Negotiation Plan Details";
    }
    private void ClearNegPlanMemberControls()
    {
        txtMember.Text = ""; txtReason.Text = ""; btnAddMember.Text = "Add Member";
        txtPosition.Text = ""; cboReason.SelectedValue = "0"; txtMember.Text = ""; txtReason.Visible = false;
    }
    private void LoadItems()
    {
        string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim();
        string ProcMethod = cboProcMethod.SelectedValue.ToString(); string ProcOfficer = cboProcurementOfficer.SelectedValue.ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();

        datatable = Process.GetPDUProcurementsForEvaluation(RecordID, PrNumber, ProcOfficer, ProcMethod, Status, AreaCode, CostCenterCode);

        if (datatable.Rows.Count > 0)
        {
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind(); DataGrid1.Visible = true;
            lblEmpty.Text = ".";
        }
        else
        {
            DataGrid1.Visible = false;
            string EmptyMessage = "No New Procurement(s) Awaiting Evaluation in the system from Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
            lblEmpty.Text = EmptyMessage;
        }
        MultiView1.ActiveViewIndex = 0;    
    }
    public string EnableFindStatus(object dataItem)
    {



        int status = Convert.ToInt32(DataBinder.Eval(dataItem, "StatusID").ToString());
        string statusString = " ";
        if(status == 106){

            statusString = "Technical Evaluation";
        }
        else if (status == 108) {

            statusString = " Financial Opening";
        }
        else if (status == 110)
        {

            statusString = "Financial Evaluation";
        }
        else if(status == 63) {

            statusString = "Combined Financial & Technical";
        }
        

        return statusString;
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
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        ShowMessage(".");
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            string Subject = e.Item.Cells[3].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            Session["statusIDeval"] = e.Item.Cells[9].Text;
            string Form = Process.GetForm(ProcMethodCode);
            if (e.CommandName == "btnUploadEvalReport")
            {
                lblAttachRefNo.Text = PRNumber;
                LoadDocuments();
                MultiView1.ActiveViewIndex = 1;
            }
            else if (e.CommandName == "btnAddNegotiationPlan")
            {
                MultiView1.ActiveViewIndex = 4;
                MultiView2.ActiveViewIndex = 0;
                MultiView4.ActiveViewIndex = 0;
                LoadControls(PRNumber);
            }
            else if (e.CommandName == "btnSubmit")
            {
                LoadControls(PRNumber);
                MultiView1.ActiveViewIndex = 4;
                MultiView2.ActiveViewIndex = 0;
                MultiView4.ActiveViewIndex = 3;
                lblReferenceNo.Text = PRNumber;
                LoadBEBS(PRNumber);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadBEBS(string PRNumber)
    {
        CreateBidderEvaluationsDataTable();
        datatable = Process.GetBidderEvaluations(PRNumber);
        lblReferenceNo.Text = PRNumber;

        if (datatable.Rows.Count > 0)
        {
            if (datatable.Rows[0]["LottID"].ToString() != "")
                LoadLottedBEBS(PRNumber);
            else
            {
                dtUpdate.Rows.Clear();
                foreach (DataRow dr in datatable.Rows)
                {
                    long RecordID = Convert.ToInt64(dr["RecordID"].ToString()); string Reason = dr["Reason"].ToString();
                    long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); string BidderName = dr["BidderName"].ToString();
                    double BidValue = Convert.ToDouble(dr["BidValue"].ToString()); long BidUnitID = Convert.ToInt64(dr["BidUnitID"].ToString());
                    string Unit = dr["Unit"].ToString(); bool IsBEB = Convert.ToBoolean(dr["IsBeB"].ToString());
                    
                    dtUpdate.Rows.Add(new object[] { RecordID, BidderID, BidderName, IsBEB, BidUnitID, Unit, BidValue, Reason });
                }
                Session["dtEvaluation"] = dtUpdate;
                DataGrid7.DataSource = datatable; DataGrid8.Visible = false;
                DataGrid7.DataBind(); DataGrid7.Visible = true; btnSubmitToCC.Enabled = true;
                lblNoRecords.Visible = false;
            }
        }
        else
        {
            DataGrid7.DataSource = null; DataGrid7.Visible = false; btnSubmitToCC.Enabled = false; 
            lblNoRecords.Visible = true;
        }
    }
    private void LoadLottedBEBS(string ReferenceNo)
    {
        CreateLottedBidderEvaluationsDataTable();
        datatable = Process.GetLottedBidderEvaluations(ReferenceNo);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long RecordID = Convert.ToInt64(dr["RecordID"].ToString()); string Reason = dr["Reason"].ToString();
                long LottID = Convert.ToInt64(dr["LottID"].ToString()); int LottNumber = Convert.ToInt32(dr["LottNumber"].ToString());
                string LottDescription = dr["LottDescription"].ToString();
                long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); string BidderName = dr["BidderName"].ToString();
                double BidValue = Convert.ToDouble(dr["BidValue"].ToString()); long BidUnitID = Convert.ToInt64(dr["BidUnitID"].ToString());
                string Unit = dr["Unit"].ToString(); bool IsBEB = Convert.ToBoolean(dr["IsBeB"].ToString());

                dtUpdate.Rows.Add(new object[] { RecordID, BidderID, BidderName, IsBEB, LottID, LottNumber, LottDescription, BidUnitID, Unit, BidValue, Reason });
            }
            Session["dtLottedEvaluation"] = dtUpdate;
            DataGrid8.DataSource = datatable; DataGrid7.Visible = false;
            DataGrid8.DataBind(); DataGrid8.Visible = true;
            lblNoRecords.Visible = false;
        }
        else
        {
            DataGrid8.DataSource = null; DataGrid8.Visible = false;
            lblNoRecords.Visible = true;
        }
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
    protected void cboDashboard_DataBound(object sender, EventArgs e)
    {
        cboDashboard.Items.Insert(0, new ListItem(" -- Select a Section -- ", "0"));
    }
    protected void cboDashboard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboDashboard.SelectedValue == "0")
                btnPrint.Enabled = false;
            else
                btnPrint.Enabled = true;

            string Section = cboDashboard.SelectedValue.ToString();
            string ReferenceNo = lblRefNo.Text;
            int ProcMethod = Convert.ToInt32(lblProcMethod.Text);

            datatable = Process.GetSectionAnswers(Section, ReferenceNo);

            if (datatable.Rows.Count > 0)
            {
                DataGrid6.DataSource = datatable; DataGrid6.DataBind();
                btnPrint.Enabled = true;
            }
            else
            {
                datatable = Process.GetSectionQuestions(ProcMethod, Section);
                DataGrid6.DataSource = datatable; DataGrid6.DataBind();
                btnPrint.Enabled = false;
            }
            DataGrid6.Visible = true;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            string ReferenceNo = lblRefNo.Text.Trim();
            int ProcMethod = Convert.ToInt32(lblProcMethod.Text.Trim());
            datatable = Process.GetFormNumberByProcMethod(ProcMethod, 1);

            string FormNumber = datatable.Rows[0]["FormNumber"].ToString();
            string Section = cboDashboard.SelectedValue.ToString();
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
                ShowMessage("No Data To Load For Report Form Selected ...");
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
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods --","0"));
    }
    protected void btnAttReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    public bool IsFileRemoveable(int IsRemoveable)
    {
        if (IsRemoveable == 1)
            return true;
        else
            return false;
    }
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 1;
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       
        MultiView1.ActiveViewIndex = 0;
        LoadItems();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage2(".");
            if (cboProvider.SelectedValue == "0")
                ShowMessage2("Please Enter Name of Provider");
            else if (String.IsNullOrEmpty(txtProposedBy.Text.Trim()))
                ShowMessage2("Please Enter The Name of Person Who Proposed Negotiations");
            else
            {
                long ProposedByID = 0;
                datatable = Process.GetUserByName(txtProposedBy.Text.Trim());
                if (datatable.Rows.Count == 0)
                    throw new Exception("Please Enter Existing User OR Select from drop down returned after typing more than two letters");
                else
                    ProposedByID = Convert.ToInt64(datatable.Rows[0]["UserID"].ToString());
                long ProviderID = Convert.ToInt64(cboProvider.SelectedValue);
                string ProviderName = cboProvider.SelectedItem.Text; string ProposedBy = txtProposedBy.Text.Trim();
                long NegotiationPlanID = 0;
                dtUpdate = (DataTable)Session["dtNegotiationPlan"];
                if (btnAdd.Text.Contains("Update"))
                {
                    NegotiationPlanID = Convert.ToInt64(lblNegotiationPlanID.Text.Trim());
                    int i = 0;
                    foreach (DataRow dr in dtUpdate.Rows)
                    {
                        if (Convert.ToInt64(dr["NegotiationPlanID"]) == NegotiationPlanID)
                        {
                            dtUpdate.Rows.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                }
                dtUpdate.Rows.Add(new object[] { NegotiationPlanID, ProviderID, ProviderName, ProposedByID, ProposedBy });
                ClearItemControls();

                ShowMessage2("Negotiation Plan Details Has Been Successfully Added");

                Session["dtNegotiationPlan"] = dtUpdate;
                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind(); DataGrid2.Visible = true;
                lblNoNegotiationPlans.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ShowMessage2(ex.Message);
        }
    }
    private void ShowMessage2(string Message)
    {
        if (Message == ".")
            lblMsg.Text = ".";
        else
            lblMsg.Text = "MESSAGE: " + Message;
    }
    private void ShowMessage3(string Message)
    {
        if (Message == ".")
            lblMsg2.Text = ".";
        else
            lblMsg2.Text = "MESSAGE: " + Message;
    }
    private void ShowMessage4(string Message)
    {
        if (Message == ".")
            lblMsg3.Text = ".";
        else
            lblMsg3.Text = "MESSAGE: " + Message;
    }
    public bool EnableNegPlanLink(object dataItem)
    {
        string MeetingID = DataBinder.Eval(dataItem, "NegotiationPlanID").ToString();

        if (MeetingID != "0")
            return true;
        else
            return false;
    }
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string NegotiationPlanID = e.Item.Cells[0].Text; string ProviderName = e.Item.Cells[2].Text;
        string ProposedBy = e.Item.Cells[4].Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtNegotiationPlan"];
        long ID = Convert.ToInt64(NegotiationPlanID);
        ShowMessage("."); ShowMessage2("."); ShowMessage3(".");
        if (e.CommandName == "btnEdit")
        {
            if (NegotiationPlanID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);

            LoadNegotiationPlanControls(NegotiationPlanID, ProviderName, ProposedBy);
            DataGrid2.DataSource = dtUpdate.DefaultView;
            DataGrid2.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (NegotiationPlanID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            else
            {
                Process.FlagNegotiationPlan(ID, true);
            }
            ShowMessage2("Negotiation Plan Have Been Successfully Removed ...");
            LoadNegotiationPlans(txtReferenceNo.Text.Trim());
        }
        else if (e.CommandName == "btnAddNegPlanDetails")
        {
            MultiView1.ActiveViewIndex = 4;
            MultiView2.ActiveViewIndex = 0;
            MultiView4.ActiveViewIndex = 1;
            LoadExistingNegotiationPlans(txtReferenceNo.Text);
        }
    }
    private void LoadNegotiationPlanControls(string NegotiationPlanID, string ProviderName, string ProposedBy)
    {
        lblNegotiationPlanID.Text = NegotiationPlanID;
       // cboBidder.SelectedIndex = cboBidder.Items.IndexOf(cboBidder.Items.FindByValue(ProviderName));
        txtProposedBy.Text = ProposedBy;
        btnAdd.Text = "Update Negotiation Plan";
    }
    private void LoadControls(string PRNumber)
    {
        datatable = Process.GetLevelProcurements("0", PRNumber, "0", "0", "", "", "");
        if (datatable.Rows.Count > 0)
        {
            txtReferenceNo.Text =  datatable.Rows[0]["ScalaPRNumber"].ToString();
            txtEstimatedCost.Text = Convert.ToDouble(datatable.Rows[0]["EstimatedCost"]).ToString("#,##0");
            txtProcSubject.Text = datatable.Rows[0]["Subject"].ToString();
            txtProcType.Text = datatable.Rows[0]["ProcurementType"].ToString();
            txtProcMethod.Text = datatable.Rows[0]["Method"].ToString();
            txtDateRequisitioned.Text = datatable.Rows[0]["CreationDate"].ToString();
            txtRequisitioner.Text = datatable.Rows[0]["Requisitioner"].ToString();
            txtDateRequired.Text = datatable.Rows[0]["DateRequired"].ToString();
            txtBudgetCostCenter.Text = datatable.Rows[0]["CostCenterName"].ToString();
        }
        LoadNegotiationPlans(PRNumber);
    }
    private void LoadNegotiationPlans(string PRNumber)
    {
        CreateNegotiationPlanDataTable();

        datatable = Process.GetBiddersForBidOpeningByReferenceNo(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            cboProvider.DataSource = datatable;
            cboProvider.DataValueField = "BidderID";
            cboProvider.DataTextField = "BidderName";
            cboProvider.DataBind();
        }

        datatable = Process.GetNegotiationPlan(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {

                long NegotiationPlanID = Convert.ToInt64(dr["NegotiationPlanID"].ToString());
                long ProviderID = Convert.ToInt64(dr["ProviderID"].ToString()); string ProviderName = dr["ProviderName"].ToString();
                long ProposedByID = Convert.ToInt64(dr["ProposedByID"].ToString()); string ProposedBy = dr["ProposedBy"].ToString();

                dtUpdate.Rows.Add(new object[] { NegotiationPlanID, ProviderID, ProviderName, ProposedByID, ProposedBy });
            }
            Session["dtNegotiationPlan"] = dtUpdate;
            DataGrid2.DataSource = datatable;
            DataGrid2.DataBind(); DataGrid2.Visible = true;
            lblNoNegotiationPlans.Visible = false;
        }
        else
        {
            DataGrid2.Visible = false;
            lblNoNegotiationPlans.Visible = true;
        }
    }
    private void LoadExistingNegotiationPlans(string PRNumber)
    {
        datatable = Process.GetNegotiationPlan(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            DataGrid3.DataSource = datatable;
            DataGrid3.DataBind();
        }
    }
    private void LoadMemberReasons(int Type)
    {
        cboReason.DataSource = Process.GetBidderReasons(Type);
        cboReason.DataTextField = "Reason";
        cboReason.DataValueField = "ID";
        cboReason.DataBind();
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnSubmitNegotiationPlan_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtNegotiationPlan"];
        ShowMessage2("."); ShowMessage(".");

        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Negotiation Plan Details");
            ShowMessage2("Please Add Negotiation Plan Details");
        }
        else
        {
            Session["dtNegotiationPlan"] = dtUpdate;
            DataTable dtNegotiationPlan = (DataTable)Session["dtNegotiationPlan"];

            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString()); string RefNo = txtReferenceNo.Text.Trim();

            string Response = Process.SaveEditNegotiationPlan(RefNo, dtNegotiationPlan, CreatedBy);
            LoadNegotiationPlans(txtReferenceNo.Text);
            ShowMessage(Response);
            ShowMessage2(Response);
        }
    }
    protected void DataGrid3_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        lblNegPlanID.Text = e.Item.Cells[0].Text;
        long NegPlanID = Convert.ToInt64(lblNegPlanID.Text);

        if (e.CommandName == "btnAddIssue")
        {
            LoadNegotiationPlanDetails(NegPlanID);
            MultiView1.ActiveViewIndex = 4;
            MultiView2.ActiveViewIndex = 0;
            MultiView4.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 0;
        }
        else if (e.CommandName == "btnAddTeam")
        {
            LoadMembers(NegPlanID); LoadMemberReasons(1);
            MultiView1.ActiveViewIndex = 4;
            MultiView2.ActiveViewIndex = 0;
            MultiView4.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 1;
        }
    }
    private void LoadNegotiationPlanDetails(long NegPlanID)
    {
        CreateNegPlanDetailsDataTable();
        datatable = Process.GetNegotiationPlanByID(NegPlanID);
        if (datatable.Rows.Count > 0)
        {
            txtProviderNameD.Text = datatable.Rows[0]["ProviderName"].ToString();
            txtProposedByD.Text = datatable.Rows[0]["ProposedBy"].ToString();
        }
        datatable = Process.GetNegotiationPlanDetails(NegPlanID);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long NegotiationPlanDetailID = Convert.ToInt64(dr["NegotiationPlanDetailID"].ToString());
                string Issue = dr["Issue"].ToString(); string Objective = dr["Objective"].ToString();
                string NegotiationParameters = dr["NegotiationParameters"].ToString();

                dtUpdate.Rows.Add(new object[] { NegotiationPlanDetailID, Issue, Objective, NegotiationParameters });
            }
            Session["dtNegPlanDetails"] = dtUpdate;
            DataGrid4.DataSource = datatable;
            DataGrid4.DataBind();
            lblNoNegIssues.Visible = false;
        }
        else
            lblNoNegIssues.Visible = true;
    }
    protected void btnAddDetails_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage3(".");
            if (String.IsNullOrEmpty(txtIssue.Text.Trim()))
                ShowMessage3("Please Enter Issue");
            else if (String.IsNullOrEmpty(txtObjective.Text.Trim()))
                ShowMessage3("Please Enter Objective");
            else if (String.IsNullOrEmpty(txtParameter.Text.Trim()))
                ShowMessage3("Please Enter Negotiation Parameter");
            else
            {
                string Issue = txtIssue.Text.Trim(); string Objective = txtObjective.Text.Trim();
                string Parameter = txtParameter.Text.Trim();

                long NegPlanDetailID = 0;
                dtUpdate = (DataTable)Session["dtNegPlanDetails"];
                if (btnAddDetails.Text.Contains("Update"))
                {
                    NegPlanDetailID = Convert.ToInt64(lblNegPlanDetailID.Text.Trim());
                    int i = 0;
                    foreach (DataRow dr in dtUpdate.Rows)
                    {
                        if (Convert.ToInt64(dr["NegotiationPlanDetailID"]) == NegPlanDetailID)
                        {
                            dtUpdate.Rows.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                }

                dtUpdate.Rows.Add(new object[] { NegPlanDetailID, Issue, Objective, Parameter });

                ClearItemControls();
                ShowMessage3("Negotiation Plan Details Has Been Successfully Added");

                Session["dtNegPlanDetails"] = dtUpdate;
                DataGrid4.DataSource = dtUpdate.DefaultView;
                DataGrid4.DataBind();
                lblNoNegIssues.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ShowMessage3(ex.Message);
        }
    }
    protected void btnSubmitDetails_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtNegPlanDetails"];
        ShowMessage3("."); ShowMessage(".");

        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage3("Please Add Negotiation Plan Details");
        }
        else
        {
            Session["dtNegPlanDetails"] = dtUpdate;
            DataTable dtNegPlanDetails = (DataTable)Session["dtNegPlanDetails"];
            long NegotiationPlanDetailID = 0; long NegotiationPlanID = Convert.ToInt64(lblNegPlanID.Text.Trim());
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());
            string Issue; string Objective; string Parameter;

            foreach (DataRow dr in dtNegPlanDetails.Rows)
            {
                NegotiationPlanDetailID = Convert.ToInt64(dr["NegotiationPlanDetailID"].ToString());
                Issue = dr["Issue"].ToString(); Objective = dr["Objective"].ToString();
                Parameter = dr["NegotiationParameters"].ToString();

                Process.SaveEditNegotiationPlanDetails(NegotiationPlanDetailID, NegotiationPlanID, Issue, Objective, Parameter, CreatedBy);
            }
            ShowMessage("Negotiation Plan Detail(s) Have Been Successfully Added to Negotiation Plan");
            MultiView1.ActiveViewIndex = 4;
            MultiView2.ActiveViewIndex = 0;
            MultiView4.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 0;
        }
    }
    protected void btnCancelDetails_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
        MultiView2.ActiveViewIndex = 0;
        MultiView4.ActiveViewIndex = 1;
    }
    protected void btnPrintDetails_Click(object sender, EventArgs e)
    {
        try
        {
         //   ClearItemControls();
            if (DataGrid4.Items.Count == 0)
            {
                ShowMessage3("There is no data to print for the Record of Negotiation Plan ...");
            }
            else
            {
                // PP Form 50
                string ReportName = "PPForm50";
                long NegotiationPlanID = Convert.ToInt64(lblNegPlanID.Text);

                datatable = Process.GetReportForNegotiationPlan(NegotiationPlanID);
                int rowcount = datatable.Rows.Count;

                if (rowcount != 0)
                {
                    loadreport(ReportName);

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Negotiations Plan - PP Form 50");
                }
                else
                {
                    ShowMessage("No data to load for report ..... ");
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void DataGrid4_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string ID = e.Item.Cells[0].Text; string Issue = e.Item.Cells[1].Text; 
        string Objective = e.Item.Cells[2].Text; string NegotiationParameters = e.Item.Cells[3].Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtNegPlanDetails"];
        ShowMessage("."); ShowMessage3(".");
        if (e.CommandName == "btnEdit")
        {
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);

            LoadNegPlanDetailsControls(ID, Issue, Objective, NegotiationParameters);
            DataGrid4.DataSource = dtUpdate.DefaultView;
            DataGrid4.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            else
            {
                long NegPlanDetailsID = Convert.ToInt64(ID);
                Process.FlagNegPlanDetails(NegPlanDetailsID, true);
            }
            ShowMessage3("Negotiation Plan Issue Detail Has Been Successfully Removed ...");
            LoadNegotiationPlanDetails(Convert.ToInt64(lblNegPlanID.Text));
        }
    }
    private void LoadNegPlanDetailsControls(string ID, string Issue, string Objective, string NegotiationParameters)
    {
        lblNegPlanDetailID.Text = ID; txtIssue.Text = Issue; txtObjective.Text = Objective; txtParameter.Text = NegotiationParameters;
        btnAddDetails.Text = "Update Negotiation Plan Details";
    }
    protected void DataGrid5_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string ID = e.Item.Cells[0].Text; string Issue = e.Item.Cells[1].Text;
        string Objective = e.Item.Cells[2].Text; string NegotiationParameters = e.Item.Cells[3].Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtNegPlanDetails"];
        ShowMessage("."); ShowMessage3(".");
        if (e.CommandName == "btnEdit")
        {
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);

            LoadNegPlanDetailsControls(ID, Issue, Objective, NegotiationParameters);
            DataGrid4.DataSource = dtUpdate.DefaultView;
            DataGrid4.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            else
            {
                long NegPlanDetailsID = Convert.ToInt64(ID);
                Process.FlagNegPlanDetails(NegPlanDetailsID, true);
            }
            ShowMessage3("Negotiation Plan Issue Detail Has Been Successfully Removed ...");
            LoadNegotiationPlanDetails(Convert.ToInt64(lblNegPlanID.Text));
        }
    }
    protected void cboProvider_DataBound(object sender, EventArgs e)
    {
        cboProvider.Items.Insert(0, new ListItem(" -- Select Provider Name --", "0"));
    }
    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage4(".");
            if (String.IsNullOrEmpty(txtMember.Text.Trim()))
                ShowMessage4("Please Select From the List of Members After Typing One or More Letters");
            else if (String.IsNullOrEmpty(txtPosition.Text.Trim()))
                ShowMessage4("Please Enter The Position of Member");
            else if (cboReason.SelectedValue == "0")
                ShowMessage4("Please Select Reason For Selection Of Member");
            else if (cboReason.SelectedItem.ToString() == "Other" && String.IsNullOrEmpty(txtReason.Text.Trim()))
                ShowMessage4("Please Enter Other Reason For Selection of Member");
            else
            {
                string Member = txtMember.Text.Trim();
                string Position = txtPosition.Text.Trim();
                int ReasonID = Convert.ToInt32(cboReason.SelectedValue.ToString());
                string Reason = cboReason.SelectedItem.Text.Trim();
                string OtherReason = txtReason.Text.Trim();
                int UserID = 0;
                datatable = Process.GetUserByName(Member);
                if (datatable.Rows.Count == 0)
                    throw new Exception("Please Enter Existing User OR Select from drop down returned after typing more than two letters");
                else
                    UserID = Convert.ToInt32(datatable.Rows[0]["UserID"].ToString());

                long MemberID = 0;
                dtUpdate = (DataTable)Session["dtMembers"];
                if (btnAddMember.Text.Contains("Update"))
                {
                    MemberID = Convert.ToInt64(lblMemberID.Text.Trim());
                    int i = 0;
                    foreach (DataRow dr in dtUpdate.Rows)
                    {
                        if (Convert.ToInt64(dr["MemberID"]) == MemberID)
                        {
                            dtUpdate.Rows.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                }

                dtUpdate.Rows.Add(new object[] { MemberID, UserID, Member, Position, ReasonID, Reason, OtherReason });
                ClearNegPlanMemberControls();

                ShowMessage4("Member Has Been Successfully Added To Negotiation Team");

                Session["dtMembers"] = dtUpdate;
                DataGrid5.DataSource = dtUpdate.DefaultView;
                DataGrid5.DataBind();
            }
        }
        catch (Exception ex)
        {
            ShowMessage4(ex.Message);
        }
    }
    private void LoadMembers(long NegPlanID)
    {
        CreateNegPlanMembersDataTable();
        datatable = Process.GetNegotiationPlanByID(NegPlanID);
        if (datatable.Rows.Count > 0)
        {
            txtProviderNameD.Text = datatable.Rows[0]["ProviderName"].ToString();
            txtProposedByD.Text = datatable.Rows[0]["ProposedBy"].ToString();
        }
        datatable = Process.GetNegotiationPlanMembers(NegPlanID);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long MemberID = Convert.ToInt64(dr["MemberID"].ToString()); long UserID = Convert.ToInt64(dr["UserID"].ToString());
                string Member = dr["Member"].ToString();
                string Position = dr["Position"].ToString(); int ReasonID = Convert.ToInt32(dr["ReasonID"].ToString());
                string Reason = dr["Reason"].ToString(); string OtherReason = dr["OtherReason"].ToString();
                dtUpdate.Rows.Add(new object[] { MemberID, UserID, Member, Position, ReasonID, Reason, OtherReason });
            }
            Session["dtMembers"] = dtUpdate;
            DataGrid5.DataSource = datatable;
            DataGrid5.DataBind();
        }
    }
    protected void btnSubmitTeam_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtMembers"];
        ShowMessage4("."); ShowMessage(".");
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Members Before Submission");
            ShowMessage4("Please Add Members Before Submission");
        }
        else
        {
            Session["dtMembers"] = dtUpdate;
            DataTable dtMembers = (DataTable)Session["dtMembers"];
            string CreatedBy = Session["UserID"].ToString();
            long NegotiationPlanID = Convert.ToInt64(lblNegPlanID.Text.Trim());
            string Response = Process.SaveEditNegotiationPlanMembers(NegotiationPlanID, dtMembers, CreatedBy);
            ShowMessage(Response);
            MultiView1.ActiveViewIndex = 4;
            MultiView2.ActiveViewIndex = 0;
            MultiView4.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 0;
        }
    }
    protected void btnPrintTeam_Click(object sender, EventArgs e)
    {
        try
        {
            if (DataGrid5.Items.Count == 0)
            {
                ShowMessage4("There is no data to print for the Record of Negotiation Plan Members...");
            }
            else
            {
                // PP Form 40
                string ReportName = "NegotiationTeam50";
                long NegotiationPlanID = Convert.ToInt64(lblNegPlanID.Text);

                datatable = Process.GetReportForNegotiationTeam(NegotiationPlanID);
                int rowcount = datatable.Rows.Count;

                if (rowcount != 0)
                {
                    loadreport(ReportName);

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Negotiations Plan Members");
                }
                else
                {
                    ShowMessage("No data to load for report ..... ");
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnCancelTeam_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
        MultiView2.ActiveViewIndex = 0;
        MultiView4.ActiveViewIndex = 1;
    }
    protected void cboReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboReason.SelectedItem.Text == "Other")
        {
            txtReason.Visible = true;
        }
        else
        {
            txtReason.Visible = false;
        }
    }
    protected void cboReason_DataBound(object sender, EventArgs e)
    {
        cboReason.Items.Insert(0, new ListItem(" -- Select Reason -- ", "0"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int QuestionID; string Answer; string ReferenceNo = lblRefNo.Text.Trim();
            int UserID = Convert.ToInt32(Session["UserID"].ToString());

            foreach (DataGridItem Record in DataGrid6.Items)
            {
                QuestionID = Convert.ToInt32(Record.Cells[0].Text);
                TextBox txtAnswer = ((TextBox)(Record.FindControl("txtAnswer")));
                Answer = txtAnswer.Text.Trim();

                Process.SaveEditQuestions(ReferenceNo, QuestionID, Answer, UserID);
            }
            ShowMessage("Form Section Has Been Successfully Saved...");
            btnPrint.Enabled = true;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void DataGrid5_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        string ID = e.Item.Cells[0].Text; string Member = e.Item.Cells[2].Text;
        string Position = e.Item.Cells[3].Text; string ReasonID = e.Item.Cells[4].Text;
        string OtherReason = e.Item.Cells[5].Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtMembers"];
        ShowMessage("."); ShowMessage4(".");
        if (e.CommandName == "btnEdit")
        {
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);

            LoadNegMemberDetailsControls(ID, Member, Position, ReasonID, OtherReason);
            DataGrid5.DataSource = dtUpdate.DefaultView;
            DataGrid5.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            else
            {
                long MemberID = Convert.ToInt64(ID);
                Process.FlagNegotiationTeamMember(MemberID, true);
            }
            ShowMessage4("Negotiation Plan Issue Detail Has Been Successfully Removed ...");
            LoadMembers(Convert.ToInt64(lblNegPlanID.Text));
        }
    }
    private void LoadNegMemberDetailsControls(string ID, string Member, string Position, string ReasonID, string OtherReason)
    {
        lblMemberID.Text = ID; txtMember.Text = Member; txtPosition.Text = Position; cboReason.SelectedValue = ReasonID;
        txtReason.Text = OtherReason; btnAddMember.Text = "Update Member";
    }
    protected void cboProcurementOfficer_DataBound(object sender, EventArgs e)
    {
        cboProcurementOfficer.Items.Insert(0, new ListItem(" -- All Proc. Officers -- ", "0"));
    }
    protected void btnSubmitToCC_Click(object sender, EventArgs e)
    {
        
       int status=  Convert.ToInt32(Session["statusIDeval"].ToString());
       int newStatus = 0;
       if (status == 106) { 

       newStatus =  80;

       }else if(status == 108){

           newStatus = 83 ;

       }
       else if (status == 110) {

           newStatus = 86;
       
       }else if(status == 63){

           newStatus = 103;
       }

        try
        {
            string Comment = "";
            if (txtComment.Text.Trim() != "")
                Comment += txtComment.Text.Trim();

            // Notify Requisitioner, Proc. Officer and CC Members
            string ReferenceNo = txtReferenceNo.Text.Trim(); string By = HttpContext.Current.Session["FullName"].ToString();
            DataTable dtAlert = Process.GetBiddingDetailsForNotification(ReferenceNo);
            string OfficerID = dtAlert.Rows[0]["POID"].ToString(); string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
            string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString(); string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
            string Message = "";

            dtUpdate = (DataTable)Session["dtEvaluation"];
            if (dtUpdate.Rows.Count == 0)
                dtUpdate = (DataTable)Session["dtLottedEvaluation"];
            if (rbnApproval.SelectedValue == "66" && cboCCOption.SelectedValue == "0")
                ShowMessage("Please Select Submission Option");
            else if (rbnApproval.SelectedValue == "65" && txtComment.Text == "")
                ShowMessage("Please Enter Comment/Remark For Rejection");
            else if (dtUpdate.Rows.Count == 0)
                ShowMessage("Please Enter Evaluations for Bidders");
            else if (rbnApproval.SelectedValue == "65" && txtComment.Text != "")
            {

                if (status == 106) {

                    newStatus = 107;
                }
                else if (status == 110)
                {
                    newStatus = 111;
                }
                string Subject = "Procurement " + dtAlert.Rows[0]["Subject"].ToString() + "  Evaluation Rejected By Procurement Supervisor";
                Process.LogandCommitBiddingDetails(lblReferenceNo.Text, newStatus, Comment);
                Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                            + RequisitionerName + "</strong> from " + CostCenterName + " has been rejected by Procurement Supervisor " + By + " </p>";
                // Notify Procurement Officer
                ProcessReq.NotifyOfficer(By, Subject, OfficerID, Message);
                ShowMessage("Evaluation Report For Procurement " + lblReferenceNo.Text + " has been rejected and sent to Desk Officer");
                LoadItems();
            }
            else
            {
                string Subject = "Procurement " + dtAlert.Rows[0]["Subject"].ToString() + "  Evaluation Submission To Contracts Committee";
            
                double BEBAmount = 0;
                datatable = Process.GetBEBDetails(ReferenceNo);
                if ((datatable.Rows.Count == 0) && !(cboCCOption.SelectedValue.Equals("2")))
                {
                    throw new Exception("Best Evaluated Bidder wasn't selected. Please reject procurement so the desk officer may add BEB.");
                }
                else
                {
                    if (cboCCOption.SelectedValue.Equals("2"))
                    {
                        BEBAmount = 0;
                    }
                    else
                    {
                        BEBAmount = Convert.ToDouble(datatable.Rows[0]["Amount"].ToString());
                    }
                }

                datatable = Process.GetCCIDForEvaluationReport(ReferenceNo, BEBAmount);
                long CCID = Convert.ToInt64(datatable.Rows[0]["CCID"].ToString());
                string ContractsCommittee = datatable.Rows[0]["CCDescription"].ToString();

                datatable = Process.GetCCIDForReferenceNo("");
                long HQCCID = Convert.ToInt64(datatable.Rows[0]["CCID"].ToString());

                if (CCID != HQCCID)
                {
                    if (cboCCOption.SelectedValue == "1")
                    {
                        if (newStatus == 86 || newStatus == 103)
                        {
                            Process.LogandCommitBiddingDetails(lblReferenceNo.Text, 54, "Submitted to " + ContractsCommittee + " For Award of Contract " + Comment);
                            Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                        + RequisitionerName + "</strong> from " + CostCenterName + " has been submitted to " + ContractsCommittee
                                        + " For Award of Contract By " + By + " </p>";
                        }
                    }
                    else if (cboCCOption.SelectedValue == "2")
                    {
                        Process.LogandCommitBiddingDetails(lblReferenceNo.Text, 55, "Submitted to " + ContractsCommittee + " For Negotiation Plan Approval " + Comment);
                        Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                    + RequisitionerName + "</strong> from " + CostCenterName + " has been submitted to " + ContractsCommittee
                                    + " For Negotiation Plan Approval By " + By + " </p>";
                    }
                    else if (cboCCOption.SelectedValue == "3")
                    {
                        Process.LogandCommitBiddingDetails(lblReferenceNo.Text, newStatus, "Submitted to " + ContractsCommittee + " For Post Qualification " + Comment);
                        Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                    + RequisitionerName + "</strong> from " + CostCenterName + " has been submitted to " + ContractsCommittee
                                    + " For Post Qualification By " + By + " </p>";
                    }
                    Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

                    // Notify Contracts Committee
                    // Process.NotifyContractsCommittee(By, Subject, Message, CCID);
                    // Notify Requisitioner
                    ProcessPlan.NotifyPlanner(By, Subject, Requisitioner, Message);
                    // Notify Procurement Officer
                    ProcessReq.NotifyOfficer(By, Subject, OfficerID, Message);
                    Process.LogCCForEvaluation(ReferenceNo, CCID);
                }
                else
                {
                    if (cboCCOption.SelectedValue == "1")
                    {
                        if (newStatus == 103)
                        {
                            Process.LogandCommitBiddingDetails(lblReferenceNo.Text, 66, "Submitted to " + ContractsCommittee + " For Award of Contract " + Comment);
                            Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                        + RequisitionerName + "</strong> from " + CostCenterName + " has been submitted to " + ContractsCommittee
                                        + " For Award of Contract By " + By + " </p>";
                        }
                       
                    }
                    else if (cboCCOption.SelectedValue == "2")
                    {

                        if (newStatus == 80)
                        {
                            Process.LogandCommitBiddingDetails(lblReferenceNo.Text, newStatus, "Submitted to " + ContractsCommittee + " For Procurement Technical Bid Evaluation Report Approval" + Comment);
                            Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                        + RequisitionerName + "</strong> from " + CostCenterName + " has been submitted to " + ContractsCommittee
                                        + " For Technical Evaluation Aprroval " + By + " </p>";
                        }


                    }
                    else if (cboCCOption.SelectedValue == "3") 
                    {

                        if (newStatus == 86)
                        {
                            Process.LogandCommitBiddingDetails(lblReferenceNo.Text, newStatus, "Submitted to " + ContractsCommittee + " For Procurement Financial Bid Evaluation Report Approval" + Comment);
                            Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                        + RequisitionerName + "</strong> from " + CostCenterName + " has been submitted to " + ContractsCommittee
                                        + " For Award of Contract By " + By + " </p>";
                        }
                    
                    
                    }
                 
                    Message += "<p>Comment: " + txtComment.Text.Trim();
                    Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

                    // Notify Contracts Committee
                    //Process.NotifyContractsCommittee(By, Subject, Message, CCID);
                    // Notify Requisitioner
                    ProcessPlan.NotifyPlanner(By, Subject, Requisitioner, Message);
                    // Notify Procurement Officer
                    ProcessReq.NotifyOfficer(By, Subject, OfficerID, Message);
                    Process.LogCCForEvaluation(ReferenceNo, 1); 
                }
                
                ShowMessage("Evaluation Report For Procurement " + lblReferenceNo.Text + " has been successfully submitted to " + ContractsCommittee);
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void rbnApproval_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbnApproval.SelectedValue == "66")
        {
            lblCCOption.Visible = true; cboCCOption.Visible = true;
        }
        else
        {
            lblCCOption.Visible = false; cboCCOption.Visible = false;
        }
    }
    protected void DataGrid8_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public bool EnableSubmitButton(object dataItem)
    {
        int IsSubmitEnabled = Convert.ToInt32(DataBinder.Eval(dataItem, "StatusID").ToString());

        if (IsSubmitEnabled == 103 || IsSubmitEnabled == 80 || IsSubmitEnabled == 83 || IsSubmitEnabled == 86)
            return true;
        else
            return false;
    }
}
