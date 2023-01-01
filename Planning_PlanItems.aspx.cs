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
public partial class Planning_PlanItems : System.Web.UI.Page
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
                LoadProcurementTypes();
                LoadQuarters();
                LoadItems();
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
    private void LoadProcurementTypes()
    {
        dtable = Process.GetProcurementTypes();
        cboProcType.DataSource = dtable;
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
    }
    private void LoadQuarters()
    {
        cboQuarter.DataSource = Process.GetQuarters();
        cboQuarter.DataValueField = "QuarterCode";
        cboQuarter.DataTextField = "Quarter";
        cboQuarter.DataBind();
    }
    private void LoadItems()
    {
        string Search = txtSearch.Text.Trim();
        string ProcTypeCode = cboProcType.SelectedValue.ToString();
        string CostCenterID = Session["CostCenterID"].ToString();
        string QuarterID = cboQuarter.SelectedValue.ToString();
        dtable = Process.GetManagerPlanItems(Search, ProcTypeCode, QuarterID, CostCenterID);
        if (dtable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = dtable;
            DataGrid1.DataBind();
            Button1.Enabled = true;
            chkSelect.Enabled = true;
            CheckBox2.Enabled = true;
        }
        else
        {
            MultiView1.ActiveViewIndex = 2;
            DataGrid1.DataSource = dtable;
            DataGrid1.DataBind();
            Button1.Enabled = false;
            chkSelect.Enabled = false;
            CheckBox2.Enabled = false;
            ShowMessage("No Plan Item(s) Submitted To You For Approval");
            lblEmpty.Text = "No Plan Item(s) Awaiting Approval";
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private string GetItemsToSubmit()
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
    private void SubmitPlanItems()
    {
        try
        {
            if (rbnApproval.SelectedIndex == -1)
            {
                ShowMessage("Please select whether to approve/reject/delete the selected plans.");
            }
            else if (rbnApproval.SelectedIndex == 1 && txtComment.Text.Trim() == "")
            {
                ShowMessage("Please provide a comment/note for the rejection of the plan.");
            }
            else if (rbnApproval.SelectedIndex == 2 && txtComment.Text.Trim() == "")
            {
                ShowMessage("Please provide a comment/note for the deletion of the plan.");
            }
            else
            {
                string ItemArr = GetItemsToSubmit().TrimEnd(',');

                if (ItemArr != "")
                {
                    string returned;
                    switch (rbnApproval.SelectedIndex)
                    {
                        case 0:
                            
                            //if (Session["IsAreaProcess"].ToString() == "0")
                            //    returned = Process.SubmitPlanItemsForApproval(ItemArr, 6, txtComment.Text);
                            //else
                                returned = Process.SubmitPlanItemsForApproval(ItemArr, 6, txtComment.Text);
                            break;
                        case 1:
                            returned = Process.SubmitPlanItemsForApproval(ItemArr, 3, txtComment.Text);
                            break;
                        case 2:
                            returned = Process.DeletePlanItems(ItemArr, 5, txtComment.Text, 1);
                            break;
                        default:
                            returned = "Please select items to be approved / rejected / deleted.";
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
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void ResetControls()
    {
        rbnApproval.SelectedIndex = -1;
        txtComment.Text = "";
        LoadItems();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SubmitPlanItems();
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
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SelectAllItems(CheckBox2.Checked);
            if (CheckBox2.Checked == true)
            {
                chkSelect.Checked = true;
            }
            else
            {
                chkSelect.Checked = false;
            }
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
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - All Procurement Types - -", "0"));
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string Plancode = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[2].Text;
            Session["PreviousPage"] = "Planning_PlanItems.aspx";
            ShowMessage(".");
            if (e.CommandName == "btnView")
            {
                Response.Redirect("Planning_PlanDetails.aspx?transferid=" + Plancode, true);
            }
            if (e.CommandName == "btnDetail")
            {
                //ShowMessage(Plancode);
                Response.Redirect("./Planning_ApproveItems.aspx?transferid=" + Plancode,true);
            }
            else if (e.CommandName == "btnFiles")
            {
                lblPlanCode.Text = Plancode;
                lblHeaderMsg.Text = Desc;
                cboProcType.Enabled = false;
                LoadDocuments();
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
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 0;
            cboProcType.Enabled = true;
            LoadItems();
            lblPlanCode.Text = "0";
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
                Process.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false,Session["FullName"].ToString());

            }
        }
    }
    protected void GridAttachments_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void cboQuarter_DataBound(object sender, EventArgs e)
    {
        cboQuarter.Items.Insert(0, new ListItem("- - All Quarters - -", "0"));
    }
    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        LoadItems();
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
    }
    private void ConfirmRemoveDocument(string FileCode)
    {
        lblFileCode.Text = FileCode;
        lblRemoveAtt.Text = "Are You Sure You Want To Delete Attachment?";
        MultiView1.ActiveViewIndex = 3;
    }
    protected void btnYesAtt_Click(object sender, EventArgs e)
    {
        Process.RemoveDocument(lblFileCode.Text.Trim());
        LoadDocuments();
        MultiView1.ActiveViewIndex = 1;
    }
    protected void btnNoAtt_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
}
