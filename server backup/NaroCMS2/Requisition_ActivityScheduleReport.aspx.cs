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

public partial class Requisition_ActivityScheduleReport : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    DataLogin dac = new DataLogin();
    BusinessRequisition bll = new BusinessRequisition();
    private DataTable dtGetReport = new DataTable();
    private DataTable dtData;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsPostBack == false)
            {
                btnPrint.Enabled = false;
                Label msg = (Label)Master.FindControl("lblmsg");
                msg.Text = ".";
                LoadOfficers(); LoadFinancialYears();
            }
            else
            {
                GetReportData();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadFinancialYears()
    {
        cboFinancialYear.DataSource = dac.GetFinancialYears();
        cboFinancialYear.DataValueField = "FYCode";
        cboFinancialYear.DataTextField = "FYear";
        cboFinancialYear.DataBind();

        string ActiveFinYearCode = Session["RFinYearCode"].ToString();
        cboFinancialYear.SelectedIndex = cboFinancialYear.Items.IndexOf(cboFinancialYear.Items.FindByValue(ActiveFinYearCode));
    }
    private void LoadOfficers()
    {
        cboProcurementOfficer.DataSource = Process.GetPDUMembers();
        cboProcurementOfficer.DataValueField = "UserID";
        cboProcurementOfficer.DataTextField = "Name";
        cboProcurementOfficer.DataBind();
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
    protected void cboProcurementOfficer_DataBound(object sender, EventArgs e)
    {
        cboProcurementOfficer.Items.Insert(0, new ListItem(" -- All Procurement Officers -- ", "0"));
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            GetReportData();
            MultiView1.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    /// <summary>
    /// Message to display to user.
    /// </summary>
    /// <param name="MessageToDisplay"></param>
    private void ShowMessage(string MessageToDisplay)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        msg.Text = "MESSAGE:  " + MessageToDisplay;
    }
    private void GetReportData()
    {
        int PDUCategory = Convert.ToInt32(cboPDUCategory.SelectedValue);
        string ProcurementOfficer = cboProcurementOfficer.SelectedValue;
        string FinancialYear = cboFinancialYear.SelectedValue;

        dtData = Process.GetMainScheduleActivityDetails(PDUCategory, ProcurementOfficer, FinancialYear);
        DataTable dtSReport = Process.GetActivityScheduleForSubReport(PDUCategory, ProcurementOfficer);

        int rowcount = dtData.Rows.Count;

        if (rowcount != 0)
        {
            btnPrint.Enabled = true;
            loadreport(dtSReport);
        }
    }

    public void loadreport(DataTable dtSReport)
    {
        string appPath, physicalPath, rptName, rptFile, rptSubFile;
        rptFile = "MainActivity.rpt";
        rptSubFile = "SubActivity.rpt";

        if (DropDownList1.SelectedValue == "2")
        {
            rptFile = "PDUMainActivity.rpt";
            rptSubFile = "PDUSubActivity.rpt";
        }
        else if (DropDownList1.SelectedValue == "3")
        {
            rptFile = "PDUMainActivityGroup.rpt";
            rptSubFile = "PDUSubActivity.rpt";
        }

        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\" + rptFile;

        //doc.Load(rptName);
        //doc.SetDataSource(dtData);

        //Hidetoolbar();
        //doc.Subreports[rptSubFile].SetDataSource(dtSReport);
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

    private void PrintReport()
    {
        //loadreport();
        //Response.Buffer = false;
        //Response.ClearContent();
        //Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Assigned PRs");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            int PDUCategory = Convert.ToInt32(cboPDUCategory.SelectedValue);
            string ProcurementOfficer = cboProcurementOfficer.SelectedValue;
            string FinancialYear = cboFinancialYear.SelectedValue;

            dtData = Process.GetMainScheduleActivityDetails(PDUCategory, ProcurementOfficer, FinancialYear);
            DataTable dtSReport = Process.GetActivityScheduleForSubReport(PDUCategory, ProcurementOfficer);

            int rowcount = dtData.Rows.Count;

            if (rowcount != 0)
            {
                btnPrint.Enabled = true;
                loadreport(dtSReport);
            }

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Activity Schedule");
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
}
