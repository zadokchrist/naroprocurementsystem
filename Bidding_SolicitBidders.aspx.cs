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
public partial class Bidding_SolicitBidders : System.Web.UI.Page
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
   
   
    bool saved2 = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadProcMethod();
                MultiView1.ActiveViewIndex = 0;
                txtOfficer.Text = Session["FullName"].ToString();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void CreateSolDocDetailsDataTable()
    {
        DataTable dtSolDocDetails = new DataTable("SolDocDetails");

        dtSolDocDetails.Columns.Add(new DataColumn("ID", typeof(long)));
        dtSolDocDetails.Columns.Add(new DataColumn("ReferenceNo", typeof(string)));
        dtSolDocDetails.Columns.Add(new DataColumn("RequestReceivedDate", typeof(DateTime)));
        dtSolDocDetails.Columns.Add(new DataColumn("IsFeePayable", typeof(bool)));
        dtSolDocDetails.Columns.Add(new DataColumn("FeePaidDate", typeof(DateTime)));
        dtSolDocDetails.Columns.Add(new DataColumn("DocumentsIssuedDate", typeof(DateTime)));
        dtSolDocDetails.Columns.Add(new DataColumn("BidderID", typeof(long)));
        dtSolDocDetails.Columns.Add(new DataColumn("BidderName", typeof(string)));
        dtSolDocDetails.Columns.Add(new DataColumn("IssuingOfficer", typeof(long)));
        dtSolDocDetails.Columns.Add(new DataColumn("IssuingOfficerName", typeof(string)));
        dtSolDocDetails.Rows.Clear();

        Session["dtSolDocDetails"] = dtSolDocDetails;
        dtUpdate = dtSolDocDetails;
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
    private void LoadProcMethod()
    {
        datatable = ProcessPlan.GetProcurementMethods();
        cboProcMethod.DataSource = datatable;
        cboProcMethod.DataValueField = "MethodCode";
        cboProcMethod.DataTextField = "Method";
        cboProcMethod.DataBind();
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

        datatable = Process.GetBidSolicitationProcurements(RecordID, PrNumber, ProcMethod, ProcOfficer, Status, AreaCode, CostCenterCode);

        //datatable = Process.GetProcurementsForSolicitation(RecordID, PrNumber, ProcMethod, ProcOfficer, Status, AreaCode, CostCenterCode);
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind(); DataGrid1.Visible = true;
            lblEmpty.Text = ".";
        }
        else
        {
            DataGrid1.Visible = false;
            string EmptyMessage = "No Procurement(s) Ready For Issue of Solicitation Documents in the system From Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
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
        string methd = txtProcMethod.Text.ToString();
        int openprocbidder = 0;
        if (methd.Contains("Open "))
        {
            openprocbidder = 1;
            cboBidder.Visible = false; txtBidder.Visible = true;
        }
        else
        {
            cboBidder.Visible = true; txtBidder.Visible = false;
        }
            datatable = Process.GetBiddersForBidSolicitByReferenceNo(PRNumber);
            cboBidder.DataSource = datatable; cboBidder.DataValueField = "BidderID";
            cboBidder.DataTextField = "BidderName"; cboBidder.DataBind();
      
        LoadSolicitationDocuments(PRNumber);
        LoadSolDocDetails(PRNumber);
    }
    private void LoadSolDocDetails(string PRNumber)
    {
        CreateSolDocDetailsDataTable();
        datatable = Process.GetSoliticationDocumentDetails(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                string ReferenceNo = dr["ReferenceNo"].ToString();
                long ID = Convert.ToInt64(dr["ID"].ToString()); DateTime RequestReceivedDate = Convert.ToDateTime(dr["RequestReceivedDate"].ToString());
                bool IsFeePayable = Convert.ToBoolean(dr["IsFeePayable"].ToString());
                DateTime FeePaidDate = Convert.ToDateTime(dr["FeePaidDate"].ToString()); DateTime DocumentsIssuedDate = Convert.ToDateTime(dr["DocumentsIssuedDate"].ToString());
                long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); string BidderName = dr["BidderName"].ToString();
                long IssuingOfficer = Convert.ToInt64(dr["IssuingOfficer"].ToString()); string IssuingOfficerName = dr["IssuingOfficerName"].ToString();

                dtUpdate.Rows.Add(new object[] { ID, ReferenceNo, RequestReceivedDate, IsFeePayable, FeePaidDate, DocumentsIssuedDate, BidderID, BidderName, IssuingOfficer, IssuingOfficerName });
            }
            Session["dtSolDocDetails"] = dtUpdate;
            DataGrid2.DataSource = datatable;
            DataGrid2.DataBind(); DataGrid2.Visible = true;
            lblNoRecords.Visible = false; btnPrint.Enabled = true;
        }
        else
        {
            DataGrid2.DataSource = null; DataGrid2.Visible = false;
            lblNoRecords.Visible = true; btnPrint.Enabled = false;
        }
    }
    private void LoadSolicitationDocuments(string PRNumber)
    {
        datatable = Process.GetSoliticationDocuments(PRNumber);
        ClearSolicitationDocControls();
        if (datatable.Rows.Count > 0)
        {
            lblDocID.Text = datatable.Rows[0]["ID"].ToString();
            txtDateNoticePublished.Text = datatable.Rows[0]["DateNoticePublished"].ToString();
            txtDateDocumentAvailable.Text = datatable.Rows[0]["DateDocumentAvailable"].ToString();
            txtAddendumNumber.Text = datatable.Rows[0]["AddendumNumber"].ToString();
            chkIsFeePayable.Checked = Convert.ToBoolean(datatable.Rows[0]["IsFeePayable"].ToString());
            txtCostOfDocuments.Text = Convert.ToDouble(datatable.Rows[0]["CostOfDocument"]).ToString("#,##0");
            if (chkIsFeePayable.Checked == false)
            {
                lblCostOfDoc.Visible = false; txtCostOfDocuments.Visible = false;
                lblFeePaidDate.Visible = false; txtFeePaidDate.Visible = false;
            }
        }
    }

    private void ClearSolicitationDocControls()
    {
        lblDocID.Text = "0"; txtDateNoticePublished.Text = ""; txtDateDocumentAvailable.Text = "";
        txtAddendumNumber.Text = ""; txtCostOfDocuments.Text = "";
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
            Session["prebidmeeting"] = e.Item.Cells[8].Text;
            
            lblProcMethod.Text = ProcMethodCode.ToString();
            lblRefNo.Text = PRNumber;

            if (e.CommandName == "btnAddIssue")
            {
                Label1.Text = ".";
                btnSubmit.Text = "save";
                MultiView1.ActiveViewIndex = 2;
                MultiView2.ActiveViewIndex = 0;

                if (ProcMethodCode == 11 || ProcMethodCode == 12 || ProcMethodCode == 2)
                {
                    chkIsFeePayable.Checked = false;
                    lblCostOfDoc.Visible = false; txtCostOfDocuments.Visible = false;
                    lblFeePaidDate.Visible = false; txtFeePaidDate.Visible = false;
                }
                else
                {
                    chkIsFeePayable.Checked = true;
                    lblFeePaidDate.Visible = true; txtFeePaidDate.Visible = true;
                    lblCostOfDoc.Visible = true; txtCostOfDocuments.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ShowMessage("."); ShowMessage2("."); Label1.Text = "";
        try
        {
            LoadItems();
            Session["saved"] = false;
            Session["saved2"] = false;
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
    //{
    //    if (doc != null)
    //    {
    //        doc.Close();
    //        doc.Dispose();
    //        GC.Collect();
    //    }
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
            if (String.IsNullOrEmpty(txtRequestReceivedDate.Text.Trim()))
                ShowMessage2("Please Enter The Request Received Date");
            else if (String.IsNullOrEmpty(txtOfficer.Text.Trim()))
                ShowMessage2("Please Select From the List of Officers After Typing One or More Letters");
            else if (String.IsNullOrEmpty(txtDocsIssuedDate.Text.Trim()))
                ShowMessage2("Please Select Document Issued Date");
            else if (chkIsFeePayable.Checked == true && String.IsNullOrEmpty(txtFeePaidDate.Text.Trim()))
                ShowMessage2("Please Enter Fee Paid Date");
            else
            {
                DateTime RequestReceivedDate = Convert.ToDateTime(txtRequestReceivedDate.Text.Trim());
                string Bidder;
                if (cboBidder.Visible == false)
                    Bidder = txtBidder.Text.Trim();
                else
                    Bidder = cboBidder.SelectedItem.Text;
                string IssuingOfficer = txtOfficer.Text.Trim();
                DateTime DocsIssuedDate = Convert.ToDateTime(txtDocsIssuedDate.Text.Trim());
                bool IsFeePayable = chkIsFeePayable.Checked;
                DateTime FeePaidDate = bll.ReturnDate("",1);
                if (IsFeePayable)
                    FeePaidDate = Convert.ToDateTime(txtFeePaidDate.Text.Trim());
                string RefNo = txtReferenceNo.Text.Trim();
                long Officer = 0; long BidderID = 0;

                Officer = Convert.ToInt64(Session["UserID"].ToString());

    
                    datatable = Process.GetBidderByName(Bidder);
                    if (datatable.Rows.Count == 0)
                        throw new Exception("Please Enter Existing Bidder Name OR Select from drop down returned after typing more than two letters");
                    else
                        BidderID = Convert.ToInt64(datatable.Rows[0]["BidderID"].ToString());
                
                long ID = 0;

                dtUpdate = (DataTable)Session["dtSolDocDetails"];
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
                dtUpdate.Rows.Add(new object[] { ID, RefNo, RequestReceivedDate, IsFeePayable, FeePaidDate, DocsIssuedDate, BidderID, Bidder, Officer, IssuingOfficer });
                ClearItemControls();

                ShowMessage2("Solicitation Document Details Has Been Successfully Added");

                Session["dtSolDocDetails"] = dtUpdate;
                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind(); DataGrid2.Visible = true;
                lblNoRecords.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ShowMessage2(ex.Message);
        }
    }
    private void ClearItemControls()
    {
        txtFeePaidDate.Text = ""; txtRequestReceivedDate.Text = ""; txtBidder.Text = "";
        cboBidder.SelectedIndex = cboBidder.Items.IndexOf(cboBidder.Items.FindByValue("0"));
        txtOfficer.Text = Session["FullName"].ToString(); txtDocsIssuedDate.Text = "";
        if (txtProcMethod.Text.Contains("Request For"))
            chkIsFeePayable.Checked = false;
        else
            chkIsFeePayable.Checked = true;
        btnAdd.Text = "Add Doc Issue";
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
        string ID = e.Item.Cells[0].Text; string Bidder = e.Item.Cells[1].Text; string RequestReceivedDate = e.Item.Cells[2].Text;
        string FeePaidDate = e.Item.Cells[3].Text; string DocsIssuedDate = e.Item.Cells[4].Text; string Officer = e.Item.Cells[5].Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtSolDocDetails"];
        ShowMessage("."); ShowMessage2(".");
        if (e.CommandName == "btnEdit")
        {
         
           // if (ID == "0")
               // dtUpdate.Rows.RemoveAt(ItemRowIndex);
            
            LoadSolDocDetailsControls(ID, Bidder, RequestReceivedDate, FeePaidDate, DocsIssuedDate, Officer);
            DataGrid2.DataSource = dtUpdate.DefaultView;
            DataGrid2.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (ID == "0")
            {
                    dtUpdate.Rows.RemoveAt(ItemRowIndex);
                    Session["dtSolDocDetails"] = dtUpdate;
                    DataGrid2.DataSource = dtUpdate;
                    DataGrid2.DataBind(); DataGrid2.Visible = true;
                    LoadSolicitationDocuments(txtReferenceNo.Text.ToString().Trim());
                
            }
            else
            {
                long SolDocID = Convert.ToInt64(ID);
                Process.FlagSolicitationDocumentDetail(SolDocID, true);
                LoadControls(txtReferenceNo.Text);
            }
            ShowMessage2("Solicitation Document Detail Has Been Successfully Removed ...");
            
        }
    }
    private void LoadSolDocDetailsControls(string ID, string Bidder, string RequestReceivedDate, string FeePaidDate, string DocumentsIssuedDate, string IssuingOfficer)
    {
        lblID.Text = ID; txtRequestReceivedDate.Text = RequestReceivedDate; txtFeePaidDate.Text = FeePaidDate;
        if (txtBidder.Visible == true)
            txtBidder.Text = Bidder;
        else if (cboBidder.Visible == true)
            cboBidder.SelectedIndex = cboBidder.Items.IndexOf(cboBidder.Items.FindByText(Bidder));
        txtDocsIssuedDate.Text = DocumentsIssuedDate; txtOfficer.Text = IssuingOfficer; btnAdd.Text = "Update Doc Issue";
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtSolDocDetails"];
        ShowMessage2("."); ShowMessage(".");
        if (String.IsNullOrEmpty(txtDateNoticePublished.Text.Trim()))
            ShowMessage("Please Enter The Date Notice Published");
        else if (String.IsNullOrEmpty(txtDateDocumentAvailable.Text.Trim()))
            ShowMessage("Please Enter The Data Documents Available");
        else if (chkIsFeePayable.Checked == true && String.IsNullOrEmpty(txtCostOfDocuments.Text.Trim()))
            ShowMessage("Please Enter The Cost of Documents");
        else if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Solicitation Documents Details");
            ShowMessage2("Please Add Solicitation Documents Details");
        }
        else
        {
            Session["dtSolDocDetails"] = dtUpdate;
            DataTable dtSolDocDetails = (DataTable)Session["dtSolDocDetails"];
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());

            long ID = Convert.ToInt64(lblDocID.Text.Trim()); string RefNo = txtReferenceNo.Text.Trim();
            DateTime DateNoticePublished = Convert.ToDateTime(txtDateNoticePublished.Text.Trim());
            DateTime DateDocumentAvailable = Convert.ToDateTime(txtDateDocumentAvailable.Text.Trim());
            string AddendumNumber = txtAddendumNumber.Text.Trim(); bool IsFeePayable = chkIsFeePayable.Checked;
            double CostOfDocument = 0;
            if (txtCostOfDocuments.Text.Trim() != "")
                CostOfDocument = Convert.ToDouble(txtCostOfDocuments.Text.Trim().Replace(",","")); 
            Process.SaveEditSolicitationDocuments(ID, RefNo, DateNoticePublished, DateDocumentAvailable, AddendumNumber, IsFeePayable, CostOfDocument, CreatedBy, CreatedBy);
            string Response = Process.SaveEditSolicitationDocumentsDetails(RefNo, dtSolDocDetails, CreatedBy);
            ShowMessage(Response); btnPrint.Enabled = true;
            if ((bool)Session["saved"] == true)
            {
                Session["saved2"] = true;
            }
            else
            {

                Session["saved"] = true;
            }
            LoadControls(RefNo);
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            string ReferenceNo = txtReferenceNo.Text.Trim();
            datatable = Process.GetReportForSolicitationDocumentsIssue(ReferenceNo);
            int rowcount = datatable.Rows.Count;
            string proctype = txtProcType.Text.Trim();
            if (rowcount != 0)
            {
                string ReportName =" ";
             /*   // PP Form 30(Fee Payable) or 31 (No Fee Payable)
                string ReportName = "SolicitationDocsIssue31";
                // If No Fee Payable then Report Name = SolicitationDocsIssue31
                bool FeePayable = Convert.ToBoolean(datatable.Rows[0]["IsFeePayable"].ToString());
                if (FeePayable)
                    ReportName = "SolicitationDocsIssue30";
                */
                if(proctype.Equals("CONSULTATIONAL SERVICES")){
                
                    ReportName = "form20";

                }else{
                
                    ReportName = "form8";
                }
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
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods --", "0"));
    }
    protected void cboBidder_DataBound(object sender, EventArgs e)
    {
        cboBidder.Items.Insert(0, new ListItem(" -- Select Bidder -- ", "0"));
    }
    protected void chkIsFeePayable_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsFeePayable.Checked)
        {
            lblCostOfDoc.Visible = true; txtCostOfDocuments.Visible = true;
            lblFeePaidDate.Visible = true; txtFeePaidDate.Visible = true;
        }
        else
        {
            lblCostOfDoc.Visible = false; txtCostOfDocuments.Visible = false;
            lblFeePaidDate.Visible = false; txtFeePaidDate.Visible = false;
        }
    }

    protected void btnfinalSubmit_Click(object sender, EventArgs e)
    {
        
        String prebidmeeting = Session["prebidmeeting"].ToString();
        string pr = txtReferenceNo.Text.ToString();
        if ((bool)Session["saved"] == true)
        {
            if((bool)Session["saved2"]==false){
                
              ShowMessage("Please confirm save before you can submit");
                btnSubmit.Text = "confirm save";
              //  btnfinalSubmit.Text = "click me again";
         }
        else{

            if (prebidmeeting.Equals("0"))
            {

                Process.LogandCommitBiddingDetails(pr, 76, "Procurement now at Bid Receipt");
                Label1.Text = "Procurement Succesfully now at Bid Receipt";
            }

            else if (prebidmeeting.Equals("1"))
            {
                Process.LogandCommitBiddingDetails(pr, 77, "Procurement now at PreBid Meeting");
                Label1.Text = "Procurement Succesfully now at PreBid Meeting";
            }
            MultiView1.ActiveViewIndex = 0;
            LoadItems();
            Session["saved2"] = false;
            Session["saved"] = false;
           
       }
        }
        else {
            ShowMessage("Please save before you can submit!");
        }
    }
}
