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
public partial class Planning_ConsolidatedPlans : System.Web.UI.Page
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
                LoadAreas(); LoadCostCenters();
                LoadQuarters(); ToggleControls();
                ShowMessage(".");
            }
            else
            {
                LoadReport();
            }
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
            chkSummary.Enabled = false;
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
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //    GC.Collect();
        //}
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
    private void LoadQuarters()
    {
        dataTable = Process.GetPlanningQuaters();
        cboQuarter.DataSource = dataTable;
        cboQuarter.DataValueField = "QuarterCode";
        cboQuarter.DataTextField = "Quarter";
        cboQuarter.DataBind();

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

        try
        {
            if (cboprocType.SelectedValue.ToString().Equals("0"))
            {

                lbltitle.Text = "PROCUREMENT PLAN FOR CONSULTANCY SERVICES".ToUpper();

            }
            else if (cboprocType.SelectedValue.ToString().Equals("1"))
            {
                lbltitle.Text = "PROCUREMENT PLAN FOR GOODS, WORKS AND NON CONSULTANCY SERVICES".ToUpper();
            }


            if (cboprocType.SelectedValue.ToString().Equals("2"))
            {

                ShowMessage("Please Select Procurement Type Category");
                lbltitle.Text = "Please Select Procurement Type Category";

            }
            else {
                LoadReport();
            }

           
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadReportToPrint()
    {
        string FinancialYearCode = cboFinancialYear.SelectedValue.ToString();
        string AreaCode = cboAreas.SelectedValue.ToString();
        Label1.Text = "DETAILED CONSOLIDATED PLAN FOR THE FINANCIAL YEAR: " + cboFinancialYear.SelectedItem.Text;
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        string Quarter = cboQuarter.SelectedValue.ToString();
        string appPath, physicalPath;
        string rptName = "";
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        if (chkSummary.Checked == true)
        {
            dataTable = Process.GetPlanCosolidatedSummary(FinancialYearCode, AreaCode, CostCenter, Quarter);
            ConsolidatedPlans.DataSource = dataTable;
            ConsolidatedPlans.DataBind();
        }
        else
        {
            if (cboprocType.SelectedValue.ToString().Equals("0"))
            {
                Reports reports = new Reports();
                dataTable = Process.GetPlanCosolidatedDetails(FinancialYearCode, AreaCode, CostCenter, Quarter, "0");
                Byte[] pdfreport = reports.GenerateAllTransactionsPdfReport(dataTable, Label1.Text,"","","","");
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
            else if (cboprocType.SelectedValue.ToString().Equals("1"))
            {

                dataTable = Process.GetPlanCosolidatedDetails(FinancialYearCode, AreaCode, CostCenter, Quarter, "1");
                ConsolidatedPlans.DataSource = dataTable;
                ConsolidatedPlans.DataBind();

            }
        }
        if (dataTable.Rows.Count > 0)
        {
            Decimal total = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                total += Decimal.Parse(row["estimateCost"].ToString());
            }

            btnPrint.Enabled = true;
            btnPrint2.Enabled = true;
            Hidetoolbar();
            ShowMessage(" THE TOTAL IS " + total.ToString());
            total = 0;
        }
        else
        {
            btnPrint.Enabled = false;
            btnPrint2.Enabled = false;
            ShowMessage("No Record(s) found");
        }

    }

    private void LoadReport()
    {
        string FinancialYearCode = cboFinancialYear.SelectedValue.ToString();
        string AreaCode = cboAreas.SelectedValue.ToString();
        Label1.Text = "DETAILED CONSOLIDATED PLAN FOR THE FINANCIAL YEAR: " + cboFinancialYear.SelectedItem.Text;
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        string Quarter = cboQuarter.SelectedValue.ToString();
        string appPath, physicalPath;
        string rptName = "";
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        if (chkSummary.Checked == true)
        {
            dataTable = Process.GetPlanCosolidatedSummary(FinancialYearCode, AreaCode, CostCenter, Quarter);
            ConsolidatedPlans.DataSource = dataTable;
            ConsolidatedPlans.DataBind();
        }
        else
        {
            if (cboprocType.SelectedValue.ToString().Equals("0"))
            {

                dataTable = Process.GetPlanCosolidatedDetails(FinancialYearCode, AreaCode, CostCenter, Quarter, "0");
                ConsolidatedPlans.DataSource = dataTable;
                ConsolidatedPlans.DataBind();
            }
            else if (cboprocType.SelectedValue.ToString().Equals("1"))
            {

                dataTable = Process.GetPlanCosolidatedDetails(FinancialYearCode, AreaCode, CostCenter, Quarter, "1");
                ConsolidatedPlans.DataSource = dataTable;
                ConsolidatedPlans.DataBind();

            }
        }
        if (dataTable.Rows.Count > 0)
        {
            Decimal total = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                total += Decimal.Parse(row["estimateCost"].ToString());
            }

            //doc.Load(rptName);
            //doc.SetDataSource(dataTable);
            btnPrint.Enabled = true;
            btnPrint2.Enabled = true;
            Hidetoolbar();
            ShowMessage(" THE TOTAL IS " + total.ToString());
            total = 0;
        }
        else
        {
            btnPrint.Enabled = false;
            btnPrint2.Enabled = false;
            ShowMessage("No Record(s) found");
            //CrystalReportViewer1.Visible = false;
        }

    }

    protected void GridCCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            ConsolidatedPlans.PageIndex = newPageIndex;

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void GridCCenter_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    private void Hidetoolbar()
    {
    }

    private void PrintReport()
    {
        ShowMessage(".");
        LoadReportToPrint();
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
        cboFinancialYear.Items.Insert(0, new ListItem(" -- Select Financial Year --", "0"));
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
    protected void cboQuarter_DataBound(object sender, EventArgs e)
    {
        cboQuarter.Items.Insert(0, new ListItem("- - All Quarter - -", "0"));
    }
    protected void btnPrint2_Click(object sender, EventArgs e)
    {
        try
        {
            PrintReport2();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void PrintReport2()
    {
        ShowMessage(".");
        LoadReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
    }
}
