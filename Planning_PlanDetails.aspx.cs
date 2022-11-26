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

public partial class Planning_PlanDetails : System.Web.UI.Page
{

    ProcessPlanning Process = new ProcessPlanning();
    BusinessPlanning bll = new BusinessPlanning();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadControls();
        }
    }

    private void LoadDocuments()
    {
        string PlanID = txtPlanCode.Text.Trim();
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

    private void DisableControls(bool status)
    {
        foreach (Control c in Page.Controls)
            foreach (Control ctrl in c.Controls)
                if (ctrl is TextBox)
                   ((TextBox)ctrl).Enabled = status;
                else if (ctrl is RadioButton)
                    ((RadioButton)ctrl).Enabled = status;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Enabled = status;
    }

    private void LoadControls()
    {
        //TODO: Complete Loading of Plan and Add Audit Log
        string PlanCode = Request.QueryString["transferid"].ToString().Trim();

        dtable = Process.GetPlanItemForViewing(PlanCode);
        txtPlanCode.Text = dtable.Rows[0]["PlanCode"].ToString();

        bool IsGroup = Convert.ToBoolean(dtable.Rows[0]["IsGroupItem"].ToString());
        chbIsGroup.Checked = IsGroup;
        bool IsFrameWork = Convert.ToBoolean(dtable.Rows[0]["IsFramework"].ToString());
        chkIsFramework.Checked = IsFrameWork;
        txtProcType.Text = dtable.Rows[0]["ProcurementType"].ToString();
        txtProcMethod.Text = dtable.Rows[0]["Method"].ToString();
        txtPriorityRanking.Text = dtable.Rows[0]["ItemCategory"].ToString();
        txtItemCategoryType.Text = dtable.Rows[0]["CategoryType"].ToString();
        txtItemCategory.Text = dtable.Rows[0]["NonStockCategory"].ToString();
        txtFunding.Text = dtable.Rows[0]["Funding"].ToString();
        txtDescription.Text = dtable.Rows[0]["Description"].ToString();
        txtQuantity.Text = dtable.Rows[0]["Quantity"].ToString();
        txtQuater.Text = dtable.Rows[0]["Quarter"].ToString();
        txtDateWhenNeeded.Text = dtable.Rows[0]["DateWhenNeeded"].ToString();
        txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
        txtPP20Date.Text = dtable.Rows[0]["Date4PP20"].ToString();
        txtUnitCost.Text = Convert.ToDouble(dtable.Rows[0]["UnitCost"]).ToString("#,##0");
        txtMarketPrice.Text = Convert.ToDouble(dtable.Rows[0]["MarketPrice"]).ToString("#,##0");
        txtStatusLevel.Text = dtable.Rows[0]["StatusDesc"].ToString();
        lblStatusID.Text = dtable.Rows[0]["StatusID"].ToString();
        txtAuthority.Text = dtable.Rows[0]["Authority"].ToString();
        txtPlanRecorder.Text = dtable.Rows[0]["PlanRecordedBy"].ToString();
        txtUnits.Text = dtable.Rows[0]["Unit"].ToString();
        txtStockName.Text = dtable.Rows[0]["StockName"].ToString();

        DisableControls(false);
        PopulateGrid();
        LoadLogTransactions();

        MultiView1.ActiveViewIndex = 0;
    }

    private void PopulateGrid()
    {
        string PlanId = Request.QueryString["transferid"].ToString();
        DataTable dtReturnAttachments = Process.GetPlanDocuments(PlanId, "");

        int rowcount = dtReturnAttachments.Rows.Count;

        if (rowcount != 0)
        {
            GridAttachments.DataSource = dtReturnAttachments;
            GridAttachments.DataBind();
        }
    }

    private void LoadLogTransactions()
    {
        dtable = Process.GetPlanItemLogs(txtPlanCode.Text);
        dgPlanLog.DataSource = dtable;
        dgPlanLog.DataBind();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(Session["PreviousPage"].ToString() + "?transferid=1");
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

    protected void GridAttachments_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string filepath = Convert.ToString(GridAttachments.DataKeys[index].Value);

            if (e.CommandName == "ViewDetails")
            {
                DownloadFile(filepath, true);
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
                case ".rtf":
                    type = "Application/msword";
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

    protected void btnViewAttachments_Click(object sender, EventArgs e)
    {
        if (int.Parse(lblStatusID.Text) < 8 && Session["AccessLevelID"].ToString() != "3")
        {
            MultiView1.ActiveViewIndex = 2;
            LoadEditDocuments();
        }
        else
        {
            MultiView1.ActiveViewIndex = 3;
            LoadDocuments();
        } 
    }

    public void LoadEditDocuments()
    {
        string PlanID = txtPlanCode.Text.Trim();
        lblPlanCode.Text = PlanID;
        dtable = Process.GetPlanDocuments(PlanID, "");
        if (dtable.Rows.Count > 0)
        {
            GridView1.DataSource = dtable;
            GridView1.DataBind();
            GridView1.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            lblmsg.Visible = true;
            GridView1.Visible = false;
        }
    }

    protected void btnViewStatus_Click(object sender, EventArgs e)
    {   
        MultiView1.ActiveViewIndex = 1;
        LoadLogTransactions();
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            string Plancode = lblPlanCode.Text.Trim();
            UploadFiles(Plancode);
            LoadEditDocuments();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView1.DataKeys[intIndex].Value);
                ConfirmRemoveDocument(FileCode);
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView1.DataKeys[intIndex].Value);
                string Path = Process.GetDocumentPath(FileCode);
                DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
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
        MultiView1.ActiveViewIndex = 2;
    }
    protected void btnNoAtt_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }
}
