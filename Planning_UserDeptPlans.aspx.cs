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
using iTextSharp.text;
using iTextSharp.text.pdf;
public partial class Planning_UserDeptPlans : System.Web.UI.Page
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
                GetReport();
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
            GC.Collect();
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
            GetReport();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void DownloadReport()
    {
        string FinancialYearCode = cboFinancialYear.SelectedValue.ToString();
        string AreaCode = cboAreas.SelectedValue.ToString();
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        if (AreaCode == "0")
            ShowMessage("Please Select Area");
        else if (FinancialYearCode == "0")
            ShowMessage("Please Select Financial Year");
        else if (CostCenter == "0")
            ShowMessage("Please Select Cost Center");
        else
        {
            Label1.Text = "USER DEPARTMENT PLAN FOR THE FINANCIAL YEAR: " + cboFinancialYear.SelectedItem.Text;

            string appPath, physicalPath, rptName;
            appPath = HttpContext.Current.Request.ApplicationPath;
            physicalPath = HttpContext.Current.Request.MapPath(appPath);

            dataTable = Process.GetUserDeptPlan(FinancialYearCode, AreaCode, CostCenter);

            if (dataTable.Rows.Count > 0)
            {
                Reports reports = new Reports();
                Byte[] pdfreport = reports.GenerateAllTransactionsPdfReport(dataTable, "USER DEPARTMENT PLAN REPORT", DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"), "TEST USER", "");
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=UserDeptReport.pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(pdfreport);
                Response.End();
                Response.Close();
            }
            else
            {
                ShowMessage("No Record(s) Found");
            }
        }
    }
    private void GetReport()
    {
        string FinancialYearCode = cboFinancialYear.SelectedValue.ToString();
        string AreaCode = cboAreas.SelectedValue.ToString();
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        if (AreaCode == "0")
            ShowMessage("Please Select Area");
        else if (FinancialYearCode == "0")
            ShowMessage("Please Select Financial Year");
        else if (CostCenter == "0")
            ShowMessage("Please Select Cost Center");
        else
        {
            Label1.Text = "USER DEPARTMENT PLAN FOR THE FINANCIAL YEAR: " + cboFinancialYear.SelectedItem.Text;

            string appPath, physicalPath, rptName;
            appPath = HttpContext.Current.Request.ApplicationPath;
            physicalPath = HttpContext.Current.Request.MapPath(appPath);

            dataTable = Process.GetUserDeptPlan(FinancialYearCode, AreaCode, CostCenter);

            if (dataTable.Rows.Count > 0)
            {
                DeptPlans.DataSource = dataTable;
                DeptPlans.DataBind();
            }
            else
            {
                ShowMessage("No Record(s) Found");
            }
        }
    }
    private void Hidetoolbar()
    {
    }

    private void PrintReport()
    {
        ShowMessage(".");
        DownloadReport();
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
        cboFinancialYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem(" -- Select Financial Year --", "0"));
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
        cboAreas.Items.Insert(0, new System.Web.UI.WebControls.ListItem("- - All Areas - -", "0"));
    }
    protected void cboCostCenters_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new System.Web.UI.WebControls.ListItem("- - All Cost Centers - -", "0"));
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
    protected void GridCCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            DeptPlans.PageIndex = newPageIndex;

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void GridCCenter_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
}
