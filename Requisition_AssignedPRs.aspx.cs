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

public partial class Requisition_AssignedPRs : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    private DataTable dtGetAssignedPRs = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsPostBack == false)
            {
                LoadAreas();
                LoadProcOfficers();
                btnPrint.Enabled = false;
                btnExportToExcel.Enabled = false;
                Label msg = (Label)Master.FindControl("lblmsg");
                msg.Text = ".";
                
                

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
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            GetReportData();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    #region Methods
    public void loadreport()
    {
        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\AssignedPR.rpt";

        //doc.Load(rptName);
        //doc.SetDataSource(dtGetAssignedPRs);
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

    private void PrintReport(string Format)
    {
        loadreport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        if (Format == "Excel")
        {
            //doc.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, true, "Assigned PRs Excel");
        }
        else
        {
            //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Assigned PRs");
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
    private void GetReportData()
    {
        string AreaCode = cboAreas.SelectedValue;
        string ProcOfficer = cboProcOfficers.SelectedValue;
        string SearchStartDate = txtStartDate.Text.Trim(); string SearchEndDate = txtEndDate.Text.Trim();
        dtGetAssignedPRs = Process.GetAssignedRequisitions(AreaCode, ProcOfficer, SearchStartDate, SearchEndDate);

        int rowcount = dtGetAssignedPRs.Rows.Count;

        if (rowcount != 0)
        {
            btnPrint.Enabled = true;
            btnExportToExcel.Enabled = true;
            loadreport();
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

    #endregion
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            dtGetAssignedPRs = Process.GetAssignedRequisitions(cboAreas.SelectedValue, cboProcOfficers.SelectedValue, txtStartDate.Text.Trim(), txtEndDate.Text.Trim());
            PrintReport("PDF");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            dtGetAssignedPRs = Process.GetAssignedRequisitions(cboAreas.SelectedValue, cboProcOfficers.SelectedValue, txtStartDate.Text.Trim(), txtEndDate.Text.Trim());
            PrintReport("Excel");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadAreas()
    {
        cboAreas.DataSource = ProcessOthers.GetAreas();
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();

        if (Session["IsAreaProcess"].ToString() == "1")
        {
            cboAreas.Enabled = false;
            cboAreas.SelectedValue = Session["AreaCode"].ToString();
        }
    }
    private void LoadProcOfficers()
    {
        DataTable officers = new DataTable();
        if (Session["AccessLevelID"].ToString() == "3")
        {
            cboProcOfficers.Enabled = true;

            cboProcOfficers.DataSource = Process.GetProcOfficers();
            cboProcOfficers.DataValueField = "UserID";
            cboProcOfficers.DataTextField = "FullName";
            cboProcOfficers.DataBind();
        }
        else if (Session["AccessLevelID"].ToString() == "1025")
        {
            cboProcOfficers.Enabled = true;
            cboProcOfficers.DataSource = Process.GetProcLPOfficers();
            cboProcOfficers.DataValueField = "UserID";
            cboProcOfficers.DataTextField = "FullName";
            cboProcOfficers.DataBind();
        }
        else if (Session["AccessLevelID"].ToString() == "1027")
        {
            cboProcOfficers.Enabled = true;
            cboProcOfficers.DataSource = Process.GetProcSPOfficers();
            cboProcOfficers.DataValueField = "UserID";
            cboProcOfficers.DataTextField = "FullName";
            cboProcOfficers.DataBind();
        }
        else
        {
            cboProcOfficers.Enabled = false;
        }
        
    }
    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        //DataGrid1.CurrentPageIndex = e.NewPageIndex;
        //BindItemsToGrid();
    }
    protected void cboAreas_DataBound(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem(" -- All Areas -- ", "0"));
    }
    protected void cboProcOfficers_DataBound(object sender, EventArgs e)
    {
        cboProcOfficers.Items.Insert(0, new ListItem(" -- All Officers -- ", "0"));
    }
}
