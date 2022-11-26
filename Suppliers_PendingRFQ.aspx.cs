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

public partial class Requisition_PlannedItems : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessPlanning bll = new BusinessPlanning();
    BusinessRequisition bllReq = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataSet dataSet = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                if (bllReq.CheckIfUserInConsolidationCenter(Session["UserID"].ToString()))
                {
                  //  Label2.Visible = true;
                 //   CheckBox1.Visible = true;
                }
                else
                {
                   // Label2.Visible = false;
                   // CheckBox1.Visible = false;
                }
                LoadProcurmentTypes();
                LoadQuarters();
                if (Request.QueryString["transferid"] != null)
                {
                    //cboPlanned.SelectedIndex = cboPlanned.Items.IndexOf(cboPlanned.Items.FindByValue(Session["Status"].ToString()));
                    cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(Session["ProcType"].ToString()));
                   // cboQuarters.SelectedIndex = cboQuarters.Items.IndexOf(cboQuarters.Items.FindByValue(Session["Quarter"].ToString()));
                   // CheckBox1.Checked = Convert.ToBoolean(Session["IsConsolidate"].ToString());

                    //cboPlanned.SelectedValue = Session["Status"].ToString();
                    //cboProcType.SelectedValue = Session["ProcType"].ToString();
                    //cboQuarters.SelectedValue = Session["Quarter"].ToString();
                    //CheckBox1.Checked = Convert.ToBoolean(Session["IsConsolidate"].ToString());
                }
                LoadPlanItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadProcurmentTypes()
    {
        //datatable = Process.GetRequisitionProcurementTypes();
        //cboProcType.DataSource = datatable;
        //cboProcType.DataValueField = "Code";
        //cboProcType.DataTextField = "Type";
        //cboProcType.DataBind();
    }
    private void LoadPlanItems()
    {
        ShowMessage(".");
        //if (Request.QueryString["transferid"] != null)
        //{
        //    cboPlanned.SelectedIndex = cboPlanned.Items.IndexOf(cboPlanned.Items.FindByValue(Session["Status"].ToString()));
        //    cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(Session["ProcType"].ToString()));
        //    cboQuarters.SelectedIndex = cboQuarters.Items.IndexOf(cboQuarters.Items.FindByValue(Session["Quarter"].ToString()));
        //    CheckBox1.Checked = Convert.ToBoolean(Session["IsConsolidate"].ToString());

        //    SelectItems();
        //    DataGrid1.CurrentPageIndex = 0;
        //    DataGrid2.CurrentPageIndex = 0;
        //    BindSelectItemsToGrid();
        //}
        //else
        //{
            SelectItems();
            DataGrid1.CurrentPageIndex = 0;
          //  DataGrid2.CurrentPageIndex = 0;
            BindSelectItemsToGrid();
       // }
    }

    private void SelectItems()
    {
      //  string Planned = cboPlanned.SelectedValue.ToString();
        string ProcType = cboProcType.SelectedValue.ToString();
      //  string Plancode = txtSearch.Text.Trim();
        string Desc = txtDesc.Text.Trim();
       // string Quarter = cboQuarters.SelectedValue.ToString();
        bool IsConsolidatedChecked = false;
      //  if (CheckBox1.Checked == true)
            IsConsolidatedChecked = true;

      //  datatable = Process.GetItemForRequisition(Plancode, Desc, ProcType, Quarter, Planned, IsConsolidatedChecked);      
    }

    private void BindSelectItemsToGrid()
    {
        //if (cboPlanned.SelectedValue.ToString() == "1")
        //{
        //    if (datatable.Rows.Count > 0)
        //    {
        //        MultiView1.ActiveViewIndex = 0;
        //        DataGrid1.DataSource = datatable;
        //        DataGrid1.DataBind();
        //    }
        //    else
        //    {
        //        MultiView1.ActiveViewIndex = -1;
        //        ShowMessage("No Record(s) for Planned found");
        //    }
        //}
        //else
        //{
        //    if (datatable.Rows.Count > 0)
        //    {
        //        MultiView1.ActiveViewIndex = 1;
        //        DataGrid2.DataSource = datatable;
        //        DataGrid2.DataBind();
        //    }
        //    else
        //    {
        //        MultiView1.ActiveViewIndex = 1;
        //        ShowMessage("No Record(s)for unplanned found");
        //    }
        //}
    }

    private void LoadQuarters()
    {
        //datatable = Process.GetRequisitionQuarters();
        //cboQuarters.DataSource = datatable;
        //cboQuarters.DataValueField = "QuarterCode";
        //cboQuarters.DataTextField = "Quarter";
        //cboQuarters.DataBind();
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
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - All Procurement Types - -", "0"));
    }
    protected void cboQuarters_DataBound(object sender, EventArgs e)
    {
       // cboQuarters.Items.Insert(0, new ListItem("- - All Quarters - -", "0"));
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            LoadPlanItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        ShowMessage(".");
        try
        {
            // Get Item Name......
            string Plancode = e.Item.Cells[0].Text;
            string IsGrouped = e.Item.Cells[3].Text;
            if (e.CommandName == "btnRequisition")
            {
                if (IsGrouped == "YES")
                {
                    CreateRequisitionDataTable();
                    StoreSelectedValues();
                    Response.Redirect("Requisition_NewGroupRequisition.aspx?transferid=" + Plancode, true);
                }
                else
                {
                    CreateIndividualPlanItemsDataTable();
                    CreateProjectDataTable();
                    StoreSelectedValues();
                    Response.Redirect("Requisition_NewRequisition.aspx?transferid=" + Plancode, false);
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void CreateRequisitionDataTable()
    {
        DataTable dtRequisition = new DataTable("Requisitions");
        dtRequisition.Columns.Add(new DataColumn("ItemDesc", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("StockCode", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("StockName", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("StockBalance", typeof(int)));
        dtRequisition.Columns.Add(new DataColumn("Quantity", typeof(int)));
        dtRequisition.Columns.Add(new DataColumn("UnitCode", typeof(int)));
        dtRequisition.Columns.Add(new DataColumn("Units", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("UnitCost", typeof(double)));
        dtRequisition.Columns.Add(new DataColumn("TotalCost", typeof(double)));
        dtRequisition.Columns.Add(new DataColumn("MarketPrice", typeof(double)));

        dtRequisition.Rows.Clear();

        Session["dtRequisition"] = dtRequisition;
    }

    private void CreateIndividualPlanItemsDataTable()
    {
        DataTable dtIndividualPlanItems = new DataTable("IndividualPlanItems");
        dtIndividualPlanItems.Columns.Add(new DataColumn("PlanCode", typeof(string)));
        dtIndividualPlanItems.Columns.Add(new DataColumn("Description", typeof(string)));
        dtIndividualPlanItems.Columns.Add(new DataColumn("InitialQty", typeof(int)));
        dtIndividualPlanItems.Columns.Add(new DataColumn("CurrentQty", typeof(int)));
        dtIndividualPlanItems.Columns.Add(new DataColumn("UnitCode", typeof(int)));
        dtIndividualPlanItems.Columns.Add(new DataColumn("UnitCost", typeof(double)));
        dtIndividualPlanItems.Columns.Add(new DataColumn("TotalCost", typeof(double)));
        dtIndividualPlanItems.Columns.Add(new DataColumn("RequiredQty", typeof(int)));
        dtIndividualPlanItems.Columns.Add(new DataColumn("MarketPrice", typeof(double)));

        dtIndividualPlanItems.Rows.Clear();
        Session["dtIndividualPlanItems"] = dtIndividualPlanItems;
    }

    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

    }
    protected void btnStagesExport_Click(object sender, EventArgs e)
    {

    }
    protected void btnStagesReturn_Click(object sender, EventArgs e)
    {




    }
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string Plancode = e.Item.Cells[0].Text;
            string IsGrouped = e.Item.Cells[3].Text;
            if (e.CommandName == "btnRequisition")
            {
                if (IsGrouped == "YES")
                {
                    CreateRequisitionDataTable();
                    StoreSelectedValues();
                    Response.Redirect("Requisition_NewGroupRequisition.aspx?transferid=" + Plancode, true);
                }
                else
                {
                    CreateIndividualPlanItemsDataTable();
                    StoreSelectedValues();
                    Response.Redirect("Requisition_NewRequisition.aspx?transferid=" + Plancode, true);
                }
            }
            else if (e.CommandName == "btnEdit")
            {
                Response.Redirect("Planning_AddPlan.aspx?transferid=" + Plancode, true);

                Session["Type"] = cboProcType.SelectedValue.ToString();
               // Session["Status"] = cboStatus.SelectedValue.ToString();
               // lblPD_Code.Text = PD_Code;
                LoadLogs();


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
        //cboStatus.Enabled = false;
        cboProcType.Enabled = false;
        MultiView1.ActiveViewIndex = 6;
        //string PD_Code = lblPD_Code.Text.Trim();
        datatable = Process.GetLogs("300420185-11013-13");
        DataGrid4.DataSource = datatable;
        DataGrid4.DataBind();
    }
    private void CreateProjectDataTable()
    {
        DataTable dtProject = new DataTable("ProjectDetails");
        dtProject.Columns.Add(new DataColumn("FinYear", typeof(string)));
        dtProject.Columns.Add(new DataColumn("ItemDesc", typeof(string)));
        dtProject.Columns.Add(new DataColumn("TotalCost", typeof(double)));

        dtProject.Rows.Clear();

        Session["dtProject"] = dtProject;
    }
    private void StoreSelectedValues()
    {
        //Session["PreviousPage"] = "Requisition_Items.aspx";
        //Session["Status"] = cboPlanned.SelectedValue.ToString();
        //Session["ProcType"] = cboProcType.SelectedValue.ToString();
        //Session["Quarter"] = cboQuarters.SelectedValue.ToString();
        //Session["IsConsolidate"] = CheckBox1.Checked;
       
    }
    protected void btnCreateItem_Click(object sender, EventArgs e)
    {
        try
        {
            StoreSelectedValues();
            Response.Redirect("Requisition_AddUnPlannedItem.aspx?transfertype=" + 1, true);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void DataGrid1_PageIndexChanged1(object source, DataGridPageChangedEventArgs e)
    {
        SelectItems();
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        BindSelectItemsToGrid();
    }

    protected void DataGrid2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
       // SelectItems();
       // DataGrid2.CurrentPageIndex = e.NewPageIndex;
       // BindSelectItemsToGrid();
    }
}
