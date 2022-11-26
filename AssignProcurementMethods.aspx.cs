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
public partial class Requisition_InventoryViewItems : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataSet dataSet = new DataSet();
    DataLogin data = new DataLogin();
    private string Status = "20";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadProcurementMethods();
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadProcurementMethods()
    {
        cboProcurementMethod.DataSource = ProcessOthers.GetProcurementMethods();
        cboProcurementMethod.DataValueField = "MethodCode";
        cboProcurementMethod.DataTextField = "Method";
        cboProcurementMethod.DataBind();
    }
    private void LoadItems()
    {
        string RecordID = "0";
        string StartDate = txtStartDate.Text.Trim();
        string EndDate = txtEndDate.Text.Trim();
        string PDUCategory = cboPDUCategory.SelectedValue.ToString();
        string ProcMethod = cboProcurementMethod.SelectedValue.ToString();
        string PrNumber = txtPrNumber.Text.Trim();
        string access = Session["AccessLevelID"].ToString();
        if (access == "3")//PM
        {
            int statusid = 45;
            cboPDUCategory.Enabled = true;
            datatable = Process.GetGetActivityPlansApprovedByMd(RecordID, PrNumber, StartDate, EndDate, PDUCategory, ProcMethod, statusid);
        }

        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind();
            lblEmpty.Text = ".";
        }
        else
        {
            MultiView1.ActiveViewIndex = 1;
            string EmptyMessage = "No New Activity Schedule(s) in the system from PDU (" + cboPDUCategory.SelectedItem + ")" + Environment.NewLine;
            EmptyMessage += "from " + bll.ReturnDate(StartDate, 1).ToString("dd-MMM-yyyy") + " to " + bll.ReturnDate(EndDate, 2).ToString("dd-MMM-yyyy");
            lblEmpty.Text = EmptyMessage;
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
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PD_Code = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[2].Text;
            if (e.CommandName == "btnAction")
            {
                //ShowMessage(Plancode);
                Session["Status"] = "";//cboProcType.SelectedValue.ToString();
                Response.Redirect("./AssignProcMethods.aspx?transferid=" + RecordID, true);
            }
            else if (e.CommandName == "btnFiles")
            {
                lblPD_Code.Text = PD_Code;
                lblHeaderMsg.Text = Desc;
                btnOK.Enabled = false;
                txtStartDate.Enabled = false;
                txtEndDate.Enabled = false;
                //cboProcType.Enabled = false;
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
        MultiView1.ActiveViewIndex = 2;
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = ProcessOthers.GetPlanDocuments("",PD_Code);
        if (datatable.Rows.Count > 0)
        {
            GridAttachments.DataSource = datatable;
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
        try
        {
            MultiView1.ActiveViewIndex = 0;
            //cboProcType.Enabled = true;
            btnOK.Enabled = true;
            txtStartDate.Enabled = true;
            txtEndDate.Enabled = true;
            LoadItems();
            lblPD_Code.Text = "0";
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
                ProcessOthers.RemoveDocument(FileCode);
                LoadDocuments();
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                string Path = ProcessOthers.GetDocumentPath(FileCode);
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
    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            string PD_Code = lblPD_Code.Text.Trim();
            UploadFiles(PD_Code);
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
                ProcessOthers.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false);

            }
        }
    }

    protected void cboProcurementMethod_DataBound(object sender, EventArgs e)
    {
        cboProcurementMethod.Items.Insert(0, new ListItem(" -- Select Procurement Method -- ", "0"));
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
}
