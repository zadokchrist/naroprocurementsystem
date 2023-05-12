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
    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        btnAddItem.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnAddItem, "").ToString());
        Button1.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(Button1, "").ToString());
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DisableBtnsOnClick();
            if (IsPostBack == false)
            {
                CreateRequisitionDataTable();
                Toggle(false, ".");
                ACEStockName.ContextKey = Session["ScalaCode"].ToString();

                if (Session["CostCenterID"].ToString().Equals("53") || Session["CostCenterID"].ToString().Equals("113"))
                {

                    chkIsProject.Visible = true;

                }
                else
                {

                    chkIsProject.Visible = false;

                } 
                if (Request.QueryString["transferid"] != null)
                {
                    string RecordCode = Request.QueryString["transferid"].ToString();
                    lblRecordCode.Text = RecordCode;
                    string RecordID = lblRecordCode.Text.Trim();
                    LoadControls(RecordID);
                }
                else
                {
                    Response.Redirect("Requisition_ViewItems.aspx", true);
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
        LoadLocations(); LoadWareHouses(); LoadItemsUnits();
        dtable = Process.GetRequisitions(RecordID, "0", "", "", Status);
        lblEntity.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtSubject.Text = dtable.Rows[0]["Subject"].ToString();
        string Type = dtable.Rows[0]["TypeID"].ToString();
        CboRequisition.SelectedIndex = CboRequisition.Items.IndexOf(CboRequisition.Items.FindByValue(Type));
        string LocationID = dtable.Rows[0]["LocationID"].ToString();
        cboLocation.SelectedIndex = cboLocation.Items.IndexOf(cboLocation.Items.FindByValue(LocationID));
        string WareHouseID = dtable.Rows[0]["WareHouse"].ToString();
        cboWareHouse.SelectedIndex = cboWareHouse.Items.IndexOf(cboWareHouse.Items.FindByValue(WareHouseID));
        txtDateRequired.Text = dtable.Rows[0]["DateRequired"].ToString();
        lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
        lblPlanAmount.Text = Convert.ToDouble(dtable.Rows[0]["InitialPlanAmount"]).ToString("#,##0");
        lblPlanCode.Text = dtable.Rows[0]["PlanCode"].ToString();
        lblCurrentPlanAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");
        lblAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");
        chkIsFramework.Checked = Convert.ToBoolean(dtable.Rows[0]["IsFrameWork"].ToString());
        chkIsProject.Checked = Convert.ToBoolean(dtable.Rows[0]["IsProject"].ToString());
        if (chkIsProject.Checked == true)
        {
            lblContractAmount.Visible = true;
            txtContractAmount.Visible = true;
        }
        LoadPDItems();

        MultiView2.ActiveViewIndex = 0;
        
    }

    private void LoadPDItems()
    {
        string PD_Code = lblPDCode.Text.Trim();
        dtable = Process.GetGroupPD_CodeItems(PD_Code);
        dtUpdate = dtable;
        
        Session["dtRequisition"] = dtUpdate;
        if (chkIsProject.Checked == true)
        {
            DataGrid2.Columns[7].HeaderText = "Contract Amount";
        }
        else
        {

            DataGrid2.Columns[7].HeaderText = "Market Price";

        }

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
        LoadWareHouses();
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

    private void LoadWareHouses()
    {
        dtable = Process.GetWareHouses(Session["AreaCode"].ToString());

        cboWareHouse.DataSource = dtable;
        cboWareHouse.DataValueField = "WareHouseID";
        cboWareHouse.DataTextField = "WareHouse";
        cboWareHouse.DataBind();
    }

    private void LoadItemsUnits()
    {
        dtable = ProcessOther.GetItemUnits();
        cboUnits.DataSource = dtable;
        cboUnits.DataValueField = "UnitCode";
        cboUnits.DataTextField = "Unit";
        cboUnits.DataBind();
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
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private bool IsFrameWorkContract()
    {
        bool IsFrameWork = false;
        if (chkIsFramework.Checked == true)
            IsFrameWork = true;

        return IsFrameWork;
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
            string WareHouseCode = cboWareHouse.SelectedValue.ToString();
            string PD_Code = lblPDCode.Text.Trim(); string Plancode = lblPlanCode.Text.Trim();
            string ItemCode = lblItemID.Text.Trim(); string RecordCode = lblRecordCode.Text.Trim();
            string Quantity = txtRequired.Text.Trim(); string CurReqCost = lblPlanAmount.Text.Trim().Replace(",", "");
            string AmountBalance = lblAmount.Text.Trim().Replace(",", ""); string ProcType = lblTypeID.Text.Trim();
            string CurPalBalance = lblCurrentPlanAmount.Text.Trim().Replace(",", "");
            string PlanBalance = Convert.ToString(Convert.ToDouble(CurReqCost) + Convert.ToDouble(CurPalBalance));
            //string MarketPrice = txtMarketprice.Text.Trim().Replace(",", ""); ;

            bool IsFrameWork = IsFrameWorkContract();
            bool IsProject = chkIsProject.Checked;

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
            else if (DateRequired == "")
            {
                ShowMessage("Please Enter Date When Item(s) Is Required");
                txtDateRequired.Focus();
            }
            else if (cboWareHouse.SelectedValue.ToString() == "0")
            {
                ShowMessage("Please Select Ware House");
                cboWareHouse.Focus();
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
                        LocationCode, ReqTypeCode, DateRequired, ProcType, WareHouseCode, IsFrameWork, IsProject);
                Process.UpdateGroupRequisitionItems(lblPDCode.Text, Plancode, PlanBalance, dtRequisition);
                lblSuccess.Text = "Requisition Items Have Been Updated Successfully";
                ShowMessage("Requisition Items Have Been Updated Successfully");
                MultiView1.ActiveViewIndex = 1;
            }
        }

    }
    //private void ActionToTake()
    //{
    //    string PlanCode = lblPlanCode.Text.Trim();
    //    string PD_Code = lblPDCode.Text.Trim();

    //    Process.LogandCommitRequisition(PD_Code, 11, "Updated Group Requisition");
    //    //TODO: Notify Manager
    //    AlertManager();
    //    ClearMajorControls();

    //    Response.Redirect("Requisition_Items.aspx", true);
    //}
    //private void AlertManager()
    //{
    //    if (CboRequisition.SelectedValue == "2")
    //    {
    //        IsEmergency = true;
    //    }
    //    string EmmergencyStatus = "(Normal)";
    //    if (IsEmergency)
    //        EmmergencyStatus = " (Emmergency)";
    //    string Message = "You have been sent a Requisition for approval. " + EmmergencyStatus + Environment.NewLine + Environment.NewLine;
    //    Message += "Please access the link: http://192.168.8.110:4070/procurement/  to Login. ";
    //    int ManagerID = Convert.ToInt32(cboAreaManagers.SelectedValue.ToString());
    //    ProcessOther.NotifyManager(ManagerID, Message);
    //}
    private void Toggle(bool Check, string returned)
    {
        lblSuccess.Visible = Check;
        if (Check)
        {
            MultiView1.ActiveViewIndex = 1;
            lblSuccess.Text = returned;
        }
        else
        {
            MultiView1.ActiveViewIndex = 0;
            lblSuccess.Text = ".";
        }
    }
    private void ClearMajorControls()
    {
        txtDateRequired.Text = "";
        txtSubject.Text = "";
        lblPDCode.Text = "0";
        lblPlanCode.Text = "0";
        //lblPlanTitle.Text = "0";
        lblItemID.Text = "0";
        lblInitail.Text = "0";
        lblAmount.Text = "0";
        //lblPlanTitle.Visible = false;
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
            cboUnits.Enabled = false;
            txtTotalCost.Enabled = false;
            btnAddItem.Enabled = false;
        }
        else
        {
            txtDescription.Enabled = true;
            txtRequired.Enabled = true;
            cboUnits.Enabled = true;
            txtUnitCost1.Enabled = true;
            txtTotalCost.Enabled = false;
            btnAddItem.Enabled = true;
        }
    }

    private void EnableItemControls()
    {
        txtDescription.Enabled = true;
        txtRequired.Enabled = true;
        cboUnits.Enabled = true;
        txtUnitCost1.Enabled = true;
        txtTotalCost.Enabled = false;
        btnAddItem.Enabled = true;
        
    }

    //private void UploadFiles(string PlanCode)
    //{
    //    HttpFileCollection uploads;
    //    uploads = HttpContext.Current.Request.Files;
    //    int countfiles = 0;
    //    for (int i = 0; i <= (uploads.Count - 1); i++)
    //    {
    //        if (uploads[i].ContentLength > 0)
    //        {
    //            string c = System.IO.Path.GetFileName(uploads[i].FileName);
    //            string cNoSpace = c.Replace(" ", "-");
    //            string c1 = PlanCode + "_" + (countfiles + i + 1) + "_" + cNoSpace;
    //            string Path = Process.GetDocPath();
    //            FileField.PostedFile.SaveAs(Path + "" + c1);
    //           ProcessOther.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false,Session["FullName"].ToString());

    //        }
    //    }
    //}
    protected void txtRequired_TextChanged(object sender, EventArgs e)
    {
        // Get Total Cost
        if (txtRequired.Text.Trim() != "" && txtUnitCost1.Text.Trim() != "")
        {
            string UnitCost = txtUnitCost1.Text.Trim();
            double Cost = Convert.ToDouble(UnitCost.Replace(",", ""));
            int Qty = Convert.ToInt32(txtRequired.Text.Trim()) - Convert.ToInt32(lblOldQuantity.Text);
            double ReqAmount = Qty * Cost;
            double totalcost = Convert.ToInt32(txtTotalCost.Text);
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
                txtTotalCost.Text = (ReqAmount + totalcost).ToString("#,##0");
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
        lblOldQuantity.Text = dtable.Rows[0]["Quantity"].ToString();
        double Amount = Convert.ToDouble(dtable.Rows[0]["TotalCost"].ToString());
        double UnitCost = Convert.ToDouble(dtable.Rows[0]["UnitCost"].ToString());
        bool IsStock = Convert.ToBoolean(dtable.Rows[0]["IsStockItem"]);
        cboUnits.SelectedValue = dtable.Rows[0]["UnitCodeID"].ToString();
        txtTotalCost.Text = Amount.ToString("#,##0");
        txtUnitCost1.Text = UnitCost.ToString("#,##0");
        ChkStockItem.Checked = IsStock;
        btnAddItem.Text = "Update Item";
        lblAddEditItemHeader.Text = "UPDATE REQUISITION ITEM";
        lblPrevTotalCost.Text = Amount.ToString("#,##0");
        lblRecordID.Text = dtable.Rows[0]["Item Code"].ToString();
        lblItemIndex.Text = ItemIndex.ToString();
        txtStockName.Text = dtable.Rows[0]["StockCode"].ToString() + " --- " + dtable.Rows[0]["StockName"].ToString();
        double ContractAmount = Convert.ToDouble(dtable.Rows[0]["MarketPrice"].ToString());
        txtContractAmount.Text = ContractAmount.ToString("#,##0");
        if (IsStock)
        {
            lblStockItem.Visible = true; lblStockName.Visible = true;
            ChkStockItem.Visible = true; txtStockName.Visible = true; txtStockName.Enabled = true;
        }
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
                    ShowMessage2("Cannot remove all the items from the requisition...");
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
                    ShowMessage2("Requisition Item has been successfully removed");
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
        try
        {
            if (String.IsNullOrEmpty(txtDescription.Text.Trim()))
                ShowMessage2("Please Enter Item Description");
            else if (String.IsNullOrEmpty(txtRequired.Text.Trim()))
                ShowMessage2("Please enter required quantity");
            else if (String.IsNullOrEmpty(txtUnitCost1.Text.Trim()))
                ShowMessage2("Please enter the unit cost");
            else if (cboUnits.SelectedValue == "0")
                ShowMessage2("Please Select Units");
            else if (String.IsNullOrEmpty(txtStockName.Text.Trim()) && ChkStockItem.Checked == true)
                ShowMessage2("Please Enter the Stock Code");
            else if (String.IsNullOrEmpty(txtContractAmount.Text.Trim()) && chkIsProject.Checked == true)
                ShowMessage2("Please Enter the Contract Amount");
            else
            {
                string ItemDesc = txtDescription.Text.Trim();
                string StockName = txtStockName.Text.Trim();
                int Quantity = int.Parse(txtRequired.Text.Trim());
                double UnitCost = Convert.ToDouble(txtUnitCost1.Text.Trim());
                double TotalCost = UnitCost * Quantity;
                double RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
                bool IsStock = ChkStockItem.Checked; string StockCode = "";
                int UnitCode = Convert.ToInt32(cboUnits.SelectedValue);
                string Units = cboUnits.SelectedItem.Text; int StockBalance = 0;

                double ContractAmount = Convert.ToDouble(txtContractAmount.Text.Trim());

                if (ChkStockItem.Checked && !String.IsNullOrEmpty(StockName))
                {
                    if (txtStockName.Text.Contains("---"))
                    {
                        int dashPosition = txtStockName.Text.Trim().IndexOf(" --- ");
                        StockCode = txtStockName.Text.Trim().Substring(0, dashPosition).Trim();
                    } 
                    else
                        StockCode = txtStockName.Text.Trim();

                    string CompanyCode = HttpContext.Current.Session["ScalaCode"].ToString();
                    dtable = ProcessOther.GetStockItemsByCode(StockCode, CompanyCode);
                    if (dtable.Rows.Count == 0)
                        throw new Exception("Item Not Updated. Please Enter Correct Stock Code OR Select From Drop-down Returned After Typing More Than Two Numbers");
                    else
                        StockName = dtable.Rows[0]["ACTUALSTOCKNAME"].ToString();
                    string WareHouseNo = "0" + cboWareHouse.SelectedValue;
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
                        dtUpdate.Rows.Add(new object[] { 0, ItemDesc, IsStock, StockCode, StockName, StockBalance, Quantity, UnitCode, Units, UnitCost, TotalCost });
                        lblAmount.Text = NewRemAmount.ToString("#,##0");
                        ClearItemControls();
                    }
                    else
                    {
                        ShowMessage2("Item not updated. Your Total Cost (" + TotalCost + ") was greater than (" + RemAmount + ") balance on the Plan Item");
                    }
                }
                else
                {
                    RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", "")) + Convert.ToDouble(lblPrevTotalCost.Text.Trim().Replace(",", ""));
                    if (TotalCost <= RemAmount)
                    {
                        double NewRemAmount = RemAmount - TotalCost;
                        long RecordID = Convert.ToInt64(lblRecordID.Text.Trim());
                        int i = 0;
                        foreach (DataRow dr in dtUpdate.Rows)
                        {
                            if (Convert.ToInt64(dr["RecordID"]) == RecordID)
                            {
                                dtUpdate.Rows.RemoveAt(i);
                                break;
                            }
                            i++;
                        }
                        dtUpdate.Rows.Add(new object[] { RecordID, ItemDesc, IsStock, StockCode, StockName, StockBalance, Quantity, UnitCode, Units, UnitCost, TotalCost, ContractAmount });
                        lblAmount.Text = NewRemAmount.ToString("#,##0");
                        ClearItemControls();
                    }
                    else
                    {
                        ShowMessage2("Item not updated. Your Total Cost (" + TotalCost + ") was greater than (" + RemAmount + ") balance on the Plan Item");
                    }
                }
                Session["dtRequisition"] = dtUpdate;
                if (chkIsProject.Checked == true)
                {
                    DataGrid2.Columns[7].HeaderText = "Contract Amount";
                }
                else
                {

                    DataGrid2.Columns[7].HeaderText = "Market Price";

                }
                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind();
                ClearItemControls();
                ToggleAddViewItems(false);
            }
        }
        catch (Exception ex)
        {
            ShowMessage2(ex.Message);
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
        Response.Redirect("Requisition_ViewItems.aspx?transferStatus=1", true);
    }
    protected void cboWareHouse_DataBound(object sender, EventArgs e)
    {
        cboWareHouse.Items.Insert(0, new ListItem("-- Select Ware House --", "0"));
    }

    protected void btnReturnItems_Click(object sender, EventArgs e)
    {
        Response.Redirect("Requisition_ViewItems.aspx?transferStatus=1", true);
    }
    protected void cboUnits_DataBound(object sender, EventArgs e)
    {
        cboUnits.Items.Insert(0, new ListItem("- - Select Item Unit - -", "0"));
    }
    protected void ChkStockItem_CheckedChanged(object sender, EventArgs e)
    {
        ACEStockName.ContextKey = Session["ScalaCode"].ToString();
        if (ChkStockItem.Checked)
            txtStockName.Enabled = true;
        else
            txtStockName.Enabled = false;
    }
    protected void chkIsProject_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsProject.Checked == true)
        {
            lblContractAmount.Visible = true;
            txtContractAmount.Visible = true;
            chkIsFramework.Checked = false;
        }
        else
        {
            

        }
    }
    protected void chkIsFramework_CheckedChanged(object sender, EventArgs e)
    {

        if (chkIsFramework.Checked == true)
        {

            chkIsProject.Checked = false;
        }
    }
}
