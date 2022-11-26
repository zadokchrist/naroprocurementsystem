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
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Web;
//using CrystalDecisions.Shared;

public partial class Bidding_BidOpening : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
//    private ReportDocument doc = new ReportDocument();
    DataTable datatable = new DataTable();
    DataTable dtUpdate = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "52";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadPDUMembers(); LoadBidOpeningType();
                LoadProcMethod();
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
    private void LoadBidOpeningType()
    {
        cboBidOpeningType.DataSource = Process.GetBidOpeningTypes();
        cboBidOpeningType.DataValueField = "BidOpeningTypeID";
        cboBidOpeningType.DataTextField = "OpeningType";
        cboBidOpeningType.DataBind();
    }
    private void LoadPDUMembers()
    {
        cboPDUSign.DataSource = ProcessReq.GetPDUMembers();
        cboPDUSign.DataValueField = "UserID";
        cboPDUSign.DataTextField = "Name";
        cboPDUSign.DataBind();
    }
    private void LoadCurrencies()
    {
        cboCurrency.DataSource = Process.GetCurrencies();
        cboCurrency.DataValueField = "CurrencyID";
        cboCurrency.DataTextField = "Currency";
        cboCurrency.DataBind();

        cboBidCurrency.DataSource = Process.GetCurrencies();
        cboBidCurrency.DataValueField = "CurrencyID"; cboBidCurrency.DataTextField = "Currency";
        cboBidCurrency.DataBind();
    }
    private void LoadBidders(string ReferenceNo)
    {
        cboBidder.DataSource = Process.GetBiddersForBidOpeningByReferenceNo(ReferenceNo);
        cboBidder.DataValueField = "BidderID";
        cboBidder.DataTextField = "BidderName";
        cboBidder.DataBind();
    }
    private void LoadCCMembers(long CCID)
    {
        datatable = Process.GetCCMembersByCCID(CCID);
        if (datatable.Rows.Count > 0)
            cboContractsCommitteeSign.DataSource = datatable;
        else
        {
            DataTable dtable = Process.GetCCIDForReferenceNo(txtReferenceNo.Text);
            if (dtable.Rows.Count > 0)
            {
                CCID = Convert.ToInt64(dtable.Rows[0]["CCID"].ToString());
                cboContractsCommitteeSign.DataSource = Process.GetCCMembersByCCID(CCID);
            }
            else
                throw new Exception("No Contracts Committee Members, Please Contact System Administrator");
        }
        cboContractsCommitteeSign.DataValueField = "UserID";
        cboContractsCommitteeSign.DataTextField = "CCMemberName";
        cboContractsCommitteeSign.DataBind();
    }
    public bool EnableCloseButton(object dataItem)
    {
        bool IsBidOpeningCloseEnabled = Convert.ToBoolean(DataBinder.Eval(dataItem, "IsBidOpeningCloseEnabled").ToString());
        string status = DataBinder.Eval(dataItem, "StatusID").ToString();

        if ((IsBidOpeningCloseEnabled)&& !(status.Equals("117")))
            return true;
        else
            return false;
    }
    private void CreateBidOpeningDataTable()
    {
        DataTable dtBidOpening = new DataTable("BidOpening");

        dtBidOpening.Columns.Add(new DataColumn("BidOpeningID", typeof(long)));
        dtBidOpening.Columns.Add(new DataColumn("Location", typeof(string)));
        dtBidOpening.Columns.Add(new DataColumn("DateOfOpening", typeof(DateTime)));
        dtBidOpening.Columns.Add(new DataColumn("OpeningTypeID", typeof(int)));
        dtBidOpening.Columns.Add(new DataColumn("OpeningType", typeof(string)));
        dtBidOpening.Columns.Add(new DataColumn("PDUMemberID", typeof(long)));
        dtBidOpening.Columns.Add(new DataColumn("PDUMember", typeof(string)));
        dtBidOpening.Columns.Add(new DataColumn("CCMemberID", typeof(long)));
        dtBidOpening.Columns.Add(new DataColumn("CCMember", typeof(string)));

        dtBidOpening.Rows.Clear();

        Session["dtBidOpening"] = dtBidOpening;
        dtUpdate = dtBidOpening;
    }
    private void CreateBidOpeningDetailsDataTable()
    {
        DataTable dtBidOpeningDetails = new DataTable("BidOpeningDetails");
        
        dtBidOpeningDetails.Columns.Add(new DataColumn("BidOpeningDetailsID", typeof(long)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("BidderID", typeof(long)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("BidderName", typeof(string)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("CurrencyID", typeof(int)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("Currency", typeof(string)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("Price", typeof(double)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("BidSecurityReceived", typeof(bool)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("BidSecurityCurrencyID", typeof(int)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("BidSecurityCurrency", typeof(string)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("BidSecurityAmount", typeof(double)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("NoOfCopies", typeof(int)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("Remarks", typeof(string)));
        dtBidOpeningDetails.Columns.Add(new DataColumn("PowerOfAttorney", typeof(string)));
        dtBidOpeningDetails.Rows.Clear();

        Session["dtBidOpeningDetails"] = dtBidOpeningDetails;
        dtUpdate = dtBidOpeningDetails;
    }
    private void ClearItemControls()
    {
        ClearOpenedBidItemControls(); ClearBidOpeningControls();
    }
    private void LoadAreas()
    {
        datatable = data.GetAreas();
        cboAreas.DataSource = datatable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();

        if (Session["IsAreaProcess"].ToString() == "1")
        {
            cboAreas.SelectedValue = Session["AreaCode"].ToString();
            int AreaID = Convert.ToInt32(cboAreas.SelectedValue);
            LoadCostCenters(AreaID);
            cboAreas.Enabled = false;
        }
        else
        {
            cboAreas.Enabled = true;
            LoadCostCenters(cboAreas.SelectedIndex);
        }
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
        string ProcMethod = cboProcMethod.SelectedValue.ToString(); string ProcOfficer = Session["UserID"].ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();

        datatable = Process.GetBidOpeningProcurements(RecordID, PrNumber, ProcMethod, ProcOfficer, Status, AreaCode, CostCenterCode);

        if (datatable.Rows.Count > 0)
        {
            DataGrid1.Visible = true;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind();
            lblEmpty.Text = ".";
        }
        else
        {
            DataGrid1.Visible = false;
            string EmptyMessage = "No Procurement(s) Ready For Bid Opening in the system From Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
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
            long CCID = 0;
            string sCCID = datatable.Rows[0]["CCID"].ToString();
            if (sCCID != "")
                CCID = Convert.ToInt64(datatable.Rows[0]["CCID"].ToString());
            LoadCCMembers(CCID);
        }
        LoadBidOpening(PRNumber);
    }
    private void LoadBidOpeningDetails(long BidOpeningID)
    {
        CreateBidOpeningDetailsDataTable();
        datatable = Process.GetBidOpeningDetails(BidOpeningID);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long BidOpeningDetailsID = Convert.ToInt64(dr["BidOpeningDetailsID"].ToString()); //long BidOpeningID = Convert.ToInt64(dr["BidOpeningID"].ToString());
                long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); string BidderName = dr["BidderName"].ToString();
                int CurrencyID = Convert.ToInt32(dr["CurrencyID"].ToString()); string Currency = dr["Currency"].ToString();
                int BidSecurityCurrencyID = Convert.ToInt32(dr["BidSecurityCurrencyID"].ToString()); string BidSecurityCurrency = dr["BidSecurityCurrency"].ToString();
                double Price = Convert.ToDouble(dr["Price"].ToString()); bool BidSecurityReceived = Convert.ToBoolean(dr["BidSecurityReceived"].ToString());
                double BidSecurityAmount = Convert.ToDouble(dr["BidSecurityAmount"].ToString()); int NoOfCopies = Convert.ToInt32(dr["NoOfCopies"].ToString());
                string Remarks = dr["Remarks"].ToString(); string PowerOfAttorney = dr["PowerOfAttorney"].ToString();

                dtUpdate.Rows.Add(new object[] { BidOpeningDetailsID, BidderID, BidderName, CurrencyID, Currency, Price, BidSecurityReceived, BidSecurityCurrencyID, BidSecurityCurrency, BidSecurityAmount, NoOfCopies, Remarks, PowerOfAttorney });
            }
            Session["dtBidOpeningDetails"] = dtUpdate;
            DataGrid4.DataSource = datatable; btnPrintOpenedBids.Enabled = true;
            DataGrid4.DataBind(); DataGrid4.Visible = true; btnSubmitOpenedBids.Enabled = true;
            lblNoDetails.Visible = false;
        }
        else
        {
            DataGrid4.DataSource = null; DataGrid4.Visible = false; btnPrintOpenedBids.Enabled = false;
            lblNoDetails.Visible = true; btnSubmitOpenedBids.Enabled = false;
        }
        LoadCurrencies(); LoadBidders(txtReferenceNo.Text);
    }
    public bool EnableDetailsLink(object dataItem)
    {
        string BidOpeningID = DataBinder.Eval(dataItem, "BidOpeningID").ToString();
        string OpeningTypeString = DataBinder.Eval(dataItem, "OpeningType").ToString();
        string statuscheck = Session["currentstatus"].ToString().Trim();
        if ((BidOpeningID != "0") && (OpeningTypeString.Contains("Financial")))
            return true;
        else
            if (statuscheck.Equals("52") && (BidOpeningID != "0"))
                return true;
            else
                return false;
    }
    public bool Disable(object dataItem)
    {
       string OpeningTypeString = DataBinder.Eval(dataItem, "OpeningType").ToString();
       string statuscheck = Session["currentstatus"].ToString().Trim();
       if (OpeningTypeString.Contains("Financial"))
           return true;
       else
           if (statuscheck.Equals("52"))
               return true;
           else
            return false;
    }
    private void LoadBidOpening(string PRNumber)
    {
        CreateBidOpeningDataTable();
        datatable = Process.GetBidOpening(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long BidOpeningID = Convert.ToInt64(dr["BidOpeningID"].ToString()); string Location = dr["Location"].ToString();
                DateTime DateOfOpening = Convert.ToDateTime(dr["DateOfOpening"].ToString());
                int OpeningTypeID = Convert.ToInt32(dr["OpeningTypeID"].ToString());
                string OpeningType = dr["OpeningType"].ToString(); long WitnessedByPDU = Convert.ToInt64(dr["PDUMemberID"].ToString());
                string PDUMember = dr["PDUMember"].ToString(); long WitnessedByCC = Convert.ToInt64(dr["CCMemberID"].ToString());
                string CCMember = dr["CCMember"].ToString();

                dtUpdate = (DataTable)Session["dtBidOpening"];
                dtUpdate.Rows.Add(new object[] { BidOpeningID, Location, DateOfOpening, OpeningTypeID, OpeningType, WitnessedByPDU, PDUMember, WitnessedByCC, CCMember });
            }
            Session["dtBidOpening"] = dtUpdate;
            DataGrid2.DataSource = datatable;
            DataGrid2.DataBind(); btnSubmit.Enabled = true;
            DataGrid2.Visible = true; lblNoBids.Visible = false;
        }
        else
        {
            DataGrid2.DataSource = null; btnSubmit.Enabled = false;
            DataGrid2.Visible = false; lblNoBids.Visible = true;
        }
        lblAttachRefNo.Text = PRNumber;
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            ShowMessage(".");
            ShowMessage2(".");
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            LoadControls(PRNumber);       
            string Subject = e.Item.Cells[3].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            lblHeading.Text = Subject;
            lblProcMethod.Text = ProcMethodCode.ToString();
            lblRefNo.Text = PRNumber;

            string statusID = e.Item.Cells[9].Text;

            if (e.CommandName == "btnAddOpening")
            {
                cboPDUSign.SelectedValue = Session["UserID"].ToString();
                MultiView1.ActiveViewIndex = 2;
                MultiView2.ActiveViewIndex = 0;
                if (statusID.Equals("117"))
                {
                    cboBidOpeningType.SelectedValue = "2";
                    cboBidOpeningType.Enabled = false;

                }
                else {
                    cboBidOpeningType.SelectedValue = "0";
                    cboBidOpeningType.Enabled = true;
                }
                Session["currentstatus"] = statusID;
            }
            else if (e.CommandName == "btnAddBidOpeningDetails")
            {
                MultiView1.ActiveViewIndex = 2;
                MultiView2.ActiveViewIndex = 1;
            }
            else if (e.CommandName == "btnCloseOpening")
            {
              if (lblProcMethod.Text.Equals("1") || lblProcMethod.Text.Equals("11"))
                {

                    Process.LogandCommitBiddingDetails(PRNumber, 91, "Bid Opening Closed on " + DateTime.Now.ToString());
                
                }
                else
                {

                   DataTable dtSample                       =   Process.GetBidOpening(PRNumber);
                   string bidopeningtypeid = dtSample.Rows[0]["OpeningTypeID"].ToString();
                   if (dtSample.Rows.Count > 1) {

                       bidopeningtypeid = dtSample.Rows[1]["OpeningTypeID"].ToString();
                   }
                   
                   


                   string message = "";
                   if(bidopeningtypeid.Equals("4"))
                    {              
                       
                                     //Combined
                        message = "Combined Bid Opening";
                        Process.LogandCommitBiddingDetails(PRNumber, 112, "Combined Bid Opening Closed on " + DateTime.Now.ToString());
                    
                    }

                   else if(bidopeningtypeid.Equals("3"))

                    {            
                                   //Technical
                       message = "Technical Bid Opening";
                        Process.LogandCommitBiddingDetails(PRNumber, 113, "Technical Bid Opening Closed on " + DateTime.Now.ToString());
                    
                    }

                   else if(bidopeningtypeid.Equals("2"))

                    {              
                                   //Financial
                        message = "Financial Bid Opening ";
                        Process.LogandCommitBiddingDetails(PRNumber, 114, "Financial Bid Opening Closed on " + DateTime.Now.ToString());

                    }

                    //Process.LogandCommitBiddingDetails(PRNumber, 53, "Bid Opening Closed on " + DateTime.Now.ToString());
                }
                LoadItems();
                ShowMessage("Opening of Bids for Procurement " + PRNumber + " has been successfully closed");
                MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage("."); LoadItems();
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

        //doc.Load(rptName);
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
    protected void btnFiles_Click(object sender, EventArgs e)
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage2(".");
            if (String.IsNullOrEmpty(txtLocation.Text.Trim()))
                ShowMessage2("Please Enter The Location of Bid Opening");
            else if (String.IsNullOrEmpty(txtBidOpeningDate.Text.Trim()))
                ShowMessage2("Please Enter The Date of Bid Opening");
            else if (String.IsNullOrEmpty(txtBidOpeningTime.Text.Trim()))
                ShowMessage2("Please Enter The Time of Bid Opening");
            else if (cboBidOpeningType.SelectedValue == "0")
                ShowMessage2("Please Select The Bid Opening Type");
            else if (cboContractsCommitteeSign.SelectedValue == "0")
                ShowMessage2("Please Select The Contracts Committee Signatory");
            else if (cboPDUSign.SelectedValue == "0")
                ShowMessage2("Please Select The PDU Signatory");
            else
            {
                string RefNo = txtReferenceNo.Text.Trim(); string Location = txtLocation.Text.Trim();
                DateTime BidOpeningDate = Convert.ToDateTime(txtBidOpeningDate.Text.Trim());
                string[] BidOpeningTime = txtBidOpeningTime.Text.Trim().Split(':');
                int Hour = Convert.ToInt32(BidOpeningTime[0]); int Min = Convert.ToInt32(BidOpeningTime[1]);
                DateTime BidOpeningDateTime = new DateTime(BidOpeningDate.Year, BidOpeningDate.Month, BidOpeningDate.Day, Hour, Min, 0);
                int itemRow = 0;       
                int BidOpeningTypeID = Convert.ToInt32(cboBidOpeningType.SelectedValue); string BidOpeningType = cboBidOpeningType.SelectedItem.Text;
                long PDUMemberID = Convert.ToInt64(cboPDUSign.SelectedValue); string PDUMember = cboPDUSign.SelectedItem.Text;
                long CCMemberID = Convert.ToInt64(cboContractsCommitteeSign.SelectedValue); string CCMember = cboContractsCommitteeSign.SelectedItem.Text;
                long BidOpeningID = 0;
                dtUpdate = (DataTable)Session["dtBidOpening"];
                if (btnAdd.Text.Contains("Update"))
                {
                    BidOpeningID = Convert.ToInt64(lblOpenedBidID.Text.Trim());
                    itemRow = Convert.ToInt32(lblbidOpeningRow.Text.Trim());
                    if (BidOpeningID == 0)
                    {
                        dtUpdate.Rows.RemoveAt(itemRow);

                    }
                    else
                    {
                        int i = 0;

                        foreach (DataRow dr in dtUpdate.Rows)
                        {
                            if (Convert.ToInt64(dr["BidOpeningID"]) == BidOpeningID)
                            {
                                dtUpdate.Rows.RemoveAt(i);
                                break;
                            }
                            i++;
                        }
                    }
                }

                dtUpdate.Rows.Add(new object[] { BidOpeningID, Location, BidOpeningDateTime, BidOpeningTypeID, BidOpeningType, PDUMemberID, PDUMember, CCMemberID, CCMember });
                
                ClearBidOpeningControls();

                ShowMessage2("Bid Opening Has Been Successfully Added");

                Session["dtBidOpening"] = dtUpdate;
                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind(); DataGrid2.Visible = true;
                lblNoBids.Visible = false; btnSubmit.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            ShowMessage2(ex.Message);
        }
    }
    private void ClearBidOpeningControls()
    {
        txtBidOpeningDate.Text = ""; txtLocation.Text = ""; cboBidOpeningType.SelectedIndex = 0;
        cboPDUSign.SelectedIndex = 0; cboContractsCommitteeSign.SelectedIndex = 0; txtBidOpeningTime.Text = "";
        btnAdd.Text = "Add Opened Bid Details"; ShowMessage("."); ShowMessage2(".");
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
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string BidOpeningID = e.Item.Cells[0].Text;
        string Location = e.Item.Cells[1].Text; string BidOpeningDate = e.Item.Cells[2].Text; string BidOpeningTypeID = e.Item.Cells[3].Text;
        string PDUMemberID = e.Item.Cells[5].Text; string CCMemberID = e.Item.Cells[7].Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtBidOpening"];
        if (e.CommandName == "btnEdit")
        {
            lblbidOpeningRow.Text = ItemRowIndex.ToString().Trim();
            LoadBidOpeningControls(BidOpeningID, Location, BidOpeningDate, BidOpeningTypeID, PDUMemberID, CCMemberID);
            DataGrid2.DataSource = dtUpdate.DefaultView;
            DataGrid2.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (BidOpeningID == "0")
            {

                dtUpdate.Rows.RemoveAt(ItemRowIndex);
                Session["dtBidOpening"] = dtUpdate;
                DataGrid2.DataSource = dtUpdate;
                DataGrid2.DataBind(); DataGrid2.Visible = true;
                ShowMessage2("Bid Opening has been successfully removed ...");

            }
            else
            {
                if ((Session["currentstatus"].ToString().Trim().Equals("119")))
                {
          Process.LogandCommitBiddingDetails(txtReferenceNo.Text.ToString().Trim(), 117, " ");
                }
                long id = Convert.ToInt64(BidOpeningID);
                Process.FlagBidOpening(id, true);
                ShowMessage2("Bid Opening has been successfully removed ...");
                LoadControls(txtReferenceNo.Text.Trim());
            }
        }
        else if (e.CommandName == "btnAddOpeningDetails")
        {
            lblOpenedBidID.Text = BidOpeningID;
            long ID = Convert.ToInt64(lblOpenedBidID.Text);
            LoadBidOpeningDetails(ID);
            MultiView1.ActiveViewIndex = 2;
            MultiView2.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 0;
            if (Session["currentstatus"].ToString().Trim().Equals("117") || Session["currentstatus"].ToString().Trim().Equals("119"))
            {
                txtPowerOfAttorney.Enabled = false;
                chkBidSecurityReceived.Enabled = false;
                txtBidSecurityAmount.Enabled = false;
                cboBidCurrency.Enabled = false;

                txtPowerOfAttorney.Visible = false;
                chkBidSecurityReceived.Visible = false;
                txtBidSecurityAmount.Visible = false;
                cboBidCurrency.Visible = false; 
            }
        }
    }
    private void LoadBidOpeningControls(string BidOpeningID, string Location, string BidOpeningDate, string BidOpeningTypeID, string PDUMemberID, string CCMemberID)
    {
        txtBidOpeningDate.Text = BidOpeningDate; txtLocation.Text = Location; cboBidOpeningType.SelectedValue = BidOpeningTypeID;
        cboPDUSign.SelectedValue = PDUMemberID; cboContractsCommitteeSign.SelectedValue = CCMemberID; lblOpenedBidID.Text = BidOpeningID;
        btnAdd.Text = "Update Opened Bid Details";
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        //btnAddOpenedBid.Text = "Add Opened Bid";
        LoadItems();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void cboPDUSign_DataBound(object sender, EventArgs e)
    {
        cboPDUSign.Items.Insert(0, new ListItem(" -- Select PDU Signatory -- ", "0"));
    }
    protected void cboContractsCommitteeSign_DataBound(object sender, EventArgs e)
    {
        cboContractsCommitteeSign.Items.Insert(0, new ListItem(" -- Select Contracts Committee Signatory", "0"));
    }
    protected void cboBidder_DataBound(object sender, EventArgs e)
    {
        cboBidder.Items.Insert(0, new ListItem(" -- Select Bidder -- ", "0"));
    }
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtBidOpening"];
        ShowMessage2("."); ShowMessage(".");
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Bid Opening Details");
            ShowMessage2("Please Add Bid Opening Details");
        }
        else
        {
            Session["dtBidOpening"] = dtUpdate;
            DataTable dtBidOpening = (DataTable)Session["dtBidOpening"];
            string RefNo = txtReferenceNo.Text.Trim();
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());

            string Response = Process.SaveEditBidOpening(RefNo, dtBidOpening, CreatedBy);
            ShowMessage(Response); ShowMessage2(Response);
            LoadControls(RefNo);
        }
    }
    protected void cboBidOpeningType_DataBound(object sender, EventArgs e)
    {
        cboBidOpeningType.Items.Insert(0, new ListItem(" -- Select Bid Opening Type --", "0"));
    }
    protected void cboCurrency_DataBound(object sender, EventArgs e)
    {
        cboCurrency.Items.Insert(0, new ListItem(" -- Select Currency -- ", "0"));
    }
    protected void DataGrid3_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        lblOpenedBidID.Text = e.Item.Cells[0].Text;
        long BidOpeningID = Convert.ToInt64(lblOpenedBidID.Text);
        if (e.CommandName == "btnAddBidsOpened")
        {
            LoadBidOpeningDetails(BidOpeningID);
            MultiView1.ActiveViewIndex = 2;
            MultiView2.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 0;
        }
        else if (e.CommandName == "btnAddAttendence")
        {
            MultiView1.ActiveViewIndex = 2;
            MultiView2.ActiveViewIndex = 2;
            MultiView3.ActiveViewIndex = 1;
            LoadDocuments();
        }
    }
    protected void btnAddOpenedBid_Click(object sender, EventArgs e)
    {
        if (cboBidder.SelectedValue == "0")
            ShowMessage3("Please Select Bidder Whose Bid Has Been Opened");
        //else if (cboCurrency.SelectedValue == "0")
        //    ShowMessage3("Please Select Currency");
        //else if (txtPrice.Text.Trim() == "")
        //    ShowMessage3("Please Enter The Price");
        else if (txtNoOfCopies.Text.Trim() == "")
            ShowMessage3("Please Enter The Number of Copies");
        else if (chkBidSecurityReceived.Checked && txtBidSecurityAmount.Text.Trim() == "")
            ShowMessage3("Please Enter the Bid Security Amount");
        else
        {
            long BidOpeningDetailsID = 0;
           
            long BidderID = Convert.ToInt64(cboBidder.SelectedValue); string BidderName = cboBidder.SelectedItem.Text;
            int CurrencyID = Convert.ToInt32(cboCurrency.SelectedValue); string Currency = cboCurrency.SelectedItem.Text;
            string PowerOfAttorney = txtPowerOfAttorney.Text.ToString().Trim();
            string BidSecurityCurrency = cboBidCurrency.SelectedItem.Text;
            double Price = 0; bool BidSecurityReceived = Convert.ToBoolean(chkBidSecurityReceived.Checked);
            int BidSecurityCurrencyID = Convert.ToInt32(cboCurrency.SelectedValue);
            if (txtPrice.Text.Trim() != "")
                Price = Convert.ToDouble(txtPrice.Text.Trim());
            double BidSecurityAmount = 0;
            if (cboCurrency.SelectedValue == "0")
                Currency = "";
            if (cboBidCurrency.SelectedValue == "0")
                BidSecurityCurrency = "";
            if (txtBidSecurityAmount.Text.Trim() != "")
                BidSecurityAmount = Convert.ToDouble(txtBidSecurityAmount.Text.Trim()); 
            int NoOfCopies = Convert.ToInt32(txtNoOfCopies.Text.Trim());
            string Remarks = txtRemarks.Text.Trim();

            dtUpdate = (DataTable)Session["dtBidOpeningDetails"];
            if (btnAddOpenedBid.Text.Contains("Update"))
            {
                /*
                BidOpeningDetailsID = Convert.ToInt64(lblOpenedBidDetailsID.Text.Trim());
              
                int i = 0;
                foreach (DataRow dr in dtUpdate.Rows)
                {
                    if (Convert.ToInt64(dr["BidOpeningDetailsID"]) == BidOpeningDetailsID)
                    {
                        dtUpdate.Rows.RemoveAt(i);
                        break;
                    }
                    i++;
            }*/

            }
            dtUpdate.Rows.Add(new object[] { BidOpeningDetailsID, BidderID, BidderName, CurrencyID, Currency, Price, BidSecurityReceived, BidSecurityCurrencyID, BidSecurityCurrency, BidSecurityAmount, NoOfCopies, Remarks, PowerOfAttorney });

            ClearOpenedBidItemControls();
            Session["dtBidOpeningDetails"] = dtUpdate;
            DataGrid4.DataSource = dtUpdate.DefaultView;
            DataGrid4.DataBind(); DataGrid4.Visible = true;
            lblNoDetails.Visible = false; btnSubmitOpenedBids.Enabled = true;
        }
    }
    private void ClearOpenedBidItemControls()
    {
        cboBidder.SelectedValue = "0"; cboCurrency.SelectedValue = "0"; txtRemarks.Text = ""; txtPrice.Text = ""; txtPowerOfAttorney.Text = "";
        cboBidCurrency.SelectedValue = "0"; txtBidSecurityAmount.Text = ""; chkBidSecurityReceived.Checked = false; txtNoOfCopies.Text = "";
        btnAddOpenedBid.Text = "Add Opened Bid"; ShowMessage("."); ShowMessage3("."); ShowMessage2(".");
    }
    protected void DataGrid4_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string BidOpeningDetailsID = e.Item.Cells[0].Text; string BidderID = e.Item.Cells[1].Text;
        string CurrencyID = e.Item.Cells[3].Text; string Price = e.Item.Cells[5].Text; string BidSecurityCurrency = e.Item.Cells[7].Text;
        string BidSecurityReceived = e.Item.Cells[6].Text; string BidSecurityAmount = e.Item.Cells[9].Text;
        string NoOfCopies = e.Item.Cells[10].Text; string PowerOfAttorney = e.Item.Cells[11].Text; dtUpdate = (DataTable)Session["dtBidOpeningDetails"];
        int ItemRowIndex = e.Item.DataSetIndex; 
        ShowMessage("."); ShowMessage3(".");
        if (e.CommandName == "btnEdit")
        {
          //  if (BidOpeningDetailsID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);

            LoadBidOpeningDetailsControls(BidOpeningDetailsID, BidderID, CurrencyID, Price, BidSecurityReceived, BidSecurityCurrency, BidSecurityAmount, NoOfCopies, PowerOfAttorney);
            DataGrid4.DataSource = dtUpdate.DefaultView;
            DataGrid4.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (BidOpeningDetailsID == "0")
            {
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
                dtUpdate.AcceptChanges();
                DataGrid4.DataSource = dtUpdate;
                DataGrid4.DataBind();
            }
            else
            {
                long id = Convert.ToInt64(BidOpeningDetailsID);
                Process.FlagBidOpeningDetails(id, true);
                long BidOpeningID = Convert.ToInt64(lblOpenedBidID.Text.Trim());
                LoadBidOpeningDetails(BidOpeningID);
            }
            ShowMessage3("Bid Opening Details has been successfully removed ...");
            
        }
    }
    private void LoadBidOpeningDetailsControls(string BidOpeningDetailsID, string BidderID, string CurrencyID, string Price, string BidSecurityReceived, string BidSecurityCurrencyID, string BidSecurityAmount, string NoOfCopies, string PowerOfAttorney)
    {
        lblOpenedBidDetailsID.Text = BidOpeningDetailsID; cboBidCurrency.SelectedValue = BidSecurityCurrencyID;
        cboBidder.SelectedValue = BidderID; cboCurrency.SelectedValue = CurrencyID;
        txtPrice.Text = Price; chkBidSecurityReceived.Checked = Convert.ToBoolean(BidSecurityReceived);
        txtBidSecurityAmount.Text = BidSecurityAmount; txtNoOfCopies.Text = NoOfCopies; txtPowerOfAttorney.Text = PowerOfAttorney;
        btnAddOpenedBid.Text = "Update Opened Bid Details";
    }
    protected void btnSubmitOpenedBids_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtBidOpeningDetails"];
        ShowMessage3("."); ShowMessage(".");

        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Opened Bid Details");
            ShowMessage3("Please Add Opened Bid Details");
        }
        else
        {
            Session["dtBidOpeningDetails"] = dtUpdate;
            DataTable dtBidOpeningDetails = (DataTable)Session["dtBidOpeningDetails"];
            long BidOpeningDetailsID = 0; long BidOpeningID = Convert.ToInt64(lblOpenedBidID.Text.Trim());
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString()); int BidSecurityCurrencyID = 0;
            long BidderID = 0; int CurrencyID = 0; bool BidSecurityReceived; double BidSecurityAmount;
            int NoOfCopies; string Remarks; double Price; string PowerOfAttorney;
            
            foreach (DataRow dr in dtBidOpeningDetails.Rows)
            {
                BidOpeningDetailsID = Convert.ToInt64(dr["BidOpeningDetailsID"].ToString());
                BidderID = Convert.ToInt64(dr["BidderID"].ToString()); CurrencyID = Convert.ToInt32(dr["CurrencyID"].ToString());
                Price = Convert.ToDouble(dr["Price"].ToString()); BidSecurityCurrencyID = Convert.ToInt32(dr["BidSecurityCurrencyID"].ToString());
                BidSecurityReceived = Convert.ToBoolean(dr["BidSecurityReceived"].ToString());
                BidSecurityAmount = Convert.ToDouble(dr["BidSecurityAmount"].ToString());
                NoOfCopies = Convert.ToInt32(dr["NoOfCopies"].ToString()); Remarks = dr["Remarks"].ToString();
                PowerOfAttorney = dr["PowerOfAttorney"].ToString();

                Process.SaveEditBidOpeningDetails(BidOpeningDetailsID, BidOpeningID, BidderID, CurrencyID, Price, BidSecurityReceived, BidSecurityCurrencyID, BidSecurityAmount, NoOfCopies, Remarks, CreatedBy, PowerOfAttorney);
            }
            btnPrintOpenedBids.Enabled = true; 
            LoadBidOpeningDetails(BidOpeningID);
            ShowMessage("Bid Opening Details Have Been Successfully Added to Bid Opening");
            ShowMessage3("Bid Opening Details Have Been Successfully Added to Bid Opening");

            if (Session["currentstatus"].ToString().Equals("117"))
            {
                string refrnce = txtReferenceNo.Text.ToString();

                Process.LogandCommitBiddingDetails(refrnce, 119, "Financial Bids Opened and Ready For Ready For Closing");
                Session["currentstatus"] = "119";
                
            }
        }
    }
    protected void btnPrintOpenedBids_Click(object sender, EventArgs e)
    {
        try
        {
            ClearItemControls();
            if (DataGrid4.Items.Count == 0)
            {
                ShowMessage3("There is not data to print for the Record of Bid Opening ...");
            }
            else
            {

                string ReportName = "";
                if (txtProcType.Text.Trim().Equals("CONSULTATIONAL SERVICES"))
                {
                    if (Session["currentstatus"].ToString().Trim().Equals("119"))
                    {
                        ReportName = "form25";
                    }
                    else
                    {
                        ReportName = "form23";
                    }
                }
                else
                {

                    ReportName = "form12";
                }


                
                long BidOpeningID = Convert.ToInt64(lblOpenedBidID.Text);

                datatable = Process.GetReportForBidOpening(BidOpeningID);
                int rowcount = datatable.Rows.Count;

                if (rowcount != 0)
                {
                    loadreport(ReportName);

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, ReportName);
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
    protected void btnCancelOpenedBids_Click(object sender, EventArgs e)
    {
        ClearOpenedBidItemControls();
        MultiView1.ActiveViewIndex = 2;
        MultiView2.ActiveViewIndex = 0;
    }
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods --", "0"));
    }
    protected void btnCancelPart1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 2;
        MultiView2.ActiveViewIndex = 2;
        MultiView3.ActiveViewIndex = 1;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments(RefNo, 7);
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
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 7);
                LoadDocuments();
            }
        }
    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = Convert.ToInt32(GridAttachments.SelectedIndex);
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
    public bool IsFileRemoveable(int IsRemoveable)
    {
        if (IsRemoveable == 1)
            return true;
        else
            return false;
    }
    protected void btnAddAttachments_Click(object sender, EventArgs e)
    {
        lblAttachRefNo.Text = txtReferenceNo.Text;
        LoadDocuments();
        MultiView1.ActiveViewIndex = 4;
    }
    protected void btnAttReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        MultiView2.ActiveViewIndex = 0;
    }
    protected void cboBidCurrency_DataBound(object sender, EventArgs e)
    {
        cboBidCurrency.Items.Insert(0, new ListItem(" -- Select Currency -- ", "0"));
    }
    
}
