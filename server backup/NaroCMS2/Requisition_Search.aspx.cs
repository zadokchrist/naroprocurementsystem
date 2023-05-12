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

public partial class Requisition_Print : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataLogin data = new DataLogin();
    DataTable datatable = new DataTable();
    DataSet dataSet = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas();
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

        int AreaID = Convert.ToInt32(Session["AreaCode"].ToString());
        LoadCostCenters(AreaID);
        ToggleCenter();
    }

    private void ShowMessage(string Message)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        if (Message == ".")
        {
            msg.Text = ".";
        } else if (Message.Contains("Parameter name: index"))
            msg.Text = ".";
        else
        {
            msg.Text = "MESSAGE: " + Message;
        }
    }
    private void LoadCostCenters(int AreaID)
    {
        string AreaCode = AreaID.ToString();
        datatable = ProcessOthers.GetCostCentersByName("", AreaCode);
        cboCostCenters.DataSource = datatable;
        cboCostCenters.DataValueField = "CostCenterID";
        cboCostCenters.DataTextField = "CostCenterDesc";
        cboCostCenters.DataBind();
        //ToggleCenter();
    }
    private void ToggleCenter()
    {
        int AccessLevelID = Convert.ToInt32(Session["AccessLevelID"].ToString());
        string AreaID = Session["AreaCode"].ToString();
        cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(AreaID));
        string CostCenter = Session["CostCenterID"].ToString();
        cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(CostCenter));
        if (CostCenter == "73" || CostCenter == "4" || AccessLevelID == 1 || AccessLevelID == 3 || AccessLevelID == 9)
        {
            cboAreas.Enabled = true;
            cboCostCenters.Enabled = true;
            cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue("0"));
            cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue("0"));
        }
        else if (AccessLevelID == 5 || AccessLevelID == 6)
        {
            cboAreas.Enabled = false;
            cboCostCenters.Enabled = false;
        }
        else if (AccessLevelID == 7)
            cboAreas.Enabled = false;
        else
        {
            cboAreas.Enabled = true;
            cboCostCenters.Enabled = true;
        }
    }
    private void LoadItems()
    {
        string ProcType = "0";
        string PRNumber = txtPrNumber.Text.Trim();
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        string Area = cboAreas.SelectedValue.ToString();
        string StartDate = txtStartDate.Text.Trim();
        string EndDate = txtEndDate.Text.Trim();
        datatable = Process.GetRequisitionforPrinting(PRNumber, "0", StartDate, EndDate, Area, CostCenter);
    }

    private void BindItemsToGrid()
    {
        string StartDate = txtStartDate.Text.Trim();
        string EndDate = txtEndDate.Text.Trim();
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind();
            lblEmpty.Text = ".";
        }
        else
        {
            MultiView1.ActiveViewIndex = 2;
            string EmptyMessage = "";
            EmptyMessage = "No Requisition(s) in the System for Area ( " + cboAreas.SelectedItem.Text + " ) and Cost Center ( " + cboCostCenters.SelectedItem.ToString() + ")" + Environment.NewLine;
            EmptyMessage += "from " + bll.ReturnDate(StartDate, 1).ToString("dd-MMM-yyyy") + " to " + bll.ReturnDate(EndDate, 2).ToString("dd-MMM-yyyy");
            lblEmpty.Text = EmptyMessage;
        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PD_Code = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[3].Text;
            if (e.CommandName == "btnPrint")
            {
                Session["Status"] = "0";
                Session["Center"] = cboCostCenters.SelectedValue.ToString();
                lblPD_Code.Text = PD_Code;
                LoadReport();
            }
            else if (e.CommandName == "btnStatus")
            {
                Session["Status"] = "0";
                Session["Center"] = cboCostCenters.SelectedValue.ToString();
                lblPD_Code.Text = PD_Code;
                LoadLogs();
            }
            else if (e.CommandName == "btnView")
            {
                Response.Redirect("Requisition_ViewDetails.aspx?transferid=" + RecordID, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadLogs()
    {
        btnOK.Enabled = false;
        cboCostCenters.Enabled = false;
        MultiView1.ActiveViewIndex = 3;
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = Process.GetLogs(PD_Code);
        DataGrid2.DataSource = datatable;
        DataGrid2.DataBind();
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

    private void LoadReport()
    {
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = Process.GetRequisitionDetailform20(PD_Code);
        if (datatable.Rows.Count > 0)
        {
            btnOK.Enabled = false;
            cboCostCenters.Enabled = false;
            MultiView1.ActiveViewIndex = 1;
            string appPath, physicalPath, rptName;
            appPath = HttpContext.Current.Request.ApplicationPath;
            physicalPath = HttpContext.Current.Request.MapPath(appPath);
            rptName = physicalPath + "\\Bin\\Reports\\Requisitioning.rpt";
            //doc.Load(rptName);
            //doc.SetDataSource(datatable);
            //Hidetoolbar();
            //CrystalReportViewer1.ReportSource = doc;
            btnPrint.Enabled = true;
        }
        else
        {
            btnPrint.Enabled = false;
        }
    }
    private void LoadStatusReport()
    {
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = Process.GetReportLogs(PD_Code);

        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\PRStatus.rpt";
        //doc.Load(rptName);
        //doc.SetDataSource(datatable);
        //Hidetoolbar();
        //CrystalReportViewer1.ReportSource = doc; 
    }
    private void Hidetoolbar()
    {
        //CrystalReportViewer1.HasCrystalLogo = false;
        //CrystalReportViewer1.HasRefreshButton = false;
        //CrystalReportViewer1.HasExportButton = false;
        //CrystalReportViewer1.HasPrintButton = false;
        //CrystalReportViewer1.HasPageNavigationButtons = false;
        //CrystalReportViewer1.HasSearchButton = false;
        //CrystalReportViewer1.HasGotoPageButton = false;
        //CrystalReportViewer1.HasZoomFactorList = false;
        //CrystalReportViewer1.HasToggleGroupTreeButton = false;
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
    private void PrintReport()
    {
        LoadReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Requisition");

    }
    private void PrintStatusReport()
    {
        LoadStatusReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Requistion Status");
    }
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            btnOK.Enabled = true;
            cboCostCenters.Enabled = true;
            string PreviousType = Session["Status"].ToString();
            string PreviousCenter = Session["Center"].ToString();
            cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(PreviousCenter));
            LoadItems();
            DataGrid1.CurrentPageIndex = 0;
            BindItemsToGrid();
            ToggleCenter();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        try
        {
            LoadItems();
            DataGrid1.CurrentPageIndex = 0;
            BindItemsToGrid();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboAreas_DataBound(object sender, EventArgs e)
    {

    }
    protected void cboCostCenters_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("- - All Cost Center - -", "0"));
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        LoadItems();
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        BindItemsToGrid();
    }
    protected void cboAreas_DataBound1(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem(" -- All Areas --", "0"));
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int AreaID = Convert.ToInt32(cboAreas.SelectedValue.ToString());
        LoadCostCenters(AreaID);
    }

}
