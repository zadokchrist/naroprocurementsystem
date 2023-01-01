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
public partial class Planning_ViewPlanItems : System.Web.UI.Page
{
    ProcessPlanning Process = new ProcessPlanning();
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
                if (Request.QueryString["transferid"] != null)
                {
                    string statusCode = Session["Status"].ToString(); // Request.QueryString["transferid"].ToString();
                    cboStatus.SelectedIndex = cboStatus.Items.IndexOf(cboStatus.Items.FindByValue(statusCode));
                    LoadPlanItems();
                }
                //else
                //    LoadPlanItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadProcurmentTypes()
    {
        dtable = Process.GetProcurementTypes();
        cboProcType.DataSource = dtable;
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
    }
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - All Procurement Types - -", "0"));
    }
    private void LoadPlanItems()
    {
        ShowMessage(".");
        if (cboStatus.SelectedValue == "0")
        {
            lblSearchLabel.Text = "SUBMITTED PLAN ITEM(S)";
            GetAllPlanItems();
            DataGrid1.CurrentPageIndex = 0;
            BindPlanToDataGrid();
        }
        else if (cboStatus.SelectedValue == "4")
        {
            lblSearchLabel.Text = "PENDING PLAN ITEM(S)";
            GetPendingPlanItems();
            DataGrid1.CurrentPageIndex = 0;
            BindPlanToDataGrid();
        }
        else if (cboStatus.SelectedValue == "1")
        {
            // Call Approved
            lblSearchLabel.Text = "APPROVED PLAN ITEM(S)";
            CallApprovedPlanItems();
            DataGrid1.CurrentPageIndex = 0;
            BindPlanToDataGrid();
        }
        else if (cboStatus.SelectedValue == "2")
        {
            lblSearchLabel.Text = "CONSOLIDATED PLAN ITEM(S)";
            CallConsolidatedPlanItems();
            DataGrid1.CurrentPageIndex = 0;
            BindPlanToDataGrid();
        }
        else
        {
            // Call Rejected
            lblSearchLabel.Text = "REJECTED PLAN ITEM(S)";
            CallRejectedPlanItems();
            DataGrid2.CurrentPageIndex = 0;
            BindRejectedPlanItems();
        }
    }
    private void CallRejectedPlanItems()
    {
        string Plancode = txtSearch.Text.Trim();
        string ProcTypeCode = cboProcType.SelectedValue.ToString();
        string CostCenterCode = Session["CostCenterID"].ToString();
        dtable = Process.GetRejectedPlanItems(Plancode,ProcTypeCode, CostCenterCode);
    }

    public bool EnableGridButtons()
    {
        if (Session["AccessLevelID"].ToString() == "5" || Session["AccessLevelID"].ToString() == "4")
            return true;
        else
            return false;
    }

    private void BindRejectedPlanItems()
    {
        if (dtable.Rows.Count > 0)
        {
            if (Session["AccessLevelID"].ToString() == "6")
            {
                Button1.Enabled = false;
                btnResubmit.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
            }
            DataGrid2.DataSource = dtable;
            DataGrid2.DataBind();
            MultiView1.ActiveViewIndex = 1;
            ShowMessage(".");
        }
        else
        {
            MultiView1.ActiveViewIndex = -1;
            ShowMessage("No rejected Plan Item(s) found");
        }
    }

    private void GetAllPlanItems()
    {
        string Plancode = txtSearch.Text.Trim();
        string ProcTypeCode = cboProcType.SelectedValue.ToString();
        string CostCenterCode = Session["CostCenterID"].ToString();
        dtable = Process.GetAllPlanItems(Plancode, ProcTypeCode, CostCenterCode);
    }
    private void GetPendingPlanItems()
    {
        string Plancode = txtSearch.Text.Trim();
        string ProcTypeCode = cboProcType.SelectedValue.ToString();
        string CostCenterCode = Session["CostCenterID"].ToString();
        dtable = Process.GetPendingPlanItems(Plancode, ProcTypeCode, CostCenterCode);
    }
    private void CallApprovedPlanItems()
    {
        string Plancode = txtSearch.Text.Trim();
        string ProcTypeCode = cboProcType.SelectedValue.ToString();
        string CostCenterCode = Session["CostCenterID"].ToString();
        dtable = Process.GetApprovedPlanItems(Plancode, ProcTypeCode, CostCenterCode);
    }

    public void BindPlanToDataGrid()
    {   
        if (dtable.Rows.Count > 0)
        {
            DataGrid1.DataSource = dtable;
            DataGrid1.DataBind();
            MultiView1.ActiveViewIndex = 0;
            ShowMessage(".");
        }
        else
        {
            MultiView1.ActiveViewIndex = -1;
            ShowMessage("No Plan Item(s) Found");
        }
    }
    private void CallConsolidatedPlanItems()
    {
        string Plancode = txtSearch.Text.Trim();
        string ProcTypeCode = cboProcType.SelectedValue.ToString();
        string CostCenterCode = Session["CostCenterID"].ToString();
        dtable = Process.GetConsolidatedItems(Plancode, ProcTypeCode, CostCenterCode);
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
        try
        {
            // Get Item Name......
            string Plancode = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[2].Text;
            string Status = e.Item.Cells[6].Text;
            if (e.CommandName == "btnFiles")
            {
                lblPlanCode.Text = Plancode;
                lblHeaderMsg.Text = Desc;
                cboStatus.Enabled = false;
                //if (Status == "Consolidated")
                    LoadReadOnlyDocuments();
                //else
                  //  LoadDocuments();
            }
            else if (e.CommandName == "btnView")
            {
                Session["PreviousPage"] = "Planning_ViewPlanItems.aspx";
                Session["Status"] = cboStatus.SelectedValue;
                Response.Redirect("Planning_PlanDetails.aspx?transferid=" + Plancode, true);
            }
            else if (e.CommandName == "btnEdit")
            {
                Session["PreviousPage"] = "Planning_ViewPlanItems.aspx";
                Session["Status"] = cboStatus.SelectedValue;
                Response.Redirect("Planning_AddPlan.aspx?transferid=" + Plancode, true);

            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            ShowMessage(".");
            string Plancode = e.Item.Cells[0].Text;
            string Desc = e.Item.Cells[1].Text;
            if (e.CommandName == "btnFiles")
            {
                lblPlanCode.Text = Plancode;
                lblHeaderMsg.Text = Desc;
                cboStatus.Enabled = false;
                if (Session["AccessLevelID"].ToString() == "5")
                    LoadDocuments();
                else
                    LoadReadOnlyDocuments();
            }
            else if (e.CommandName == "btnEdit")
            {
                Session["PreviousPage"] = "Planning_ViewPlanItems.aspx";
                Session["Status"] = cboStatus.SelectedValue;
                Response.Redirect("Planning_AddPlan.aspx?transferid=" + Plancode, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            string Plancode = lblPlanCode.Text.Trim();
            UploadFiles(Plancode);
            LoadDocuments();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 2;
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
    private void LoadReadOnlyDocuments()
    {
        MultiView1.ActiveViewIndex = 3;
        string PlanID = lblPlanCode.Text.Trim();
        dtable = Process.GetPlanDocuments(PlanID, "");
        if (dtable.Rows.Count > 0)
        {
            GridReadOnlyAttachments.DataSource = dtable;
            GridReadOnlyAttachments.DataBind();
            GridReadOnlyAttachments.Visible = true;
            lblNoAttachments.Visible = false;
        }
        else
        {
            lblNoAttachments.Visible = true;
            GridReadOnlyAttachments.Visible = false;
        }
    }

    protected void GridReadOnlyAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // View 
            int intIndex = Convert.ToInt32(e.CommandArgument);
            string FileCode = Convert.ToString(GridReadOnlyAttachments.DataKeys[intIndex].Value);
            string Path = Process.GetDocumentPath(FileCode);
            DownloadFile(Path, true);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
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
                ConfirmRemoveDocument(FileCode);
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
    protected void GridAttachments_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    private void SelectAllRecords()
    {
        foreach (DataGridItem Items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(Items.FindControl("CheckBox1")));
            chk.Checked = true;
        }
    }
    private void SelectAllItems()
    {
        foreach (DataGridItem Items in DataGrid2.Items)
        {
            CheckBox chk = ((CheckBox)(Items.FindControl("CheckBox1")));
            if (chk.Checked)
            {
                chk.Checked = false;
            }
            else
            {
                chk.Checked = true;
            }
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            cboStatus.Enabled = true;
            LoadPlanItems();
            lblPlanCode.Text = "0";
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
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
                Process.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false, Session["FullName"].ToString());
               
            }
        }
    }
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SelectAllItems();

            if (CheckBox2.Checked == true)
            {
                CheckBox3.Checked = true;
            }
            else
            {
                CheckBox3.Checked = false;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void CheckBox3_Unload(object sender, EventArgs e)
    {

    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
             try
        {
            SelectAllItems();

            if (CheckBox3.Checked == true)
            {
                CheckBox2.Checked = true;
            }
            else
            {
                CheckBox2.Checked = false;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void btnResubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string ItemArr = GetItemsToResubmit().TrimEnd(',');
            //int Status = 4;
            string returned = Process.ResubmitPlanItems(ItemArr);
            cboStatus.SelectedIndex = cboStatus.Items.IndexOf(cboStatus.Items.FindByValue("3"));
            LoadPlanItems();
            ShowMessage(returned);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private string GetItemsToResubmit()
    {
        int Count = 0;
        string ItemArr = "";
        foreach (DataGridItem Items in DataGrid2.Items)
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage("Working Now");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridAttachments_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        if (cboStatus.SelectedValue == "0")
        {
            lblSearchLabel.Text = "SUBMITTED PLAN ITEM(S)";
            GetAllPlanItems();
            DataGrid1.CurrentPageIndex = e.NewPageIndex;
            BindPlanToDataGrid();
        }
        else if (cboStatus.SelectedValue == "1")
        {
            // Call Approved
            CallApprovedPlanItems();
            DataGrid1.CurrentPageIndex = e.NewPageIndex;
            BindPlanToDataGrid();
        }
        else if (cboStatus.SelectedValue == "2")
        {
            CallConsolidatedPlanItems();
            DataGrid1.CurrentPageIndex = e.NewPageIndex;
            BindPlanToDataGrid();
        }
        else
        {
            // Call Rejected
            CallRejectedPlanItems();
            DataGrid1.CurrentPageIndex = e.NewPageIndex;
            BindRejectedPlanItems();
        } 
    }

    private void ConfirmRemoveDocument(string FileCode)
    {
        lblFileCode.Text = FileCode;
        lblRemoveAtt.Text = "Are You Sure You Want To Delete Attachment?";
        MultiView1.ActiveViewIndex = 4;
    }

    protected void btnYesAtt_Click(object sender, EventArgs e)
    {
        Process.RemoveDocument(lblFileCode.Text.Trim());
        LoadDocuments();
        LoadReadOnlyDocuments();
        MultiView1.ActiveViewIndex = 2;
    }
    protected void btnNoAtt_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }

}
