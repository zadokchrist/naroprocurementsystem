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

public partial class Requisition_RankApproval : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();
    private string Status = "24";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                if (Request.QueryString["transferid"] != null)
                {
                    string RecordCode = Request.QueryString["transferid"].ToString();
                    lblRecordCode.Text = RecordCode;
                    string RecordID = lblRecordCode.Text.Trim();
                    LoadControls(RecordID);
                }
                else
                {
                    Response.Redirect("Requisition_ManagerViewItems.aspx", true);
                }
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
    private void LoadControls(string RecordID)
    {
        MultiView1.ActiveViewIndex = 0;
        string Access = Session["AccessLevelID"].ToString();
        AssignStatus(Access);
        dtable = Process.GetRequisitions(RecordID, "0", "", "", Status);
        txtEntityCode.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtProcType.Text = dtable.Rows[0]["ProcurementType"].ToString();
        txtProcSubject.Text = dtable.Rows[0]["Subject"].ToString();
        txtRequisitionType.Text = dtable.Rows[0]["Type"].ToString();
        txtDeliveryLocation.Text = dtable.Rows[0]["Location"].ToString();
        txtRequisitioner.Text = dtable.Rows[0]["Requisitioner"].ToString();
        txtDateRequired.Text = dtable.Rows[0]["DateRequired"].ToString();
        txtDateRequisitioned.Text = dtable.Rows[0]["CreationDate"].ToString();
        txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
        lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
        lblCostCenter.Text = dtable.Rows[0]["CostCenterCode"].ToString();
        lblCostCenterID.Text = dtable.Rows[0]["CostCenterID"].ToString();
        lblAreaID.Text = dtable.Rows[0]["AreaID"].ToString();

        if (Session["AccessLevelID"].ToString() == "5")
        {
            MultiView2.ActiveViewIndex = -1;
        }
        else
        {
            MultiView2.ActiveViewIndex = 0;
        }
        LoadPDItems();
    }

    private void AssignStatus(string Access)
    {
       Status = "24";
    }

    private void LoadPDItems()
    {
        string PD_Code = lblPDCode.Text.Trim();
        lblPDDesc.Text = "List of Item(s) for Procurement Entitled: " + txtProcSubject.Text;
        dtable = Process.GetPD_CodeItems(PD_Code);
        dtable.Columns.Remove("StockCode"); dtable.Columns.Remove("StockName");
        dtable.Columns.Remove("IsStockItem"); dtable.Columns.Remove("NumberOfItems");
        GridItems.DataSource = dtable;
        GridItems.DataBind();
        if (dtable.Rows.Count > 0)
        {
            string Total = GetTotal(dtable);
            lblTotal.Visible = true;
            lblTotal.Text = "GRAND TOTAL AMOUNT : " + Total;
        }
        else
        {
            lblTotal.Visible = false;
            lblTotal.Text = ".";
        }
    }
    private string GetTotal(DataTable dt)
    {
        double total = 0;
        string Returnamount = "";
        foreach (DataRow dr in dt.Rows)
        {
            double amount = Convert.ToDouble(dr["TotalCost"]);
            total += amount;
        }
        Returnamount = total.ToString("#,##0");
        return Returnamount;
    }
    protected void btnShowHideFiles_Click(object sender, EventArgs e)
    {
        try
        {
            lblHeaderMsg.Text = txtProcSubject.Text;
            LoadDocuments();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnSubmitRequistn_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            string selectedstatus = GetSelectedStatus();
            if (selectedstatus == "0")
            {
                ShowMessage("Please select the Approval Option.......");
            }
            else if (selectedstatus != "1" && txtComment.Text.Trim() == "")
            {
                ShowMessage("Please enter your Comment.......");
            }
            else if (Session["AccessLevelID"].ToString() == "1")
            {
                ShowMessage("Administrative Account cannot approve any requisition in the system");
            }
            else
            {
                //ShowMessage("Submitted successfully.....");
                // Call ManagerAction
                string PDCode = lblPDCode.Text.Trim();
                string remark = txtComment.Text.Trim();
                string CostCenterID = lblCostCenterID.Text.Trim();
                string CostCenterName = txtBudgetCostCenter.Text.Trim();
                string AreaCode = lblAreaID.Text.Trim();
                string Subject = txtProcSubject.Text.Trim();
                string DateRequired = txtDateRequired.Text.Trim();
                string Location = txtDeliveryLocation.Text.Trim();
                string CostCenterCode = lblCostCenter.Text.Trim();
                string amount = GetRequisitionAmount().ToString();
                string returned = Process.RankApproving(PDCode, Convert.ToDouble(amount), selectedstatus, remark, CostCenterID,
                    CostCenterName, AreaCode);
                ShowMessage(returned);
                MultiView1.ActiveViewIndex = 2;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Failure sending mail."))
            {
                ShowMessage("Submitted successfully, However Mail sending to Requisitioner failed. Please Contact System Admin");
            }
            else
            {
                ShowMessage(ex.Message);
            }
        }

    }
    private double GetRequisitionAmount()
    {
        string PD_Code = lblPDCode.Text.Trim();
        dtable = Process.GetPD_CodeItems(PD_Code);
        double Total = 0;
        if (dtable.Rows.Count > 0)
        {
            Total = Convert.ToDouble(GetTotal(dtable).Replace(",", ""));
        }
        return Total;
    }
    private string GetSelectedStatus()
    {
        string status = "0";
        foreach (ListItem lst in rbnApproval.Items)
        {
            if (lst.Selected == true)
            {
                status = lst.Value;
            }
        }

        return status;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            string RecordID = lblRecordCode.Text.Trim();
            LoadControls(RecordID);
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
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 1;
        string PD_Code = lblPDCode.Text.Trim();
        dtable = ProcessOthers.GetPlanDocuments("", PD_Code);
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
    protected void btnNo_Click(object sender, EventArgs e)
    {

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            LoadPDItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            string RecordID = lblRecordCode.Text.Trim();
            LoadControls(RecordID);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        try
        {
            string PreviousStatus = Session["Status"].ToString();
            GetGoBackPage(PreviousStatus);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void GetGoBackPage(string PreviousStatus)
    {
        int UserID = Convert.ToInt32(Session["UserID"]);
        if (bll.RankItemToApprove(UserID))
        {
            Response.Redirect("Requisition_RankItems.aspx", true);
            //Response.Redirect("Requisition_RankApproval.aspx?transferid=" + PreviousStatus, true);
        }
         else
        {
            Response.Redirect("Requisition_Welcome.aspx", true);
        }
    }

    protected void btnViewStatus_Click(object sender, EventArgs e)
    {
        LoadLogs();
    }

    private void LoadLogs()
    {
        MultiView1.ActiveViewIndex = 4;
        string PD_Code = lblPDCode.Text.Trim();
        dtable = Process.GetLogs(PD_Code);
        DataGrid2.DataSource = dtable;
        DataGrid2.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
}
