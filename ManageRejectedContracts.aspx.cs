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

public partial class ManageRejectedContracts : System.Web.UI.Page
{
    ProcessUsers Process = new ProcessUsers();
    ProcessRequisition ProcessREQ = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    DataLogin data = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        msg.Text = ".";
        try
        {
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                LoadItems();
                //LoadWorkFlows();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadItems()
    {
        ProcessRequisition Process2 = new ProcessRequisition();
        string RecordID = "0";
        string contractype = "0";
        string StartDate = "";
        string EndDate = "";
        if (string.IsNullOrEmpty(StartDate))
        {
            StartDate = DateTime.Parse("01/11/2022").ToString();
        }

        if (string.IsNullOrEmpty(EndDate))
        {
            EndDate = DateTime.Parse("01/11/2025").ToString();
        }
        dataTable = Process2.GetUploadedContractsRejected(contractype, StartDate, EndDate);
        DataGrid1.DataSource = dataTable;
        DataGrid1.DataBind();
    }

    private void LoadWorkFlows()
    {
        dataTable = data.GetAllWorkFlows("0");
        GridWorkFLow.DataSource = dataTable;
        GridWorkFLow.DataBind();
    }
    protected void cboCCcategory_DataBound(object sender, EventArgs e)
    {
    }



    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            string Name = txtCcCode.Text.Trim();
            bool Active = CheckBox1.Checked;
            string flowid = workflowid.Text;
            Process.UpdateWorkFlowDetails(Name, Active, flowid);
            ShowMessage("Workflow (" + Name + ") has been updated successfull......");
            clearControls();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void saveDetails()
    {
        try
        {
            int ccid = Convert.ToInt32(lblcode.Text.Trim());
            string CostCenterCode = txtCcCode.Text.Trim();
            string compareCode = lblCcCode.Text.Trim();
            string compareInitials = lblInitials.Text.Trim();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void loadForm()
    {
        try
        {
            MultiView1.ActiveViewIndex = 1;
            dataTable = data.GetAllWorkFlows(workflowid.Text.Trim());
            txtCcCode.Text = dataTable.Rows[0]["WorkFlowName"].ToString();

            bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["IsActive"].ToString());
            CheckBox1.Checked = IsActive;

        }
        catch (Exception ex)
        {
            Label msg = (Label)Master.FindControl("lblmsg");
            msg.Text = "MESSAGE: " + ex.Message;
        }
    }
    protected void GridCCenter_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
   

    private void LoadLogs(string workflowid)
    {
        MultiView1.ActiveViewIndex = 4;
        dataTable = ProcessREQ.GetLogs(workflowid);
        DataGrid2.DataSource = dataTable;
        DataGrid2.DataBind();
    }

    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            string contractid = e.Item.Cells[0].Text;
            string flowid = e.Item.Cells[1].Text;
            if (e.CommandName == "btnFiles")
            {
                contid.Text = contractid;
                LoadDocuments(contractid);
            }
            else if (e.CommandName == "btnStatus")
            {
                LoadLogs(contractid);
            }
            else if (e.CommandName == "btnApprove")
            {
                workflowid.Text = flowid;
                contid.Text = contractid;
                MultiView1.ActiveViewIndex = 5;
            }
            else if (e.CommandName.Equals("btnMileStones"))
            {
                MultiView1.ActiveViewIndex = 6;
                contraid.Text = contractid;
                DataGrid3.DataSource = data.GetMileStonesByContractId(contractid);
                DataGrid3.DataBind();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridWorkFlow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnEdit")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                workflowid.Text = GridWorkFLow.DataKeys[intIndex].Value.ToString();
                loadForm();
            }
            else if (e.CommandName == "btnFiles")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                workflowid.Text = GridWorkFLow.DataKeys[intIndex].Value.ToString();
                LoadDocuments(workflowid.Text);
            }
            else if (e.CommandName == "btnStatus")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                workflowid.Text = GridWorkFLow.DataKeys[intIndex].Value.ToString();
                //LoadLogs();
            }
            
            else if (e.CommandName == "btnAction")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                workflowid.Text = GridWorkFLow.DataKeys[intIndex].Value.ToString();
                MultiView1.ActiveViewIndex = 5;
            }

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadDocuments(string PDCode)
    {
        MultiView1.ActiveViewIndex = 3;
        
        dataTable = ProcessOthers.GetPlanDocuments("", PDCode);
        if (dataTable.Rows.Count > 0)
        {
            DataGridAttachments.DataSource = dataTable;
            DataGridAttachments.DataBind();
            DataGridAttachments.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            lblmsg.Visible = true;
            DataGridAttachments.Visible = false;
        }
    }

    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            //string Plancode = lblPlanCode.Text.Trim();
            string PD_Code = contid.Text.Trim();
            LoadDocuments(PD_Code);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void cboSendTo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSubmitRequistn_Click(object sender, EventArgs e)
    {
        try
        {

            string userid = Session["UserID"].ToString();
            string description = txtComment.Text;
            dataTable = data.GetStatusesByWorkflowid(workflowid.Text);
            string currentstatus = dataTable.Rows[0]["StatusID"].ToString();
            var rows = dataTable.Select("StatusID="+ currentstatus);
            var indexOfRow = dataTable.Rows.IndexOf(rows[0]);
            string nextStatus = "";
            if (rbnApproval.SelectedIndex==0)
            {
                nextStatus = data.GetRejectedPrevStatus(contid.Text).Rows[0]["PrevStatus"].ToString();
            }
            else
            {
            }
            data.NextContractStatus(contid.Text, workflowid.Text, description, userid, nextStatus);
            data.RemoveRejection(contid.Text);
            txtComment.Text = "";
            ShowMessage("Contract Moved to the next stage");
            MultiView1.ActiveViewIndex = 0;
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
            //string Plancode = e.Item.Cells[1].Text;
            string PD_Code = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[3].Text;
            if (e.CommandName == "btnPrint")
            {
                //ShowMessage(Plancode);
                //lblPD_Code.Text = PD_Code;
                //LoadReport();
            }
            else if (e.CommandName == "btnStatus")
            {
                //lblPD_Code.Text = PD_Code;
                //LoadLogs();
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
            //cboProcType.Enabled = true;
            btnOK.Enabled = true;
            //txtStartDate.Enabled = true;
            //txtEndDate.Enabled = true;
            LoadItems();
            //lblPDCode.Text = "0";
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void DataGridAttachments_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            string FileCode = e.Item.Cells[0].Text;
            if (e.CommandName == "btnRemove")
            {
                ProcessOthers.RemoveDocument(FileCode);
                LoadDocuments(contid.Text);
            }
            else
            {
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
    private void clearControls()
    {
        txtCcCode.Text = "";
        txtAName.Text = "";
        txtCcCode.Text = "";
        lblcode.Text = "0";
        CheckBox2.Checked = false;
        CheckBox1.Checked = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearControls();
        LoadItems();
        MultiView1.ActiveViewIndex = 0;



    }
    protected void GridCCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridWorkFLow.PageIndex = newPageIndex;
            LoadWorkFlows();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadWorkFlows();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }







    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {
            string Name = txtAName.Text.Trim();
            string CostCenterID = lblCenterID.Text.Trim();
            bool Active = CheckBox2.Checked;
            Process.SaveWorkFlowDetails(Name, Active);

            ShowMessage("Workflow (" + Name + ") has been added successfull......");
            clearControls();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        lblCenterID.Text = "0";
    }

    protected void DataGrid3_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            string RecordID = e.Item.Cells[0].Text;
            if (e.CommandName == "btnDownloadFile")
            {
                milestoneid.Text = RecordID;
                string Path = data.GetMilestoneDocumentPath(milestoneid.Text).Rows[0]["FilePath"].ToString();
                DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    



}
