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

public partial class Bidding_Evaluation : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    BusinessBidding bllBidding = new BusinessBidding();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "0";
    DataTable dtUpdate = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadProcMethod();
                Session["FORM"] = "";
               // Status = cbostatus.SelectedValue.ToString();
                MultiView1.ActiveViewIndex = 0;
            }
            
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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
    private void CreateLottDataTable()
    {
        DataTable dtLott = new DataTable("Lott");

        dtLott.Columns.Add(new DataColumn("LottID", typeof(long)));
        dtLott.Columns.Add(new DataColumn("LottNumber", typeof(int)));
        dtLott.Columns.Add(new DataColumn("LottDescription", typeof(string)));

        Session["dtLott"] = dtLott;
        dtUpdate = dtLott;
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
    private void ClearItemControls()
    {
        ClearNegotiationPlanControls();
        ClearNegPlanDetailControls();
        ClearNegPlanMemberControls();
    }
    private void ClearNegotiationPlanControls()
    {
        cboBidder.SelectedIndex = cboBidder.Items.IndexOf(cboBidder.Items.FindByValue("0"));
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
        Status = cbostatus.SelectedValue.ToString();
        if (Status.Equals("0"))
        {

            ShowMessage("PLEASE SELECT A STATUS FOR YOUR SEARCH");

        }
        else
        {
            string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim();
            string ProcMethod = cboProcMethod.SelectedValue.ToString(); string ProcOfficer = Session["UserID"].ToString();
            string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();

            datatable = Process.GetBidEvaluationProcurements(RecordID, PrNumber, ProcOfficer, ProcMethod, Status, AreaCode, CostCenterCode);

            if (datatable.Rows.Count > 0)
            {
                DataGrid1.DataSource = datatable;
                DataGrid1.DataBind(); DataGrid1.Visible = true;
                lblEmpty.Text = ".";
            }
            else
            {
                DataGrid1.Visible = false;
                if (Status.Equals("1"))
                {
                    string EmptyMessage = "No Procurement(s) Awaiting Evaluation in the system from Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
                    lblEmpty.Text = EmptyMessage;
                }
                else {
                    string EmptyMessage = "No Evaluation Procurement(s)  in the system from Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
                    lblEmpty.Text = EmptyMessage;
                
                }
                
            }
            MultiView1.ActiveViewIndex = 0;

        }
    }
    public bool EnableSubmitButton(object dataItem)
    {
        
           int IsSubmitEnabled = Convert.ToInt32(DataBinder.Eval(dataItem, "StatusID").ToString());
            if ((IsSubmitEnabled == 89 )|| (IsSubmitEnabled == 90) || (IsSubmitEnabled == 115) || (IsSubmitEnabled == 116))
                return true;
            else
                return false;
        
        
    }

    public bool DisableViewComment(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "72") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "65") || 
            (DataBinder.Eval(dataItem, "StatusID").ToString() == "74") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "107") ||
            (DataBinder.Eval(dataItem, "StatusID").ToString() == "118") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "111") || 
            (DataBinder.Eval(dataItem, "StatusID").ToString() == "87"))
          
            return true;
        else
            return false;
    }
    public string ViewComment(object dataItem)
    {

        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "72") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "65") || 
            (DataBinder.Eval(dataItem, "StatusID").ToString() == "74") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "107") || 
            (DataBinder.Eval(dataItem, "StatusID").ToString() == "118") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "111") ||
            (DataBinder.Eval(dataItem, "StatusID").ToString() == "87"))

            return DataBinder.Eval(dataItem, "Remark").ToString();
        else
            return "";
    }
    public bool Disable(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "74"))

            return false;
        else
            return true;
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
            string proctype = e.Item.Cells[4].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            ProcMethodCode = ReturnProcMethod(ProcMethodCode);
            string Form = Process.GetForm(ProcMethodCode);
            string statusid = e.Item.Cells[13].Text;
            if (e.CommandName == "btnFillEvaluationForm")
            {

                if ((statusid.Equals("65")) || (statusid.Equals("72"))) {

                    Process.LogandCommitBiddingDetails(PRNumber, 112, "Forwarded to Pending Submission Section");
                    ShowMessage("Procurement Forwarded to Pending Submission Section");
                    cbostatus.SelectedValue = "1";
                    LoadItems();

                }
                else if ((statusid.Equals("107"))||(statusid.Equals("118"))){
                    Process.LogandCommitBiddingDetails(PRNumber, 113, "Forwarded to Pending Submission Section");
                    ShowMessage("Procurement Forwarded to Pending Submission Section");
                    cbostatus.SelectedValue = "1";
                    LoadItems();

                }
                else if ((statusid.Equals("111")) || (statusid.Equals("87")))
                {
                    Process.LogandCommitBiddingDetails(PRNumber, 114, "Forwarded to Pending Submission Section");
                    ShowMessage("Procurement Forwarded to Pending Submission Section");
                    cbostatus.SelectedValue = "1";
                    LoadItems();

                }
                else
                {
                    if (proctype.Equals("CONSULTATIONAL SERVICES"))
                    {

                        datatable = Process.GetSectionsForEvaluationReport2("I");

                    }
                    else
                    {

                        datatable = Process.GetSectionsForEvaluationReport2("J");

                    }

                    if (datatable.Rows.Count > 0)
                    {
                        cboDashboard.DataSource = datatable;
                        cboDashboard.DataTextField = "Narration";
                        cboDashboard.DataValueField = "ID";
                        cboDashboard.DataBind();
                    }
                    lblProcMethod.Text = ProcMethodCode.ToString();
                    lblRefNo.Text = PRNumber;
                    lblattach.Text = PRNumber;
                    LoadControls(PRNumber);

                    LoadDocuments1(PRNumber);
                    MultiView1.ActiveViewIndex = 3;
                    MultiView2.ActiveViewIndex = 0;
                    MultiView4.ActiveViewIndex = 7;

                    if ((statusid.Equals("114")))
                    {
                        cboDashboard.SelectedValue = "78";
                        string Section = cboDashboard.SelectedItem.ToString();
                        Session["FORM"] = "FORM26.doc";
                        lblsubheading.Text = Section;
                        btndownload.Text = "Click HERE to Download " + Section.Substring(0, 7);
                        MultiView4.ActiveViewIndex = 8;
                    }
                    else if (statusid.Equals("113"))
                    {
                        cboDashboard.SelectedValue = "76";
                        string Section = cboDashboard.SelectedItem.ToString();
                        Session["FORM"] = "FORM24.doc";
                        lblsubheading.Text = Section;
                        btndownload.Text = "Click HERE to Download " + Section.Substring(0, 7);
                        MultiView4.ActiveViewIndex = 8;
                    }
                }
            }
            else if (e.CommandName == "btnAddNegotiationPlan")
            {
                MultiView1.ActiveViewIndex = 3;
                MultiView2.ActiveViewIndex = 0;
                MultiView4.ActiveViewIndex = 0;
                LoadControls(PRNumber);
            }
            else if (e.CommandName == "btnSubmit")
            {
                
                LoadControls(PRNumber);
                MultiView1.ActiveViewIndex = 3;
                MultiView2.ActiveViewIndex = 0;
                lblReferenceNo.Text = PRNumber;
                LoadCurrencies(); LoadBidders(PRNumber);

                //LoadBidderEvaluations(PRNumber);
                
                if (statusid.Equals("90")) 
                {
                    //form 24
                    rbnForm.SelectedValue = "106";
                    rbnForm.Enabled = false;
                    txtBidValue.Visible = false;
                    txtBidValue.Text = "0,0";
                    chkIsBidderAwarded.Visible = false;
                    chkIsBidderAwarded.Checked = false;
                    cboCurrency.Visible = false;
                    cboCurrency.SelectedIndex = 5;
                    lblAreaStatus.Text = "80";
                    lblMsgs.Text = "Technical Evaluation Approval";
                    cboBidder.Enabled = true;
                }
                else if (statusid.Equals("116"))
                {
                    //form 26
                    rbnForm.SelectedValue = "110";
                    rbnForm.Enabled = false;
                    chkIsBidderAwarded.Visible = true;
                    cboCurrency.Visible = false;
                    cboCurrency.SelectedIndex = 5;
                    cboBidder.Enabled = false;
                    cboBidder.SelectedValue = "0";
                    //LoadBidderEvaluations(PRNumber, 1);
                    lblAreaStatus.Text = "86";
                    lblMsgs.Text = "Financial Evaluation Approval";
                }
                else if (statusid.Equals("89"))
                {
                    //form 16
                    rbnForm.SelectedValue = "63";
                    rbnForm.Enabled = false;
                    lblAreaStatus.Text = "66";
                    cboBidder.Enabled = true;
                    lblMsgs.Text = "Award of Contract ";
                }
                MultiView4.ActiveViewIndex = 4;
                LoadBEBS(txtReferenceNo.Text);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadBidderEvaluations(string PRNumber)
    {
        datatable = Process.GetBidderEvaluations(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            if (datatable.Rows[0]["LottID"].ToString() == "")
            {
                LoadBEBS(PRNumber); MultiView4.ActiveViewIndex = 4;
            }

        }
        else 
        {
            datatable =  dtUpdate;
            DataGrid7.DataSource = datatable;
            DataGrid7.DataBind(); DataGrid7.Visible = true; btnSubmitToCC.Enabled = false;
            lblNoRecords.Visible = false; btnPrint.Enabled = true;
        
        }
        
    }
    private void LoadBEBS(string PRNumber)
    {
        CreateBidderEvaluationsDataTable();
        datatable = Process.GetBidderEvaluations(PRNumber);
        lblReferenceNo.Text = PRNumber;
        if (!bllBidding.IsProcurementFromArea(txtReferenceNo.Text))
        {
            lblCCOption.Visible = false; cboCCOption.Visible = false;
        }
        else
        {
            lblCCOption.Visible = false; cboCCOption.Visible = false;
        }
        if (datatable.Rows.Count > 0)
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
            DataGrid7.DataSource = datatable;
            DataGrid7.DataBind(); DataGrid7.Visible = true; btnSubmitToCC.Enabled = true;
            lblNoRecords.Visible = false; btnPrint.Enabled = true;
        }
        else
        {
            DataGrid7.DataSource = null; DataGrid7.Visible = false; btnSubmitToCC.Enabled = false; 
            lblNoRecords.Visible = true; btnPrint.Enabled = false;
        }
    }
    private void LoadCurrencies()
    {
        datatable = ProcessPlan.GetCurrencies();
        cboCurrency.DataSource = datatable; cboCurrency.DataValueField = "Code"; 
        cboCurrency.DataTextField = "Currency"; cboCurrency.DataBind();

        cboCurrencyLott.DataSource = datatable; cboCurrencyLott.DataValueField = "Code";
        cboCurrencyLott.DataTextField = "Currency"; cboCurrencyLott.DataBind();
    }
    private void LoadBidders(string ReferenceNo)
    {
        cboBidder.DataSource = Process.GetBiddersForBidOpeningByReferenceNo(ReferenceNo);
        cboBidder.DataValueField = "BidderID";
        cboBidder.DataTextField = "BidderName";
        cboBidder.DataBind();

        cboSupplierLott.DataSource = Process.GetBiddersForBidOpeningByReferenceNo(ReferenceNo);
        cboSupplierLott.DataValueField = "BidderID";
        cboSupplierLott.DataTextField = "BidderName";
        cboSupplierLott.DataBind();
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
            {
              //  btnSubmitFinal.Enabled = false; btnPrint.Enabled = false;
                btnSubmitFinal.Visible = false; btnPrint.Visible = false;
                Session["FORM"] = "";
            }
            else if (cboDashboard.SelectedValue == "75")
            {

                string Section = cboDashboard.SelectedItem.ToString();
                Session["FORM"] = "FORM16.docx";
                lblsubheading.Text = Section;
                btndownload.Text = "Click HERE to Download " + Section.Substring(0, 7);
                MultiView4.ActiveViewIndex = 8;
            
            }
            else if (cboDashboard.SelectedValue == "76")
            {

                string Section = cboDashboard.SelectedItem.ToString();
                Session["FORM"] = "FORM24.doc";
                lblsubheading.Text = Section;
                btndownload.Text = "Click HERE to Download " + Section.Substring(0,7);
                MultiView4.ActiveViewIndex = 8;
               
               // btnSubmit.Enabled = true; btnPrint.Enabled = true;
            }
            else if (cboDashboard.SelectedValue == "78") {

                string Section = cboDashboard.SelectedItem.ToString();
                Session["FORM"] = "FORM26.doc";
                lblsubheading.Text = Section;
                btndownload.Text = "Click HERE to Download " + Section.Substring(0, 7);
                MultiView4.ActiveViewIndex = 8;
                
            }

            
           
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
             string ReportName="";
            if (txtProcType.Text.Equals("CONSULTATIONAL SERVICES"))
            {
                ReportName = "form24";
            }
            else {

                ReportName = "form16";
                btnPrint.Enabled = true;
            }

           /* string FormNumber = datatable.Rows[0]["FormNumber"].ToString();
            string Section = cboDashboard.SelectedValue.ToString();
            int NewProcMethod = ReturnProcMethod(ProcMethod);
            ReportName = Process.GetReportName(NewProcMethod, FormNumber, Section, true);

            
            int rowcount = datatable.Rows.Count;*/
            datatable = Process.GetDetailsForForm16(ReferenceNo);
            //if (rowcount != 0)
           // {
                btnPrint.Enabled = true;
                loadreport(ReportName);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, ReportName);
           // }
         //   else
          ///      ShowMessage("No Data To Load For Report Form Selected ...");
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
        rptName = physicalPath + "\\Bin\\Reports\\Bidding\\newreports\\" + ReportName + ".rpt";

       // doc.Load(rptName);
       //doc.SetDataSource(datatable);

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
    private void LoadDocuments1(string Reference)
    {
        //MultiView4.ActiveViewIndex = 7;
        string Ref = Reference;
        DataTable dt = new DataTable();
        dt = Process.GetBiddingDocuments(Ref, 5);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Visible = true;
            lblNoAttachments1.Visible = false;
        }
        else
        {
            lblNoAttachments1.Visible = true;
            GridView1.Visible = false;
        }
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
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 5);
                LoadDocuments();
            }
        }
    }
    private int UploadFiles1(string ReferenceNo)
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
                FileField1.PostedFile.SaveAs(Path + "" + c1);
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 5);
                // LoadDocuments1();
            }
            else {

                return 0;
            
            }
           
        }
        return 1;
    }
    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            string RefNo = lblAttachRefNo.Text.Trim();
            UploadFiles(RefNo);
            LoadDocuments();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
              
                string FileCode = e.CommandArgument.ToString();
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
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try 
        {
            if (e.CommandName == "btnRemove")
            {
               
                string FileCode = e.CommandArgument.ToString();
                //ConfirmRemoveDocument(FileCode);
                Process.RemoveDocument(FileCode);
                LoadDocuments1(txtReferenceNo.Text.Trim());
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView1.DataKeys[intIndex].Value);
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
        ShowMessage(".");
    }
    protected void btnSubmitToCC_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        SubmitProcurementToCCHQPDU((DataTable)Session["dtEvaluation"]);
    }
    public void SubmitProcurementToCCHQPDU(DataTable dtEvaluations)
    {

        int statusID = 0;
        if (rbnForm.SelectedValue.ToString().Equals(""))
        {

            ShowMessage("Please Select a Form to Submit");
        }
        else
        {
            statusID = Convert.ToInt32(rbnForm.SelectedValue.ToString());

                    try
                    {
                        if (bllBidding.IsProcurementFromArea(txtReferenceNo.Text) && cboCCOption.SelectedValue == "0" && cboCCOption.Visible == true)
                            ShowMessage("Please Select Option");
                        else if (bllBidding.IsProcurementFromArea(txtReferenceNo.Text) && cboCCOptionLott.SelectedValue == "0" && cboCCOptionLott.Visible == true)
                            ShowMessage("Please Select Option");
                        else if (dtEvaluations.Rows.Count == 0)
                            ShowMessage("Please Enter Evaluations for Bidders");
                        else
                        {
                            // Notify Requisitioner, Proc. Officer and CC Members
                            string ReferenceNo = txtReferenceNo.Text.Trim(); string By = HttpContext.Current.Session["FullName"].ToString();
                            DataTable dtAlert = Process.GetBiddingDetailsForNotification(ReferenceNo);
                            string Subject = "Procurement " + dtAlert.Rows[0]["Subject"].ToString() + "  Evaluation Submission To Contracts Committee";
                            string OfficerID = dtAlert.Rows[0]["POID"].ToString(); string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
                            string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
                            string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString(); string ContractsCommittee = dtAlert.Rows[0]["CCDescription"].ToString();
                            long CCID = Convert.ToInt64(dtAlert.Rows[0]["CCID"].ToString());

                            string Message = "";
                            if (bllBidding.IsProcurementFromArea(ReferenceNo))
                            {
                                
                                double Amount = 0, MaxAmount = 0; DataTable dtExchangeRate;
                                foreach (DataRow dr in dtEvaluations.Rows)
                                {
                                    if (dr["IsBeB"].ToString() == "True")
                                    {
                                        Amount = Convert.ToDouble(dr["BidValue"].ToString());
                                        dtExchangeRate = ProcessPlan.GetCurrency(dr["BidUnitID"].ToString());
                                        MaxAmount = Amount * Convert.ToDouble(dtExchangeRate.Rows[0]["Amount"].ToString());
                                        if (Amount >= MaxAmount)
                                            MaxAmount = Amount;
                                    }
                                }
                                long CCEvaluationID = 0;
                                datatable = Process.GetCCIDForEvaluationReport(txtReferenceNo.Text, MaxAmount);
                                if (datatable.Rows.Count > 0)
                                {
                                    CCEvaluationID = Convert.ToInt64(datatable.Rows[0]["CCID"].ToString());
                                    Process.LogCCForEvaluation(txtReferenceNo.Text, CCEvaluationID);
                                }

                                if (CCID == CCEvaluationID && Session["IsAreaProcess"].ToString() == "1")
                                {

                                    int status = Convert.ToInt32(lblAreaStatus.Text.ToString().Trim());
                                    string msg = lblMsgs.Text.ToString().Trim();
                                    Process.LogandCommitBiddingDetails(txtReferenceNo.Text, status, "Submitted to " + ContractsCommittee + " For Award of Contract ");
                                        Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                                    + RequisitionerName + "</strong> from " + CostCenterName + " has been submitted to " + ContractsCommittee
                                                    + " For " + msg + " By " + By + " </p>";
                                    
                                    
                                 
                                    Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

                                    // Notify Contracts Committee
                                    //Process.NotifyContractsCommittee(By, Subject, Message, CCID);
                                    // Notify Requisitioner
                                    ProcessPlan.NotifyPlanner(By, Subject, Requisitioner, Message);

                                    ShowMessage("Evaluation Report For Procurement " + txtReferenceNo.Text + " has been successfully submitted to " + ContractsCommittee + " FOR " + msg);
                                }
                                
                            }
                                //HQ EVALUATION REPORT
                            else
                            {
                              
                 
                                Process.LogandCommitBiddingDetails(txtReferenceNo.Text, statusID, "Submitted to HQ Procurement Supervisor ");

                                Process.LogCCForEvaluation(txtReferenceNo.Text, 1);
                                Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + " By "
                                                + RequisitionerName + "</strong> from " + CostCenterName + " has been sent For Evaluation Report Review By " + By + " </p>";
                                Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";
                                // Notify Procurement Supervisor
                                Process.NotifyPDUSupervisors(By, Subject, Message);

                                ShowMessage("Evaluation Report For Procurement " + txtReferenceNo.Text + " has been successfully submitted to HQ Procurement Supervisor ");
                            }
                            Status = "1";
                            LoadItems();
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message);
                    }
        }
    }
    protected void cboBidder_DataBound(object sender, EventArgs e)
    {
        cboBidder.Items.Insert(0, new ListItem("-- Select Bidders --", "0"));
    }
    protected void cboUnit_DataBound(object sender, EventArgs e)
    {
       cboCurrency.Items.Insert(0, new ListItem("-- Select Currency --", "0"));
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
    private void ShowMessage5(string Message)
    {
        if (Message == ".")
            lblMsg4.Text = ".";
        else
            lblMsg4.Text = "MESSAGE: " + Message;
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
            MultiView1.ActiveViewIndex = 3;
            MultiView2.ActiveViewIndex = 0;
            MultiView4.ActiveViewIndex = 1;
            LoadExistingNegotiationPlans(txtReferenceNo.Text);
        }
    }
    private void LoadNegotiationPlanControls(string NegotiationPlanID, string ProviderName, string ProposedBy)
    {
        lblNegotiationPlanID.Text = NegotiationPlanID;
        cboBidder.SelectedIndex = cboBidder.Items.IndexOf(cboBidder.Items.FindByValue(ProviderName));
        txtProposedBy.Text = ProposedBy;
        btnAdd.Text = "Update Negotiation Plan";
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
        //MultiView1.ActiveViewIndex = 0;
        MultiView1.ActiveViewIndex = 3;
        MultiView2.ActiveViewIndex = 0;
        MultiView4.ActiveViewIndex = 7;
        ShowMessage(".");
        Status = "1";
        LoadItems();

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
            MultiView1.ActiveViewIndex = 3;
            MultiView2.ActiveViewIndex = 0;
            MultiView4.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 0;
        }
        else if (e.CommandName == "btnAddTeam")
        {
            LoadMembers(NegPlanID); LoadMemberReasons(1);
            MultiView1.ActiveViewIndex = 3;
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
            DataGrid4.DataBind(); DataGrid4.Visible = true;
            lblNoNegIssues.Visible = false;
        }
        else
        {
            DataGrid4.DataSource = null; DataGrid4.Visible = false;
            lblNoNegIssues.Visible = true;
        }
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
                DataGrid4.DataBind(); DataGrid4.Visible = true;
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
            MultiView1.ActiveViewIndex = 3;
            MultiView2.ActiveViewIndex = 0;
            MultiView4.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 0;
        }
    }
    protected void btnCancelDetails_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
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

            MultiView1.ActiveViewIndex = 3;
            MultiView2.ActiveViewIndex = 0;
            MultiView4.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 1;
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
        MultiView1.ActiveViewIndex = 3;
        MultiView2.ActiveViewIndex = 0;
        MultiView4.ActiveViewIndex = 1;
        LoadExistingNegotiationPlans(txtReferenceNo.Text); 
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
    protected void btnSubmitFinal_Click(object sender, EventArgs e)
    {


        try
        {
            ShowMessage(".");
            string RefNo = txtReferenceNo.Text.Trim();

            int done = UploadFiles1(RefNo);

            

            if(done == 0){

             ShowMessage(" Please Upload a File ");
                

            } else if (done == 1){

                ShowMessage(".");
               LoadDocuments1(RefNo);
                
                string remark = "";
                int status = 0;
                if (cboDashboard.SelectedValue == "75")
                {

                  remark =   "FORM16 uploaded and ready for submission";
                    
                    status = 89;
                }
                else if (cboDashboard.SelectedValue == "76")
                {

                    remark = "FORM 24  uploaded and ready for submission";
                    status = 90  ;
                }
                else if (cboDashboard.SelectedValue == "77")
                {


                    remark = "FORM 25 uploaded and ready for submission ";
                    status = 115 ;


                }
                else if (cboDashboard.SelectedValue == "78")
                {

                    remark = "FORM 26  uploaded and ready for submission ";
                    status = 116;

                }
                ShowMessage("Form successfully uploaded");
            Process.LogandCommitBiddingDetails(RefNo, status ,remark);

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
    private void LoadNonLottedEvaluationControls(string ID, string BidderID, bool IsBEB, string BidUnitID, string BidValue, string Reason)
    {
        lblRecordID.Text = ID; cboBidder.SelectedValue = BidderID; chkIsBidderAwarded.Checked = IsBEB;
        cboCurrency.SelectedValue = BidUnitID; txtBidValue.Text = BidValue; txtComment.Text = Reason;
        btnAddBiddingDetails.Text = "Update Evaluation Details";
    }
    protected void btnAddBiddingDetails_Click(object sender, EventArgs e)
    {
        if ((cboCurrency.SelectedValue == "0") && (rbnForm.SelectedValue != "106"))
            ShowMessage("Please Select Final Bid Value Unit");
        else if (cboBidder.SelectedValue == "0")
            ShowMessage("Please Select Recommended Bidder");
        else if ((txtBidValue.Text.Trim() == "") && (rbnForm.SelectedValue != "106"))
            ShowMessage("Please Enter The Final Bid Value");
        else if (txtComment.Text.Trim() == "")
            ShowMessage("Please Enter A Comment / Recommendation");
        else
        {
            double BidValue;
            long BidUnitID;
            string Unit;
            bool IsBEB;
            long BidderID = Convert.ToInt64(cboBidder.SelectedValue.ToString()); string BidderName = cboBidder.SelectedItem.Text;
            if (rbnForm.SelectedValue != "106")
            {
                BidValue = Convert.ToDouble(txtBidValue.Text.Trim().Replace(",", ""));
                BidUnitID = Convert.ToInt64(cboCurrency.SelectedValue.ToString());
                Unit = cboCurrency.SelectedItem.Text; IsBEB = chkIsBidderAwarded.Checked;
            }
            else {

               BidValue = 0.0;
               BidUnitID = Convert.ToInt64(5);
               Unit = "Uganda Shillings"; IsBEB = chkIsBidderAwarded.Checked;
            
            }
            
            string Reason = txtComment.Text.Trim(); 
            long RecordID = 0;
            dtUpdate = (DataTable)Session["dtEvaluation"];
            if (btnAddBiddingDetails.Text.Contains("Update"))
            {
                RecordID = Convert.ToInt64(lblRecordID.Text.Trim());
                /*int i = 0;
                foreach (DataRow dr in dtUpdate.Rows)
                {
                    if (Convert.ToInt64(dr["RecordID"]) == RecordID)
                    {
                        dtUpdate.Rows.RemoveAt(i);
                        break;
                    }
                    i++;
                }*/
                btnAddBiddingDetails.Text = "ADD DETAILS";
            }

            dtUpdate.Rows.Add(new object[] { RecordID, BidderID, BidderName, IsBEB, BidUnitID, Unit, BidValue, Reason });
            ClearNonLottedEvaluationItemControls();

            ShowMessage2("Bid Evaluation Detail Has Been Successfully Added");

            Session["dtEvaluation"] = dtUpdate;
            DataGrid7.DataSource = dtUpdate.DefaultView;
            DataGrid7.DataBind(); DataGrid7.Visible = true;
            lblNoRecords.Visible = false;
        }
    }
    private void ClearNonLottedEvaluationItemControls()
    {
        txtComment.Text = ""; lblRecordID.Text = ""; 
        chkIsBidderAwarded.Checked = false; txtBidValue.Text = "";
        cboCurrency.SelectedValue = "0"; cboBidder.SelectedValue = "0";
    }
    private void ClearLottedEvaluationItemControls()
    {
        txtCommentLott.Text = ""; chkIsBidderAwardedLott.Checked = false;
        txtBidValueLott.Text = ""; cboCurrencyLott.SelectedValue = "0"; cboSupplierLott.SelectedValue = "0";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        dtUpdate = (DataTable)Session["dtEvaluation"];
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Bidder Evaluations");
        }
        else
        {
            Session["dtEvaluation"] = dtUpdate;
            DataTable dtEvaluation = (DataTable)Session["dtEvaluation"];
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());
            string RefNo = lblReferenceNo.Text;
            string Response = Process.SaveEditBidderEvaluations(RefNo, dtEvaluation, CreatedBy);
            ShowMessage(Response); btnSubmitToCC.Enabled = true;
           LoadBEBS(RefNo);
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
    protected void btnYes_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        MultiView2.ActiveViewIndex = 0;
        MultiView4.ActiveViewIndex = 5;
        LoadExistingLotts();
    }
    private void ClearLottControls()
    {
        txtLottNumber.Text = ""; txtLottDescription.Text = ""; btnAddLott.Text = "ADD LOTT";
    }
    private void LoadLottControls(string LottID, string LottNumber, string LottDescription)
    {
        lblLottID.Text = LottID; txtLottNumber.Text = LottNumber;
        txtLottDescription.Text = LottDescription; btnAddLott.Text = "UPDATE LOTT";
    }
    private void LoadExistingLotts()
    {
        CreateLottDataTable(); ClearLottControls();
        datatable = Process.GetLotts(txtReferenceNo.Text);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long LottID = Convert.ToInt64(dr["LottID"].ToString()); 
                int LottNumber = Convert.ToInt32(dr["LottNumber"].ToString());
                string LottDescription = dr["LottDescription"].ToString();

                dtUpdate.Rows.Add(new object[] { LottID, LottNumber, LottDescription });
            }
            Session["dtLott"] = dtUpdate;
            DataGrid8.DataSource = datatable;
            DataGrid8.DataBind(); DataGrid8.Visible = true; 
            btnSaveLotts.Enabled = true; lblNoLotts.Visible = false;
            btnAddLottDetails.Enabled = true;
        }
        else
        {
            DataGrid8.DataSource = null; DataGrid8.Visible = false;
            btnSaveLotts.Enabled = false; lblNoLotts.Visible = true;
            btnAddLottDetails.Enabled = false;
        }
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        MultiView2.ActiveViewIndex = 0;
        MultiView4.ActiveViewIndex = 4;
        LoadBEBS(txtReferenceNo.Text);
    }
    protected void btnAddLott_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage("."); ShowMessage5(".");
            if (String.IsNullOrEmpty(txtLottNumber.Text.Trim()))
                ShowMessage5("Please Enter Lott Number");
            else if (String.IsNullOrEmpty(txtLottDescription.Text.Trim()))
                ShowMessage5("Please Enter Lott Description");
            else
            {
                long LottID = 0;
                int LottNumber = Convert.ToInt32(txtLottNumber.Text.Trim());
                string LottDescription = txtLottDescription.Text.Trim();

                dtUpdate = (DataTable)Session["dtLott"];
                if (btnAddLott.Text.Contains("Update"))
                {
                    LottID = Convert.ToInt64(lblLottID.Text);
                    int i = 0;
                    foreach (DataRow dr in dtUpdate.Rows)
                    {
                        if (Convert.ToInt64(dr["LottID"]) == LottID)
                        {
                            dtUpdate.Rows.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                }
                dtUpdate.Rows.Add(new object[] { LottID, LottNumber, LottDescription });
                ClearLottControls();

                ShowMessage5("Lott Details Has Been Successfully Added");

                Session["dtLott"] = dtUpdate;
                DataGrid8.DataSource = dtUpdate.DefaultView;
                DataGrid8.DataBind(); DataGrid8.Visible = true;
                lblNoLotts.Visible = false; btnSaveLotts.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            ShowMessage4(ex.Message);
        }
    }
    protected void btnSaveLotts_Click(object sender, EventArgs e)
    {
        ShowMessage5("."); ShowMessage(".");
        dtUpdate = (DataTable)Session["dtLott"];

        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Lott Details");
            ShowMessage5("Please Add Lott Details");
        }
        else
        {
            Session["dtLott"] = dtUpdate;
            DataTable dtLott = (DataTable)Session["dtLott"];
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());
            string RefNo = txtReferenceNo.Text;
            string Response = Process.SaveEditLotts(RefNo, dtLott, CreatedBy);
            ShowMessage(Response); ShowMessage5(Response);
            LoadExistingLotts();
        }
    }
    protected void btnLottCancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void cboCurrencyLott_DataBound(object sender, EventArgs e)
    {
        cboCurrencyLott.Items.Insert(0, new ListItem("-- Select Currency --", "0"));
    }
    protected void btnCancelLottDetails_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        MultiView2.ActiveViewIndex = 0;
        MultiView4.ActiveViewIndex = 5;
        LoadExistingLotts();
    }
    private void LoadLottedBEBS(string ReferenceNo)
    {
        CreateLottedBidderEvaluationsDataTable();
        LoadLotts(ReferenceNo);
        datatable = Process.GetLottedBidderEvaluations(ReferenceNo);
        if (!bllBidding.IsProcurementFromArea(ReferenceNo))
        {
            lblCCOptionLott.Visible = false; cboCCOptionLott.Visible = false;
        }
        else
        {
            lblCCOptionLott.Visible = true; cboCCOptionLott.Visible = true;
        }
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
            DataGrid9.DataSource = datatable;
            DataGrid9.DataBind(); DataGrid9.Visible = true;
            lblNoLottEvaluations.Visible = false;
        }
        else
        {
            DataGrid9.DataSource = null; DataGrid9.Visible = false;
            lblNoLottEvaluations.Visible = true;
        }
    }
    private void LoadLotts(string ReferenceNo)
    {
        datatable = Process.GetLottDetails(ReferenceNo);
        cboLott.DataSource = datatable; cboLott.DataValueField = "LottID";
        cboLott.DataTextField = "Lott"; cboLott.DataBind();
    }
    protected void cboLott_DataBound(object sender, EventArgs e)
    {
        cboLott.Items.Insert(0, new ListItem(" -- Select Lott -- ", "0"));
    }
    protected void DataGrid8_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string LottID = e.Item.Cells[0].Text;
        if (e.CommandName == "btnAddLottDetails")
        {
            
        }
    }
    protected void btnAddLottDetails_Click(object sender, EventArgs e)
    {
        LoadLottedBEBS(txtReferenceNo.Text);
        MultiView1.ActiveViewIndex = 3;
        MultiView2.ActiveViewIndex = 0;
        MultiView4.ActiveViewIndex = 6;
    }
    protected void btnAddLottEvaluations_Click(object sender, EventArgs e)
    {
        if (cboCurrencyLott.SelectedValue == "0")
            ShowMessage("Please Select Final Bid Value Currency");
        else if (cboSupplierLott.SelectedValue == "0")
            ShowMessage("Please Select Bidder");
        else if (txtBidValueLott.Text.Trim() == "")
            ShowMessage("Please Enter The Final Bid Value");
        else if (txtCommentLott.Text.Trim() == "")
            ShowMessage("Please Enter A Comment / Recommendation / Reason");
        else if (cboLott.SelectedValue == "0")
            ShowMessage("Please Select Lott");
        else
        {
            long RecordID = 0;
            long LottID = Convert.ToInt32(cboLott.SelectedValue.ToString());
            datatable = Process.GetLottByID(LottID);
            int LottNumber = 0; string LottDescription = "";
            if (datatable.Rows.Count > 0)
            {
                LottNumber = Convert.ToInt32(datatable.Rows[0]["LottNumber"].ToString());
                LottDescription = datatable.Rows[0]["LottDescription"].ToString();
            }
            long BidderID = Convert.ToInt64(cboSupplierLott.SelectedValue); string BidderName = cboSupplierLott.SelectedItem.Text;
            double BidValue = Convert.ToDouble(txtBidValueLott.Text.Trim().Replace(",", "")); long BidUnitID = Convert.ToInt64(cboCurrencyLott.SelectedValue);
            string Unit = cboCurrencyLott.SelectedItem.Text; bool IsBEB = chkIsBidderAwardedLott.Checked;
            string Reason = txtCommentLott.Text.Trim();

            dtUpdate = (DataTable)Session["dtLottedEvaluation"];
            if (btnAddLottEvaluations.Text.Contains("Update"))
            {
                RecordID = Convert.ToInt64(lblRecordIDLott.Text.Trim());
                int i = 0;
                foreach (DataRow dr in dtUpdate.Rows)
                {
                    if (Convert.ToInt64(dr["RecordID"]) == RecordID)
                    {
                        dtUpdate.Rows.RemoveAt(i);
                        break;
                    }
                    i++;
                }
            }
            dtUpdate.Rows.Add(new object[] { RecordID, BidderID, BidderName, IsBEB, LottID, LottNumber, LottDescription, BidUnitID, Unit, BidValue, Reason });
            ClearLottedEvaluationItemControls();

            ShowMessage2("Lott Bid Evaluation Detail Has Been Successfully Added");

            Session["dtLottedEvaluation"] = dtUpdate;
            DataGrid9.DataSource = dtUpdate.DefaultView;
            DataGrid9.DataBind(); DataGrid9.Visible = true;
            lblNoLottEvaluations.Visible = false;
        }
    }
    protected void btnSaveLottDetails_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        dtUpdate = (DataTable)Session["dtLottedEvaluation"];
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Lotted Bidder Evaluations");
        }
        else
        {
            Session["dtLottedEvaluation"] = dtUpdate;
            DataTable dtLottedEvaluation = (DataTable)Session["dtLottedEvaluation"];
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());
            string RefNo = txtReferenceNo.Text;
            string Response = Process.SaveEditLottedBidderEvaluations(RefNo, dtLottedEvaluation, CreatedBy);
            ShowMessage(Response);
            LoadLottedBEBS(txtReferenceNo.Text);
        }
    }
    protected void cboSupplierLott_DataBound(object sender, EventArgs e)
    {
        cboSupplierLott.Items.Insert(0, new ListItem(" -- Select Bidder -- ", "0"));
    }
    protected void btnSubmitLotts_Click(object sender, EventArgs e)
    {
        SubmitProcurementToCCHQPDU((DataTable)Session["dtLottedEvaluation"]);
    }
    protected void DataGrid7_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string ID = e.Item.Cells[0].Text; int ItemRowIndex = e.Item.DataSetIndex;

        dtUpdate = (DataTable)Session["dtEvaluation"];
        ShowMessage("."); ShowMessage3(".");
        if (e.CommandName == "btnEdit")
        {
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            else {

                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            }

            string BidderID = e.Item.Cells[1].Text;
            string BidderName = e.Item.Cells[2].Text; bool IsBEB = Convert.ToBoolean(e.Item.Cells[3].Text);
            string BidUnitID = e.Item.Cells[4].Text; string BidValue = e.Item.Cells[6].Text;
            string Reason = e.Item.Cells[7].Text;

            ClearNonLottedEvaluationItemControls();
            LoadNonLottedEvaluationControls(ID, BidderID, IsBEB, BidUnitID, BidValue, Reason);
            DataGrid7.DataSource = dtUpdate.DefaultView;
            DataGrid7.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            else
            {
                long EvaluationID = Convert.ToInt64(ID);
                Process.FlagBidderEvaluation(EvaluationID, true);
            }
            ShowMessage3("Bidder Evaluation Detail Has Been Successfully Removed ...");
            LoadBidderEvaluations(lblReferenceNo.Text);
        }
    }
    protected void btndownload_click(object sender, EventArgs e)
    {
       

        if (!Session["FORM"].ToString().Equals(""))
        {
            string form = Session["FORM"].ToString();
            string Path = "D:\\Reports\\ProcurementAttachments\\biddingFormsForDownload\\" + form;
            //Process.GetDocumentPath(FileCode);
            Process.DownloadFile(Path, true);
        }
        else {
            ShowMessage("PLEASE SELECT A FORM TO DOWNLOAD");
        }
    }


    protected void rbnForm_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
