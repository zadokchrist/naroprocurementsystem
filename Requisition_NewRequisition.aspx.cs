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
using System.Linq;
public partial class Requisition_NewRequisition : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOther = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();
    private bool IsEmergency = false;
    private DataTable dtUpdate;
    private DataTable dtProject;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DisableBtnsOnClick();
            if (IsPostBack == false)
            {
                LoadControls();
                Toggle(false, ".");
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
        dtUpdate = (DataTable)Session["dtIndividualPlanItems"];
        dtProject = (DataTable)Session["dtProject"];
    }
    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        btnAddItems.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnAddItems, "").ToString());
        btnSaveRequisition.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnSaveRequisition, "").ToString());
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
    private void LoadControls()
    {        
        if (Request.QueryString["transferid"] != null)
        {
            MultiView1.ActiveViewIndex = 0;
            string PlanID = Request.QueryString["transferid"].ToString();
            LoadDetails(PlanID); LoadFinYearStartDate();
            lblPlanCode.Text = PlanID;
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
    private void LoadDetails(string PlanCode)
    {
        LoadLocations();
        LoadWareHouses();
        dtable = Process.GetItemDetails(PlanCode);
        string PlanDesc = dtable.Rows[0]["Description"].ToString();
        lblQuantity.Text = dtable.Rows[0]["CurrentQty"].ToString();
        lblAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");
        txtMarketprice.Text = Convert.ToDouble(dtable.Rows[0]["MarketPrice"]).ToString("#,##0");
        txtDescription.Text = dtable.Rows[0]["Description"].ToString();
        lblUnitCost.Text = Convert.ToDouble(dtable.Rows[0]["UnitCost"]).ToString("#,##0");
        lblUnitCode.Text = dtable.Rows[0]["UnitCode"].ToString();
        //lblCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
        lblInitQty.Text = dtable.Rows[0]["Quantity"].ToString();
        lblInitail.Text = dtable.Rows[0]["Intial"].ToString();
        lblDesc.Text = dtable.Rows[0]["RequisitionInitial"].ToString();
        lblYear.Text = dtable.Rows[0]["FinancialYear"].ToString();
        lblTypeID.Text = dtable.Rows[0]["ProcurementTypeID"].ToString();

        if (dtable.Rows[0]["ProcurementTypeID"].ToString() == "1") //Works
        {
            lblUploadType.Text = "Upload Technical Specification. Max size is 10 Mb.(PDF, doc, excel file)";
            txtDelivery.Visible = false;
            cboLocation.Visible = false;
            txtWarehouse.Visible = false;
            cboWareHouses.Visible = false;

            lblDelivery2.Visible = false;
            cboLocations1.Visible = false;
            lblWarehouse.Visible = false;
            cboWareHouses1.Visible = false;

        }
        else if (dtable.Rows[0]["ProcurementTypeID"].ToString() == "2")//Consultancy
        {
            lblUploadType.Text = "Upload Terms of Reference (TOR). Max size is 10 Mb.(PDF, doc, excel file)";
            txtDelivery.Visible = false;
            cboLocation.Visible = false;
            txtWarehouse.Visible = false;
            cboWareHouses.Visible = false;

            lblDelivery2.Visible = false;
            cboLocations1.Visible = false;
            lblWarehouse.Visible = false;
            cboWareHouses1.Visible = false;
        }
        else if (dtable.Rows[0]["ProcurementTypeID"].ToString() == "3" || dtable.Rows[0]["ProcurementTypeID"].ToString() == "5")//Consultancy
        {
            lblUploadType.Text = "Upload Terms of Reference (TOR). Max size is 10 Mb.(PDF, doc, excel file)";
            txtDelivery.Visible = false;
            cboLocation.Visible = false;
            txtWarehouse.Visible = false;
            cboWareHouses.Visible = false;

            lblDelivery2.Visible = false;
            cboLocations1.Visible = false;
            lblWarehouse.Visible = false;
            cboWareHouses1.Visible = false;
        }
        else if (dtable.Rows[0]["ProcurementTypeID"].ToString() == "4")//Goods
        {
            lblUploadType.Text = "Upload Goods Specification. Max size is 10 Mb.(PDF, doc, excel file)";
            txtDelivery.Visible = true;
            cboLocation.Visible = true;
            txtWarehouse.Visible = true;
            cboWareHouses.Visible = true;

            lblDelivery2.Visible = true;
            cboLocations1.Visible = true;
            lblWarehouse.Visible = true;
            cboWareHouses1.Visible = true;
        }

            chkIsFramework.Checked = Convert.ToBoolean(dtable.Rows[0]["IsFramework"].ToString());

        LoadAreaManagers();
        DataTable Manager = ProcessOther.GetDefaultCCManager();
        if (Manager.Rows.Count > 0)
        {
            if (Session["AccessLevelID"].ToString().Equals("5"))
            {
                cboAreaManagers.Enabled = false;
            }
            string ManagerName = Manager.Rows[0]["FullName"].ToString();
            cboAreaManagers.SelectedIndex = cboAreaManagers.Items.IndexOf(cboAreaManagers.Items.FindByText(ManagerName));    
        }
    }

    private void LoadWareHouses()
    {

        dtable = Process.GetWareHouses(Session["AreaCode"].ToString());

        cboWareHouses.DataSource = dtable;
        cboWareHouses.DataValueField = "WareHouseID";
        cboWareHouses.DataTextField = "WareHouse";
        cboWareHouses.DataBind();

        cboWareHouses1.DataSource = dtable;
        cboWareHouses1.DataValueField = "WareHouseID";
        cboWareHouses1.DataTextField = "WareHouse";
        cboWareHouses1.DataBind();

    }
    private void LoadLocations()
    {
        dtable = Process.GetLocations();
        cboLocation.DataSource = dtable;
        cboLocation.DataValueField = "LocationID";
        cboLocation.DataTextField = "Location";
        cboLocation.DataBind();

        cboLocations1.DataSource = dtable;
        cboLocations1.DataValueField = "LocationID";
        cboLocations1.DataTextField = "Location";
        cboLocations1.DataBind();
    }
   
    protected void btnYes_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        string PlanCode = lblPlanCode.Text.Trim();
        MultiView1.ActiveViewIndex = 2;
        LoadOtherPlanItems();
    }

    private void LoadOtherPlanItems()
    {
        string ProcType = lblTypeID.Text.ToString();
        string PlanCode = lblPlanCode.Text.ToString();
        string Desc = txtDesc.Text.Trim();
        dtable = Process.GetOtherPlanItems(ProcType, PlanCode, Desc);
        DataGrid1.DataSource = dtable;
        DataGrid1.DataBind();
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        MultiView1.ActiveViewIndex = 4;
        cboAreaManagers1.Enabled = false;
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
            ConfirmRequisition();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadAreaManagers()
    {
        if(Session["IsAreaProcess"].ToString() == "1")
        {
            dtable = ProcessOther.GetAreaManagers();
        }
        else{
            dtable = ProcessOther.GetDefaultCCManager();
        }
        
        cboAreaManagers.DataSource = dtable;
        cboAreaManagers.DataValueField = "UserID";
        cboAreaManagers.DataTextField = "FullName";
        cboAreaManagers.DataBind();

        cboAreaManagers1.DataSource = dtable;
        cboAreaManagers1.DataValueField = "UserID";
        cboAreaManagers1.DataTextField = "FullName";
        cboAreaManagers1.DataBind();
    }
    private bool IsFrameWorkContract()
    {
        bool IsFrameWork = false;
        if (chkIsFramework.Checked == true)
            IsFrameWork = true;

        return IsFrameWork;
    }
    private bool IsFrameWorkContract1()
    {
        bool IsFrameWork = false;
        if (chkIsFramework1.Checked == true)
            IsFrameWork = true;

        return IsFrameWork;
    }

    private void ConfirmRequisition()
    {
        int Required = Convert.ToInt32(txtRequired.Text.Trim());
        int Qty = Convert.ToInt32(lblQuantity.Text.Trim());
        DateTime StartDate = Convert.ToDateTime(lblFinYearStartDate.Text.Trim());
        //double marketprice = Convert.ToDouble(txtMarketprice.Text.Trim());
        string marketprice = txtMarketprice.Text.Trim();
        if (StartDate > DateTime.Now)
            ShowMessage("You Cannot Create A Requisition For The Past Financial Year");
        else if (txtRequired.Text == "")
        {
            ShowMessage("Please Enter Quantity Required");
            txtRequired.Focus();
        }
        else if (txtAmount.Text == "")
        {
            ShowMessage("Please Enter Cost of the Item");
            txtAmount.Focus();
        }
        else if (Required > Qty)
        {
            ShowMessage("Please Enter A Quantity Lower Than Quantity Remaining ( " + lblQuantity.Text + " ) On The Plan Item");
            txtRequired.Focus();
        }
        else if (txtMarketprice.Text == "")
        {
            ShowMessage("Please Enter Market Price");
            txtMarketprice.Focus();
        }
        else if (txtMarketprice.Text == "0")
        {
            ShowMessage("Market Price Cannot be zero");
            txtMarketprice.Focus();

        }
        else
        {
            string Subject = txtSubject.Text.Trim();
            string LocationCode = cboLocation.SelectedValue.ToString();
            string WareHouseCode = cboWareHouses.SelectedValue.ToString();
            string DateRequired = txtDateRequired.Text.Trim();
            string ReqTypeCode = CboRequisition.SelectedValue.ToString();
            string PD_Code = lblPDCode.Text.Trim(); string Plancode = lblPlanCode.Text.Trim();
            string ItemCode = lblItemID.Text.Trim(); string RecordCode = lblRecordCode.Text.Trim();
            string Quantity = txtRequired.Text.Trim(); string TotalCost = txtAmount.Text.Trim();
            string ItemDesc = txtDescription.Text.Trim(); string UnitCode = lblUnitCode.Text.Trim();
            double Bal = Convert.ToDouble(lblAmount.Text.Replace(",", ""));
            double Req = Convert.ToDouble(TotalCost.Replace(",", ""));
            double AmountBalance = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
            int QuantityBalance = Convert.ToInt32(lblQuantity.Text.Trim()) - Convert.ToInt32(Quantity);
            string ProcType = lblTypeID.Text.Trim();
            //double MarketPrice = Convert.ToDouble(txtMarketprice.Text.Replace(",", ""));
            
            if (ReqTypeCode == "0")
            {
                ShowMessage("Please Select Type of Requisition");
            }
            else if (LocationCode == "0" && ProcType == "4")
            {
                ShowMessage("Please Select Location of Delievery" );
            }
            else if (Subject == "")
            {
                ShowMessage("Please Enter Subject of Procurement");
                txtSubject.Focus();
            }
            else if (cboWareHouses.SelectedValue == "0" && ProcType == "4")
            {
                ShowMessage("Please Select Ware House");
                cboWareHouses.Focus();
            }
            else if (cboAreaManagers.SelectedValue == "0")
            {
                ShowMessage("Please Select Manager To Submit Requisition To");
                cboAreaManagers.Focus();
            }
            else if (DateRequired == "")
            {
                ShowMessage("Please Enter Date When Item(s) is required");
                txtDateRequired.Focus();
            }
            else if (ItemDesc == "")
            {
                ShowMessage("Please Enter Item Description");
                txtDescription.Focus();
            }
            else if (txtMarketprice.Text == "")
            {
                ShowMessage("Please Enter Market Price");
                txtMarketprice.Focus();
            }
            else if (Req > Bal)
            {
                ShowMessage("Your Total Cost(" + Req + ") was greater than (" + Bal + ") balance on the Plan Item");
                txtAmount.Text = ""; txtRequired.Text = "";
            }
            else if (Plancode == "0")
            {
                ShowMessage("Sorry, this could be a system error. Contact System Admin for help");
            }
            else
            {
                bool IsFrameWork = IsFrameWorkContract();
                chkIsFramework1.Checked = IsFrameWork;

                txtDateRequired1.Text = txtDateRequired.Text.Trim();
                txtSubject1.Text = txtSubject.Text.Trim();

               
                cboReqType1.SelectedIndex = CboRequisition.SelectedIndex;

                cboLocations1.SelectedIndex = cboLocation.SelectedIndex;
                cboWareHouses1.SelectedIndex = cboWareHouses.SelectedIndex;

                cboAreaManagers1.SelectedIndex = cboAreaManagers.SelectedIndex;

                Plancode = lblPlanCode.Text.Trim();
                int UnitCodeID = Convert.ToInt32(lblUnitCode.Text.Trim());
                ItemCode = lblItemID.Text.Trim();
                TotalCost = txtAmount.Text.Trim();
                ItemDesc = txtDescription.Text.Trim();
                double UnitCost = Convert.ToDouble(lblUnitCost.Text.Replace(",", ""));
                double DTotalCost = Convert.ToDouble(TotalCost.Replace(",", ""));
                int InitQty = Convert.ToInt32(lblInitQty.Text.Trim());
                int CurQty = Convert.ToInt32(lblQuantity.Text.Trim());
                int ReqQty = Convert.ToInt32(txtRequired.Text.Trim());
                double Marketpricex = Convert.ToDouble(txtMarketprice.Text.Replace(",", ""));
                
                if (!Process.IsRequisitionInAreaThreshold(DTotalCost))
                    ShowMessage("The Requisition Amount Is Above Your Cost Center Threshold. Please Contact Operations Department To Raise The Requisition");
                else
                {
                    dtUpdate.Rows.Clear();
                    dtUpdate.Rows.Add(new object[] { Plancode, ItemDesc, InitQty, CurQty, UnitCodeID, UnitCost, DTotalCost, ReqQty,Marketpricex});

                    dgFinalItems.DataSource = dtUpdate.DefaultView;
                    dgFinalItems.DataBind();

                    ShowMessage("Plan Item ( " + Plancode + " ) has been added to requisition");
                    string Question = "Requisition on a Plan Item ( " + Plancode + " ) has been captured successfully, Do you want to add another Item";
                    Toggle(true, Question);
                    lblLoc.Text = cboLocation.SelectedValue.ToString();
                }
            }
        }
    }
    private void ValidateRequisition()
    {
        string SerialNumber = Process.GetRequisitionNumber();
        string EntityCode = "LWC/" + lblInitail.Text + "/" + lblDesc.Text + "/" + lblYear.Text + "/" + SerialNumber;
        string Subject = txtSubject.Text.Trim();
        string ProcType = lblTypeID.Text.Trim();
        string LocationCode = "";
        string WareHouseCode = "";
        if (ProcType != "4")
        {
            LocationCode = "2";
            WareHouseCode = "2";
        }else
        {
            LocationCode = cboLocations1.SelectedValue.ToString();
            WareHouseCode = cboWareHouses1.SelectedValue.ToString();

        }


        string DateRequired = txtDateRequired1.Text.Trim();
        string ReqTypeCode = cboReqType1.SelectedValue.ToString();
        string PD_Code = lblPDCode.Text.Trim(); string RecordCode = lblRecordCode.Text.Trim();
        
        //double MarketPrice = Convert.ToDouble(txtMarketprice.Text.Trim().Replace(",", ""));
        string MarketPrice =txtMarketprice.Text.Trim();
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;

        if (ReqTypeCode == "0")
        {
            ShowMessage("Please Select Type of Requisition");
        }
        else if (LocationCode == "0" && ProcType != "4")
        {
            ShowMessage("Please Select Location of Delievery");
        }
        else if (Subject == "")
        {
            ShowMessage("Please Enter Subject of Procurement");
            txtSubject.Focus();
        }
        else if (WareHouseCode == "0" && ProcType != "4")
        {
            ShowMessage("Please Select Ware House");
            cboWareHouses1.Focus();
        }
        else if (cboAreaManagers1.SelectedValue == "0")
        {
            ShowMessage("Please Select Manager To Submit Requisition To");
            cboAreaManagers1.Focus();
        }
        else if (DateRequired == "")
        {
            ShowMessage("Please Enter Date When Item(s) is Required");
            txtDateRequired.Focus();
        }
        else if(MarketPrice == "")
        {
            ShowMessage("Please Enter Market price of the procurement");
            txtMarketprice.Focus();

        } else if ((uploads[0].ContentLength / 1000) > 9800)
        {
            ShowMessage("Max file size is 10Mb");
        }
        else if ((uploads.Count > 0 && uploads[0].ContentLength == 0))
        {
            
            ShowMessage(lblUploadType.Text);
        }
        else if (!ValidateFiles())
        {
            ShowMessage("Wrong File formats have been uploaded please check and upload again");
        }
        else{

            bool IsFrameWork = IsFrameWorkContract1();
            bool IsProject = chkIsProject.Checked;
            int CCManagerID = int.Parse(cboAreaManagers1.SelectedValue.ToString());
            string PDReturn = Process.SaveRequisition(RecordCode, EntityCode, Subject, LocationCode, WareHouseCode, ReqTypeCode, DateRequired, ProcType, CCManagerID, MarketPrice, IsFrameWork, IsProject);
            lblPDCode.Text = PDReturn;
            SaveRequisitionItems(PDReturn);
            UploadFiles(PDReturn);
            Process.LogandCommitRequisition(PDReturn, 11, "Submitted New Requisition to " + cboAreaManagers.SelectedItem.Text);
            AlertManager(PDReturn);
            lblSuccess.Text = " Requisition ( " + PDReturn + " ) has been captured and submitted successfully to " + cboAreaManagers.SelectedItem.Text;
            DisplaySuccessMessage();
        }
    }

    public void DisplaySuccessMessage()
    {
        try
        {
            MultiView1.ActiveViewIndex = 3;
            string PD_Code = lblPDCode.Text.Trim();
            lblSuccess.Text = " Requisition ( " + PD_Code + " ) has been captured and submitted successfully to " + cboAreaManagers.SelectedItem.Text;
            ClearMajorControls();
            ClearControls();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void AlertManager(string PD_Code)
    {
        DataTable dtAlert = Process.GetRequisitionerAndCCManager(PD_Code);
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        string Subject = dtAlert.Rows[0]["Subject"].ToString();

        if (CboRequisition.SelectedValue == "2")
        {
            IsEmergency = true;
        }
        string By = HttpContext.Current.Session["FullName"].ToString();
        int CCManagerID = int.Parse(cboAreaManagers.SelectedValue.ToString());
        string CCManager = cboAreaManagers.SelectedItem.Text.ToString();
        string Message = "";

        if (IsEmergency)
        {
            Message = "<p><strong>EMMERGENCY REQUISITION</strong></p>";
            Message += "<p>You have been sent an emmergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> for approval</p>";
        }
        else
        {
            Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> for approval</p>";
        }

        Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

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
        lblPDCode.Text = "0";
        lblPlanCode.Text = "0";
        lblItemID.Text = "0";
        lblInitail.Text = "0";
        lblAmount.Text = "0";
        txtMarketprice.Text = "0";
        btnOK.Enabled = false;
        cboLocation.SelectedIndex = cboLocation.Items.IndexOf(cboLocation.Items.FindByValue("0"));
        CboRequisition.SelectedIndex = CboRequisition.Items.IndexOf(CboRequisition.Items.FindByValue("0"));
    }
    
    private void ClearControls()
    {
        lblQuantity.Text = "0";
        txtDescription.Text = "";
        txtAmount.Text = "";
        txtRequired.Text = "0";
        lblUnitCost.Text = "0";
    }

    private bool ValidateFiles()
    {
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        int countfiles = 0;
        for (int i = 0; i <= (uploads.Count - 1); i++)
        {
            if (uploads[i].ContentLength > 0)
            {
                string c = System.IO.Path.GetFileName(uploads[i].FileName);
                string extension = Path.GetExtension(c);
                string[] allowedfiles = { ".docx", ".doc",".pdf"};
                if (!allowedfiles.Contains(extension.ToLower()))
                {
                    return false;
                }
            }
        }
        return true;
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
        int CurQty = Convert.ToInt32(lblQuantity.Text.Trim());
        int ReqQty = Convert.ToInt32(txtRequired.Text.Trim());
      //  double UnitCost = Convert.ToDouble(lblUnitCost.Text.Replace(",", ""));
        double UnitCost = Convert.ToDouble(txtMarketprice.Text.Replace(",", ""));
        if (ReqQty > CurQty)
        {
            lblWarning.Text = ReqQty + " is greater than amount balance " + CurQty;
            lblWarning.Visible = true;
        }
        else
        {
            lblWarning.Visible = false;
            double TotalCost = ReqQty * UnitCost;
            txtAmount.Text = TotalCost.ToString("#,##0");
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        LoadOtherPlanItems();
    }

    protected void btnAddItems_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        if (!AreAnyItemsSelected())
            ShowMessage("Please Select Plan Item(s) to be added to Requisition ");
        else if (!String.IsNullOrEmpty(ValidateItemsForSubmission()))
            ShowMessage("One or more Plan Item(s) has a Required Quantity Greater than its Current Quantity");
        else
        {
            GetRequisitionItems();
            dgFinalItems.DataSource = dtUpdate.DefaultView;
            dgFinalItems.DataBind();

            ShowMessage("Selected Plan Item(s) have been successfully added to the Requisition");

            MultiView1.ActiveViewIndex = 4;
        }
    }
    private void GetRequisitionItems()
    {
        foreach (DataGridItem items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(items.FindControl("chbAdd")));
            if (chk.Checked)
            {
                string plancode = items.Cells[0].Text;
                string desc = items.Cells[2].Text;
                int initQty = int.Parse(items.Cells[3].Text);
                int currentQty = int.Parse(items.Cells[4].Text);
                double unitCost = double.Parse(items.Cells[5].Text.Replace(",", ""));
                int UnitCode = int.Parse(items.Cells[8].Text);
                string reqQty = ((TextBox)items.FindControl("txtQtyRequired")).Text;
                int requiredQty = int.Parse(reqQty);
                double marketprice = double.Parse(items.Cells[7].Text);
                if (requiredQty > currentQty)
                    throw new Exception("One of the Quantities Required Entered Is Greater Than Current Quantity");
                double Cost = unitCost * requiredQty;

                dtUpdate.Rows.Add(new object[] { plancode, desc, initQty, currentQty, UnitCode, unitCost, Cost, requiredQty,marketprice});

               // Process.SaveRequisitionItems("0", PD_Code, plancode, desc, requiredQty, Cost, false, remAmount, remQty, false, "", "");
            }
        }
    }


    private void SaveRequisitionItems(string PD_Code)
    {
        foreach (DataGridItem items in dgFinalItems.Items)
        {
            string plancode = items.Cells[0].Text;
            string desc = items.Cells[1].Text;
            int currentQty = int.Parse(items.Cells[3].Text);
            int UnitCode = int.Parse(items.Cells[4].Text);
            double unitCost = double.Parse(items.Cells[5].Text.Replace(",", ""));
            int requiredQty = int.Parse(items.Cells[7].Text);
            double MarketPricex = double.Parse(items.Cells[8].Text.Replace(",", ""));
            string MarketPricex2 = items.Cells[8].Text;
           
            if (requiredQty > currentQty)
                throw new Exception("One of the Quantities Required Entered Is Greater Than Current Quantity");
            double Cost = MarketPricex * requiredQty;
            double remAmount = currentQty * unitCost;
            int remQty = currentQty - requiredQty;
            DataTable dtPlan = ProcessOther.GetPlanItemDetails(plancode);
            string StockCode = ""; string StockName = ""; int StockBalance = 0; bool IsStock = false;
            if (dtPlan.Rows.Count > 0)
            {
                IsStock = Convert.ToBoolean(dtPlan.Rows[0]["IsStockItem"].ToString());
                StockCode = dtPlan.Rows[0]["StockCode"].ToString();
                StockName = dtPlan.Rows[0]["StockName"].ToString();
                if (dtPlan.Rows[0]["StockBalance"].ToString() != "")
                    StockBalance = Convert.ToInt32(dtPlan.Rows[0]["StockBalance"].ToString());
            }
            Process.SaveRequisitionItems("0", PD_Code, plancode, desc, requiredQty, Cost, false, remAmount, remQty, IsStock, StockCode, StockName, StockBalance, UnitCode,MarketPricex2);
        }
    }

    private bool AreAnyItemsSelected()
    {
        foreach (DataGridItem items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(items.FindControl("chbAdd")));
            if (chk.Checked)
                return true;
        }
        return false;
    }

    private string ValidateItemsForSubmission()
    {
        string invalidPlanCodes = "";
        foreach (DataGridItem items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(items.FindControl("chbAdd")));
            if (chk.Checked)
            {
                string plancode = items.Cells[0].Text;
                int currentQty = int.Parse(items.Cells[4].Text);
                string reqQty = ((TextBox)items.FindControl("txtQtyRequired")).Text;
                int requiredQty = int.Parse(reqQty);

                if (requiredQty == 0 || currentQty < requiredQty)
                    invalidPlanCodes += plancode + ",";
            }
        }
        if (String.IsNullOrEmpty(invalidPlanCodes))
            return invalidPlanCodes;
        else
            return invalidPlanCodes.TrimEnd(new char[] { ',' });
    }

    protected void cboAreaManagers_DataBound(object sender, EventArgs e)
    {
        cboAreaManagers.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        lblSuccess.Text = "Create New Requisition Has Been Cancelled";
        MultiView1.ActiveViewIndex = 3;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        MultiView1.ActiveViewIndex = 4;
    }
    protected void btnReturnToReqItems_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        Response.Redirect("Requisition_Items.aspx?transferid=1", true);
    }

    protected void cboWareHouses_DataBound(object sender, EventArgs e)
    {
        cboWareHouses.Items.Insert(0, new ListItem(" -- Select Ware House --", "0"));
    }
    protected void cboReqType1_DataBound(object sender, EventArgs e)
    {
        cboReqType1.Items.Insert(0, new ListItem("-- Select Requisition Type --", "0"));
    }
    protected void cboWareHouses1_DataBound(object sender, EventArgs e)
    {
        cboWareHouses1.Items.Insert(0, new ListItem(" -- Select Ware House --", "0"));
    }
    protected void cboLocations1_DataBound(object sender, EventArgs e)
    {
        cboLocations1.Items.Insert(0, new ListItem(" -- Select Location --", "0"));
    }
    protected void cboAreaManagers1_DataBound(object sender, EventArgs e)
    {
        cboAreaManagers1.Items.Insert(0, new ListItem("-- Select Manager --", "0"));
    }

    protected void btnSaveRequisition_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            ValidateRequisition();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void chkIsProject_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsProject.Checked == true)
        {
            //   CreateProjectDataTable();
            MultiView2.ActiveViewIndex = 0;
            // tdItems.Visible = false;
            btnCancel.Visible = false;
            Button1.Visible = false;
            btnSaveRequisition.Visible = false;
            chkIsFramework.Checked = false;
            chkIsFramework1.Checked = false;


        }
        else
        {
            MultiView2.ActiveViewIndex = -1;
            //tdItems.Visible = true;
            btnCancel.Visible = true;
            Button1.Visible = true;
        }
    }

    protected void chkIsProject1_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsProject1.Checked == true)
        {
            // CreateProjectDataTable();
            MultiView2.ActiveViewIndex = 0;
            //tdItems.Visible = false;
            btnCancel.Visible = false;
            Button1.Visible = false;
            chkIsFramework.Checked = false;
            chkIsFramework1.Checked = false;


        }
        else
        {
            MultiView2.ActiveViewIndex = -1;
            //tdItems.Visible = true;
            btnCancel.Visible = true;
            Button1.Visible = true;

        }
    }
    protected void chkIsFramework1_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsFramework1.Checked == true)
        {
            MultiView2.ActiveViewIndex = -1;
          //  tdItems.Visible = true;
            chkIsProject.Checked = false;
            chkIsProject1.Checked = false;
            btnCancel.Visible = true;
            Button1.Visible = true;

        }

    }
    protected void chkIsFramework_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsFramework.Checked == true)
        {
            MultiView2.ActiveViewIndex = -1;
           // tdItems.Visible = true;
            chkIsProject.Checked = false;
            chkIsProject1.Checked = false;
            btnCancel.Visible = true;
            Button1.Visible = true;

        }
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
                double ItemTotalCost = Convert.ToDouble(e.Item.Cells[4].Text.Replace(",", ""));
                double RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
                RemAmount = RemAmount + ItemTotalCost;

                dtUpdate.Rows.RemoveAt(ItemRowIndex);
                lblAmount.Text = RemAmount.ToString("#,##0");

                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind();
            }

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnCancelProject_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        lblSuccess.Text = "Create New Requisition Has Been Cancelled";
        MultiView1.ActiveViewIndex = 3;
        MultiView2.ActiveViewIndex = -1;
    }

    private void CreateProjectDataTable()
    {

        dtProject.Columns.Add(new DataColumn("ItemDesc", typeof(string)));
        dtProject.Columns.Add(new DataColumn("StockCode", typeof(string)));
        dtProject.Columns.Add(new DataColumn("StockName", typeof(string)));
        dtProject.Columns.Add(new DataColumn("StockBalance", typeof(int)));
        dtProject.Columns.Add(new DataColumn("Quantity", typeof(int)));
        dtProject.Columns.Add(new DataColumn("UnitCode", typeof(int)));
        dtProject.Columns.Add(new DataColumn("Units", typeof(string)));
        dtProject.Columns.Add(new DataColumn("UnitCost", typeof(double)));
        dtProject.Columns.Add(new DataColumn("TotalCost", typeof(double)));
        dtProject.Columns.Add(new DataColumn("MarketPrice", typeof(double)));

        //  dtProject.Rows.Clear();
    }

    protected void txtUnitCostCurrentFinYear_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnAddProjectItem_Click(object sender, EventArgs e)
    {
        ShowMessage2(".");

        if (String.IsNullOrEmpty(txtProjectDescription.Text.Trim()))
            ShowMessage2("Please Enter Project Item Description");
        else if (String.IsNullOrEmpty(txtProjectMarketPx.Text.Trim()))
            ShowMessage2("Please enter Total Project Cost for Entire Project Duration");
        else if (String.IsNullOrEmpty(txtFinYear.Text.Trim()))
            ShowMessage2("Please enter Financial Year");
        else
        {
            string finYear = txtFinYear.Text.ToString().Trim();
            string ItemDesc = txtProjectDescription.Text.Trim();

            string PD_Code = lblPDCode.Text.Trim();


            double TotalCost = Convert.ToDouble(txtProjectMarketPx.Text.Trim());

            dtProject.Rows.Add(new object[] { finYear, ItemDesc, TotalCost });

            DataGrid2.DataSource = dtProject;
            DataGrid2.DataBind();
        }
    }

    private void ShowMessage2(string Message)
    {
        if (Message == ".")
            lblItemError.Text = ".";
        else
            lblItemError.Text = "MESSAGE: " + Message;
    }

    protected void btnProjectSubmit_Click(object sender, EventArgs e)
    {




        SaveProjectRequisition();

    }
    private void SaveProjectRequisition()
    {
        string SerialNumber = Process.GetRequisitionNumber();
        string EntityCode = "LWC/" + lblInitail.Text + "/" + lblDesc.Text + "/" + lblYear.Text + "/" + SerialNumber;
        string Subject = txtSubject.Text.Trim();
        string LocationCode = cboLocation.SelectedValue.ToString();
        string WareHouseCode = cboWareHouses.SelectedValue.ToString();
        string DateRequired = txtDateRequired.Text.Trim();
        string ReqTypeCode = CboRequisition.SelectedValue.ToString();
        string PD_Code = lblPDCode.Text.Trim(); string RecordCode = lblRecordCode.Text.Trim();
        string ProcType = lblTypeID.Text.Trim();
        string CurrentFinYearCost = txtFinCurrentFinYearCost.Text.Trim();
        string MarketPrice = txtMarketprice.Text.Trim();


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
        else if (cboWareHouses.SelectedValue == "0")
        {
            ShowMessage("Please Select Ware House");
            cboWareHouses.Focus();
        }
        else if (cboAreaManagers.SelectedValue == "0")
        {
            ShowMessage("Please Select Manager To Submit Requisition To");
            cboAreaManagers.Focus();
        }
        else if (DateRequired == "")
        {
            ShowMessage("Please Enter Date When Item(s) is Required");
            txtDateRequired.Focus();
        }
        else if (MarketPrice == "")
        {
            ShowMessage("Please Enter Market price of the procurement");
            txtMarketprice.Focus();

        }
        else if (CurrentFinYearCost == "")
        {
            ShowMessage("Please Enter Procurement Cost for this Finacial Year");
            txtMarketprice.Focus();

        }
        else
        {
            bool IsFrameWork = IsFrameWorkContract();
            bool IsProject = chkIsProject.Checked;
            int CCManagerID = int.Parse(cboAreaManagers.SelectedValue.ToString());
            string PDReturn = Process.SaveRequisition(RecordCode, EntityCode, Subject, LocationCode, WareHouseCode, ReqTypeCode, DateRequired, ProcType, CCManagerID, MarketPrice, IsFrameWork, IsProject);
            lblPDCode.Text = PDReturn;

            SaveProjectRequisitionItems(PDReturn);
            SaveProjectRequisitionDetails(PDReturn, CurrentFinYearCost);
            //UploadFiles(PDReturn);
            Process.LogandCommitRequisition(PDReturn, 11, "Submitted New Requisition to " + cboAreaManagers.SelectedItem.Text);
            AlertManager(PDReturn);
            lblSuccess.Text = " Requisition ( " + PDReturn + " ) has been captured and submitted successfully to " + cboAreaManagers.SelectedItem.Text;
            DisplaySuccessMessage();
            MultiView2.ActiveViewIndex = -1;
        }
    }

    private void SaveProjectRequisitionDetails(string PD_CODE, string CurrentFinYearCost)
    {

        Process.SaveProjectCurrentFinYearCost(PD_CODE, CurrentFinYearCost);

        if (dtProject.Rows.Count == 0)
        {

        }
        else
        {

            Process.SaveProjectItems(PD_CODE, dtProject);


        }

    }
    private void SaveProjectRequisitionItems(string PD_Code)
    {

        string plancode = lblPlanCode.Text.Trim();
        string desc = txtDescription.Text.Trim();
        int currentQty = int.Parse(lblQuantity.Text.Trim());
        int UnitCode = int.Parse(lblUnitCode.Text.Trim());
        double unitCost = double.Parse(lblUnitCost.Text.Replace(",", ""));
        int requiredQty = int.Parse(txtRequired.Text.Trim());
        double MarketPricex = double.Parse(txtMarketprice.Text.Replace(",", ""));
        string MarketPricex2 = txtMarketprice.Text.Replace(",", "");
        if (requiredQty > currentQty)
            throw new Exception("One of the Quantities Required Entered Is Greater Than Current Quantity");
        double Cost = MarketPricex * requiredQty;
        double remAmount = currentQty * unitCost;
        int remQty = currentQty - requiredQty;
        DataTable dtPlan = ProcessOther.GetPlanItemDetails(plancode);
        string StockCode = ""; string StockName = ""; int StockBalance = 0; bool IsStock = false;
        if (dtPlan.Rows.Count > 0)
        {
            IsStock = Convert.ToBoolean(dtPlan.Rows[0]["IsStockItem"].ToString());
            StockCode = dtPlan.Rows[0]["StockCode"].ToString();
            StockName = dtPlan.Rows[0]["StockName"].ToString();
            if (dtPlan.Rows[0]["StockBalance"].ToString() != "")
                StockBalance = Convert.ToInt32(dtPlan.Rows[0]["StockBalance"].ToString());
        }
        Process.SaveRequisitionItems("0", PD_Code, plancode, desc, requiredQty, Cost, false, remAmount, remQty, IsStock, StockCode, StockName, StockBalance, UnitCode, MarketPricex2);

    }


  
}
