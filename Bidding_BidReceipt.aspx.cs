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

public partial class Bidding_BidReceipt : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataTable dtUpdate = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "45,73,59";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadPDUMembers(); LoadBidReceiptMethod();
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
    private void LoadBidReceiptMethod()
    {
        cboBidReceiptMethod.DataSource = Process.GetBidReceiptMethods();
        cboBidReceiptMethod.DataValueField = "BidReceiptMethodID";
        cboBidReceiptMethod.DataTextField = "BidReceiptMethod";
        cboBidReceiptMethod.DataBind();
    }
    private void LoadPDUMembers()
    {
        cboPDUSign.DataSource = ProcessReq.GetPDUMembers();
        cboPDUSign.DataValueField = "UserID";
        cboPDUSign.DataTextField = "Name";
        cboPDUSign.DataBind();
    }
    private void LoadCCMembers(Int64 CCID)
    {
        cboContractsCommitteeSign.DataSource = Process.GetCCMembersByCCID(CCID);
        cboContractsCommitteeSign.DataValueField = "UserID";
        cboContractsCommitteeSign.DataTextField = "CCMemberName";
        cboContractsCommitteeSign.DataBind();
    }
    public bool EnableCloseButton(object dataItem)
    {
        bool IsBidReceiptCloseEnabled = Convert.ToBoolean(DataBinder.Eval(dataItem, "IsBidReceiptCloseEnabled").ToString());

        if (IsBidReceiptCloseEnabled)
            return true;
        else
            return false;
    }
    private void LoadSolicitedBidders(string RefNo)
    {
        DataTable dt = new DataTable();
        dt = Process.GetSolicitedBiddersByReferenceNo(RefNo);
      
        cboBidder.DataSource = dt;
        cboBidder.DataValueField = "BidderID";
        cboBidder.DataTextField = "BidderName";
        cboBidder.DataBind();
    }
    private void CreateBidReceiptDetailsDataTable()
    {
        DataTable dtBidReceiptDetails = new DataTable("BidReceiptDetails");
        
        dtBidReceiptDetails.Columns.Add(new DataColumn("ID", typeof(long)));
        dtBidReceiptDetails.Columns.Add(new DataColumn("ReferenceNo", typeof(string)));
        dtBidReceiptDetails.Columns.Add(new DataColumn("BidderID", typeof(long)));
        dtBidReceiptDetails.Columns.Add(new DataColumn("BidderName", typeof(string)));
        dtBidReceiptDetails.Columns.Add(new DataColumn("BidReceiveDate", typeof(DateTime)));
        dtBidReceiptDetails.Columns.Add(new DataColumn("Comment", typeof(string)));
        dtBidReceiptDetails.Columns.Add(new DataColumn("NoOfEnvelopes", typeof(int)));

        dtBidReceiptDetails.Rows.Clear();

        Session["dtBidReceiptDetails"] = dtBidReceiptDetails;
        dtUpdate = dtBidReceiptDetails;
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

        datatable = Process.GetBidReceiptProcurements(RecordID, PrNumber, ProcMethod, ProcOfficer, Status, AreaCode, CostCenterCode);
        string methd = txtProcMethod.Text.ToString();
      
        if (methd.Contains("Request For Proposal"))
        {
      
            cboBidder.Visible = false; txtBidder.Visible = true;
        }
        else
        {
            cboBidder.Visible = true; txtBidder.Visible = false;
        }

        if (datatable.Rows.Count > 0)
        {
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind(); DataGrid1.Visible = true;
            lblEmpty.Text = ".";
        }
        else
        {
            DataGrid1.Visible = false;
            string EmptyMessage = "No Procurement(s) For Bid Receipt in the system From Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
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
            
            if (!txtProcMethod.Text.Contains("Micro"))
            {
                if ((datatable.Rows[0]["CCID"].ToString().Equals("")))
                {
                    
                }
                else {
                    Int64 CCID = Convert.ToInt64(datatable.Rows[0]["CCID"].ToString());
                    LoadCCMembers(CCID);
                }
            }
            if (txtProcMethod.Text.ToString().Trim().Contains("Request For Proposal"))
            {
                //LoadSolicitedBidders(txtReferenceNo.Text.Trim());
                //    openprocbidder = 1;
                cboBidder.Visible = false; txtBidder.Visible = true;
            }
            else
            {
               
           LoadSolicitedBidders(txtReferenceNo.Text.Trim());
                
                 cboBidder.Visible = true; txtBidder.Visible = false;

            }

            
        }
        LoadBidReceipt(PRNumber);
        LoadBidReceiptDetails(PRNumber);
    }
    private void LoadBidReceiptDetails(string PRNumber)
    {
        CreateBidReceiptDetailsDataTable();
        datatable = Process.GetBidReceiptDetails(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long ID = Convert.ToInt64(dr["ID"].ToString()); string ReferenceNo = dr["ReferenceNo"].ToString();
                long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); string BidderName = dr["BidderName"].ToString();
                DateTime BidReceiveDate = Convert.ToDateTime(dr["BidReceiveDate"].ToString());
                string Comment = dr["Comment"].ToString(); int NoOfEnvelopes = Convert.ToInt32(dr["NoOfEnvelopes"].ToString());

                dtUpdate.Rows.Add(new object[] { ID, ReferenceNo, BidderID, BidderName, BidReceiveDate, Comment, NoOfEnvelopes });
            }
            Session["dtBidReceiptDetails"] = dtUpdate;
            DataGrid2.DataSource = datatable; btnPrint.Enabled = true;
            DataGrid2.DataBind(); DataGrid2.Visible = true;
            lblNoRecords.Visible = false; btnSubmit.Enabled = true;
        }
        else
        {
            DataGrid2.Visible = false; btnPrint.Enabled = false;
            lblNoRecords.Visible = true;
        }
    }
    private void LoadBidReceipt(string PRNumber)
    {
        datatable = Process.GetBidReceipt(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            DateTime DeadlineDateTime = Convert.ToDateTime(datatable.Rows[0]["DeadlineForSubmission"].ToString());
            txtDeadline.Text = DeadlineDateTime.ToString("dd MMM yyyy");
            txtDeadlineTime.Text = DeadlineDateTime.Hour + ":" + DeadlineDateTime.Minute;
            lblReceiptID.Text = datatable.Rows[0]["BidReceiptID"].ToString(); txtLocationOfSubmission.Text = datatable.Rows[0]["LocationOfSubmission"].ToString();
            cboBidReceiptMethod.SelectedIndex = cboBidReceiptMethod.Items.IndexOf(cboBidReceiptMethod.Items.FindByValue(datatable.Rows[0]["BidReceiptMethodID"].ToString()));
            cboContractsCommitteeSign.SelectedIndex = cboContractsCommitteeSign.Items.IndexOf(cboContractsCommitteeSign.Items.FindByValue(datatable.Rows[0]["CCSignatory"].ToString()));
            cboPDUSign.SelectedIndex = cboPDUSign.Items.IndexOf(cboPDUSign.Items.FindByValue(datatable.Rows[0]["PDUSignatory"].ToString()));
        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        ShowMessage("."); ShowMessage2(".");
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            LoadControls(PRNumber);       
            string Subject = e.Item.Cells[3].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            lblHeading.Text = Subject;
            lblProcMethod.Text = ProcMethodCode.ToString();
            lblRefNo.Text = PRNumber;

            if (e.CommandName == "btnAddReceipt")
            {
                MultiView1.ActiveViewIndex = 2;
                //ClearMainItemControls();
                MultiView2.ActiveViewIndex = 0;
            }
            else if (e.CommandName == "btnCloseReceipt")
            {

                Process.LogandCommitBiddingDetails(PRNumber, 52, "Bid Receipt Closed on " + DateTime.Now.ToString()+ " And at Bid Opening");
                LoadItems();
                ShowMessage("Receipt of Bids for Procurement " + PRNumber + " has been successfully closed and Sent for Bid Opening");
                MultiView1.ActiveViewIndex = 0;
            }
            else if (e.CommandName == "btnNoBids")
            {

                Process.LogandCommitBiddingDetails(PRNumber, 120, "NO BIDS RECEIVED on " + DateTime.Now.ToString() + "forwareded to CC for cancellation" );
                LoadItems();
                ShowMessage("Procurement " + PRNumber + " has been successfully Sent to CC for Cancellation");
                MultiView1.ActiveViewIndex = 0;

            
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void ClearMainItemControls()
    {
        txtDeadline.Text = ""; txtLocationOfSubmission.Text = "";
        cboBidReceiptMethod.SelectedIndex = 0; cboPDUSign.SelectedIndex = 0; cboContractsCommitteeSign.SelectedIndex = 0;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            LoadItems(); MultiView1.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboCostCenter_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem(" -- All Cost Centers -- ", "0"));
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
            if (String.IsNullOrEmpty(txtBidReceiptDate.Text.Trim()))
                ShowMessage2("Please Enter The Bid Receipt Date and Time");
            else if (cboBidder.SelectedValue == "0")
                ShowMessage2("Please Select Bidder");
            else if (String.IsNullOrEmpty(txtComment.Text.Trim()))
                ShowMessage2("Please Enter Comment");
            else if (String.IsNullOrEmpty(txtNoOfEnvelopes.Text.Trim()))
                ShowMessage2("Please Enter The Number Of Envelopes");
            else
            {
                string RefNo = txtReferenceNo.Text.Trim();
               
                DateTime BidReceiptDate = Convert.ToDateTime(txtBidReceiptDate.Text.Trim());
                string[] BidReceiptTime = txtBidReceiptTime.Text.Trim().Split(':');
                int Hour = Convert.ToInt32(BidReceiptTime[0]); int Min = Convert.ToInt32(BidReceiptTime[1]);
                DateTime BidReceiptDateTime = new DateTime(BidReceiptDate.Year, BidReceiptDate.Month, BidReceiptDate.Day, Hour, Min, 0);
                string BidderName;
                if (cboBidder.Visible == false)
                    BidderName = txtBidder.Text.Trim();
                else
                    BidderName = cboBidder.SelectedItem.Text;

                long BidderID;

                if (txtProcMethod.Text.Contains("Request For Proposal"))
                {
                    datatable = Process.GetBidderByName(BidderName);
                    if (datatable.Rows.Count == 0)
                        throw new Exception("Please Enter Existing Bidder Name OR Select from drop down returned after typing more than two letters");
                    else
                        BidderID = Convert.ToInt64(datatable.Rows[0]["BidderID"].ToString());

                }
                else
                {
                    BidderID = Convert.ToInt64(cboBidder.SelectedValue);
                }

                string Comment = txtComment.Text.Trim(); string NoOfEnvelopes = txtNoOfEnvelopes.Text.Trim();
                long ID = 0;
                dtUpdate = (DataTable)Session["dtBidReceiptDetails"];
                if (btnAdd.Text.Contains("Update"))
                {

                    ID = Convert.ToInt64(lblID.Text.Trim());
                    int i = 0;
                    foreach (DataRow dr in dtUpdate.Rows)
                    {
                        if (Convert.ToInt64(dr["BidderID"]) == BidderID)
                        {
                            dtUpdate.Rows.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
               
                }
                dtUpdate.Rows.Add(new object[] { ID, RefNo, BidderID, BidderName, BidReceiptDateTime, Comment, NoOfEnvelopes });
                ClearItemControls();

                ShowMessage2("Bid Receipt Detail Has Been Successfully Added");

                Session["dtBidReceiptDetails"] = dtUpdate;
                DataGrid2.Visible = true; lblNoRecords.Visible = false;
                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind(); btnSubmit.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            ShowMessage2(ex.Message);
        }
    }
    private void ClearItemControls()
    {
        if (cboBidder.Visible == true)
            cboBidder.SelectedIndex = 0;
        else
            txtBidder.Text = "";

        txtNoOfEnvelopes.Text = "";
        txtBidReceiptDate.Text = ""; txtComment.Text = "";
        btnAdd.Text = "Add Bid Receipt Details";
    }
    private void ShowMessage2(string Message)
    {
        if (Message == ".")
            lblMsg.Text = ".";
        else
            lblMsg.Text = "MESSAGE: " + Message;
    } 
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    { 
        string ID = e.Item.Cells[0].Text; string BidderID = e.Item.Cells[1].Text; string BidReceiveDate = e.Item.Cells[3].Text;
        string NoOfEnvelopes = e.Item.Cells[4].Text; string Comment = e.Item.Cells[5].Text;
        string Bidder = e.Item.Cells[2].Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtBidReceiptDetails"];
        if (e.CommandName == "btnEdit")
        {
            //    if (ID == "0")
                 //   dtUpdate.Rows.RemoveAt(ItemRowIndex);
            
            LoadBidReceiptDetailsControls(ID, BidderID, BidReceiveDate, NoOfEnvelopes, Comment);
            DataGrid2.DataSource = dtUpdate.DefaultView;
            DataGrid2.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (ID == "0")
            {
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
                Session["dtBidReceiptDetails"] = dtUpdate;
                DataGrid2.DataSource = dtUpdate;
                DataGrid2.DataBind(); DataGrid2.Visible = true;
                ShowMessage2("Bid Receipt has been successfully removed ...");
            }
            else
            {
                long id = Convert.ToInt64(ID);
                Process.FlagBidReceiptDetail(id, true);
                ShowMessage2("Bid Receipt has been successfully removed ...");
                LoadControls(txtReferenceNo.Text.Trim());
            }
        }
    }
    private void LoadBidReceiptDetailsControls(string ID, string BidderID, string BidReceiptDateTime, string NoOfEnvelopes, string Comment)
    {
        lblID.Text = ID; cboBidder.SelectedValue = BidderID; txtBidReceiptDate.Text = BidReceiptDateTime;
        txtNoOfEnvelopes.Text = NoOfEnvelopes; txtComment.Text = Comment; btnAdd.Text = "Update Bid Receipt Details";
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        LoadItems();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            string ReportName = "";
            if (txtProcType.Text.Trim().Equals("CONSULTATIONAL SERVICES"))
            {
                ReportName = "form22";
            }
            else
            {

                ReportName = "form11";
            }
            string ReferenceNo = txtReferenceNo.Text.Trim();
            datatable = Process.GetReportForBidReceipt(ReferenceNo);
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
                ShowMessage("No Data To Load For Report ... ");
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboBidReceiptMethod_DataBound(object sender, EventArgs e)
    {
        cboBidReceiptMethod.Items.Insert(0, new ListItem(" -- Select Bid Receipt Method -- ", "0"));
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
        dtUpdate = (DataTable)Session["dtBidReceiptDetails"];
        ShowMessage2("."); ShowMessage(".");
        if (String.IsNullOrEmpty(txtDeadline.Text.Trim()))
            ShowMessage("Please Enter Deadline For Submission");
        else if (String.IsNullOrEmpty(txtDeadlineTime.Text.Trim()))
            ShowMessage("Please Enter Deadline Time For Submission");
        else if (String.IsNullOrEmpty(txtLocationOfSubmission.Text.Trim()))
            ShowMessage("Please Enter Location Of Submission");
        else if (cboBidReceiptMethod.SelectedValue == "0")
            ShowMessage("Please Select Bid Receipt Method");
        else if (cboContractsCommitteeSign.SelectedValue == "0" && !txtProcMethod.Text.Contains("Micro"))
            ShowMessage("Please Select Contacts Committee Signatory");
        else if (cboPDUSign.SelectedValue == "0")
            ShowMessage("Please Select PDU Signatory");
        else if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Bid Receipt Details");
            ShowMessage2("Please Add Bid Receipt Details");
        }
        else
        {
            Session["dtBidReceiptDetails"] = dtUpdate;
            DataTable dtBidReceiptDetails = (DataTable)Session["dtBidReceiptDetails"];
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());

            long ID = Convert.ToInt64(lblReceiptID.Text.Trim()); string RefNo = txtReferenceNo.Text.Trim();
            DateTime DeadlineDate = Convert.ToDateTime(txtDeadline.Text.Trim());
            string[] DeadlineTime =  txtDeadlineTime.Text.Trim().Split(':');
            int Hour = Convert.ToInt32(DeadlineTime[0]); int Min = Convert.ToInt32(DeadlineTime[1]);
            DateTime DeadlineDateTime = new DateTime(DeadlineDate.Year, DeadlineDate.Month, DeadlineDate.Day, Hour, Min, 0);
                
            string LocationOfSubmission = txtLocationOfSubmission.Text.Trim(); int BidReceiptMethod = Convert.ToInt32(cboBidReceiptMethod.SelectedValue);
            long CCMemberID = 0;
            if (!txtProcMethod.Text.Contains("Micro"))
                CCMemberID = Convert.ToInt64(cboContractsCommitteeSign.SelectedValue);
            long PDUMemberID = Convert.ToInt64(cboPDUSign.SelectedValue);

            Process.SaveEditBidReceipt(ID, RefNo, DeadlineDateTime, BidReceiptMethod, LocationOfSubmission, PDUMemberID, CCMemberID, DateTime.Now, CreatedBy);
            string Response = Process.SaveEditBidReceiptDetails(RefNo, dtBidReceiptDetails, CreatedBy);
            ShowMessage(Response); btnPrint.Enabled = true;
            LoadControls(RefNo);
        }
    }
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods -- ", "0"));
    }
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 4;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments(RefNo, 4);
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
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 4);
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
    protected void chkNoBids_CheckedChanged(Object sender, EventArgs args)
    {
        CheckBox linkedItem = sender as CheckBox;
        Boolean itemState = linkedItem.Checked;
       Object obj =  DataGrid1.SelectedItem;
    }
    
    
    
}
