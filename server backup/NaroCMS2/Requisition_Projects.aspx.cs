﻿using System;
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

public partial class Requisition_Projects : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataSet dataSet = new DataSet();
    private string Status = "14";
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
                LoadAreas();
                LoadItems();

            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadAreas()
    {
        datatable = ProcessOthers.GetAreas();
        cboAreas.DataSource = datatable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();

        if (Session["IsAreaProcess"].ToString() == "1")
        {
            cboAreas.Enabled = false;
            cboAreas.SelectedValue = Session["AreaCode"].ToString();
        }
        LoadCostCenters(cboAreas.SelectedValue);
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadCostCenters()
    {
        string AreaCode = Session["AreaCode"].ToString();
        datatable = ProcessOthers.GetCostCentersByName("", AreaCode);
        cboCostCenters.DataSource = datatable;
        cboCostCenters.DataValueField = "CostCenterID";
        cboCostCenters.DataTextField = "CostCenterDesc";
        cboCostCenters.DataBind();
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
        ShowMessage(".");
        string RecordID = "0";
        string ProcType = cboProcType.SelectedValue.ToString();
        string StartDate = txtStartDate.Text.Trim();
        string EndDate = txtEndDate.Text.Trim();
        string PrNumber = txtPrNumber.Text.Trim();
        string AreaCode = cboAreas.SelectedValue; string CostCenterCode = cboCostCenters.SelectedValue.ToString();
        //Session["AreaCode"].ToString();
        datatable = Process.GetAllCentersProjectRequisitionItems(RecordID, ProcType, StartDate, EndDate, Status, AreaCode, CostCenterCode,PrNumber);
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
            string EmptyMessage = "No New requisition(s) in the system from Cost Center (" + cboCostCenters.SelectedItem + ")" + Environment.NewLine;
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
    protected void cboCostCenter_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("- - All Cost Centers - -", "0"));
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        ShowMessage(".");
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PD_Code = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[3].Text;
            bool IsProject = Convert.ToBoolean(e.Item.Cells[6].Text.ToString());
            string CurrentYearRequsition = e.Item.Cells[7].Text.ToString().Trim();
            if (e.CommandName == "btnAction")
            {

                LoadProjectDetails(PD_Code);
            }
            else if (e.CommandName == "btnFiles")
            {
                lblPD_Code.Text = PD_Code;
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
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = ProcessOthers.GetPlanDocuments("", PD_Code);
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
    private void LoadProjectDetails(string PD_Code)
    {
        MultiView1.ActiveViewIndex = 3;
       // string PD_Code = lblPD_Code.Text.Trim();
        datatable = Process.GetProjects( PD_Code);
        if (datatable.Rows.Count > 0)
        {
            GridView1.DataSource = datatable;
            GridView1.DataBind();
            GridView1.Visible = true;
            Label2.Visible = false;
        }
        else
        {
            Label2.Visible = true;
            GridView1.Visible = false;
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
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - All Procurement Types - -", "0"));
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        string AreaID = cboAreas.SelectedValue.ToString();
        LoadCostCenters(AreaID);
    }
    private void LoadCostCenters(string AreaID)
    {
        string AreaCode = AreaID;
        datatable = ProcessOthers.GetCostCentersByName("", AreaCode);
        cboCostCenters.DataSource = datatable;
        cboCostCenters.DataValueField = "CostCenterID";
        cboCostCenters.DataTextField = "CostCenterDesc";
        cboCostCenters.DataBind();
    }
    protected void cboAreas_DataBound(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem(" -- All Areas -- ", "0"));
    }
}