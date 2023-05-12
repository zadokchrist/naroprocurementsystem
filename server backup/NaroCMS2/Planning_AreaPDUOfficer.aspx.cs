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
public partial class Planning_AreaPDUOfficer : System.Web.UI.Page
{
    ProcessPlanning Process = new ProcessPlanning();
    DataLogin data = new DataLogin();
    BusinessPlanning bll = new BusinessPlanning();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadProcurmentTypes();
                LoadAreas();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadAreas()
    {
        dtable = data.GetAreas();
        DropDownList1.DataSource = dtable;
        DropDownList1.DataValueField = "AreaID";
        DropDownList1.DataTextField = "Area";
        DropDownList1.DataBind(); DropDownList1.Enabled = false;

        string AreaCode = Session["AreaCode"].ToString();
        DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(AreaCode));
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

    private void LoadItems()
    {
        string Search = "";
        string ProcTypeCode = cboProcType.SelectedValue.ToString();
        string CostCenterID = cboCostCenters.SelectedValue.ToString();
        dtable = Process.GetAreaPDUOfficerPlanItems(Search, ProcTypeCode, CostCenterID);
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
            ShowMessage(".");
            Button1.Enabled = true;
            CheckBox2.Enabled = true;
            chkSelect.Enabled = true;
            rbnApproval.Enabled = true;
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
            rbnApproval.Enabled = false;
        }
    }

    private void LoadPendingItems(int NumberOfItems)
    {
        MultiView1.ActiveViewIndex = 2;
        string Display = "You have " + NumberOfItems + " Plan Item(s) to reject, do you want to Submit the Items";
        Toggle(true, Display);

    }
    private void Toggle(bool Check, string returned)
    {
        btnYes.Visible = Check;
        btnNo.Visible = Check;
        lblQn.Visible = Check;
        if (Check)
        {
            lblQn.Text = returned;
        }
        else
        {
            lblQn.Text = ".";
        }
    }
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - All Procurement Types - -", "0"));
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            LoadItems();
            DataGrid1.CurrentPageIndex = 0;
            BindLoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            SubmitPlanItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void SubmitPlanItems()
    {
        if (rbnApproval.SelectedIndex == -1)
        {
            ShowMessage("Please select whether to approve/reject the selected plans.");
        }
        else if (rbnApproval.SelectedIndex == 1 && txtComment.Text.Trim() == "")
        {
            ShowMessage("Please provide a comment/note for the rejection of the plan.");
        }
        //else if (rbnApproval.SelectedIndex == 2 && txtComment.Text.Trim() == "")
        //{
        //    ShowMessage("Please provide a comment/note for the deletion of the plan.");
        //}
        else
        {
            string ItemArr = GetItemsToApprove().TrimEnd(',');

            if (ItemArr != "")
            {
                string returned;
                switch (rbnApproval.SelectedIndex)
                {
                    case 0:
                        returned = Process.SubmitPlanItemsForApproval(ItemArr, 6, txtComment.Text);
                        break;
                    case 1:
                        returned = Process.SubmitPlanItemsForApproval(ItemArr, 32, txtComment.Text);
                        break;
                    default:
                        returned = "Please select items to be approved / rejected.";
                        break;
                }
                ResetControls();
                ShowMessage(returned);
            }
            else
            {
                ShowMessage("Please select plan items to approve / reject / delete ...");
            }
        }
        
    }

    private void ResetControls()
    {
        txtComment.Text = "";
        rbnApproval.SelectedIndex = -1;
        LoadItems(); BindLoadItems();
    }
    private string GetItemsToApprove()
    {
        int Count = 0;
        string ItemArr = "";
        foreach (DataGridItem Items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(Items.FindControl("CheckBox1")));
            if (chk.Checked)
            {
                Count++;
                string ItemFound = Items.Cells[1].Text;
                ItemArr = ItemArr += ItemFound + ",";
            }
        }
        return ItemArr;
    }
    private void SelectAllRecords()
    {
        foreach (DataGridItem Items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(Items.FindControl("CheckBox1")));
            chk.Checked = true;
        }
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            string CostCenter = "0";
            string ret = Process.ProcessPendingPMPlanItems("", "0", CostCenter);
            ShowMessage(ret);
            Toggle(false, ".");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        try
        {
            LoadItems();
            Toggle(false, ".");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string Plancode = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[2].Text;
            string CostCenterSelected = cboCostCenters.SelectedValue;
            Session["PreviousPage"] = "Planning_Procu.aspx";
            if (e.CommandName == "btnDetail")
            {
                Response.Redirect("Planning_PlanDetails.aspx?transferid=" + Plancode, true);
                //ShowMessage(Plancode);
                //Response.Redirect("./Planning_PMRejectItem.aspx?transferid=" + Plancode+"&Centerid="+CostCenterSelected, false);
            }
            else if (e.CommandName == "btnFiles")
            {
                lblPlanCode.Text = Plancode;
                lblHeaderMsg.Text = Desc;
                cboProcType.Enabled = false;
                cboCostCenters.Enabled = false;
                LoadDocuments();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 1;
        string PlanID = lblPlanCode.Text.Trim();
        dtable = Process.GetPlanDocuments(PlanID,"");
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
    protected void cboCostCenters_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem(" -- All Cost Centers -- ", "0"));
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
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnView")
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
                case ".docx":
                case ".doc":
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
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 0;
            LoadItems();
            cboCostCenters.Enabled = true;
            cboProcType.Enabled = true;
            lblPlanCode.Text = "0";
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("-- Select Area --", "0"));
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

    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        LoadItems();
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        BindLoadItems();
    }
}
