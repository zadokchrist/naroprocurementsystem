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
public partial class Requisition_NewRequisition : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOther = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();
    private bool IsEmergency = false;

    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        btnAddNewItems.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnAddNewItems, "").ToString());
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
    }

    private void CreateRequisitionDataTable()
    {
        DataTable dtRequisition = new DataTable("Requisitions");
        dtRequisition.Columns.Add(new DataColumn("ItemDesc", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("StockName", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("UnitCode", typeof(string)));
        dtRequisition.Columns.Add(new DataColumn("Quantity", typeof(int)));
        dtRequisition.Columns.Add(new DataColumn("UnitCost", typeof(double)));
        dtRequisition.Columns.Add(new DataColumn("TotalCost", typeof(double)));
        dtRequisition.Rows.Clear();

        Session["dtRequisition"] = dtRequisition;
    }

    private void LoadControls(string RecordID)
    {
        MultiView1.ActiveViewIndex = 0;
        LoadLocations();
        LoadWareHouses();
        string Access = Session["AccessLevelID"].ToString();
        dtable = Process.GetRequisitions(RecordID, "0", "", "", "0");
        lblEntity.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtSubject.Text = dtable.Rows[0]["Subject"].ToString();
        string Type = dtable.Rows[0]["TypeID"].ToString();
        CboRequisition.SelectedIndex = CboRequisition.Items.IndexOf(CboRequisition.Items.FindByValue(Type));
        string LocationID = dtable.Rows[0]["LocationID"].ToString();
        cboLocation.SelectedIndex = cboLocation.Items.IndexOf(cboLocation.Items.FindByValue(LocationID));
        txtDateRequired.Text = dtable.Rows[0]["DateRequired"].ToString();
        lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
        string WareHouseID = dtable.Rows[0]["WareHouse"].ToString();
        chkIsFramework.Checked = Convert.ToBoolean(dtable.Rows[0]["IsFrameWork"].ToString());
        cboWareHouse.SelectedIndex = cboWareHouse.Items.IndexOf(cboWareHouse.Items.FindByValue(WareHouseID));
        LoadPDItems();
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

    private void LoadPDItems()
    {
        string PD_Code = lblPDCode.Text.Trim();
        dtable = Process.GetPD_CodeItems(PD_Code);
        lblPlanCode.Text = dtable.Rows[0]["PlanCode"].ToString();
        dtable.Columns.Remove("IsStockItem");
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

    private void LoadLocations()
    {
        dtable = Process.GetLocations();
        cboLocation.DataSource = dtable;
        cboLocation.DataValueField = "LocationID";
        cboLocation.DataTextField = "Location";
        cboLocation.DataBind();
    }

    private void LoadOtherPlanItems()
    {
        string ProcType = lblTypeID.Text.ToString();
        string PlanCode = lblPlanCode.Text.ToString();
        string Desc = txtDesc.Text.Trim();
        dtable = Process.GetOtherPlanItems(ProcType, PlanCode,Desc);
        DataGrid1.DataSource = dtable;
        DataGrid1.DataBind();
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

    private void LoadWareHouses()
    {
        dtable = Process.GetWareHouses(Session["AreaCode"].ToString());

        cboWareHouse.DataSource = dtable;
        cboWareHouse.DataValueField = "WareHouseID";
        cboWareHouse.DataTextField = "WareHouse";
        cboWareHouse.DataBind();
    }

    private string ValidateItemsForEditing()
    {
        string invalidPlanCodes = "";
        foreach (DataGridItem items in DataGrid2.Items)
        {
            CheckBox chk = ((CheckBox)(items.FindControl("chbAdd")));
            if (chk.Checked)
            {
                string plancode = items.Cells[2].Text;
                int remainingQty = int.Parse(items.Cells[5].Text);
                int currentQty = int.Parse(items.Cells[6].Text);
                string reqQty = ((TextBox)items.FindControl("txtQtyRequired")).Text;
                int requiredQty = int.Parse(reqQty);

                if (requiredQty == currentQty)
                    continue;
                else if ((requiredQty == 0) || (remainingQty + currentQty < requiredQty))
                    invalidPlanCodes += plancode + ",";
            }
        }
        if (String.IsNullOrEmpty(invalidPlanCodes))
            return invalidPlanCodes;
        else
            return invalidPlanCodes.TrimEnd(new char[] { ',' });
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
        ShowMessage(".");
        string EntityCode = lblEntity.Text.Trim();
        string Subject = txtSubject.Text.Trim();
        string LocationCode = cboLocation.SelectedValue.ToString();
        string DateRequired = txtDateRequired.Text.Trim();
        string ReqTypeCode = CboRequisition.SelectedValue.ToString();
        string WareHouse = cboWareHouse.SelectedValue.ToString();
        string PD_Code = lblPDCode.Text.Trim(); 
        string ProcType = lblTypeID.Text.Trim();
        bool IsFrameWork = IsFrameWorkContract();
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
        else if (cboWareHouse.SelectedValue == "0")
        {
            ShowMessage("Please Select Ware House");
            cboWareHouse.Focus();
        }
        else if (DateRequired == "")
        {
            ShowMessage("Please Enter Date When Item(s) Is Required");
            txtDateRequired.Focus();
        }
        else
        {
            if (!String.IsNullOrEmpty(ValidateItemsForEditing()))
                ShowMessage("One / More Plan Item(s) has a Required Quantity As Zero (0) OR Greater than its Remaining Quantity");
            else
            {
                PD_Code = lblPDCode.Text.Trim();
                Process.EditRequisition(PD_Code, Subject, LocationCode, DateRequired, ReqTypeCode, WareHouse, IsFrameWork);
                lblQn.Text = EditRequisitionItems(PD_Code);
                lblQn.Text = "Requisition Has Been Successfully Updated...";
                MultiView1.ActiveViewIndex = 1;
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
               ProcessOther.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false,Session["FullName"].ToString());
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        LoadOtherPlanItems();
    }

    protected void btnAddItems_Click(object sender, EventArgs e)
    {
        if (!AreAnyItemsSelected(DataGrid1))
            ShowMessage("Please Select Plan Item(s) To Be Added To Requisition ");
        else if (!String.IsNullOrEmpty(ValidateItemsForSubmission()))
            ShowMessage("One or more Plan Item(s) has a Required Quantity Greater than its current quantity");
        else
        {
            string PD_Code = lblPDCode.Text.Trim();
            SaveRequisitionItems(PD_Code);
            ShowMessage("Items Have Been Successfully Added To Requisition ( " + PD_Code + ")");
            LoadControls(lblRecordCode.Text.Trim());
        }
    }

    private string EditRequisitionItems(string PD_Code)
    {
        string output = "";
        foreach (DataGridItem items in DataGrid2.Items)
        {
            CheckBox chk = ((CheckBox)(items.FindControl("chbAdd")));
            if (chk.Checked)
            {
                string plancode = items.Cells[2].Text;
                long RecordId = long.Parse(items.Cells[1].Text);
                int remainingQty = int.Parse(items.Cells[5].Text);
                int currentQty = int.Parse(items.Cells[6].Text);
                int UnitCode = int.Parse(items.Cells[10].Text);

                string reqQty = ((TextBox)items.FindControl("txtQtyRequired")).Text;
                int requiredQty = int.Parse(reqQty);

                if (requiredQty == currentQty)
                    continue;
                else
                {
                    double unitCost = Convert.ToDouble(items.Cells[7].Text);

                    int PrevQty, BalQty;
                    if (requiredQty > currentQty)
                        BalQty = (currentQty + remainingQty) - requiredQty;
                    else
                        BalQty = currentQty - requiredQty;
                    PrevQty = (currentQty + remainingQty) - requiredQty;

                    double RequisitionedAmount = unitCost * requiredQty;
                    double PreviousAmount = unitCost * PrevQty;
                    double RemainingAmount = BalQty * unitCost;

                    Process.UpdateRequisitionItem(RecordId, plancode, PrevQty, PreviousAmount, requiredQty, RequisitionedAmount, BalQty, RemainingAmount);
                }
                output = "Requisition Items Have Been Updated Successfully";
            }
        }
        return output;
    }

    private void SaveRequisitionItems(string PD_Code)
    {
        foreach (DataGridItem items in DataGrid1.Items)
        {
            PD_Code = lblPDCode.Text.Trim();
            CheckBox chk = ((CheckBox)(items.FindControl("chbAdd")));
            if (chk.Checked)
            {
                string plancode = items.Cells[0].Text;
                string desc = items.Cells[2].Text;
                int currentQty = int.Parse(items.Cells[4].Text);
                double unitCost = double.Parse(items.Cells[5].Text.Replace(",", ""));
                //double Marketpricex = double.Parse(items.Cells[8].Text.Replace(",", ""));
                string Marketpricex = items.Cells[8].Text;
                int UnitCode = int.Parse(items.Cells[7].Text);
                string reqQty = ((TextBox)items.FindControl("txtQtyRequired")).Text;
                int requiredQty = int.Parse(reqQty);
                double Cost = unitCost * requiredQty;
                double remAmount = currentQty * unitCost;
                Process.SaveRequisitionItems("0", PD_Code, plancode, desc, requiredQty, Cost, false, remAmount, currentQty,false,"","",0,UnitCode,Marketpricex);
            }
        }
    }

    private bool AreAnyItemsSelected(Control control)
    {
        foreach (DataGridItem items in ((DataGrid)control).Items)
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

                if (currentQty < requiredQty)
                    invalidPlanCodes += plancode + ",";
            }
        }
        if (String.IsNullOrEmpty(invalidPlanCodes))
            return invalidPlanCodes;
        else
            return invalidPlanCodes.TrimEnd(new char[] { ',' });
    }

    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        long RecordID = Convert.ToInt64(e.Item.Cells[1].Text);
        string PlanCode = e.Item.Cells[2].Text;
        if (e.CommandName == "btnRemove")
        {
            if (DataGrid2.Items.Count == 1)
                ShowMessage("Cannot Remove All The Items From The Requisition...");
            else
            {
                int RemQty = Convert.ToInt32(e.Item.Cells[5].Text);
                int CurQty = Convert.ToInt32(e.Item.Cells[6].Text);

                int NewRemQty = RemQty + CurQty;

                Process.RemoveRequisitionItem(RecordID, PlanCode, 0, NewRemQty, true);
                //DataGrid2.DataBind();
                LoadControls(lblRecordCode.Text.Trim());
                ShowMessage("Requisition Item Has Been Removed");
            }
        }
    }
    protected void btnAddNewItems_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        LoadOtherPlanItems();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        lblHeaderMsg.Text = txtSubject.Text.Trim();
        btnOK.Enabled = false;
        LoadDocuments();
    }

    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 3;
        string PD_Code = lblPDCode.Text.Trim();
        dtable = ProcessOther.GetPlanDocuments("",PD_Code);
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
    }

    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            UploadFiles(lblPDCode.Text.Trim());
            LoadDocuments();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Requisition_ViewItems.aspx?transferStatus=1", true);
    }
    protected void cboWareHouse_DataBound(object sender, EventArgs e)
    {
        cboWareHouse.Items.Insert(0, new ListItem(" -- Select Ware House -- ", "0"));
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        Response.Redirect("Requisition_ViewItems.aspx?transferStatus=1", true);
    }
}
