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

public partial class Planning_PendingItems : System.Web.UI.Page
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
                LoadAreaManagers();
                LoadPlanItems();
                DisableBtnsOnClick();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        Button1.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(Button1, "").ToString());
        btnSubmitComment.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnSubmitComment, "").ToString());
        btnSaveFile.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnSaveFile, "").ToString());
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

    private void LoadAreaManagers()
    {

        if (Session["IsAreaProcess"].ToString() == "1")
        {
            cboAreaManagers.DataSource = Process.GetAreaManagers();
            cboTopAreaManagers.DataSource = Process.GetAreaManagers();
        }
        else
        {
            cboAreaManagers.DataSource = Process.GetDefaultCCManager();
            cboTopAreaManagers.DataSource = Process.GetDefaultCCManager();
        }

        cboAreaManagers.DataValueField = "UserID";
        cboAreaManagers.DataTextField = "FullName";
        cboAreaManagers.DataBind();

        cboTopAreaManagers.DataValueField = "UserID";
        cboTopAreaManagers.DataTextField = "FullName";
        cboTopAreaManagers.DataBind();
    }

    private void LoadPlanItems()
    {
        MultiView1.ActiveViewIndex = 0;
        string Search = txtSearch.Text.Trim();
        string ProcTypeCode = cboProcType.SelectedValue.ToString();
        string QuarterCode = cboQuarter.SelectedValue.ToString();
        string CostCenterID = Session["CostCenterID"].ToString();
        string LoggedIn = Session["UserID"].ToString();

        dtable = Process.GetPlanItemsToSubmit(Search, ProcTypeCode, QuarterCode, CostCenterID, LoggedIn);
        if (dtable.Rows.Count == 0)
            dtable = Process.GetPlanItemsToSubmit(Search, ProcTypeCode, QuarterCode, "", LoggedIn);

        if (dtable.Rows.Count != 0)
        {
            DataTable manager = Process.GetDefaultCCManager();
            if (manager.Rows.Count > 0)
            {
                string ManagerName = manager.Rows[0]["FullName"].ToString();
                cboAreaManagers.SelectedIndex = cboAreaManagers.Items.IndexOf(cboAreaManagers.Items.FindByText(ManagerName));
                cboTopAreaManagers.SelectedIndex = cboTopAreaManagers.Items.IndexOf(cboAreaManagers.Items.FindByText(ManagerName));
            }

            DataGrid1.DataSource = dtable;
            DataGrid1.DataBind();
        }
        else
        {
            string EmptyMessage = "No Pending Plan Item(s) Found In The System ";
            lblEmpty.Text = EmptyMessage;
            MultiView1.ActiveViewIndex = 3;
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (cboAreaManagers.SelectedValue == "0")
                ShowMessage("Please select Manager to submit selected plan items to");
            else
            {
                ShowMessage(".");
                SubmitPlanItems();
            }
            LoadPlanItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void SubmitPlanItems()
    {
        string ItemArr = GetItemsToApprove().TrimEnd(',');
        int Status = 2;
        int CCManagerID = int.Parse(cboAreaManagers.SelectedValue.ToString());
        string CCManager = cboAreaManagers.SelectedItem.Text.ToString();
        string returned = Process.SubmitPlanItems(ItemArr, CCManagerID, CCManager, Status);
        ShowMessage(returned);
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
                string ItemFound = Items.Cells[3].Text;
                ItemArr = ItemArr += ItemFound + ",";
            }
        }
        return ItemArr;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            LoadPlanItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - All Procurement Types - -", "0"));
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

    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SelectAllItems();
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
    private void SelectAllItems()
    {
        foreach (DataGridItem Items in DataGrid1.Items)
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
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SelectAllItems();
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
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string Plancode = e.Item.Cells[3].Text;
            string Desc = e.Item.Cells[4].Text;
            //double Marketprice =Double.Parse(e.Item.Cells[9].Text).ToString();

            Session["PreviousPage"] = "Planning_PendingItems.aspx";
            ShowMessage(".");
            if (e.CommandName == "btnView")
            {
                Response.Redirect("Planning_PlanDetails.aspx?transferid=" + Plancode, true);
            }
            if (e.CommandName == "btnFiles")
            {
                lblPlanCode.Text = Plancode;
                lblHeaderMsg.Text = Desc;
                cboProcType.Enabled = false;
                LoadDocuments();
            }
            else if (e.CommandName == "btnEdit")
            {
                Session["PreviousPage"] = "Planning_PendingItems.aspx";
                Session["Status"] = cboProcType.SelectedValue;
                Response.Redirect("Planning_AddPlan.aspx?transferid=" + Plancode, true);
            }
            else if (e.CommandName == "btnDelete")
            {
                lblDeleteHeader.Text = String.Format("Delete Plan: {0}", Plancode);
                lblDeletePlanLabel.Text = Plancode;
                lblDeleteStatusLabel.Text = "2"; // StatusID;
                MultiView1.ActiveViewIndex = 2;
                ShowMessage(".");
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
    protected void GridAttachments_RowCreated(object sender, GridViewRowEventArgs e)
    {

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
                //Process.RemoveDocument(FileCode);
                //LoadDocuments();
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
    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            string Plancode = lblPlanCode.Text.Trim();
            UploadFiles(Plancode);
            LoadDocuments();
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
            //MultiView1.ActiveViewIndex = 1;
            //cboStatus.SelectedIndex = cboStatus.Items.IndexOf(cboStatus.Items.FindByValue("2"));
            cboProcType.Enabled = true;
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
                Process.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false);
            }
        }
    }
    protected void GridAttachments_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cboQuarter_DataBound(object sender, EventArgs e)
    {
        cboQuarter.Items.Insert(0, new ListItem("- - All Quarters - -", "0"));
    }

    protected void btnReturnToView_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnSubmitComment_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtComment.Text == "")
                ShowMessage("Please enter comment for deletion of the plan");
            else
            {
                ShowMessage(".");
                btnSubmitComment.Enabled = false;
                string PlanCode = lblDeletePlanLabel.Text;
                string returned = Process.DeletePlanItem(PlanCode, 2, txtComment.Text);
                ResetDeletionControls();
                ShowMessage(returned);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ResetDeletionControls()
    {
        txtComment.Text = "";
        btnSubmitComment.Enabled = true;
        lblDeletePlanLabel.Text = "";
        ShowMessage(".");
        LoadPlanItems();
    }

    protected void cboAreaManagers_DataBound(object sender, EventArgs e)
    {
        cboAreaManagers.Items.Insert(0, new ListItem(" -- Select Manager -- ", "0"));
    }

    protected void cboTopAreaManagers_DataBound(object sender, EventArgs e)
    {
        cboTopAreaManagers.Items.Insert(0, new ListItem(" -- Select Manager -- ", "0"));
    }

    protected void cboTopAreaManagers_SelectedIndexChanged(object sender, EventArgs e)
    {
        cboAreaManagers.SelectedIndex = cboTopAreaManagers.SelectedIndex;
    }
    protected void cboAreaManagers_SelectedIndexChanged(object sender, EventArgs e)
    {
        cboTopAreaManagers.SelectedIndex = cboAreaManagers.SelectedIndex;
    }
    protected void cboTopAreaManagers_SelectedIndexChanged1(object sender, EventArgs e)
    {
        cboAreaManagers.SelectedIndex = cboTopAreaManagers.SelectedIndex;
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
        MultiView1.ActiveViewIndex = 1;
    }
    protected void btnNoAtt_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
}
