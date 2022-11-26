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

    private DataTable dtUpdate;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DisableBtnsOnClick();
            if (IsPostBack == false)
            {
                ACEStockName.ContextKey = Session["ScalaCode"].ToString();

                if (Session["CostCenterID"].ToString().Equals("53") || Session["CostCenterID"].ToString().Equals("113"))
                {

                    chkIsProject.Visible = true;

                }
                else
                {

                    chkIsProject.Visible = false;

                } 
                LoadControls();
                Toggle(false, ".");
            }
            //else if (Request.QueryString["transferid"] != null)
            //{
            //    MultiView1.ActiveViewIndex = 0;
            //    string PlanCode = lblPlanCode.Text.Trim();

            //    //MultiView2.ActiveViewIndex = 0;
            //    lblGroupRequisition.Text = "EDIT REQUISITION ITEM";
            //    //LoadProcurementTypes();
            //    //LoadControls();
            //    LoadDetails(PlanCode);
            //    //LoadPlanItem();
            //    Toggle(false, ".");
            //    //MultiView3.ActiveViewIndex = 0;
            //}
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
        dtUpdate = (DataTable)Session["dtRequisition"];
    }
    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        btnAddItem.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnAddItem, "").ToString());
        Button1.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(Button1, "").ToString());
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
    private void LoadItemsUnits()
    {
        dtable = ProcessOther.GetItemUnits();
        cboUnits.DataSource = dtable;
        cboUnits.DataValueField = "UnitCode";
        cboUnits.DataTextField = "Unit";
        cboUnits.DataBind();
    }
    private void LoadControls()
    {        
        if (Request.QueryString["transferid"] != null)
        {
            MultiView1.ActiveViewIndex = 0;
            string PlanID = Request.QueryString["transferid"].ToString();
            LoadDetails(PlanID); LoadFinYearStartDate(); LoadProcurementTypes();
            LoadItemsUnits(); lblPlanCode.Text = PlanID;
        }
        else
        {
            Response.Redirect("Requisition_Items.aspx", true);
        }  
    }
    private void LoadFinYearStartDate()
    {
        dtable = Process.GetDatesForFinancialYear(3);
        lblFinYearStartDate.Text = dtable.Rows[0]["StartDate"].ToString();
    }
    public bool DisplayStockName()
    {
        if (ProcessOther.IsUserInInventory() || Session["IsAreaProcess"].ToString() == "1")
            return true;
        else
            return false;
    }

    private void LoadDetails(string PlanCode)
    {
        LoadLocations();
        LoadWareHouses();
        dtable = Process.GetItemDetails(PlanCode);
        string PlanDesc = dtable.Rows[0]["Description"].ToString();
        chkIsFramework.Checked = Convert.ToBoolean(dtable.Rows[0]["IsFramework"].ToString());
        lblGroupRequisition.Text = PlanDesc;
        //lblQuantity.Text = dtable.Rows[0]["Quantity"].ToString();
        lblAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");
        lblPlanAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");
       // txtMarketprice.Text = Convert.ToDouble(dtable.Rows[0]["MarketPrice"]).ToString("#,##0");
        lblInitail.Text = dtable.Rows[0]["Intial"].ToString();
        lblDesc.Text = dtable.Rows[0]["RequisitionInitial"].ToString();
        lblYear.Text = dtable.Rows[0]["FinancialYear"].ToString();
        lblTypeID.Text = dtable.Rows[0]["ProcurementTypeID"].ToString();
        IsGroup = Convert.ToBoolean(dtable.Rows[0]["IsGroupItem"]);
        // txtDateRequired.Text = DateTime.Today; // dtable.Rows[0]["DateNeeded"].ToString();


        if (dtable.Rows[0]["ProcurementTypeID"].ToString() == "1") //Works
        {
            lblUploadType.Text = "Upload Technical Specification. Max size is 10 Mb.(PDF, doc, excel file)";
           
            cboLocation.Visible = false;
            cboWareHouses.Visible = false;
            lblDelivery.Visible = false;
            lblWarehouse.Visible = false;
           
        }
        else if (dtable.Rows[0]["ProcurementTypeID"].ToString() == "2")//Consultancy
        {
            lblUploadType.Text = "Upload Terms of Reference (TOR). Max size is 10 Mb.(PDF, doc, excel file)";
            cboLocation.Visible = false;
            cboWareHouses.Visible = false;
            lblDelivery.Visible = false;
            lblWarehouse.Visible = false;
        }
        else if (dtable.Rows[0]["ProcurementTypeID"].ToString() == "3" || dtable.Rows[0]["ProcurementTypeID"].ToString() == "5")//Consultancy
        {
            lblUploadType.Text = "Upload Terms of Reference (TOR). Max size is 10 Mb.(PDF, doc, excel file)";
            cboLocation.Visible = false;
            cboWareHouses.Visible = false;
            lblDelivery.Visible = false;
            lblWarehouse.Visible = false;
        }
        else if (dtable.Rows[0]["ProcurementTypeID"].ToString() == "4")//Goods
        {
            lblUploadType.Text = "Upload Goods Specification. Max size is 10 Mb.(PDF, doc, excel file)";
            cboLocation.Visible = true;
            cboWareHouses.Visible = true;
            lblDelivery.Visible = true;
            lblWarehouse.Visible = true;
        }



        LoadAreaManagers();
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
        DataTable Manager = ProcessOther.GetDefaultCCManager();
        if (Manager.Rows.Count > 0)
        {
            string ManagerName = Manager.Rows[0]["FullName"].ToString();
            cboAreaManagers.SelectedIndex = cboAreaManagers.Items.IndexOf(cboAreaManagers.Items.FindByText(ManagerName));
        }
    }
    //sas
    private void LoadPlanItem() 
    {
        Session["dtRequisition"] = dtUpdate;
        DataTable dtRequisition = (DataTable)Session["dtRequisition"];
        //string PlanDesc = dtable.Rows[0]["Description"].ToString();
        //lblPlanAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");

        string ItemDesc = dtRequisition.Rows[0]["ItemDesc"].ToString();
        //string StockCode = dtUpdate.Rows[0]["StockCode"].ToString();
        //string StockName = dtUpdate.Rows[0]["StockName"].ToString();
        txtRequired.Text = Convert.ToInt32(dtRequisition.Rows[0]["Quantity"]).ToString();
        cboUnits.SelectedValue = Convert.ToInt32(dtRequisition.Rows[0]["UnitCode"]).ToString();
        string Unit = dtRequisition.Rows[0]["UnitCode"].ToString();
        txtUnitCost1.Text = Convert.ToDouble(dtRequisition.Rows[0]["UnitCost"]).ToString("#,##0");
        //double TotalCost = UnitCost * Quantity;
        lblAmount.Text = Convert.ToDouble(dtRequisition.Rows[0]["TotalCost"]).ToString("#,##0");
        //txtMarketprice.Text = Convert.ToDouble(dtRequisition.Rows[0]["MarketPrice"]).ToString("#,##0");

    }

    private void LoadWareHouses()
    {
        dtable = Process.GetWareHouses(Session["AreaCode"].ToString());

        cboWareHouses.DataSource = dtable;
        cboWareHouses.DataValueField = "WareHouseID";
        cboWareHouses.DataTextField = "WareHouse";
        cboWareHouses.DataBind();
    }

    private void LoadAreaManagers()
    {
        if (Session["IsAreaProcess"].ToString() == "1")
        {
            cboAreaManagers.DataSource = ProcessOther.GetAreaManagers();
        }
        else
        {
            cboAreaManagers.DataSource = ProcessOther.GetDefaultCCManager();
        }
       
        cboAreaManagers.DataValueField = "UserID";
        cboAreaManagers.DataTextField = "FullName";
        cboAreaManagers.DataBind();
    }

    private void LoadLocations()
    {
        dtable = Process.GetLocations();
        cboLocation.DataSource = dtable;
        cboLocation.DataValueField = "LocationID";
        cboLocation.DataTextField = "Location";
        cboLocation.DataBind();
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
       // Clear Moniors
        string PlanCode = lblPlanCode.Text.Trim();
        if (bll.IsGroupItem(PlanCode))
        {
            MultiView1.ActiveViewIndex = 0;
            Button1.Enabled = true;
            LoadDetails(PlanCode);
            txtDescription.Focus();
            //string SelectedLocation = lblLoc.Text.Trim();
            //cboLocation.SelectedIndex = cboLocation.Items.IndexOf(cboLocation.Items.FindByValue(SelectedLocation));
            //btnReturn_Click();
        }
        else
        {
            MultiView1.ActiveViewIndex = 2;
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e) 
   {

    //    try
    //    {
    //        MultiView1.ActiveViewIndex = 0;
    //        string Plancode = lblPlanCode.Text.Trim();
    //        ShowMessage("Requisition on Group Item " + Plancode + " has been Captured and Submitted to CostCenter Manager " + cboAreaManagers.SelectedItem.Text);
    //        //ClearMajorControls();
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowMessage(ex.Message);
    //    }
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 0;
            string PlanCode = lblPlanCode.Text.Trim();
            string PD_Code = lblPDCode.Text.Trim();
            Process.LogandCommitRequisition(PD_Code, 11, "");
            AlertManager(PD_Code);
            ShowMessage("Requisition on Item " + PlanCode + " has been Captured and Submitted Successfully");
            ClearMajorControls();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
                      
    }
    protected void cboLocation_DataBound(object sender, EventArgs e)
    {
        cboLocation.Items.Insert(0, new ListItem("-- Select Delivery Location --", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            ValidateRequisition();
            MultiView1.ActiveViewIndex = 0;
            lblGroupRequisition.Visible = false;
            lblTypeID.Visible = false;


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
        DateTime StartDate = Convert.ToDateTime(lblFinYearStartDate.Text.Trim());
        string marketprice = txtMarketprice.Text.Trim();
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        if (StartDate > DateTime.Now)
            ShowMessage("You Cannot Create A Requisition For The Past Financial Year");
        else if (cboProcType.SelectedValue == "0")
            ShowMessage("Please Select A Procurement Type");
        else if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Items To Requisition");
        }
        else if (txtMarketprice.Text == "")
        {
            ShowMessage("Please Enter Market Price");
            txtMarketprice.Focus();
        }
        else if (uploads.Count > 0 && uploads[0].ContentLength == 0)
        {
            ShowMessage(lblUploadType.Text);
        }
        else
        {
            bool IsFrameWork = IsFrameWorkContract();
            bool IsProject = chkIsProject.Checked;
            string SerialNumber = Process.GetRequisitionNumber();
            //string EntityCode = "NWSC/" + lblInitail.Text + "/" + lblDesc.Text + "/" + lblYear.Text + "/" + SerialNumber;
            DataTable dtInitialProcTypes = ProcessOther.GetProcurementTypes(cboProcType.SelectedValue);
            string InitialProcType = dtInitialProcTypes.Rows[0]["RequisitionInitial"].ToString();
            string EntityCode = "LWC/" + lblInitail.Text + "/" + InitialProcType + "/" + lblYear.Text + "/" + SerialNumber;
            string Subject = txtSubject.Text.Trim();
            string LocationCode = cboLocation.SelectedValue.ToString();
            string WareHouseCode = cboWareHouses.SelectedValue.ToString();
            string DateRequired = txtDateRequired.Text.Trim();
            string ReqTypeCode = CboRequisition.SelectedValue.ToString();
            string PD_Code = lblPDCode.Text.Trim(); string Plancode = lblPlanCode.Text.Trim();
            string ItemCode = lblItemID.Text.Trim(); string RecordCode = lblRecordCode.Text.Trim();
            string Quantity = txtRequired.Text.Trim();
            string PlanBalance = lblPlanAmount.Text.Trim().Replace(",", "");
            string AmountBalance = lblAmount.Text.Trim().Replace(",", "");
            string ProcType = cboProcType.SelectedValue.ToString(); // lblTypeID.Text.Trim();
            //string MarketPrice = txtMarketPrice.Text.Trim().Replace(",", "");
            string MarketPrice = txtMarketprice.Text.Trim().Replace(",", "");
            if (ReqTypeCode == "0")
            {
                ShowMessage("Please Select Type of Requisition");
            }
            else if (LocationCode == "0" && ProcType == "4")
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
                ShowMessage("Please Enter Date When Item(s) is required");
                txtDateRequired.Focus();
            }
            else if (cboWareHouses.SelectedValue == "0" && ProcType == "4")
            {
                ShowMessage("Please Select Ware House");
                cboWareHouses.Focus();
            }
            else if (cboAreaManagers.SelectedValue == "0")
            {
                ShowMessage("Please Select Manager To Submit Selected Plan Items To");
                cboAreaManagers.Focus();
            }
            else if (ChkStockItem.Checked == true && txtStockName.Text.Trim() == "")
            {
                ShowMessage("Please Enter Stock Name / Category");
            }
            else if (Plancode == "0")
            {
                ShowMessage("Sorry, this Could be Process. Contract System Admin for help");
            }
            else if (MarketPrice == "") 
            {
                ShowMessage("Please Enter current Market price for Item");
                txtMarketprice.Focus();
            
            }
            else
            {
                Session["dtRequisition"] = dtUpdate;
                DataTable dtRequisition = (DataTable)Session["dtRequisition"];

                double TotalCost = 0, Cost = 0;
                foreach (DataRow dr in dtRequisition.Rows)
                {
                    Cost = Convert.ToDouble(dr["TotalCost"].ToString().Replace(",", ""));
                    TotalCost += Cost;
                }
                if (ProcType != "4")
                {
                    LocationCode = "2";
                    WareHouseCode = "2";
                }
                else
                {
                    LocationCode = cboLocation.SelectedValue.ToString();
                    WareHouseCode = cboWareHouses.SelectedValue.ToString();

                }
                if (!Process.IsRequisitionInAreaThreshold(TotalCost))
                    ShowMessage("The Requisition Amount Is Above Your Cost Center Threshold. Please Contact Operations Department To Raise The Requisition");
                else
                {

                    int CCManagerID = int.Parse(cboAreaManagers.SelectedValue.ToString());
                    string PDReturn = Process.SaveRequisition(RecordCode, PD_Code, ItemCode, Plancode, EntityCode, Subject,
                                        LocationCode, WareHouseCode, ReqTypeCode, DateRequired, PlanBalance, ProcType, CCManagerID, dtRequisition, MarketPrice, IsFrameWork, IsProject);
                    lblPDCode.Text = PDReturn;
                    UploadFiles(PDReturn);
                    ActionToTake();
                   
                    //dtUpdate.Rows.RemoveAt();


                }
            }
        }
    }
    private void ActionToTake()
    {
        string PlanCode = lblPlanCode.Text.Trim();
        string PD_Code = lblPDCode.Text.Trim();
        string Question = "";
        ShowMessage("Plan Item ( " + PlanCode + " ) has been sent to " + cboAreaManagers.SelectedItem.Text);
        Process.LogandCommitRequisition(PD_Code, 11,"Submitted A New Group Requisition to " + cboAreaManagers.SelectedItem.Text);
        AlertManager(PD_Code);
        ClearMajorControls();


        //Response.Redirect("Requisition_Items.aspx", true);
    }
    private void AlertManager(string PD_Code)
    {
        DataTable dtAlert = Process.GetRequisitionerAndCCManager(PD_Code);
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        string Subject = dtAlert.Rows[0]["Subject"].ToString();
        string Message = "";
        if (CboRequisition.SelectedValue == "2")
        {
            IsEmergency = true;
        }
        if (IsEmergency)
        {
            Message = "<p><strong>EMMERGENCY REQUISITION</strong></p>";
            Message += "<p>You have been sent an emmergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> for approval</p>";
        }
        else
        {
            Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> for approval</p>";
        }

        Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login. </p> ";
        int CCManagerID = Convert.ToInt32(cboAreaManagers.SelectedValue.ToString());
        ProcessOther.NotifyManager(RequisitionerName, Subject, CCManagerID, Message);
        
    }
    private void Toggle(bool Check, string returned)
    {
        btnYes.Visible = Check;
        btnNo.Visible = Check;
        lblQn.Visible = Check;
        if (Check)
        {
            MultiView1.ActiveViewIndex = 1;
            lblQn.Text = returned;
        }
        else
        {
            MultiView1.ActiveViewIndex = 0;
            lblQn.Text = ".";
        }
    }
    private void ClearMajorControls()
    {
        txtDateRequired.Text = "";
        txtSubject.Text = "";
        //lblPDCode.Text = "0";
        //lblPlanCode.Text = "0";
       // lblItemID.Text = "0";
        //lblInitail.Text = "0";
        //lblAmount.Text = "0";
        cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue("0"));
        cboLocation.SelectedIndex = cboLocation.Items.IndexOf(cboLocation.Items.FindByValue("0"));
        CboRequisition.SelectedIndex = CboRequisition.Items.IndexOf(CboRequisition.Items.FindByValue("0"));
        cboWareHouses.SelectedIndex = cboWareHouses.Items.IndexOf(cboWareHouses.Items.FindByValue("0"));
        DataGrid2.DataSource = null;
        DataGrid2.DataBind();
    }

    private void ClearItemControls()
    {
        txtUnitCost1.Text = ""; txtDescription.Text = ""; txtRequired.Text = "";
        txtTotalCost.Text = ""; ChkStockItem.Checked = false; txtStockName.Text = "";
        cboUnits.SelectedValue = "0";

        if (lblAmount.Text.Trim() == "0")
        {
            txtDescription.Enabled = false; txtRequired.Enabled = false; txtUnitCost1.Enabled = false; txtTotalCost.Enabled = false;
            btnAddItem.Enabled = false; ChkStockItem.Enabled = false; txtStockName.Enabled = false; cboUnits.Enabled = false;
        }
        else
        {
            txtDescription.Enabled = true; txtRequired.Enabled = true; txtUnitCost1.Enabled = true; cboUnits.Enabled = true;
            txtTotalCost.Enabled = true; btnAddItem.Enabled = true; ChkStockItem.Enabled = true; txtStockName.Enabled = true;
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
                ProcessOther.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false);

            }
        }
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
            if (ReqAmount > BalAmount)
            {
                lblWarning.Text = ReqAmount + " is greater than" + BalAmount;
                lblWarning.Visible = true;
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
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            //string Plancode = e.Item.Cells[0].Text;
            //string RecordID = e.Item.Cells[0].Text;
            //string PD_Code = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[0].Text;

            if (e.CommandName == "btnRemove")
            {
                int ItemRowIndex = e.Item.DataSetIndex;
                double ItemTotalCost = Convert.ToDouble(e.Item.Cells[4].Text.Replace(",",""));
                double RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
                RemAmount = RemAmount + ItemTotalCost;

                dtUpdate.Rows.RemoveAt(ItemRowIndex);
                lblAmount.Text = RemAmount.ToString("#,##0");

                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind();
            }
                //sas
            //else if (e.CommandName == "btnEdit")
            //{
            //    //MultiView1.ActiveViewIndex = 0;

            //    //lblPlanCode.Text = Plancode;
            //    //lblDesc.Text = ItemDesc;
            //    //LoadDetails(Plancode);
            //    //Session["Status"] = cboStatus.SelectedValue.ToString();
            //    Session["SelectedType"] = cboProcType.SelectedValue.ToString();


            //    Response.Redirect("Requisition_EditGroupRequisition.aspx?transferid=" + Desc, true);
            //    lblGroupRequisition.Text = "EDIT REQUISITION ITEM";
            //    int ItemRowIndex = e.Item.DataSetIndex;
            //    double ItemTotalCost = Convert.ToDouble(e.Item.Cells[4].Text.Replace(",", ""));
            //    double RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
            //    RemAmount = RemAmount + ItemTotalCost;
            //    string ItemDesc = e.Item.Cells[0].Text.Trim();

            //    string StockCode = dtUpdate.Rows[0]["StockCode"].ToString();
            //    string StockName = dtUpdate.Rows[0]["StockName"].ToString();
            //    int Quantity = Convert.ToInt32(e.Item.Cells[3].Text.ToString());
            //    int UnitCode = Convert.ToInt32(e.Item.Cells[4].Text.ToString());
            //    string Unit = e.Item.Cells[5].Text.ToString();
            //    double UnitCost = Convert.ToDouble(e.Item.Cells[6].Text.Trim().Replace(",", ""));
            //    //double TotalCost = UnitCost * Quantity;
            //    double Amount = Convert.ToDouble(e.Item.Cells[8].Text.Trim().Replace(",", ""));
            //    double MarketPrice = Convert.ToDouble(e.Item.Cells[7].Text.Trim().Replace(",", ""));



            //    DataGrid2.DataSource = dtUpdate.DefaultView;
            //    DataGrid2.DataBind();



            //}
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ValidateMainControls()
    {

    }

    private void ValidateItemControls()
    {

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
            ShowMessage2("Please enter required quantity");
        else if (cboUnits.SelectedValue == "0")
            ShowMessage2("Please Select Item Units");
        else if (String.IsNullOrEmpty(txtUnitCost1.Text.Trim()))
            ShowMessage2("Please enter the unit cost");
        else if (ChkStockItem.Checked && String.IsNullOrEmpty(txtStockName.Text.Trim()))
            ShowMessage2("Please Enter Stock Code");
        else if (String.IsNullOrEmpty(txtMarketprice.Text.Trim()))
        {
            if (chkIsProject.Checked == true)
            {
                ShowMessage2("Please Enter Contract Amount for Item");
            }
            else
            {
                ShowMessage2("Please Enter current Market price for Item");
            }
            txtMarketprice.Focus();

        }
        else
        {
            string ItemDesc = txtDescription.Text.Trim();
            string StockCode = "";
            string StockName = txtStockName.Text.Trim();
            string PD_Code = lblPDCode.Text.Trim();
            int StockBalance = 0;
            if (ChkStockItem.Checked && !String.IsNullOrEmpty(txtStockName.Text.Trim()))
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
                    throw new Exception("Stock Code Not Found. Please Enter Correct Stock Code OR Select From Drop-down Returned After Typing More Than Two Numbers");
                else
                    StockName = dtable.Rows[0]["ACTUALSTOCKNAME"].ToString();
                string WareHouseNo = "0" + cboWareHouses.SelectedValue;
                dtable = Process.GetStockBalances(StockCode, CompanyCode, WareHouseNo);
                if (dtable.Rows.Count > 0)
                    StockBalance = Convert.ToInt32(Convert.ToDouble(dtable.Rows[0]["StockBalance"].ToString()));
                else
                    StockBalance = 0;
            }
            //string Plancode = lblPlanCode.Text.Trim();
            int Quantity = int.Parse(txtRequired.Text.Trim());
            int UnitCode = int.Parse(cboUnits.SelectedValue);
            string Unit = cboUnits.SelectedItem.Text;
            double UnitCost = Convert.ToDouble(txtUnitCost1.Text.Trim());
            double TotalCost = UnitCost * Quantity;
            double RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
            double MarketPrice = Convert.ToDouble(txtMarketprice.Text.Trim());
            //string MarketPrice = txtMarketprice.Text.Trim();
            if (TotalCost <= RemAmount)
            {
                double NewRemAmount = RemAmount - TotalCost;

                dtUpdate.Rows.Add(new object[] { ItemDesc, StockCode, StockName, StockBalance, Quantity, UnitCode, Unit, UnitCost, TotalCost, MarketPrice });


                lblAmount.Text = NewRemAmount.ToString("#,##0");
                ClearItemControls();
                //ClearMajorControls();
            }
            else
            {
                ShowMessage2(" Your Total Cost (" + TotalCost + ") was greater than (" + RemAmount + ") balance on the Plan Item");
            }
            if (chkIsProject.Checked == true)
            {
                DataGrid2.Columns[8].HeaderText = "Contract Amount";
            }
            else
            {

                DataGrid2.Columns[8].HeaderText = "Market Price";

            }

            //DataGrid2.DataSource = dtUpdate.DefaultView;
            DataGrid2.DataSource = dtUpdate;
            DataGrid2.DataBind();
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
            if (ReqAmount > BalAmount)
            {
                ShowMessage2(" Your Total Cost (" + ReqAmount + ") was greater than (" + BalAmount + ") balance on the Plan Item");
            }
            else
            {
                if (chkIsProject.Checked == false)
                {
                    txtMarketprice.Text = UnitCost;
                }
                else
                {

                    if (!String.IsNullOrEmpty(txtMarketprice.Text.Trim()))
                    {


                    }
                    else
                    {
                        txtMarketprice.Text = "";
                    }



                }
                txtTotalCost.Text = ReqAmount.ToString("#,##0");
                lblWarning.Visible = false;
            }
        }
    }

    protected void lblAmount_DataBinding(object sender, EventArgs e)
    {
        
    }
    protected void cboAreaManagers_DataBound(object sender, EventArgs e)
    {
        cboAreaManagers.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
    }

    protected void cboWareHouses_DataBound(object sender, EventArgs e)
    {
        cboWareHouses.Items.Insert(0, new ListItem (" -- Select Ware House -- ","0"));
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Requisition_Items.aspx?transferid=1", true);
    }
    protected void ChkStockItem_CheckedChanged(object sender, EventArgs e)
    {
        ACEStockName.ContextKey = Session["ScalaCode"].ToString();
        if (ChkStockItem.Checked)
            txtStockName.Enabled = true;
        else
            txtStockName.Enabled = false;
    }
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - Select Procurement Type - -", "0"));
    }
    private void LoadProcurementTypes()
    {
        dtable = ProcessOther.GetProcurementTypes();
        cboProcType.DataSource = dtable;
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
    }
    protected void cboUnits_DataBound(object sender, EventArgs e)
    {
        cboUnits.Items.Insert(0, new ListItem("- - Select Item Unit - -", "0"));
    }
    protected void chkIsProject_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsProject.Checked == true)
        {
            lblContractOrMarket.Text = "Enter Contract Amount";
            txtMarketprice.Text = "";
            chkIsFramework.Checked = false;
        }
        else
        {
            lblContractOrMarket.Text = "Current Market Price";

        }
    }
    protected void chkIsFramework_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsFramework.Checked == true)
        {

            chkIsProject.Checked = false;
        }
    }

    protected void cboProcType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string proctype = cboProcType.SelectedValue;
        if (proctype == "1") //Works
        {
            lblUploadType.Text = "Upload Technical Specification. Max size is 10 Mb.(PDF, doc, excel file)";

            cboLocation.Visible = false;
            cboWareHouses.Visible = false;
            lblDelivery.Visible = false;
            lblWarehouse.Visible = false;

        }
        else if (proctype == "2")//Consultancy
        {
            lblUploadType.Text = "Upload Terms of Reference (TOR). Max size is 10 Mb.(PDF, doc, excel file)";
            cboLocation.Visible = false;
            cboWareHouses.Visible = false;
            lblDelivery.Visible = false;
            lblWarehouse.Visible = false;
        }
        else if (proctype == "3" || proctype == "5")//Consultancy
        {
            lblUploadType.Text = "Upload Terms of Reference (TOR). Max size is 10 Mb.(PDF, doc, excel file)";
            cboLocation.Visible = false;
            cboWareHouses.Visible = false;
            lblDelivery.Visible = false;
            lblWarehouse.Visible = false;
        }
        else if (proctype == "4")//Goods
        {
            lblUploadType.Text = "Upload Goods Specification. Max size is 10 Mb.(PDF, doc, excel file)";
            cboLocation.Visible = true;
            cboWareHouses.Visible = true;
            lblDelivery.Visible = true;
            lblWarehouse.Visible = true;
        }

    }
}
