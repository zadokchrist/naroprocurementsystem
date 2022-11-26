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

public partial class Planning_PPDAProcPlans : System.Web.UI.Page
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
                LoadAreas(); LoadCostCenters(); ToggleControls();
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
        Label1.Text = "USER DEPARTMENT PLAN FOR THE FINANCIAL YEAR: " + Session["PFinancialYear"].ToString();
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
    private void LoadReport()
    {
        string FinancialYearCode = cboFinancialYear.SelectedValue.ToString();
        string AreaCode = cboAreas.SelectedValue.ToString();
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        if (AreaCode == "0")
            ShowMessage("Please Select Area");
        else if (FinancialYearCode == "0")
            ShowMessage("Please Select Financial Year");
        else
        {
            Label1.Text = "NON-CONSULTANCY PROCUREMENT PLAN FOR THE FINANCIAL YEAR: " + cboFinancialYear.SelectedItem.Text;

            string appPath, physicalPath, rptName;
            appPath = HttpContext.Current.Request.ApplicationPath;
            physicalPath = HttpContext.Current.Request.MapPath(appPath);

            dataTable = Process.GetPPDAProcPlan(FinancialYearCode, AreaCode, CostCenter);
            rptName = physicalPath + "\\Bin\\Reports\\WorksNonConsultancyProcurementPlan.rpt";

            if (dataTable.Rows.Count > 0)
            {
                //doc.Load(rptName);
                //doc.SetDataSource(dataTable);
                //Hidetoolbar();
                //CrystalReportViewer1.ReportSource = doc;
                //CrystalReportViewer1.Visible = true;
            }
            else
            {
                ShowMessage("No Record(s) Found");
                //CrystalReportViewer1.Visible = false;
            }
        }
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

    private void PrintReport()
    {
        ShowMessage(".");
        LoadReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "User Dept Plan");
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
}
