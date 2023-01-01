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

public partial class Requisition_ViewItems : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
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
                    string StatusToSelect = Request.QueryString["transferid"].ToString();
                    cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(StatusToSelect));
                    LoadItems();
                }
                else if (Request.QueryString["transferStatus"] != null)
                {
                    string formerStatus = Session["Status"].ToString();
                    string formerType = Session["SelectedType"].ToString();
                    cboStatus.SelectedIndex = cboStatus.Items.IndexOf(cboStatus.Items.FindByValue(formerStatus));
                    cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(formerType));
                    LoadItems();
                }
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
        string Level = cboStatus.SelectedValue.ToString();
        string StartDate = txtStartDate.Text.Trim();
        string EndDate = txtEndDate.Text.Trim();
        datatable = Process.GetRequisitionItems(RecordID, ProcType, StartDate, EndDate, Level);
        int ViewToCall = -1;
        if (Level == "1") {
            ViewToCall = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind();
        }else if (Level == "2") {
            ViewToCall = 1;
            DataGrid2.DataSource = datatable;
            DataGrid2.DataBind();
        }
        else if (Level == "3")
        {
            ViewToCall = 4;
            DataGrid3.DataSource = datatable;
            DataGrid3.DataBind();
        }
        
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = ViewToCall;
            lblEmpty.Text = ".";
        }
        else
        {
            string EmptyMessage = "";
            MultiView1.ActiveViewIndex = 3;
            if (Level == "0")
            {
                EmptyMessage = "Please Select the Status of Requisition(s) you want to view";
            }
            else
            {
                EmptyMessage = "No " + cboStatus.SelectedItem + " Requisition(s) in the System for Cost Center " + Session["CostCenterName"].ToString() + Environment.NewLine;
                EmptyMessage += "from " + bll.ReturnDate(StartDate, 1).ToString("dd-MMM-yyyy") + " to " + bll.ReturnDate(EndDate, 2).ToString("dd-MMM-yyyy");
                
            }
            lblEmpty.Text = EmptyMessage;
        }
        CheckBox3.Checked = false;
        chkSelect.Checked = false;

        LoadAreaManagers();
    }

    private void LoadAreaManagers()
    {
        cboAreaManagers.DataSource = ProcessOthers.GetAreaManagers();
        cboAreaManagers.DataValueField = "UserID";
        cboAreaManagers.DataTextField = "FullName";
        cboAreaManagers.DataBind();
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
        ShowMessage(".");
        if (cboStatus.SelectedValue.ToString() == "0")
        {
            ShowMessage("Please Select the Status of Requisition(s) you want to view");
        }
        try
        {
            LoadItems(); 
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
                Session["Status"] = cboProcType.SelectedValue.ToString();
                Response.Redirect("Requisition_Approval.aspx?transferid=" + RecordID, true);
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
            else if (e.CommandName == "btnStatus")
            {
                Session["Type"] = cboProcType.SelectedValue.ToString();
                Session["Status"] = cboStatus.SelectedValue.ToString();
                lblPD_Code.Text = PD_Code;
                LoadLogs();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadLogs()
    {
        btnOK.Enabled = false;
        cboStatus.Enabled = false;
        cboProcType.Enabled = false;
        MultiView1.ActiveViewIndex = 6;
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = Process.GetLogs(PD_Code);
        DataGrid4.DataSource = datatable;
        DataGrid4.DataBind();
    }
    protected void btnResubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string ItemArr = GetItemsToResubmit().TrimEnd(',');
            string Comment = TextBox1.Text.Trim();
            string returned = Process.ResubmitRequisitionItems(ItemArr, Comment);
            cboStatus.SelectedIndex = cboStatus.Items.IndexOf(cboStatus.Items.FindByValue("2"));
            LoadItems();
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
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        ShowMessage(".");
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PD_Code = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[2].Text;
            bool IsGrouped = Convert.ToBoolean(e.Item.Cells[3].Text);
            string StatusID = e.Item.Cells[4].Text;
            string PlanCode = e.Item.Cells[7].Text;
            if (e.CommandName == "btnEdit")
            {
                Session["Status"] = cboStatus.SelectedValue.ToString();
                Session["SelectedType"] = cboProcType.SelectedValue.ToString();
                if (!IsGrouped)
                    Response.Redirect("Requisition_EditRequisition.aspx?transferid=" + RecordID, true);
                else
                    Response.Redirect("Requisition_EditGroupRequisition.aspx?transferid=" + RecordID, true);
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
            else if (e.CommandName == "btnRemark")
            {

            }
            else if (e.CommandName == "btnDelete")
            {
                lblDeleteReqLabel.Text = PD_Code;
                lblDeleteStatusLabel.Text = StatusID;
                lblPlanCode.Text = PlanCode; 
                lblDesc.Text = Desc;
                Session["PreviousView"] = "Rejected";
                MultiView1.ActiveViewIndex = 7;
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
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SelectAllItems();
            if (CheckBox3.Checked == true)
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
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SelectAllItems();
            if (chkSelect.Checked == true)
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
            btnOK.Enabled = true;
            txtStartDate.Enabled = true;
            txtEndDate.Enabled = true;
            cboProcType.Enabled = true;
            LoadItems();
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
                ProcessOthers.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false, Session["FullName"].ToString());

            }
        }
    }
    protected void DataGrid3_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        ShowMessage(".");
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PD_Code = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[2].Text;
            string StatusID = e.Item.Cells[6].Text;
            string RequistionType = e.Item.Cells[5].Text;
            bool IsGrouped = Convert.ToBoolean(e.Item.Cells[7].Text);
            if (e.CommandName == "btnAction")
            {
                //ShowMessage(Plancode);
                Session["Status"] = cboStatus.SelectedValue.ToString();
                Response.Redirect("Requisition_Approval.aspx?transferid=" + RecordID, true);
            }
            else if (e.CommandName == "btnEdit")
            {
                Session["Status"] = cboStatus.SelectedValue.ToString();
                Session["SelectedType"] = cboProcType.SelectedValue.ToString();

                if (!IsGrouped)
                    Response.Redirect("Requisition_EditRequisition.aspx?transferid=" + RecordID, true);
                else
                    Response.Redirect("Requisition_EditGroupRequisition.aspx?transferid=" + RecordID, true);
            }
            else if (e.CommandName == "btnForward")
            {
                lblForwardHeader.Text = "Forward Requisition : " + PD_Code;
                lblPD_CodeLabel.Text = PD_Code;
                lblStatusLabel.Text = StatusID;
                lblRequisitionType.Text = RequistionType;
                MultiView1.ActiveViewIndex = 5;

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
            else if (e.CommandName == "btnDelete")
            {
                lblDeleteStatusLabel.Text = StatusID;
                lblDesc.Text = Desc;
                lblDeleteReqLabel.Text = PD_Code;
                Session["PreviousView"] = "Pending";
                MultiView1.ActiveViewIndex = 7;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        try
        {
            cboStatus.Enabled = true;
            cboProcType.Enabled = true;
            btnOK.Enabled = true;
            string formerStatus = Session["Status"].ToString();
            string formerType = Session["Type"].ToString();
            cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(formerType));
            cboStatus.SelectedIndex = cboStatus.Items.IndexOf(cboStatus.Items.FindByValue(formerStatus));
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadStatusReport()
    {
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = Process.GetReportLogs(PD_Code);

        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\PRStatus.rpt";
        //doc.Load(rptName);
        //doc.SetDataSource(datatable);
        //Hidetoolbar();
        //CrystalReportViewer1.ReportSource = doc;

    }
    private void Hidetoolbar()
    {
        //CrystalReportViewer1.HasCrystalLogo = false;
        //CrystalReportViewer1.HasRefreshButton = false;
        //CrystalReportViewer1.HasExportButton = false;
        //CrystalReportViewer1.HasPrintButton = false;
        //CrystalReportViewer1.HasPageNavigationButtons = false;
        //CrystalReportViewer1.HasSearchButton = false;
        //CrystalReportViewer1.HasGotoPageButton = false;
        //CrystalReportViewer1.HasZoomFactorList = false;
        //CrystalReportViewer1.HasToggleGroupTreeButton = false;
    }
   
    private void PrintStatusReport()
    {
        LoadStatusReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Status");

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            PrintStatusReport();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnReturnToView_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
    }

    protected void btnSubmitComment_Click(object sender, EventArgs e)
    {
        try
        {
            if (cboAreaManagers.SelectedValue.ToString() == "0")
                ShowMessage("Please Select Area Manager to forward Requisition");
            else if (txtComment.Text.Trim() == "")
                ShowMessage("Please Enter Comment for Forwarding the Requisition");
            else
            {
                int CCManagerID = int.Parse(cboAreaManagers.SelectedValue.ToString());
                string CCManager = cboAreaManagers.SelectedItem.Text.ToString();
                int StatusID = Convert.ToInt32(lblStatusLabel.Text.Trim());
                Process.ForwardRequisition(lblPD_CodeLabel.Text.Trim(), StatusID, "Forwarded to " + CCManager + " with comment : " + txtComment.Text.Trim(), CCManagerID, CCManager);
                MultiView1.ActiveViewIndex = 4;
                AlertManager(lblPD_CodeLabel.Text.Trim());
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void AlertManager(string PD_Code)
    {
        DataTable dtAlert = Process.GetRequisitionerAndCCManager(PD_Code);
        string Subject = dtAlert.Rows[0]["Subject"].ToString();

        int CCManagerID = int.Parse(cboAreaManagers.SelectedValue.ToString());
        string CCManager = cboAreaManagers.SelectedItem.Text.ToString();
        string By = HttpContext.Current.Session["FullName"].ToString();

        string RequisitionType = "NORMAL REQUISITION ";
        if (RequisitionType == "2")
            RequisitionType = "EMERGENCY REQUISITION";
        string Message = ""; // "<p> " + RequisitionType + "</p>";
        //Message += "<p>Hello " + CCManager + " , </p>";
        Message += "<p>You have been forwarded a Requisition <strong> " + Subject + " By " + By + " </strong> for Approval. </p>";
        Message += "<p>For more details: please access the link: http://192.168.8.110:4070/procurement/  to login. ";

        ProcessOthers.NotifyManager(By, "Forwarded Requisition", CCManagerID, Message);
    }

    protected void cboAreaManagers_DataBound(object sender, EventArgs e)
    {
        cboAreaManagers.Items.Insert(0, new ListItem("-- Select Area Manager --", "0"));
    }
    protected void btnDeleteReq_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        try
        {
            if (txtDeleteComment.Text == "")
                ShowMessage("Please Enter Comment For Deleting The Requistion");
            else
            {
                ShowMessage(".");
                btnDeleteReq.Enabled = false;
                string PD_Code = lblDeleteReqLabel.Text.Trim();
                string planCode = lblPlanCode.Text;
                int StatusID = Convert.ToInt32(lblDeleteStatusLabel.Text.Trim());
                string returned = Process.DeleteRequisition(PD_Code,planCode ,StatusID, txtDeleteComment.Text.Trim());
                ResetDeletionControls();
                ShowMessage(returned);
                if (Session["PreviousView"] == "Rejected")
                    MultiView1.ActiveViewIndex = 1;
                else
                    MultiView1.ActiveViewIndex = 4;
                LoadItems();
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
        btnDeleteReq.Enabled = true;
        lblDeleteReqLabel.Text = "";
        lblDeleteStatusLabel.Text = "";
        lblDesc.Text = "";
        ShowMessage(".");
    }

    protected void btnCancelDelete_Click(object sender, EventArgs e)
    {
        ShowMessage("Deletion Has Been Cancelled ...");
        if (Session["PreviousView"] == "Rejected")    
            MultiView1.ActiveViewIndex = 1;
        else
            MultiView1.ActiveViewIndex = 4;
        LoadItems();
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //}
    }
}
