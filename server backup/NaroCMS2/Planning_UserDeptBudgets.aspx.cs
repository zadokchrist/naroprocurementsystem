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
using System.Collections.Generic;
using OfficeOpenXml;
using System.Linq;

public partial class Planning_UserDeptBudgets : System.Web.UI.Page
{
    DataLogin dac = new DataLogin();
    DataTable dataTable = new DataTable();
    ProcessPlanning Process = new ProcessPlanning();
    DataTable reportData = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadFinancialYears();
                LoadAreas(); LoadCostCenters();
                ToggleControls();
                Multiview1.ActiveViewIndex = 0;
                LoadBudgets();
                ShowMessage(".");

            }
            else
            {
                LoadBudgets();
            }
        }
        catch (Exception xe)
        {
            ShowMessage(xe.Message);
        }
    }

    private void LoadBudgets()
   {
        if (cboFinancialYear.SelectedValue == "0")
        {
            ShowMessage("Select a financial year");
        }
        else
        {
            int costcenter = int.Parse(cboCostCenters.SelectedValue);
            int fyear = int.Parse(cboFinancialYear.SelectedValue);

            dataTable = Process.GetCostCenterBudgets(costcenter, fyear);
            DataGrid1.DataSource = dataTable;
            DataGrid1.DataBind();


        }
       

    }

    private void ToggleControls()
    {
        Label1.Text = "COST CENTER BUDGETS FOR THE FINANCIAL YEAR: " + Session["PFinancialYear"].ToString();
        string Access = Session["AccessLevelID"].ToString();
        if (Access == "7" || Access == "17")
        {
            cboAreas.Enabled = true;
            cboCostCenters.Enabled = true;
        }
        else
        {
            cboAreas.Enabled = false;
            cboCostCenters.Enabled = false;
            string Area = Session["AreaCode"].ToString();
            string Center = Session["CostCenterID"].ToString();
            cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(Area));
            cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(Center));
   
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
            downloadTemplate();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void downloadTemplate()
    {
        string appPath, physicalPath;
        string rptName = "";
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        int costcenter = int.Parse(cboCostCenters.SelectedValue);
        int fyear = int.Parse(cboFinancialYear.SelectedValue);
        DataTable reportData = new DataTable();
        reportData.Columns.Add(new DataColumn("budgetId", typeof(String)));
        reportData.Columns.Add(new DataColumn("budgetCode", typeof(String)));
        reportData.Columns.Add(new DataColumn("costCenterCode", typeof(String)));
        reportData.Columns.Add(new DataColumn("costCenterName", typeof(String)));
        reportData.Columns.Add(new DataColumn("amount", typeof(String)));
        dataTable = Process.GetCostCenterBudgets(costcenter, fyear);

        foreach (DataRow crow in dataTable.Rows) {
            DataRow _row = reportData.NewRow();
            _row["budgetId"] = crow["recordid"].ToString();
            _row["budgetCode"] = crow["BudgetCode"].ToString();
            _row["costCenterCode"] = crow["CostCenterCode"].ToString();
            _row["costCenterName"] = crow["CostCenterName"].ToString();
            _row["amount"] = crow["Description"].ToString();

            reportData.Rows.Add(_row);

        }

        rptName = physicalPath + "\\Bin\\Reports\\CostCenterBudgets.rpt";
        //doc.Load(rptName);
        //doc.SetDataSource(reportData);
        //Response.Buffer = false;
        //Response.ClearContent();
        //Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, true, "CostCenterBudgetsTemplate");

    }

   
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Multiview1.ActiveViewIndex = 1;
    }

    private void UploadFiles()
    {
        

        int countfiles = 0;
        string c = System.IO.Path.GetFileName(fileUpload1.FileName);
        string cNoSpace = c.Replace(" ", "-");
        string c1 = "x" + "_" + (countfiles + 1 + 1) + "_" + cNoSpace;
        string path = Process.GetDocPath();
        string rPath = path + "" + c1;
        fileUpload1.PostedFile.SaveAs(rPath);
        string text = File.ReadAllText(@rPath).ToString();
        int succeed = 0;
        int fail = 0;
        if (fileUpload1.HasFile && (Path.GetExtension(fileUpload1.FileName) == ".xlsx"))
        {
            using (var excel = new ExcelPackage(new FileInfo(@rPath)))
            {
                var tbl = new DataTable();
                var ws = excel.Workbook.Worksheets.First();
                var hasHeader = true;  // adjust accordingly
                                       // add DataColumns to DataTable

                if (ws.Dimension.End.Column != 5)
                {
                    ShowMessage("Error processing file columns. Check number of columns in Excel file");
                }

                int i = 0;
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    String column = firstRowCell.Text;
                    if(i==0 & column != "budgetId")
                    {
                        ShowMessage("Invalid column 1. Expecting budgetId");
                        break;
                    }
                    else if (i == 1 & column != "budgetCode")
                    {
                        ShowMessage("Invalid column 2. Expecting budgetCode");
                        break;
                    }
                    else if(i == 2 & column != "costCenterCode")
                    {
                        ShowMessage("Invalid column 3. Expecting costCenterCode");
                        break;
                    }
                    else if (i == 3 & column != "costCenterName")
                    {
                        ShowMessage("Invalid column 4. Expecting costCenterName");
                        break;
                    }
                    else if(i == 4 & column != "amount")
                    {
                        ShowMessage("Invalid column 5. Expecting amount");
                        break;
                    }
                    i++;
                        tbl.Columns.Add(hasHeader ? firstRowCell.Text : String.Format("Column {0}", firstRowCell.Start.Column));
                }

                int y = 0;
                // add DataRows to DataTable
                int startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    String budgetId = "0";
                    String budgetCode = "";
                    String costcenterCode = "";
                    String amount = "";

                   
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.NewRow();

                    int u = 0;
                    foreach (var cell in wsRow)
                    {
                        if (u == 0)
                        {
                            budgetId = cell.Text;
                        }else if (u == 1)
                        {
                            budgetCode = cell.Text;
                        }
                        else if (u == 2)
                        {
                            costcenterCode = cell.Text;
                        }
                        else if (u == 4)
                        {
                            amount = cell.Text;
                        }
                        u++;
                            row[cell.Start.Column - 1] = cell.Text;
                    }

                    try
                    {
                        if (amount == "")
                        {
                            ShowMessage("Error adding budget. Invalid amount ");
                        }
                        else if(Process.GetCostCenter(costcenterCode)!= "000000")
                        {
                            int fyear = int.Parse(cboFinancialYear.SelectedValue);
                            int record = int.Parse(budgetId);
                            Process.saveCostcenterBudget(record, budgetCode, costcenterCode, amount, fyear);
                            succeed++;
                        }else 
                        {
                            ShowMessage("Error adding budget. Invalid costcenter ");
                            fail++;
                        }
                       
                    }
                    catch(Exception ex)
                    {
                        fail++;
                        ShowMessage("Error adding budget: " + ex.Message);
                    }
                    //UpdateCostCenterBudget
                    //IsCostCenterValid

                    //Is BudgetExisting -- Replace

                    
                    tbl.Rows.Add(row);
                }
                ShowMessage("Upload Result: "+succeed+" succeeded, "+fail+" failed");

            //UploadStatusLabel.Text = msg;
            }
        }else
        {
            ShowMessage("Error processing file. Upload valid Excel (.xlsx) file");
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

    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "btnRemove")
        {


        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        UploadFiles();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Multiview1.ActiveViewIndex = 0;
        LoadBudgets();
    }

    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        LoadBudgets();
    }

    protected void cboFinancialYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBudgets();
    }

    protected void cboCostCenters_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBudgets();
    }
}
