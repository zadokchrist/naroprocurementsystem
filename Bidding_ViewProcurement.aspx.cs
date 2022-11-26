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

public partial class Bidding_ViewProcurement : System.Web.UI.Page
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
                LoadAreas(); LoadProcMethod();
                if (Request.QueryString["transferid"] != null)
                {
                    txtPrNumber.Text = Session["PRNumber"].ToString();
                    cboProcMethod.SelectedIndex = cboProcMethod.Items.IndexOf(cboProcMethod.Items.FindByValue(Session["ProcMethod"].ToString()));
                    cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(Session["Area"].ToString()));
                    cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(Session["CostCenter"].ToString()));
                    LoadItems(); MultiView1.ActiveViewIndex = 2;
                    
                    LoadControls(Session["PRNumber"].ToString());
                    int ProcMethodCode = Convert.ToInt32(Session["ProcMethod"].ToString());
                    string Form = Process.GetForm(ProcMethodCode);
                    //lblHeading.Text = txtProcSubject.Text + " - [" + Form + "]";
                    lblProcMethod.Text = ProcMethodCode.ToString();
                    lblRefNo.Text = txtReferenceNo.Text;
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
        string ProcMethod = cboProcMethod.SelectedValue.ToString();

        string Status = cboStatus.SelectedValue.ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();

        datatable = Process.ViewProcurements(RecordID, PrNumber, Status, ProcMethod, AreaCode, CostCenterCode);
        
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
            string EmptyMessage = "No Procurement(s) Matching Search Criteria From Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
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
            ShowMessage(".");
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            string PD_Code = e.Item.Cells[3].Text;
            LoadControls(PRNumber);       
            string Subject = e.Item.Cells[4].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[6].Text);
            ProcMethodCode = ReturnProcMethod(ProcMethodCode);
            string Form = Process.GetForm(ProcMethodCode);
          //  lblHeading.Text = Subject + " - [" + Form + "]";
            lblProcMethod.Text = ProcMethodCode.ToString();
            lblRefNo.Text = PRNumber;
            if (e.CommandName == "btnViewStatus")
            {
                LoadLogs(PD_Code);
                lblPDCodeStatus.Text = PD_Code;
                MultiView1.ActiveViewIndex = 1;
            }
            else if (e.CommandName == "btnViewAttachments")
            {
                lblAttachRefNo.Text = txtReferenceNo.Text;
                lblHeaderMsg.Text = Subject;
                LoadDocuments();
            }
            else if (e.CommandName == "btnViewDetails")
            {
                MultiView1.ActiveViewIndex = 3;
               // MultiView2.ActiveViewIndex = 0;
            }
            else if (e.CommandName == "btnViewForms")
            {
                datatable = Process.GetAnsweredFormDetails(txtReferenceNo.Text.Trim());
                if (datatable.Rows.Count > 0)
                    LoadAnsweredFormGrid();
                MultiView1.ActiveViewIndex = 3;
                MultiView2.ActiveViewIndex = 1;
            }
            else if (e.CommandName == "btnViewOther")
            {
                datatable = Process.GetOtherPPForms(txtReferenceNo.Text);
                if (datatable.Rows.Count > 0)
                {
                    DataGrid3.DataSource = datatable;
                    DataGrid3.DataBind();
                }
                MultiView1.ActiveViewIndex = 3;
                MultiView2.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    public bool EnablePrintButton(object dataItem)
    {
        bool IsPrintEnabled = Convert.ToBoolean(DataBinder.Eval(dataItem, "IsEnabled").ToString());

        if (IsPrintEnabled)
            return true;
        else
            return false;
    }
    private void LoadLogs(string PD_Code)
    {
        datatable = ProcessReq.GetLogs(PD_Code);
        DataGrid2.DataSource = datatable;
        DataGrid2.DataBind();
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
        cboCostCenters.Items.Insert(0, new ListItem("-- All Cost Centers --", "0"));
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
        dgvQuestions.DataBind(); btnPrint.Enabled = true;
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
            lblSection.Text = Section; btnPrint.Enabled = false;
            LoadGrid(lblRefNo.Text.Trim(), lblProcMethod.Text.Trim(), Section);
        }
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
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
  
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem("-- All Proc. Methods --", "0"));
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
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
        MultiView1.ActiveViewIndex = 2;
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
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            PrintStatusReport();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void PrintStatusReport()
    {
        datatable = ProcessReq.GetReportLogs(lblPDCodeStatus.Text);

        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\PRStatus.rpt";
        //doc.Load(rptName);
        //doc.SetDataSource(datatable);
        //Hidetoolbar();
        //CrystalReportViewer1.ReportSource = doc; 

        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Procurement Status");
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        DataTable dtempty = new DataTable();
        dgvQuestions.DataSource = dtempty;
        dgvQuestions.DataBind();
        MultiView1.ActiveViewIndex = 3; MultiView1.ActiveViewIndex = 0;
    }
    protected void DataGrid3_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string ReferenceNo = e.Item.Cells[1].Text;
        string FormName = e.Item.Cells[3].Text;
        string ReportName = e.Item.Cells[4].Text;

        if (e.CommandName == "btnPrintForm")
        {
            PrintOtherPPForm(ReferenceNo, FormName, ReportName);
        }
    }
    private void PrintOtherPPForm(string ReferenceNo, string FormName, string ReportName)
    {
        if (FormName.Contains("BIDDERS"))
        {
            datatable = Process.GetReportForShortlistedBidders(ReferenceNo);
            PrintReport(FormName, ReportName, datatable);
        }
        else if (FormName.Contains("EVALUATION COMMITTEE")) 
        {
            datatable = Process.GetReportForECMembers(ReferenceNo);
            PrintReport(FormName, ReportName, datatable);
        }
        else if (FormName.Contains("SOLICITATION"))
        {
            datatable = Process.GetReportForSolicitationDocumentsIssue(ReferenceNo);
            PrintReport(FormName, ReportName, datatable);
        }
        else if (FormName.Contains("RECEIPT"))
        {
            datatable = Process.GetReportForBidReceipt(ReferenceNo);
            PrintReport(FormName, ReportName, datatable);
        }
        else if (FormName.Contains("PRE-BID MEETING"))
        {
            datatable = Process.GetPreBidMeetings(ReferenceNo);
            DataGrid4.DataSource = datatable; DataGrid4.DataBind();
            lblFormName.Text = FormName; lblReportName.Text = ReportName;
            MultiView1.ActiveViewIndex = 3; MultiView2.ActiveViewIndex = 2;
        }
        else if (FormName.Contains("BID OPENING"))
        {
            datatable = Process.GetBidOpening(ReferenceNo);
            DataGrid5.DataSource = datatable; DataGrid5.DataBind();
            lblFormName.Text = FormName; lblReportName.Text = ReportName; 
            MultiView1.ActiveViewIndex = 3; MultiView2.ActiveViewIndex = 3;
        }
        else if (FormName.Contains("BID ANALYSIS SHEET"))
        {
            datatable = Process.GetReportForMicroProcurementApproval(ReferenceNo);
            PrintReport(FormName, ReportName, datatable);
        }
    }
    private void PrintReport(string FormName, string ReportName, DataTable dtData)
    {
        try
        {
            int rowcount = dtData.Rows.Count;

            if (rowcount != 0)
            {
                loadreport(ReportName);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, FormName);
            }
            else
            {
                ShowMessage("No Data To Load " + FormName);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void DataGrid4_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        long PreBidMeetingID = Convert.ToInt64(e.Item.Cells[0].Text);
        if (e.CommandName == "btnPrintPreBidMeeting")
        {
            datatable = Process.GetReportForPreBidMeetingQuestions(PreBidMeetingID);
            PrintReport(lblFormName.Text, lblReportName.Text, datatable);
        }
    }
    protected void DataGrid5_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        long BidOpeningID = Convert.ToInt64(e.Item.Cells[0].Text);
        if (e.CommandName == "btnPrintBidOpening")
        {
            datatable = Process.GetReportForBidOpening(BidOpeningID);
            PrintReport(lblFormName.Text, lblReportName.Text, datatable);
        }
    }
}
