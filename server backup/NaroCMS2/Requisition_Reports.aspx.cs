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


public partial class Requisition_Reports : System.Web.UI.Page
{
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    ProcessRequisition Process = new ProcessRequisition();
    DataTable datatable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                
                int AreaID = Convert.ToInt32(Session["AreaCode"].ToString());
                if (Session["AccessLevelID"].ToString() == "7" || Session["AccessLevelID"].ToString() == "3")
                {
                    LoadCostCenters(0);
                }
                else {

                    LoadCostCenters(AreaID);
                
                }
                LoadFinancialYears();
                //cboStatus.SelectedValue = "0";
            }

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ShowMessage(string Message)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        if (Message == ".")
        {
            msg.Text = ".";
        }
        else if (Message.Contains("Parameter name: index"))
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

    private void LoadFinancialYears()
    {

        datatable = ProcessOthers.GetFinancialYears("0");
        cboFinYear.DataSource = datatable;
        cboFinYear.DataValueField = "Code";
        cboFinYear.DataTextField = "Year";
        cboFinYear.DataBind();
        //ToggleCenter();
    }



    protected void cboCostCenter_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("- - All Cost Center - -", "0"));
    }
    protected void cboFinYear_DataBound(object sender, EventArgs e)
    {
        cboFinYear.Items.Insert(0, new ListItem("- - All Financial Years - -", "0"));
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        LoadItems();
        BindItemsToGrid();
        ClearSearch();

    }

    private void ClearSearch()
    {

       // txtBugetCode.Text = "";
      //  cboStatus.SelectedValue = "0";
    }
    private void LoadItems()
    {
        string scalaPr = txtPrNumber.Text.ToString().Trim();
        string budgetCode = txtBugetCode.Text.ToString().Trim();
        string level = cboStatus.SelectedValue.ToString();
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        string FinYearID = cboFinYear.SelectedValue.ToString();
        //ShowMessage("BudgetCode:" + budgetCode + "level: " + level + "CostCenter: "+CostCenter + "Finincial Year" + FinYearID);
        if (scalaPr.Equals(""))
            scalaPr = "0";
        if (budgetCode.Equals(""))
            budgetCode = "0";
        if (cboStatus.SelectedValue.ToString() == "0")
        {
            ShowMessage("Please Select A status");
            DataTable dt = new DataTable();
            DataGrid1.DataSource = dt;
            DataGrid1.DataBind();
        }
        else
        {
            ShowMessage(".");
            datatable = Process.GetReport(scalaPr,budgetCode, CostCenter, FinYearID, level);
            
        }
    }
    private void BindItemsToGrid()
    {
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind();
            lblEmpty.Text = ".";
            btnPrint2.Enabled=true;
            btnPrint.Enabled = true;
        }
        else
        {
            MultiView1.ActiveViewIndex = 1;
            string EmptyMessage = "No Reports To Show";
            //EmptyMessage = "No Requisition(s) in the System for Area ( " + cboAreas.SelectedItem.Text + " ) and Cost Center ( " + cboCostCenters.SelectedItem.ToString() + ")" + Environment.NewLine;
            lblEmpty.Text = EmptyMessage;
        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
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
        ShowMessage(".");
        string scalaPr = txtPrNumber.Text.ToString().Trim();
        string budgetCode = txtBugetCode.Text.ToString().Trim();
        string level = cboStatus.SelectedValue.ToString();
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        string FinYearID = cboFinYear.SelectedValue.ToString();
        if (scalaPr.Equals(""))
            scalaPr = "0";
        if (budgetCode.Equals(""))
            budgetCode = "0";
        datatable = Process.GetReport(scalaPr, budgetCode, CostCenter, FinYearID, level);
        Reports reports = new Reports();
        Byte[] pdfreport = reports.GenerateAllTransactionsPdfReport(datatable, budgetCode, "", "", "", "");
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=RequisitionReport.pdf");
        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(pdfreport);
        Response.End();
        Response.Close();
    }

    private void PrintReport2()
    {
        ShowMessage(".");
        string scalaPr = txtPrNumber.Text.ToString().Trim();
        string budgetCode = txtBugetCode.Text.ToString().Trim();
        string level = cboStatus.SelectedValue.ToString();
        string CostCenter = cboCostCenters.SelectedValue.ToString();
        string FinYearID = cboFinYear.SelectedValue.ToString();
        if (scalaPr.Equals(""))
            scalaPr = "0";
        if (budgetCode.Equals(""))
            budgetCode = "0";
        datatable = Process.GetReport(scalaPr, budgetCode, CostCenter, FinYearID, level);
        Reports reports = new Reports();
        Byte[] pdfreport = reports.GenerateAllTransactionsPdfReport(datatable, budgetCode, "", "", "", "");
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=RequisitionReport.pdf");
        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(pdfreport);
        Response.End();
        Response.Close();
    }
    private void LoadReport(DataTable dataTable)
    {
        //string appPath, physicalPath, rptName;
        //appPath = HttpContext.Current.Request.ApplicationPath;
        //physicalPath = HttpContext.Current.Request.MapPath(appPath);
        //rptName = physicalPath + "\\Bin\\Reports\\financeexpenditureReport.rpt";
        //if (dataTable.Rows.Count > 0)
        //{
        //    //doc.Load(rptName);
        //    //doc.SetDataSource(dataTable);         
        //}
    }
}