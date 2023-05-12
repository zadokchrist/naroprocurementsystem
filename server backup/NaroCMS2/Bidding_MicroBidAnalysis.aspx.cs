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

public partial class Bidding_MicroBidAnalysis : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "91";
    DataTable dtUpdate = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); // LoadCostCenters();
                MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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
        ShowMessage(".");
        string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim(); string ProcOfficer = Session["UserID"].ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();

        Status = cbostatus.SelectedValue.ToString();
        if (Status.Equals("0"))
        {
            ShowMessage("Please Select a status");
        }
        else
        {
            datatable = Process.GetMicroProcurements(RecordID, PrNumber, ProcOfficer, Status, AreaCode, CostCenterCode);
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
                string EmptyMessage = "No Micro Procurement(s) Pending Bid Analysis Found in the System from Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
                lblEmpty.Text = EmptyMessage;
            }
        }
    }
    public bool EnableSubmitCheckBox(object dataItem)
    {
        bool IsSubmitEnabled = Convert.ToBoolean(DataBinder.Eval(dataItem, "IsSubmitEnabled").ToString());

        if (IsSubmitEnabled)
            return true;
        else
            return false;
    }
    public bool DisableLink(object dataItem)
    {
        if (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "1")
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
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            string Subject = e.Item.Cells[3].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            lblstatus.Text = e.Item.Cells[8].Text;
            LoadControls(PRNumber);

            if (e.CommandName == "btnAddBidAnalysis")
            {

                //LoadMicroProcurementItems(PRNumber);
                MultiView1.ActiveViewIndex = 1;
                lblAttachRefNo.Text = PRNumber;
                LoadDocuments();
                lblHeaderMsg.Text = Subject;
            }
            else if (e.CommandName == "btnPrintPDO2")
            {
                datatable = Process.GetReportForMicroProcurements(PRNumber);
                int rowcount = datatable.Rows.Count;
                string ReportName = "PD02";

                if (rowcount != 0)
                {
                    loadPD02();
                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Form PD 02");
                }
                else
                {
                    ShowMessage("No PD02 Data To Load For Micro Procurement " + PRNumber);
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }


    public bool DisableViewComment(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "95") ||
            (DataBinder.Eval(dataItem, "StatusID").ToString() == "99"))

            return true;
        else
            return false;
    }
    public string ViewComment(object dataItem)
    {

        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "95") ||
            (DataBinder.Eval(dataItem, "StatusID").ToString() == "99") )

            return DataBinder.Eval(dataItem, "Remark").ToString();
        else
            return "";
    }
    public bool Disable(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "99"))

            return false;
        else
            return true;
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

            LoadBidders(PRNumber); LoadCurrencies();
        }
    }
    private void LoadCurrencies()
    {
        cboCurrency.DataSource = Process.GetCurrencies();
        cboCurrency.DataValueField = "CurrencyID";
        cboCurrency.DataTextField = "Currency";
        cboCurrency.DataBind();
    }
    private void LoadBidders(string ReferenceNo)
    {
        cboBidder.DataSource = Process.GetBiddersForBidOpeningByReferenceNo(ReferenceNo);
        cboBidder.DataValueField = "BidderID";
        cboBidder.DataTextField = "BidderName";
        cboBidder.DataBind();
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
        ////doc.SetDataSource(datatable);
        //doc.SetDatabaseLogon("sa", "Terrible");
        //doc.SetParameterValue("ReferenceNo", txtReferenceNo.Text);

        //Hidetoolbar();
        //CrystalReportViewer1.ReportSource = doc;
    }
    public void loadPD02()
    {
        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\Bidding\\PD02.rpt";

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
    public bool IsFileRemoveable(int IsRemoveable)
    {
        if (IsRemoveable == 1)
            return true;
        else
            return false;
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
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 1;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments(RefNo, 8);
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
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 8);
                LoadDocuments();
            }
        }
    }
    protected void GridAttachments_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Remove")
            {
                //int intIndex = Convert.ToInt32();
                string FileCode = Convert.ToString(e.CommandArgument); //Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                //ConfirmRemoveDocument(FileCode);
                Process.RemoveDocument(FileCode);
                LoadDocuments();
                ShowMessage("File Has Been Successfully Removed...");
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
    protected void GridAttachments_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnSubmitToHOS_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            datatable = Process.GetBiddingDocuments(lblAttachRefNo.Text, 2);
            if (datatable.Rows.Count > 0)
            {
                long HOD = 0; string Comment; double BidAmount;
                if (txtHOS.Text.Trim() == "")
                    ShowMessage("Please Enter Head of DEPARTMENT");
                else if (cboBidder.SelectedValue == "0")
                    ShowMessage("Please Select The Recommended Bidder");
                else if (cboCurrency.SelectedValue == "0")
                    ShowMessage("Please Select Currency");
                else if (txtAmount.Text.Trim() == "")
                    ShowMessage("Please Enter Final Amount");
                else if (txtComment.Text.Trim() == "")
                    ShowMessage("Please Enter Comment");
                else
                {
                    datatable = Process.GetUserByName(txtHOS.Text.Trim());
                    if (datatable.Rows.Count == 0)
                        throw new Exception("Please Enter Existing User OR Select from drop down returned after typing more than two letters");
                    else
                        HOD = Convert.ToInt64(datatable.Rows[0]["UserID"].ToString());
                    int CurrencyID = Convert.ToInt32(cboCurrency.SelectedValue);
                    long BidderID = Convert.ToInt64(cboBidder.SelectedValue);
                    BidAmount = Convert.ToDouble(txtAmount.Text.Trim().Replace(",", ""));
                    long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());
                    Comment = txtComment.Text.Trim(); BidAmount = Convert.ToDouble(txtAmount.Text.Trim());

                  Process.SubmitMicroProcurement(txtReferenceNo.Text, BidderID, CurrencyID, BidAmount, HOD, Comment, CreatedBy);
                  Process.LogandCommitBiddingDetails(txtReferenceNo.Text, 94, Comment);

                   
                    LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    ShowMessage("Procurement " + txtReferenceNo.Text + " Has Been Successfully Submitted to " + txtHOS.Text.Trim());
                }
            }
            else
                ShowMessage("Please Upload Bid Analysis Sheet Before Submitting Micro Procurement");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void cboBidder_DataBound(object sender, EventArgs e)
    {
        cboBidder.Items.Insert(0, new ListItem(" -- Select Bidder -- ", "0"));
    }
    protected void cboCurrency_DataBound(object sender, EventArgs e)
    {
        cboCurrency.Items.Insert(0, new ListItem(" -- Select Currency -- ", "0"));
    }
}
