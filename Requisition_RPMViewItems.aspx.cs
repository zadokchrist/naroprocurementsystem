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
using System.Collections.Generic;
using System.Text;
public partial class Requisition_MDViewItems : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataSet dataSet = new DataSet();
    private string Status = "105";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadProcurmentTypes();
                if (Request.QueryString["transferid"] != null)
                {
                    string StatusToSelect = Request.QueryString["transferid"].ToString();
                    cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(StatusToSelect));
                }
                LoadItems();
                DataGrid1.CurrentPageIndex = 0;
                BindLoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadProcurmentTypes()
    {
        datatable = Process.GetRequisitionProcurementTypes();
        cboProcType.DataSource = datatable;
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
    }
    private void LoadItems()
    {
        string RecordID = "0";
        string ProcType = cboProcType.SelectedValue.ToString();
        string StartDate = txtStartDate.Text.Trim();
        string EndDate = txtEndDate.Text.Trim();
        datatable = Process.GetRequisitions(RecordID, ProcType, StartDate, EndDate, Status);
      }

    private void BindLoadItems()
    {
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            //for (int count = 0; count < datatable.Rows.Count; count++)
            //{
            //    double MktP = Convert.ToDouble(datatable.Rows[count]["MarketPrice"].ToString());
            //    string MktPrice = MktP.ToString("#,##0");
            //    datatable.Rows[count]["MarketPrice"] = MktPrice.ToString();
            //}
            foreach (DataRow dr in datatable.Rows)
            {
                dr["MarketPrice"] = Convert.ToDouble(dr["MarketPrice"]).ToString("#,##0");
                if (Convert.ToBoolean(dr["IsProject"].ToString()))
                {
                    dr["MarketPrice"] = 0.0;
                }
            }
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind();
            lblEmpty.Text = ".";
        }
        else
        {
            MultiView1.ActiveViewIndex = 1;
            string EmptyMessage = "No New requisition(s) in the system from Cost Center " + Session["CostCenterName"].ToString() + Environment.NewLine;
            EmptyMessage += "from " + bll.ReturnDate(txtStartDate.Text.Trim(), 1).ToString("dd-MMM-yyyy") + " to " + bll.ReturnDate(txtEndDate.Text.Trim(), 2).ToString("dd-MMM-yyyy");
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
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PDCode = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[2].Text;
            if (e.CommandName == "btnAction")
            {
                //ShowMessage(Plancode);
                Session["Status"] = cboProcType.SelectedValue.ToString();
                Response.Redirect("Requisition_Approval.aspx?transferid=" + RecordID, true);
            }
            else if (e.CommandName == "btnFiles")
            {
                lblPDCode.Text = PDCode;
                lblHeaderMsg.Text = Desc;
                btnOK.Enabled = false;
                txtStartDate.Enabled = false;
                txtEndDate.Enabled = false;
                cboProcType.Enabled = false;
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
        string PDCode = lblPDCode.Text.Trim();
        datatable = ProcessOthers.GetPlanDocuments("",PDCode);
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
            //string Plancode = lblPlanCode.Text.Trim();
            string PD_Code = lblPDCode.Text.Trim();
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
                FileField.PostedFile.SaveAs("D:\\Reports\\ProcurementAttachments\\" + c1);
                ProcessOthers.SavePlanDocuments(PlanCode, ("D:\\Reports\\ProcurementAttachments\\" + c1), c, false);
            }
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 0;
            cboProcType.Enabled = true;
            btnOK.Enabled = true;
            txtStartDate.Enabled = true;
            txtEndDate.Enabled = true;
            LoadItems();
            lblPDCode.Text = "0";
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
