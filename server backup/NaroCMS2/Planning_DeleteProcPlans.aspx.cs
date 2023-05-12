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

public partial class Planning_DeleteProcPlans : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    DataLogin data = new DataLogin();
    ProcessPlanning Process = new ProcessPlanning();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadProcurmentTypes();
                LoadAreas();

                if (Request.QueryString["transferid"] != null)
                {
                    DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(Session["SelectedArea"].ToString()));
                    cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(Session["SelectedCostCenter"].ToString()));
                    cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(Session["SelectedProcType"].ToString()));
                    int PageIndex = Convert.ToInt32(Session["PageIndex"].ToString());
                    LoadItems(0); DataGrid1.CurrentPageIndex = PageIndex; BindLoadItems();
                }
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
        else
        {
            msg.Text = "MESSAGE: " + Message;
        }
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("-- Select Area --", "0"));
    }
    protected void cboCostCenters_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem(" -- All Cost Centers -- ", "0"));
    }
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - All Procurement Types - -", "0"));
    }

    protected void cbodeletechoice_DataBound(object sender, EventArgs e)
    {
        cbodeletechoice.Items.Insert(0, new ListItem("- - NOT DELETED - -", "0"));
    }
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SelectAllItems(chkSelect.Checked);
            if (chkSelect.Checked == true)
                CheckBox2.Checked = true;
            else
                CheckBox2.Checked = false;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SelectAllItems(CheckBox2.Checked);
            if (CheckBox2.Checked == true)
                chkSelect.Checked = true;
            else
                chkSelect.Checked = false;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void SelectAllItems(bool IsChecked)
    {
        foreach (DataGridItem Items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(Items.FindControl("CheckBox1")));
            if (IsChecked)
                chk.Checked = true;
            else
                chk.Checked = false;
        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
           // string Plancode = e.Item.Cells[1].Text;
           // string Desc = e.Item.Cells[2].Text;
            string CostCenterSelected = cboCostCenters.SelectedValue;
            Session["PreviousPage"] = "Planning_Procu.aspx";
            Session["SelectedArea"] = DropDownList1.SelectedValue;
            Session["SelectedCostCenter"] = cboCostCenters.SelectedValue;
            Session["SelectedProcType"] = cboProcType.SelectedValue;
            Session["PageIndex"] = DataGrid1.CurrentPageIndex;
            
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadItems(int deleted)
    {
        string plancode = txtplancode.Text.ToString().Trim();
        string Search = DropDownList1.SelectedValue.ToString();
        string ProcTypeCode = cboProcType.SelectedValue.ToString();
        string CostCenterID = cboCostCenters.SelectedValue.ToString();
        if (plancode.Equals(""))
            plancode = "0";
        dtable = Process.GetPlanItemsForDeletePM(plancode,Search, ProcTypeCode, CostCenterID,deleted);

    }

    private void BindLoadItems()
    {
        if (dtable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;

            DataGrid1.DataSource = dtable;
            DataGrid1.DataBind();
            double totalCost = 0;
            foreach (DataRow dr in dtable.Rows)
            {
                double totalCostGet = Convert.ToDouble(dr["Total Cost"]);
                totalCost = totalCost += totalCostGet;
            }
            Label1.Visible = true;
            Label2.Visible = true;
            Label2.Text = totalCost.ToString("#,##0");
            //ShowMessage(".");
            Button1.Enabled = true;
            CheckBox2.Enabled = true;
            chkSelect.Enabled = true;
          
            txtComment.Enabled = true;
        }
        else
        {
            Label1.Visible = false;
            Label2.Visible = false;
            DataGrid1.DataSource = dtable;
            DataGrid1.DataBind();
            ShowMessage("No Plan Item(s) Found");
            Button1.Enabled = false;
            CheckBox2.Enabled = false;
            chkSelect.Enabled = false;
            txtComment.Enabled = false;
           
        }
    }


    private void LoadAreas()
    {
        dtable = data.GetAreas();
        DropDownList1.DataSource = dtable;
        DropDownList1.DataValueField = "AreaID";
        DropDownList1.DataTextField = "Area";
        DropDownList1.DataBind();
        int AreaID = Convert.ToInt32(DropDownList1.SelectedValue);
        LoadCostCenters(AreaID);
    }
    private void LoadCostCenters(int AreaID)
    {
        dtable = data.GetCostCenters(AreaID);
        cboCostCenters.DataSource = dtable;
        cboCostCenters.DataValueField = "CostCenterID";
        cboCostCenters.DataTextField = "CostCenterName";
        cboCostCenters.DataBind();
    }
    private void LoadProcurmentTypes()
    {
        dtable = Process.GetProcurementTypes();
        cboProcType.DataSource = dtable;
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int AreaID = Convert.ToInt32(DropDownList1.SelectedValue);
            LoadCostCenters(AreaID);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DeletePlanItems();
        LoadItems(0);
        DataGrid1.CurrentPageIndex = DataGrid1.CurrentPageIndex;
        BindLoadItems();
    }

    private void DeletePlanItems()
    {
        string ItemArr = GetItemsToConsolidate().TrimEnd(',');

        if (ItemArr != "")
        {
            string returned;
            if (txtComment.Text.ToString().Trim().Equals(""))
                returned = "please enter comment in text box";
            else
            returned = Process.DeletePlanItemsByProcManager(ItemArr, 8, txtComment.Text);
                  
            ShowMessage(returned);
        }
        else
        {
            ShowMessage("Please select plan items to delete ...");
        }
    }

    private string GetItemsToConsolidate()
    {
        int Count = 0;
        string ItemArr = "";
        foreach (DataGridItem Items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(Items.FindControl("CheckBox1")));
            if (chk.Checked)
            {
                Count++;
                string ItemFound = Items.Cells[0].Text;
                ItemArr = ItemArr += ItemFound + ",";
            }
        }
        return ItemArr;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            if (cbodeletechoice.SelectedValue.ToString().Trim().Equals("0"))
            {
                ShowMessage(".");
                LoadItems(0);
                DataGrid1.CurrentPageIndex = 0;
                BindLoadItems();
            }
            else if (cbodeletechoice.SelectedValue.ToString().Trim().Equals("1"))
            {

                ShowMessage(".");
                LoadItems(1);
                MultiView1.ActiveViewIndex = 1;

                LoadReport();
            }
            


        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        LoadItems(0);
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        BindLoadItems();
    }
    protected void btnOK1_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        
        string appPath, physicalPath;
        string rptName = "";
        appPath = HttpContext.Current.Request.ApplicationPath;

        physicalPath = HttpContext.Current.Request.MapPath(appPath);

        rptName = physicalPath + "\\Bin\\Reports\\DeletedPlanReport.rpt";



            if (dtable.Rows.Count > 0)
          {
            //doc.Load(rptName);
            //doc.SetDataSource(dtable);
            btnPrint.Enabled = true;
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
        //CrystalReportViewer1.HasPrintButton = false;
        //CrystalReportViewer1.HasCrystalLogo = false;
        //CrystalReportViewer1.HasDrillUpButton = false;
        //CrystalReportViewer1.HasExportButton = false;
        //CrystalReportViewer1.HasRefreshButton = false;
        //CrystalReportViewer1.HasViewList = false;
        //CrystalReportViewer1.HasZoomFactorList = false;
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            LoadItems(1);
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
        LoadReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "DeletedPlanReport");
    }
}