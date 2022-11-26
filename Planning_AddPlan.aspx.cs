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

public partial class Planning_AddPlan : System.Web.UI.Page
{
    ProcessPlanning Process = new ProcessPlanning();
    DataLogin dll = new DataLogin();
    BusinessPlanning bll = new BusinessPlanning();
    DataTable dtable = new DataTable();
    DataTable dataTable = new DataTable();
    DataSet dataSet = new DataSet();
    bool IsCapital = false;
    bool Planned;
    private int ProcurementTypeCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageLoad();
            DisableBtnsOnClick();
        }
    }

    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        btnOK.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnOK, "").ToString());
        btnCancel.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnCancel, "").ToString());
        btnYes.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnYes, "").ToString());
        btnNo.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnNo, "").ToString());
    }

    private void PageLoad()
    {
        try
        {
            Planned = true;
            string CostCenterID = Session["CostCenterID"].ToString();
            if (IsPostBack == false)
            {
                DisplayStockControls();
                if (Request.QueryString["transferid"] != null)
                {
                    MultiView1.ActiveViewIndex = 0;
                    MultiView2.ActiveViewIndex = 0;
                    lblHeader.Text = "EDIT PLAN ITEM";
                    LoadProcurementTypes();
                    LoadAllControls();
                    Toggle(false, ".");
                    //MultiView3.ActiveViewIndex = 0;
                }
                else
                {
                    MultiView3.ActiveViewIndex = -1;
                    LoadNewControls();
                    if (Request.QueryString["transfertype"] != null)
                    {
                        //MultiView1.ActiveViewIndex = 0;
                        //MultiView2.ActiveViewIndex = -1;
                        MultiView1.ActiveViewIndex = 0;
                        MultiView2.ActiveViewIndex = 0;
                        LoadProcurementTypes();
                        Planned = false;
                    }
                    else
                    {
                        //MultiView1.ActiveViewIndex = 0;
                        //MultiView2.ActiveViewIndex = -1;
                        MultiView1.ActiveViewIndex = 0;
                        MultiView2.ActiveViewIndex = 0;
                        LoadProcurementTypes();
                        if (Process.IsUserInInventory() || Session["IsAreaProcess"].ToString() == "1")
                        {
                            lblStockItem.Visible = true;
                            ChkStockItem.Visible = true;
                        }
                        Planned = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }

    }

    private void DisplayStockControls()
    {
        if (Process.IsUserInInventory() || Session["IsAreaProcess"].ToString() == "1")
        {
            lblStockItem.Visible = true;
            ChkStockItem.Visible = true;
            ToggleStockItem();
        }
    }

    private void LoadNewControls()
    {
        LoadItemsUnits();
        LoadFundSources();
        LoadProcurementTypes();
        LoadNonStockItemCategoryTypes();
        LoadCurrencies();
        LoadQuarters();
        GetCostCenterDetails();
        ToggleProcurementType();
        ProcurementTypeCode = int.Parse(cboProcType.SelectedValue);
        LoadItems();
        if (ChkStockItem.Checked)
        {
            lblStockName.Visible = true;
            txtStockName.Visible = true;
            lblNonStockCatType.Visible = false;
            lblNonStockItemCat.Visible = false;
            cboNonStockCat.Visible = false;
            cboNonStockCatType.Visible = false;
        }
        //string itemSelected;
        //if (rdCapital.Checked)
        //    itemSelected = " Capital Item";
        //else
        //    itemSelected = " Operational Item";
        cboNonStockCat.Enabled = false;
        //lblBudgetName.Text = itemSelected + " Plan of Procurement Type " + cboProcType.SelectedItem + " Selected";
    }

    private void LoadAllControls()
    {
        lblPlanCode.Text = Request.QueryString["transferid"].ToString();
        string PlanCode = lblPlanCode.Text.Trim();
        LoadDocuments(PlanCode);
        LoadItemsUnits(); LoadFundSources();
        LoadCurrencies(); LoadQuarters(); GetCostCenterDetails();
        LoadNonStockItemCategoryTypes();

        dataTable = Process.GetPlanItemDetails(PlanCode);
        cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(dataTable.Rows[0]["ProcurementTypeID"].ToString()));
        string ProcType = cboProcType.SelectedValue.ToString();
        LoadItems();
        cboItemCategory.SelectedIndex = cboItemCategory.Items.IndexOf(cboItemCategory.Items.FindByText(dataTable.Rows[0]["ItemCategory"].ToString()));
        cboNonStockCatType.SelectedIndex = cboNonStockCatType.Items.IndexOf(cboNonStockCatType.Items.FindByText(dataTable.Rows[0]["CategoryType"].ToString()));
        LoadNonStockItemCategories();
        cboNonStockCat.SelectedIndex = cboNonStockCat.Items.IndexOf(cboNonStockCat.Items.FindByText(dataTable.Rows[0]["NonStockCategory"].ToString()));
        cboQuarter.SelectedIndex = cboQuarter.Items.IndexOf(cboQuarter.Items.FindByValue(dataTable.Rows[0]["QuarterID"].ToString()));
        cboUnits.SelectedIndex = cboUnits.Items.IndexOf(cboUnits.Items.FindByValue(dataTable.Rows[0]["UnitCodeID"].ToString()));
        cboFunding.SelectedIndex = cboFunding.Items.IndexOf(cboFunding.Items.FindByValue(dataTable.Rows[0]["FundingID"].ToString()));
        cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(dataTable.Rows[0]["ProcurementTypeID"].ToString()));
        ToggleProcurementType();
        //   cboPaymentMonth.SelectedIndex = cboPaymentMonth.Items.IndexOf(cboPaymentMonth.Items.FindByValue(dataTable.Rows[0]["PaymentMonth"].ToString()));
        cboPayPeriod.SelectedIndex = cboPayPeriod.Items.IndexOf(cboPayPeriod.Items.FindByValue(dataTable.Rows[0]["PayPeriod"].ToString()));
        bool IsStockItem = Convert.ToBoolean(dataTable.Rows[0]["IsStockItem"].ToString());
        if (IsStockItem)
        {
            ChkStockItem.Checked = true;
            txtStockName.Text = dataTable.Rows[0]["StockName"].ToString();
            ToggleStockItem();
        }
        txtDescription.Text = dataTable.Rows[0]["Description"].ToString();
        txtJustify.Text = dataTable.Rows[0]["Justification"].ToString();
        txtDate4PP20.Text = dataTable.Rows[0]["Date4PP20"].ToString();
        txtDateWhenNeeded.Text = dataTable.Rows[0]["DateWhenNeeded"].ToString();
        txtQuantity.Text = dataTable.Rows[0]["Quantity"].ToString();
        bool IsGroup = Convert.ToBoolean(dataTable.Rows[0]["IsGroupItem"].ToString());
        chkQuantitifiable.Checked = IsGroup;
        double Cost = Convert.ToDouble(dataTable.Rows[0]["UnitCost"].ToString());
        txtUnitCost.Text = Cost.ToString();
        //tony 08
        double Marketprice = Convert.ToDouble(dataTable.Rows[0]["MarketPrice"].ToString());
        //Convert.ToDouble(dataTable.Rows[0]["UnitCost"].ToString());
        txtMarketPrice.Text = Marketprice.ToString();

        btnOK.Enabled = true; txtDate4PP20.Enabled = true; txtDateWhenNeeded.Enabled = true;
        bool IsOperational = Convert.ToBoolean(dataTable.Rows[0]["IsOperational"].ToString());
        string CapexCode = dataTable.Rows[0]["CapexCode"].ToString();
        ValidateCapital(IsOperational, CapexCode);
        string OperationalBudgetCode = dataTable.Rows[0]["OperationalBudgetCode"].ToString();
        GetTotalCost();
        cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByText(dataTable.Rows[0]["Method"].ToString()));
    }
    private void ValidateCapital(bool IsOperational, string Code)
    {
        if (IsOperational)
        {
            rdCapital.Checked = false;
            RadioButton1.Checked = true;
        }
        else
        {
            rdCapital.Checked = true;
            RadioButton1.Checked = false;
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
    private void LoadProcurementTypes()
    {
        dtable = Process.GetProcurementTypes();
        cboProcType.DataSource = dtable;
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
    }
    private void LoadItemsUnits()
    {
        dtable = Process.GetItemUnits();
        cboUnits.DataSource = dtable;
        cboUnits.DataValueField = "UnitCode";
        cboUnits.DataTextField = "Unit";
        cboUnits.DataBind();
    }
    private void LoadItems()
    {
        string ProcType = cboProcType.SelectedValue.ToString();
        dtable = Process.GetItems(ProcType);
        cboItemCategory.DataSource = dtable;
        cboItemCategory.DataValueField = "Code";
        cboItemCategory.DataTextField = "Item";
        cboItemCategory.DataBind();

    }
    private void LoadFundSources()
    {
        dtable = Process.GetFundSources();
        cboFunding.DataSource = dtable;
        cboFunding.DataValueField = "Code";
        cboFunding.DataTextField = "Source";
        cboFunding.DataBind();
    }
    private void LoadCurrencies()
    {
        dtable = Process.GetCurrencies();
        cboCurrency.DataSource = dtable;
        cboCurrency.DataValueField = "Code";
        cboCurrency.DataTextField = "Currency";
        cboCurrency.DataBind();
        cboCurrency.SelectedIndex = cboCurrency.Items.IndexOf(cboCurrency.Items.FindByValue("5"));
        LoadExchangeRate();

    }
    private void LoadExchangeRate()
    {
        string CurrencyCode = cboCurrency.SelectedValue.ToString();
        dtable = Process.GetCurrency(CurrencyCode);
        Label1.Text = dtable.Rows[0]["Amount"].ToString();
    }
    private void GetCostCenterDetails()
    {
        string CostCenterName = Session["CostCenterName"].ToString();
        string Details = Process.GetCostCenter(CostCenterName);
    }
    private void LoadQuarters()
    {
        dtable = Process.GetPlanningQuaters();
        cboQuarter.DataSource = dtable;
        cboQuarter.DataValueField = "QuarterCode";
        cboQuarter.DataTextField = "Quarter";
        cboQuarter.DataBind();
    }

    private void LoadNonStockItemCategoryTypes()
    {
        dtable = Process.GetNonStockItemCategoryTypes();
        cboNonStockCatType.DataSource = dtable;
        cboNonStockCatType.DataValueField = "CategoryTypeCode";
        cboNonStockCatType.DataTextField = "CategoryTypeName";
        cboNonStockCatType.DataBind();
    }

    protected void rdOperational_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void rdCapital_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void cboProcType_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetTotalCost();
        LoadItems();
        ToggleProcurementType();
    }

    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - Select Procurement Type - -", "0"));
    }
    protected void cboItemCategory_DataBound(object sender, EventArgs e)
    {
        cboItemCategory.Items.Insert(0, new ListItem("- - Select Item Category - -", "0"));
    }

    protected void txtUnitCost_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GetTotalCost();
            if (txtUnitCost.Text.Trim() != "")
            {
                string UnitCost = txtUnitCost.Text.Trim().Replace(",", "");
                //double marketprice = Process.GetMarketPrice(UnitCost);

                //txtMarketPrice.Text = marketprice.ToString("#,##0");
                //txtMarketPrice.Text = txtMarketPrice.Text + Environment.NewLine + UnitCost;
                txtMarketPrice.Text = UnitCost + Environment.NewLine;
                //txtMarketPrice.Text = "";
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void GetTotalCost()
    {
        if (txtQuantity.Text.Trim() != "" && txtUnitCost.Text.Trim() != "")
        {
            double Qty = double.Parse(txtQuantity.Text.Trim().Replace(",", ""));
            string UnitCost = txtUnitCost.Text.Trim().Replace(",", "");
            double ExRate = Convert.ToDouble(Label1.Text);
            double amount = Process.GetTotalCost(Qty, UnitCost, ExRate);

            if (Request.QueryString["transfertype"] != null)
            {
                Planned = false;
            }
            else
            {
                Planned = true;
            }

            txtTotalCost.Text = amount.ToString("#,##0");
            string SelectedType = cboProcType.SelectedValue.ToString();
            LoadProcMethod(amount, SelectedType);
        }
    }
    private void GetMarketPrice()
    {
        if (txtUnitCost.Text.Trim() != "")
        {
            string UnitCost = txtUnitCost.Text.Trim().Replace(",", "");
            double marketprice = Process.GetMarketPrice(UnitCost);

            txtMarketPrice.Text = marketprice.ToString("#,##0");

        }

    }
    private void txtMarketPrice_TextChanged(object sender, EventArgs e)
    {

        try
        {
            GetMarketPrice();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadProcMethod(double amount, string ProcTypeSelected)
    {
        int ProcType = Convert.ToInt32(ProcTypeSelected);
        if (bll.isSpecificMethod(ProcType, amount))
        {
            cboProcurementMethod.Items.Clear();
            dtable = Process.GetProcurementMethods();
            cboProcurementMethod.DataSource = dtable;
            cboProcurementMethod.DataValueField = "MethodCode";
            cboProcurementMethod.DataTextField = "Method";
            cboProcurementMethod.DataBind();
            string ProcMethod = Process.GetProcurementMethod(ProcTypeSelected, amount).ToString();
            cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByValue(ProcMethod));
            cboProcurementMethod.Enabled = false;
            LoadProcLength(ProcMethod);
        }
        else
        {
            cboProcurementMethod.Items.Clear();
            cboProcurementMethod.Enabled = true;
            dtable = Process.GetProcMethodsForBig(ProcType, amount);
            cboProcurementMethod.DataSource = dtable;
            cboProcurementMethod.DataValueField = "MethodCode";
            cboProcurementMethod.DataTextField = "Method";
            cboProcurementMethod.DataBind();
            cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByValue("0"));

        }

    }
    protected void cboProcurementMethod_DataBound(object sender, EventArgs e)
    {
        cboProcurementMethod.Items.Insert(0, new ListItem("- - Select Procurement Method - -", "0"));
    }
    protected void cboProcurementMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboProcurementMethod.SelectedValue != "0")
            {
                string ProcMethod = cboProcurementMethod.SelectedValue.ToString();
                LoadProcLength(ProcMethod);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboQuarter_DataBound(object sender, EventArgs e)
    {
        cboQuarter.Items.Insert(0, new ListItem("- - Select Quarter - -", "0"));
    }
    protected void cboQuarter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboQuarter.SelectedValue != "0")
        {
            string Quarter = cboQuarter.SelectedValue.ToString();
            string Range = Process.GetQuarterRange(Quarter);
            Label3.Text = Range.ToString();
            txtDate4PP20.Enabled = true;
            txtDateWhenNeeded.Enabled = true;
        }
        else
        {
            Label3.Text = ".";
            txtDateWhenNeeded.Enabled = false;
            txtDate4PP20.Enabled = false;
        }
    }
    protected void cboFunding_DataBound(object sender, EventArgs e)
    {
        cboFunding.Items.Insert(0, new ListItem("- - Select Source of Funds - -", "0"));
    }
    protected void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadExchangeRate();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboUnits_DataBound(object sender, EventArgs e)
    {
        cboUnits.Items.Insert(0, new ListItem("- - Select Item Unit - -", "0"));
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ValidateDetails();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnNo_Click(this, e);
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["transfertype"] != null)
            Planned = false;
        else
            Planned = true;

        if (Planned)
            Response.Redirect("Planning_PendingItems.aspx", true);
        else
            Response.Redirect("Requisition_Items.aspx?transferid=1", true);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        Response.Redirect("Planning_AddPlan.aspx", true);
    }
    private void ValidateDetails()
    {
        ShowMessage(".");
        if (rdCapital.Checked != true && RadioButton1.Checked != true)
        {
            ShowMessage("Please Select Whether Capex or Operational Item");
        }
        else if (ChkStockItem.Checked == true && txtStockName.Text.Trim() == "")
        {
            ShowMessage("Please Enter Stock Name / Category");
        }
        else if (cboItemCategory.SelectedValue == "0")
        {
            ShowMessage("Please Select Item Category");
            cboItemCategory.Focus();
        }
        else if (!ChkStockItem.Checked && cboNonStockCatType.SelectedValue == "0")
        {
            ShowMessage("Please Select Non Stock Category Type");
            cboNonStockCatType.Focus();
        }
        else if (!ChkStockItem.Checked && cboNonStockCat.SelectedValue == "0")
        {
            ShowMessage("Please Select Non Stock Category");
            cboNonStockCat.Focus();
        }
        else if (txtDescription.Text == "")
        {
            ShowMessage("Please Enter Item/Service Description");
            txtDescription.Focus();
        }
        else if (cboProcurementMethod.SelectedValue == "0")
        {
            ShowMessage("Please Select Procurement Method");
        }
        else if (cboFunding.SelectedValue == "0")
        {
            ShowMessage("Please Select Source of Funding");
        }
        else if (txtQuantity.Text == "")
        {
            ShowMessage("Please Enter Quantity of Item being planned");
        }
        else if (txtUnitCost.Text == "")
        {
            ShowMessage("Please Enter Unit Cost of Item being Planned");
        }
        else if (txtMarketPrice.Text == "")
        {
            ShowMessage("Please Enter Market price of Item being Planned");
        }
        else if (cboPayPeriod.SelectedValue == "0")
        {
            ShowMessage("Please Select Planned Pay Period");
        }
        else if (cboQuarter.SelectedValue == "0")
        {
            ShowMessage("Please Select Plan Quarter");
        }
        else if (cboUnits.SelectedValue == "")
        {
            ShowMessage("Please Select Plan Item Units");
        }
        else
        {
            bool IsStock = IsStockItem();
            bool IsFrameWork = IsFrameWorkContract();
            string StockCode = ""; string StockItemName = "";
            if (IsStock == true)
            {
                string CompanyCode = Session["ScalaCode"].ToString();
                dtable = Process.GetStockCodeByName(txtStockName.Text.Trim(), CompanyCode);
                if (dtable.Rows.Count == 0)
                {
                    throw new Exception("Please enter stock name or select from drop down returned after typing more than two letters");
                }
                else
                {
                    StockCode = dtable.Rows[0]["StockCode"].ToString();
                    StockItemName = txtStockName.Text;
                }
            }
            string PlanCode = lblPlanCode.Text.Trim();
            string ProcType = cboProcType.SelectedValue.ToString();
            string ProcMethod = cboProcurementMethod.SelectedValue.ToString();
            bool IsOperational;
            bool IsGroup = IsGroupItem();
            string ItemCategory = GetItem(cboItemCategory.Text, cboItemCategory.SelectedValue.ToString());
            string FinCode = Session["PFinYearCode"].ToString();
            string FinYear = Session["PFinancialYear"].ToString();

            if (Request.QueryString["transfertype"] != null)
            {
                Planned = false;
                FinCode = Session["RFinYearCode"].ToString();
                FinYear = Session["RFinancialYear"].ToString();
            }
            else
                Planned = true;

            string BudgetCostCenterCode = Session["CostCenterID"].ToString();
            string Planner = Session["UserID"].ToString();
            string Desc = txtDescription.Text.Trim();
            string Justify = txtJustify.Text.Trim();
            string ProcLength = txtProclength.Text.Trim();
            string FundingCode = cboFunding.SelectedValue.ToString();
            dtable = dll.GetUserDetails(Session["UserCode"].ToString());
            string CostCenterCode = "";
            if (dtable.Rows.Count > 0)
                CostCenterCode = Session["CostCenterID"].ToString();
            //CostCenterCode = dtable.Rows[0]["CostCenterID"].ToString();
            if (rdCapital.Checked == true)
                IsOperational = false;
            else
                IsOperational = true;

            string Qty = txtQuantity.Text.Trim(); string UnitCode = cboUnits.SelectedValue.ToString();

            double TotalCost = Convert.ToDouble(txtTotalCost.Text.Trim().Replace(",", ""));
            double Quantity = Convert.ToDouble(txtQuantity.Text.Trim().Replace(",", ""));
            double UnitCost = TotalCost / Quantity;
            double MarketPrice = Convert.ToDouble(txtMarketPrice.Text.Trim().Replace(",", ""));

            string QuarterCode = cboQuarter.SelectedValue.ToString();
            string NonStockItemCategoryCode = cboNonStockCat.SelectedValue.ToString();
            string Date4PP20 = txtDate4PP20.Text.Trim(); string DateNeeded = txtDateWhenNeeded.Text.Trim();
            string PayPeriod = cboPayPeriod.SelectedValue.ToString();
            // string PaymentMonth = cboPaymentMonth.SelectedValue.ToString();

            if (!bll.DateWhenNeededIsValid(Convert.ToDateTime(DateNeeded.Trim()), Convert.ToDateTime(Date4PP20.Trim()), int.Parse(ProcLength)))
                throw new Exception("The Date When Needed is invalid. Please check against the Procurement Length.");
            if (!bll.IsDateInQuarter(Convert.ToDateTime(DateNeeded.Trim()), int.Parse(cboQuarter.SelectedValue.ToString())))
                throw new Exception("Please Select A Date When Needed which is within the Quarter Selected");
            // this is commented out inorder to facilitate future plans
            //if (!bll.IsDateWhenNeededWithinFinYear(Convert.ToDateTime(DateNeeded.Trim()), FinYear))
            //{
            //    throw new Exception("The Date When Needed is invalid. Please enter a date within the Financial Year ( " + FinYear + " )");
            //}
            string returned = Process.SavePlan(PlanCode, ProcType, ProcMethod, FinCode, IsOperational, IsStock, StockCode, StockItemName, "",
                "", ItemCategory, Desc, Justify, IsGroup, CostCenterCode, BudgetCostCenterCode, NonStockItemCategoryCode, FundingCode, UnitCode,
                UnitCost, Qty, QuarterCode, Date4PP20, DateNeeded, PayPeriod, "1", ProcLength, Planner, Planned, MarketPrice, IsFrameWork);
            string PlanCodeReturn = Process.PlanCodeReturn;
            if (PlanCodeReturn != "0")
                UploadFiles(PlanCodeReturn);
            else
                UploadFiles(PlanCode);

            if (returned.Contains("captured Successfully"))
            {
                Process.LogPlanItemTransaction(PlanCodeReturn, 1, "New Plan Item logged by Planner");
                if (Planned)
                    Toggle(true, returned);
                else
                    Response.Redirect("Requisition_Items.aspx?transferid=1", true);
            }
            else
            {
                Toggle(false, ".");
                if (lblPlanCode.Text != "0")
                {
                    string PreviousPage = Session["PreviousPage"].ToString();
                    string PreviousStatus = Session["Status"].ToString();
                    Response.Redirect(PreviousPage + "?transferid=1", true);
                }
                else
                {
                    ShowMessage(returned);
                }
            }
        }
    }

    private void UploadFiles(string PlanCode)
    {
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        int countfiles = 0;
        for (int i = 0; i <= (uploads.Count - 1); i++)
        {
            if (uploads[i].ContentLength > 0)
            {
                string c = System.IO.Path.GetFileName(uploads[i].FileName);
                string cNoSpace = c.Replace(" ", "-");
                string c1 = PlanCode + "_" + (countfiles + i + 1) + "_" + cNoSpace;
                string Path = Process.GetDocPath();
                FileField.PostedFile.SaveAs(Path + "" + c1);
                Process.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false);
            }
        }
    }

    private bool IsGroupItem()
    {
        bool IsGroup = false;
        if (chkQuantitifiable.Checked == true)
            IsGroup = true;
        return IsGroup;
    }

    private bool IsStockItem()
    {
        bool IsStock = false;
        if (ChkStockItem.Checked == true)
            IsStock = true;

        return IsStock;
    }

    private bool IsFrameWorkContract()
    {
        bool IsFrameWork = false;
        if (chkIsFramework.Checked == true)
            IsFrameWork = true;

        return IsFrameWork;
    }
    private string GetItem(string ProcType, string ProcTypeSelected)
    {
        string Item = "117";
        if (ProcType != "")
        {
            Item = ProcTypeSelected;
        }
        return Item;
    }
    private void ClearControls()
    {
        txtDescription.Text = ""; txtJustify.Text = ""; txtDate4PP20.Text = ""; txtDateWhenNeeded.Text = "";
        txtProclength.Text = ""; txtQuantity.Text = ""; txtTotalCost.Text = ""; txtUnitCost.Text = "";
        txtStockName.Text = ""; lblProcLength.Text = ""; lblQn.Text = "";
        txtProclength.Text = ""; lblStockName.Text = ""; Label3.Text = "";
        cboProcurementMethod.Items.Clear(); cboProcurementMethod.Enabled = false;
        cboQuarter.SelectedIndex = cboQuarter.Items.IndexOf(cboQuarter.Items.FindByValue("0"));
        cboUnits.SelectedIndex = cboUnits.Items.IndexOf(cboUnits.Items.FindByValue("0"));
        cboFunding.SelectedIndex = cboFunding.Items.IndexOf(cboFunding.Items.FindByValue("0"));
        cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue("0"));
        // cboPaymentMonth.SelectedIndex = cboPaymentMonth.Items.IndexOf(cboPaymentMonth.Items.FindByValue("0"));
        cboPayPeriod.SelectedIndex = cboPayPeriod.Items.IndexOf(cboPayPeriod.Items.FindByValue("0"));
        cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByValue("0"));
        cboNonStockCat.SelectedIndex = cboNonStockCat.Items.IndexOf(cboNonStockCat.Items.FindByValue("0"));
        cboNonStockCatType.SelectedIndex = cboNonStockCatType.Items.IndexOf(cboNonStockCatType.Items.FindByValue("0"));
    }
    private void ToggleProcurementType()
    {
        try
        {
            if (cboProcType.SelectedValue == "0")
                btnOK.Enabled = false;
            else
                btnOK.Enabled = true;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ToggleStockItem()
    {
        if (ChkStockItem.Checked)
        {
            lblStockName.Visible = true;
            txtStockName.Visible = true;
            lblNonStockCatType.Visible = false;
            lblNonStockItemCat.Visible = false;
            cboNonStockCat.Visible = false;
            cboNonStockCatType.Visible = false;
            cboNonStockCatType.SelectedIndex = 0;
        }
        else
        {
            lblStockName.Visible = false;
            txtStockName.Visible = false;
            txtStockName.Text = "";
            lblNonStockCatType.Visible = true;
            lblNonStockItemCat.Visible = true;
            cboNonStockCat.Visible = true;
            cboNonStockCatType.Visible = true;
        }
    }

    private void LoadProcLength(string ProcMethod)
    {

        int ProcLength = Process.GetProcurementLength(ProcMethod);
        txtProclength.Text = ProcLength.ToString();
        string StrProcLength = Process.GetProcurementLengthstr(ProcMethod);
        lblProcLength.Text = StrProcLength;
    }
    private void Toggle(bool Check, string returned)
    {
        btnYes.Visible = Check;
        btnNo.Visible = Check;
        lblQn.Visible = Check;
        if (Check)
        {
            MultiView1.ActiveViewIndex = -1;
            MultiView2.ActiveViewIndex = 1;
            lblQn.Text = returned + ", Do you want to add another item ?  ";
        }
        else
        {
            lblQn.Text = ".";
            MultiView2.ActiveViewIndex = 0;
        }
    }
    protected void chkQuantitifiable_CheckedChanged(object sender, EventArgs e)
    {
        if (chkQuantitifiable.Checked == true)
        {
            txtQuantity.Text = "1";
            //  txtQuantity.Enabled = false;

        }
        else
        {
            txtQuantity.Text = "";
            txtQuantity.Focus();
            txtQuantity.Enabled = true;
        }
    }

    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GetTotalCost();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    //sas
    //protected void txtMarketPrice_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GetTotalCost();
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowMessage(ex.Message);
    //    }
    //}
    protected void btnEnterProcDetails_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        try
        {
            if (Request.QueryString["transferid"] != null)
            {
                LoadAllControls();
                MultiView1.ActiveViewIndex = 0;
                MultiView2.ActiveViewIndex = 0;
            }
            else if (cboProcType.SelectedValue == "0")
                ShowMessage("Please Select The Procurement Type");
            else if (cboProcType.SelectedValue != "0")
            {
                if (rdCapital.Checked != true && RadioButton1.Checked != true)
                {
                    ShowMessage("Please Select Whether Plan Item Is Operational OR Capex");
                }
                else
                {
                    MultiView1.ActiveViewIndex = -1;
                    MultiView2.ActiveViewIndex = 0;
                    LoadItemsUnits();
                    LoadFundSources();
                    LoadNonStockItemCategoryTypes();
                    LoadCurrencies();
                    LoadQuarters();
                    GetCostCenterDetails();
                    ToggleProcurementType();
                    LoadItems();
                    ProcurementTypeCode = int.Parse(cboProcType.SelectedValue);

                    string itemSelected;
                    if (rdCapital.Checked)
                        itemSelected = " Capital Item";
                    else
                        itemSelected = " Operational Item";
                    cboNonStockCat.Enabled = false;
                    lblBudgetName.Text = itemSelected + " Plan of Procurement Type " + cboProcType.SelectedItem + " Selected";
                }
            }
            else
            {
                ClearControls();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboNonStockCatType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadNonStockItemCategories();
            cboNonStockCat.Enabled = true;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadNonStockItemCategories()
    {
        cboNonStockCat.DataSource = Process.GetNonStockItemCategoriesByCategoryTypeCode(int.Parse(cboNonStockCatType.SelectedValue));
        cboNonStockCat.DataValueField = "Code";
        cboNonStockCat.DataTextField = "ItemCategory";
        cboNonStockCat.DataBind();
    }
    protected void cboNonStockCatType_DataBound(object sender, EventArgs e)
    {
        cboNonStockCatType.Items.Insert(0, new ListItem("-- Select Non Stock Category Type -- ", "0"));
    }
    protected void cboNonStockCat_DataBound(object sender, EventArgs e)
    {
        cboNonStockCat.Items.Insert(0, new ListItem("-- Select Non Stock Category -- ", "0"));
    }

    protected void txtDateWhenNeeded_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int ProcLength = -1;
            ProcLength = int.Parse(txtProclength.Text.Trim());
            if (ProcLength != -1 && txtDateWhenNeeded.Text != "")
            {
                DateTime DateForPP20 = Convert.ToDateTime(txtDateWhenNeeded.Text).AddMonths((-1 * ProcLength));
                txtDate4PP20.Text = DateForPP20.ToString("MMMM d, yyyy");

                int PaymentMonth = (Convert.ToDateTime(txtDateWhenNeeded.Text).AddMonths(1)).Month;
                // cboPaymentMonth.SelectedValue = PaymentMonth.ToString();
            }
        }
        catch (Exception ex)
        {
            ShowMessage("Failed to get date for PP 20");
        }
    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                Process.RemoveDocument(FileCode);
                LoadDocuments(lblPlanCode.Text.Trim());
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                string Path = Process.GetDocumentPath(FileCode);
                DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridAttachments_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void DownloadFile(string path, bool forceDownload)
    {
        string name = Path.GetFileName(path);
        string ext = Path.GetExtension(path);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                    type = "text/HTML";
                    break;

                case ".txt":
                    type = "text/plain";
                    break;

                case ".doc":
                case ".docx":
                case ".rtf":
                    type = "Application/msword";
                    break;
                case ".xls":
                case ".xlsx":
                    type = "Application/vnd.ms-excel";
                    break;
                case ".pdf":
                    type = "Application/pdf";
                    break;
            }
        }
        if (forceDownload)
        {
            Response.AppendHeader("content-disposition",
                "attachment; filename=" + name);
        }
        if (type != "")
            Response.ContentType = type;
        Response.WriteFile(path);
        Response.End();
    }

    private void LoadDocuments(string PlanID)
    {
        MultiView3.ActiveViewIndex = 0;
        dtable = Process.GetPlanDocuments(PlanID, "");
        if (dtable.Rows.Count > 0)
        {
            GridAttachments.DataSource = dtable;
            GridAttachments.DataBind();
            GridAttachments.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            lblmsg.Visible = true;
            GridAttachments.Visible = false;
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        MultiView2.ActiveViewIndex = -1;
    }

    protected void ChkStockItem_CheckedChanged(object sender, EventArgs e)
    {
        ToggleStockItem();
    }

    private void ConfirmRemoveDocument(string FileCode)
    {
        lblFileCode.Text = FileCode;
        lblRemoveAtt.Text = "Are You Sure You Want To Delete Attachment?";
        MultiView2.ActiveViewIndex = 2;
    }

    protected void btnYesAtt_Click(object sender, EventArgs e)
    {
        Process.RemoveDocument(lblFileCode.Text.Trim());
        LoadDocuments(lblPlanCode.Text.Trim());
        MultiView1.ActiveViewIndex = 0;
        MultiView2.ActiveViewIndex = 0;
    }
    protected void btnNoAtt_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        MultiView2.ActiveViewIndex = 0;
    }
}
