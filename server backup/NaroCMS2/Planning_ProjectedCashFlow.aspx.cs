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

public partial class Planning_ExpectedExpenditure : System.Web.UI.Page
{
    DataLogin dac = new DataLogin();
    DataTable dataTable = new DataTable();
    ProcessPlanning Process = new ProcessPlanning();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadFinancialYears();
                LoadAreas();LoadCostCenters();
                ToggleControls();
                ShowMessage(".");
            }
            else
                LoadReport();
        }
        catch (Exception xe)
        {
            ShowMessage(xe.Message);
        }
    }

    private void ToggleControls()
    {
        Label1.Text = "DETAILED CONSOLIDATED PLAN FOR THE FINANCIAL YEAR: " + Session["PFinancialYear"].ToString();
        string Access = Session["AccessLevelID"].ToString();
        if (Access == "5" || Access == "6")
        {
            cboAreas.Enabled = false;
            cboCostCenters.Enabled = false;
            string Area = Session["AreaCode"].ToString();
            string Center = Session["CostCenterID"].ToString();
            cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(Area));
            cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(Center));
        }
        else
        {
            cboAreas.Enabled = true;
            cboCostCenters.Enabled = true;
        }
    }
    private void Page_Unload(object sender, EventArgs e)
    {
        GC.Collect();
    }
    private void LoadAreas()
    {
        dataTable = dac.GetAreas();
        cboAreas.DataSource = dataTable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();
    }
    private void LoadCostCenters()
    {
        int AreaID = Convert.ToInt32(cboAreas.SelectedValue.ToString());
        dataTable = dac.GetCostCenters(AreaID);
        cboCostCenters.DataSource = dataTable;
        cboCostCenters.DataValueField = "CostCenterID";
        cboCostCenters.DataTextField = "CostCenterName";
        cboCostCenters.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            LoadReport();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadReportToDownload()
    {
        string FinancialYearCode = cboFinancialYear.SelectedValue.ToString();
        string AreaCode = cboAreas.SelectedValue.ToString();
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        bool ByQuarter = chkQuarter.Checked;

        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        Label1.Text = "DETAILED CONSOLIDATED PLAN FOR THE FINANCIAL YEAR: " + Session["PFinancialYear"].ToString();

        if (ByQuarter)
        {
            Label1.Text += " BY QUARTER";
            dataTable = Process.GetPlannedCashFlowByQuarter(FinancialYearCode, AreaCode, CostCenter);
            Reports reports = new Reports();
            Byte[] pdfreport = reports.GenerateAllTransactionsPdfReport(dataTable, Label1.Text, "", "", "", "");
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=DETAILEDCONSOLIDATEDPLANFORTHEFINANCIALYEAR.pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(pdfreport);
            Response.End();
            Response.Close();
        }
        else
        {
            dataTable = Process.GetPlannedCashFlow(FinancialYearCode, AreaCode, CostCenter);
            Reports reports = new Reports();
            Byte[] pdfreport = reports.GenerateAllTransactionsPdfReport(dataTable, Label1.Text, "", "", "", "");
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=DETAILEDCONSOLIDATEDPLANFORTHEFINANCIALYEAR.pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(pdfreport);
            Response.End();
            Response.Close();
        }

        if (dataTable.Rows.Count > 0)
        {
            Hidetoolbar();
        }
        else
        {
            ShowMessage("No Record(s) found");
        }
    }
    private void LoadReport()
    {
        string FinancialYearCode = cboFinancialYear.SelectedValue.ToString();
        string AreaCode = cboAreas.SelectedValue.ToString();
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        bool ByQuarter = chkQuarter.Checked;

        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        Label1.Text = "DETAILED CONSOLIDATED PLAN FOR THE FINANCIAL YEAR: " + Session["PFinancialYear"].ToString();

        if (ByQuarter)
        {
            Label1.Text += " BY QUARTER";
            dataTable = Process.GetPlannedCashFlowByQuarter(FinancialYearCode, AreaCode, CostCenter);
            ProjectedCashFlow.DataSource = dataTable;
            ProjectedCashFlow.DataBind();
        }
        else
        {
            dataTable = Process.GetPlannedCashFlow(FinancialYearCode, AreaCode, CostCenter);
            ProjectedCashFlow.DataSource = dataTable;
            ProjectedCashFlow.DataBind();
        }

        if (dataTable.Rows.Count > 0)
        {
            //doc.Load(rptName);
            //doc.SetDataSource(dataTable);
            Hidetoolbar();
            //CrystalReportViewer1.ReportSource = doc;
            //CrystalReportViewer1.Visible = true;
        }
        else
        {
            ShowMessage("No Record(s) found");
            //CrystalReportViewer1.Visible = false;
        }
    }
    private void Hidetoolbar()
    {
    }
    private void PrintReport()
    {
        LoadReportToDownload();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            PrintReport();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboFinancialYear_DataBound(object sender, EventArgs e)
    {

    }
    private void ShowMessage(string Message)
    {
        Message = "";
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
    private void LoadFinancialYears()
    {
        dataTable = dac.GetFinancialYears();
        cboFinancialYear.DataSource = dataTable;
        cboFinancialYear.DataValueField = "FYCode";
        cboFinancialYear.DataTextField = "FYear";
        cboFinancialYear.DataBind();

        string ActiveFinYearCode = Session["PFinYearCode"].ToString();
        cboFinancialYear.SelectedIndex = cboFinancialYear.Items.IndexOf(cboFinancialYear.Items.FindByValue(ActiveFinYearCode));
    }
    protected void cboAreas_DataBound(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem("- - All Areas - -", "0"));
    }
    protected void cboCostCenters_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("- - All Cost Centers - -", "0"));
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int AreaID = Convert.ToInt32(cboAreas.SelectedValue);
            LoadCostCenters();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridCCenter_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridCCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            ProjectedCashFlow.PageIndex = newPageIndex;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
}
