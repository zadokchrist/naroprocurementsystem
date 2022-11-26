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
public partial class Requisition_NewGroupRequisition : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOther = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();
    private bool IsGroup = false;
    private bool IsEmergency = false;
    string Status = "0";

    private DataTable dtUpdate;

    private void CreateRequisitionDataTable()
    {
        DataTable dtRequisition = new DataTable("Requisitions");
        dtRequisition.Columns.Add(new DataColumn("RecordID", typeof(long)));
        dtRequisition.Columns.Add(new DataColumn("ItemDesc", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("IsStockItem", typeof(bool)));
        dtRequisition.Columns.Add(new DataColumn("StockCode", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("StockName", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("StockBalance", typeof(int)));
        dtRequisition.Columns.Add(new DataColumn("Quantity", typeof(int)));
        dtRequisition.Columns.Add(new DataColumn("UnitCost", typeof(double)));
        dtRequisition.Columns.Add(new DataColumn("TotalCost", typeof(double)));
        dtRequisition.Rows.Clear();

        Session["dtRequisition"] = dtRequisition;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                CreateRequisitionDataTable();

                if (Request.QueryString["transferid"] != null)
                {
                    string RecordCode = Request.QueryString["transferid"].ToString();
                    lblRecordCode.Text = RecordCode;
                    string RecordID = lblRecordCode.Text.Trim();
                    LoadControls(RecordID);
                }
                else
                {
                    Response.Redirect("Requisition_InventoryViewItems.aspx", true);
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
        dtUpdate = (DataTable)Session["dtRequisition"];
    }

    private void LoadControls(string RecordID)
    {
        LoadLocations();
        LoadWareHouses();
        dtable = Process.GetRequisitions(RecordID, "0", "", "", Status);
        lblEntity.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtSubject.Text = dtable.Rows[0]["Subject"].ToString();
        string Type = dtable.Rows[0]["TypeID"].ToString();
        CboRequisition.SelectedIndex = CboRequisition.Items.IndexOf(CboRequisition.Items.FindByValue(Type));
        string LocationID = dtable.Rows[0]["LocationID"].ToString();
        cboLocation.SelectedIndex = cboLocation.Items.IndexOf(cboLocation.Items.FindByValue(LocationID));
        string WareHouseID = dtable.Rows[0]["WareHouseID"].ToString();
        cboWareHouses.SelectedIndex = cboWareHouses.Items.IndexOf(cboWareHouses.Items.FindByValue(WareHouseID));
        txtDateRequired.Text = dtable.Rows[0]["DateRequired"].ToString();
        lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
        lblPlanAmount.Text = Convert.ToDouble(dtable.Rows[0]["InitialPlanAmount"]).ToString("#,##0");
        lblPlanCode.Text = dtable.Rows[0]["PlanCode"].ToString();
        lblCurrentPlanAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");
        lblAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");
        txtBudgetCode.Text = dtable.Rows[0]["BudgetCode"].ToString();
        txtExpenditure.Text = Convert.ToDouble(dtable.Rows[0]["Expenditure"]).ToString("#,##0");
        txtBalanceOnBudet.Text = Convert.ToDouble(dtable.Rows[0]["BudgetBalance"]).ToString("#,##0");
        txtAmountApproved.Text = Convert.ToDouble(dtable.Rows[0]["ApprovedAmount"]).ToString("#,##0");
        txtRequisition.Text = Convert.ToDouble(dtable.Rows[0]["RequisitionToDate"]).ToString("#,##0");
        lblCostCenterForBudget.Text = dtable.Rows[0]["CostCenterName"].ToString();
        lblAreaID.Text = dtable.Rows[0]["AreaID"].ToString();
        AlignTextBoxDataCenter();
        LoadPDItems();
        MultiView2.ActiveViewIndex = 0;
        MultiView1.ActiveViewIndex = 0;
        
    }

    private void LoadWareHouses()
    {
        dtable = Process.GetWareHouses(Session["AreaCode"].ToString());
        cboWareHouses.DataSource = dtable;
        cboWareHouses.DataValueField = "WareHouseID";
        cboWareHouses.DataTextField = "WareHouse";
        cboWareHouses.DataBind();
    }

    private void LoadPDItems()
    {
        string PD_Code = lblPDCode.Text.Trim();
        dtable = Process.GetGroupPD_CodeItems(PD_Code);
        dtUpdate = dtable;
        
        Session["dtRequisition"] = dtUpdate;
        DataGrid2.DataSource = dtable;
        DataGrid2.DataBind();
        if (dtable.Rows.Count > 0)
        {
            string Total = GetTotal(dtable);
            lblTotal.Visible = true;
            lblTotal.Text = "GRAND TOTAL AMOUNT : " + Total;
        }
        else
        {
            lblTotal.Visible = false;
            lblTotal.Text = ".";
        }
        ClearItemControls();
    }

    private string GetTotal(DataTable dt)
    {
        double total = 0;
        string Returnamount = "";
        foreach (DataRow dr in dt.Rows)
        {
            double amount = Convert.ToDouble(dr["TotalCost"]);
            total += amount;
        }
        Returnamount = total.ToString("#,##0");
        return Returnamount;
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
    
    public bool DisplayStockName()
    {
        if (ProcessOther.IsUserInInventory())
            return true;
        else
            return false;
    }

    private void LoadDetails(string PlanCode)
    {
        dtable = Process.GetItemDetails(PlanCode);
        lblGroupRequisition.Text = dtable.Rows[0]["Description"].ToString();
        lblAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");
        lblPlanAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");
        
        lblInitail.Text = dtable.Rows[0]["Intial"].ToString();
        lblDesc.Text = dtable.Rows[0]["RequisitionInitial"].ToString();
        lblYear.Text = dtable.Rows[0]["FinancialYear"].ToString();
        lblTypeID.Text = dtable.Rows[0]["ProcurementTypeID"].ToString();
        IsGroup = Convert.ToBoolean(dtable.Rows[0]["IsGroupItem"]);
        txtDateRequired.Text = dtable.Rows[0]["DateNeeded"].ToString();
        if (ProcessOther.IsUserInInventory())
        {
            lblStockItem.Visible = true;
            ChkStockItem.Visible = true;
            lblStockName.Visible = true;
            txtStockName.Visible = true;
        }
        else
        {
            lblStockItem.Visible = false;
            ChkStockItem.Visible = false;
            lblStockName.Visible = false;
            txtStockName.Visible = false;
        }

    }

    private void LoadLocations()
    {
        dtable = Process.GetLocations();
        cboLocation.DataSource = dtable;
        cboLocation.DataValueField = "LocationID";
        cboLocation.DataTextField = "Location";
        cboLocation.DataBind();
    }

    protected void cboLocation_DataBound(object sender, EventArgs e)
    {
        cboLocation.Items.Insert(0, new ListItem("-- Select Delivery Location --", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            ValidateRequisition();
            SubmitRequisition();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void ValidateRequisition()
    {
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Items To Requisition");
        }
        else
        {
            string EntityCode = lblEntity.Text.Trim(); string Subject = txtSubject.Text.Trim();
            string LocationCode = cboLocation.SelectedValue.ToString(); string DateRequired = txtDateRequired.Text.Trim();
            string ReqTypeCode = CboRequisition.SelectedValue.ToString();
            string PD_Code = lblPDCode.Text.Trim(); string Plancode = lblPlanCode.Text.Trim();
            string ItemCode = lblItemID.Text.Trim(); string RecordCode = lblRecordCode.Text.Trim();
            string Quantity = txtRequired.Text.Trim(); string CurReqCost = lblPlanAmount.Text.Trim().Replace(",", "");
            string AmountBalance = lblAmount.Text.Trim().Replace(",", ""); string ProcType = lblTypeID.Text.Trim();
            string CurPalBalance = lblCurrentPlanAmount.Text.Trim().Replace(",", "");
            string WareHouseCode = cboWareHouses.SelectedValue.ToString();
            string PlanBalance = Convert.ToString(Convert.ToDouble(CurReqCost) + Convert.ToDouble(CurPalBalance));
            if (ReqTypeCode == "0")
            {
                ShowMessage("Please Select Type of Requisition");
            }
            else if (LocationCode == "0")
            {
                ShowMessage("Please Select Location of Delievery");
            }
            else if (Subject == "")
            {
                ShowMessage("Please Enter Subject of Procurement");
                txtSubject.Focus();
            }
            else if (WareHouseCode == "0")
            {
                ShowMessage("Please Select WareHouse");
                cboWareHouses.Focus();
            }
            else if (DateRequired == "")
            {
                ShowMessage("Please Enter Date When Item(s) is required");
                txtDateRequired.Focus();
            }
            else if (ChkStockItem.Checked == true && txtStockName.Text.Trim() == "")
            {
                ShowMessage("Please Enter Stock Name / Category");
            }
            else if (Plancode == "0")
            {
                ShowMessage("Sorry, this Could be Process. Contract System Admin for help");
            }
            else
            {
                Session["dtRequisition"] = dtUpdate;
                DataTable dtRequisition = (DataTable)Session["dtRequisition"];
                Process.UpdateGroupRequisition(RecordCode, PD_Code, ItemCode, EntityCode, Subject,
                        LocationCode, ReqTypeCode, DateRequired, ProcType, WareHouseCode,false,false);
                Process.UpdateGroupRequisitionItems(lblPDCode.Text, Plancode, PlanBalance, dtRequisition);

                Process.ManagerAction(PD_Code, "21", "","", "","","",WareHouseCode, "", "","","","","","","","","","","");
            }
        }
    }

    private string GetSelectedStatus()
    {
        string status = "0";
        foreach (ListItem lst in rbnApproval.Items)
        {
            if (lst.Selected == true)
            {
                status = lst.Value;
            }
        }

        return status;
    }
    private void SubmitRequisition()
    {
        try
        {
            string selectedstatus = GetSelectedStatus();
            if (selectedstatus == "0")
            {
                ShowMessage("Please Select The Approval Option ...");
            }
            else if (selectedstatus != "1" && txtComment.Text.Trim() == "")
            {
                ShowMessage("Please Enter A Rejection Comment ...");
            }
            else if (Session["AccessLevelID"].ToString() == "1")
            {
                ShowMessage("Administrative Account cannot approve any requisition in the system");
            }
            else
            {
                string PDCode = lblPDCode.Text.Trim();
                string remark = txtComment.Text.Trim();
                string CostCenterName = lblCostCenterForBudget.Text.Trim();
                string AreaCode = lblAreaID.Text.Trim();
                string amount = txtTotalCost.Text;
                string returned = Process.ManagerAction(PDCode, "1", remark, "", "", CostCenterName, AreaCode, amount, 
                    "", "", "", "", "", "", "", "", "", "", "", "");
                ShowMessage(returned);
                MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void AlignTextBoxDataCenter()
    {
        txtBudgetCode.Style["text-align"] = "center";
        //txtCostCenter.Style["text-align"] = "center";
        txtAmountApproved.Style["text-align"] = "center";
        txtExpenditure.Style["text-align"] = "center";
        txtRequisition.Style["text-align"] = "center";
        txtBalanceOnBudet.Style["text-align"] = "center";
    }

    private void ActionToTake()
    {
        string PD_Code = lblPDCode.Text.Trim();

        ClearMajorControls();
    }


    private void ClearMajorControls()
    {
        txtDateRequired.Text = "";
        txtSubject.Text = "";
        lblPDCode.Text = "0";
        lblPlanCode.Text = "0";
        lblItemID.Text = "0";
        lblInitail.Text = "0";
        lblAmount.Text = "0";
        cboLocation.SelectedIndex = cboLocation.Items.IndexOf(cboLocation.Items.FindByValue("0"));
        CboRequisition.SelectedIndex = CboRequisition.Items.IndexOf(CboRequisition.Items.FindByValue("0"));
    }
    private void ClearControls()
    {
    //    txtDescription.Text = "";
    }

    private void ClearItemControls()
    {
        txtUnitCost1.Text = "";
        txtDescription.Text = "";
        txtRequired.Text = "";
        txtTotalCost.Text = "";
        lblRecordID.Text = "0";
        lblPrevTotalCost.Text = "0";
        lblItemIndex.Text = "0";
        btnAddItem.Text = "Add Item";
        lblAddEditItemHeader.Text = "ADD NEW REQUISITION ITEM";

        double Amount = Convert.ToDouble(lblCurrentPlanAmount.Text.Trim().Replace(",",""));

        if (Amount <= 0)
        {
            txtDescription.Enabled = false;
            txtRequired.Enabled = false;
            txtUnitCost1.Enabled = false;
            txtTotalCost.Enabled = false;
            btnAddItem.Enabled = false;
        }
        else
        {
            txtDescription.Enabled = true;
            txtRequired.Enabled = true;
            txtUnitCost1.Enabled = true;
            txtTotalCost.Enabled = false;
            btnAddItem.Enabled = true;
        }
    }

    private void EnableItemControls()
    {
        txtDescription.Enabled = true;
        txtRequired.Enabled = true;
        txtUnitCost1.Enabled = true;
        txtTotalCost.Enabled = false;
        btnAddItem.Enabled = true;
    }

    protected void txtRequired_TextChanged(object sender, EventArgs e)
    {
        // Get Total Cost
        if (txtRequired.Text.Trim() != "" && txtUnitCost1.Text.Trim() != "")
        {
            string UnitCost = txtUnitCost1.Text.Trim();
            double Cost = Convert.ToDouble(UnitCost.Replace(",", ""));
            int Qty = Convert.ToInt32(txtRequired.Text.Trim());
            double ReqAmount = Qty * Cost;
            double BalAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
            if (ReqAmount > BalAmount && btnAddItem.Text != "Edit Item")
            {
                lblWarning.Text = ReqAmount + " is greater than" + BalAmount;
                lblWarning.Visible = true;
            }
            else if (btnAddItem.Text == "Edit Item")
            {
                BalAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", "")) + Convert.ToDouble(lblPrevTotalCost.Text.Trim().Replace(",", ""));
                if (ReqAmount > BalAmount)
                    ShowMessage2(" Your Total Cost (" + ReqAmount + ") was greater than (" + BalAmount + ") balance on the Plan Item");
                else
                {
                    txtTotalCost.Text = ReqAmount.ToString("#,##0");
                    lblWarning.Visible = false;
                }
            }
            else
            {
                lblWarning.Visible = false;
                txtTotalCost.Text = ReqAmount.ToString("#,##0");
            }
        }
   }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }

    private void LoadItemControls(long RecordID, int ItemIndex)
    {
        dtable = Process.GetGroupPDItem(RecordID);
        txtDescription.Text = dtable.Rows[0]["Description"].ToString();
        txtRequired.Text = dtable.Rows[0]["Quantity"].ToString();
        double Amount = Convert.ToDouble(dtable.Rows[0]["TotalCost"].ToString());
        double UnitCost = Convert.ToDouble(dtable.Rows[0]["UnitCost"].ToString());
        bool IsStock = Convert.ToBoolean(dtable.Rows[0]["IsStockItem"]);
        txtTotalCost.Text = Amount.ToString("#,##0");
        txtUnitCost1.Text = UnitCost.ToString("#,##0");
        ChkStockItem.Checked = IsStock;
        btnAddItem.Text = "Update Item";
        lblAddEditItemHeader.Text = "UPDATE REQUISITION ITEM";
        lblPrevTotalCost.Text = Amount.ToString("#,##0");
        lblRecordID.Text = dtable.Rows[0]["Item Code"].ToString();
        lblItemIndex.Text = ItemIndex.ToString();
        txtStockName.Text = dtable.Rows[0]["StockName"].ToString();
        EnableItemControls();
    }

    private void ToggleAddViewItems(bool DisplayAddItem)
    {
        if (DisplayAddItem)
        {
            MultiView2.ActiveViewIndex = 1;
            Button1.Visible = false;
            btnCancel.Visible = false;
        }
        else
        {
            MultiView2.ActiveViewIndex = 0;
            Button1.Visible = true;
            btnCancel.Visible = true;
        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            long RecordID = Convert.ToInt64(e.Item.Cells[0].Text);
            if (e.CommandName == "btnEdit")
            {
                ToggleAddViewItems(true);
                LoadItemControls(RecordID, e.Item.ItemIndex);
            }
            if (e.CommandName == "btnRemove")
            {
                if (DataGrid2.Items.Count == 1)
                    ShowMessage2("Cannot Remove All The Items From The Requisition...");
                else
                {
                    int ItemRowIndex = e.Item.DataSetIndex;
                    double ItemTotalCost = Convert.ToDouble(e.Item.Cells[5].Text.Replace(",", ""));
                    double RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
                    RemAmount = RemAmount + ItemTotalCost;
                    dtUpdate.Rows.RemoveAt(ItemRowIndex);
                    lblAmount.Text = RemAmount.ToString("#,##0");
                    Process.RemoveRequisitionItem(RecordID, true);
                    Session["dtRequisition"] = dtUpdate;
                    DataGrid2.DataSource = dtUpdate.DefaultView;
                    DataGrid2.DataBind();
                    ShowMessage2("Requisition Item Has Been Successfully Removed");
                }
            }
            else if (e.CommandName == "btnAdd")
            {
                MultiView1.ActiveViewIndex = 0;
                ClearControls();
                txtDescription.Focus();
                string SelectedLocation = lblLoc.Text.Trim();
                cboLocation.SelectedIndex = cboLocation.Items.IndexOf(cboLocation.Items.FindByValue(SelectedLocation));
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ShowMessage2(string Message)
    {
        if (Message == ".")
            lblItemError.Text = ".";
        else
            lblItemError.Text = "MESSAGE: " + Message;
    }

    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        ShowMessage2(".");
        if (String.IsNullOrEmpty(txtDescription.Text.Trim()))
            ShowMessage2("Please Enter Item Description");
        else if (String.IsNullOrEmpty(txtRequired.Text.Trim()))
            ShowMessage2("Please Enter Required Quantity");
        else if (String.IsNullOrEmpty(txtUnitCost1.Text.Trim()))
            ShowMessage2("Please Enter The Unit Cost");
        else if (String.IsNullOrEmpty(txtStockName.Text.Trim()) && ChkStockItem.Checked == true)
            ShowMessage2("Please Enter the Stock Name");
        else
        {
            string ItemDesc = txtDescription.Text.Trim();
            string StockName = txtStockName.Text.Trim();
            int Quantity = int.Parse(txtRequired.Text.Trim());
            double UnitCost = Convert.ToDouble(txtUnitCost1.Text.Trim());
            double TotalCost = UnitCost * Quantity;
            double RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
            bool IsStock = ChkStockItem.Checked; string StockCode = ""; int StockBalance = 0;
            if (!String.IsNullOrEmpty(StockName) && ChkStockItem.Checked == true)
            {
                IsStock = true;
                string CompanyCode = Session["ScalaCode"].ToString();
                dtable = ProcessOther.GetStockCodeByName(StockName, CompanyCode);
                if (dtable.Rows.Count == 0)
                    throw new Exception("Item Was Not Updated. Please Enter Stock Name or Select From Drop Down Returned After Typing More Than Two Letters");
                else
                    StockCode = dtable.Rows[0]["StockCode"].ToString();
                string WareHouseNo = "0" + cboWareHouses.SelectedValue;
                dtable = Process.GetStockBalances(StockCode, CompanyCode, WareHouseNo);
                if (dtable.Rows.Count > 0)
                    StockBalance = Convert.ToInt32(Convert.ToDouble(dtable.Rows[0]["StockBalance"].ToString()));
                else
                    StockBalance = 0;
            }

            dtUpdate = (DataTable)Session["dtRequisition"];
            if (btnAddItem.Text != "Update Item")
            {
                if (TotalCost <= RemAmount)
                {
                    double NewRemAmount = RemAmount - TotalCost;
                    dtUpdate.Rows.Add(new object[] { 0, ItemDesc, IsStock, StockCode, StockName, StockBalance, Quantity, UnitCost, TotalCost });
                    lblAmount.Text = NewRemAmount.ToString("#,##0");
                    ClearItemControls();
                }
                else
                {
                    ShowMessage2("Item Was Not Updated. Your Total Cost (" + TotalCost + ") was greater than (" + RemAmount + ") balance on the Plan Item");
                }
            }
            else
            {
                RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", "")) + Convert.ToDouble(lblPrevTotalCost.Text.Trim().Replace(",", ""));
                if (TotalCost <= RemAmount)
                {
                    double NewRemAmount = RemAmount - TotalCost;
                    long RecordID = Convert.ToInt64(lblRecordID.Text.Trim());
                    dtUpdate.Rows.RemoveAt(Convert.ToInt32(lblItemIndex.Text.Trim()));
                    dtUpdate.Rows.Add(new object[] { RecordID, ItemDesc, IsStock, StockCode, StockName, StockBalance, Quantity, UnitCost, TotalCost });
                    lblAmount.Text = NewRemAmount.ToString("#,##0");
                    ClearItemControls();
                }
                else
                {
                    ShowMessage2("Item Was Not Updated. Your Total Cost (" + TotalCost + ") was greater than (" + RemAmount + ") balance on the Plan Item");
                }
            }
            Session["dtRequisition"] = dtUpdate;
            DataGrid2.DataSource = dtUpdate.DefaultView;
            DataGrid2.DataBind();
            ClearItemControls();
            ToggleAddViewItems(false);
        }

    }

    protected void txtUnitCost1_TextChanged(object sender, EventArgs e)
    {
        if (txtRequired.Text.Trim() != "" && txtUnitCost1.Text.Trim() != "")
        {
            string UnitCost = txtUnitCost1.Text.Trim();
            double Cost = Convert.ToDouble(UnitCost.Replace(",", ""));
            int Qty = Convert.ToInt32(txtRequired.Text.Trim());
            double ReqAmount = Qty * Cost;
            double BalAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
            if (ReqAmount > BalAmount && btnAddItem.Text != "Edit Item")
            {
                ShowMessage2("Your Total Cost (" + ReqAmount + ") was greater than (" + BalAmount + ") balance on the Plan Item");
            }
            else if (btnAddItem.Text == "Update Item")
            {
                BalAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", "")) + Convert.ToDouble(lblPrevTotalCost.Text.Trim().Replace(",",""));
                if (ReqAmount > BalAmount)
                    ShowMessage2("Your Total Cost (" + ReqAmount + ") was greater than (" + BalAmount + ") balance on the Plan Item");
                else
                {
                    txtTotalCost.Text = ReqAmount.ToString("#,##0");
                    lblWarning.Visible = false;
                }
            }
            else
            {
                txtTotalCost.Text = ReqAmount.ToString("#,##0");
                lblWarning.Visible = false;
            }
        }
    }

    protected void lblAmount_DataBinding(object sender, EventArgs e)
    {
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Requisition_InventoryViewItems.aspx?transferStatus=1", true);
    }

    protected void cboWareHouses_DataBound(object sender, EventArgs e)
    {
        cboWareHouses.Items.Insert(0, new ListItem(" -- Select Ware House --", "0"));
    }
}
