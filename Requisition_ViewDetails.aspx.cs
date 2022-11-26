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

public partial class Requisition_Approval : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();
    private string Status = "0";
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
                    Response.Redirect("Requisition_Search.aspx", true);
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
        
        dtable = Process.GetRequisitions(RecordID, "0", "", "", Status);
        lblEntity.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtProcType.Text = dtable.Rows[0]["ProcurementType"].ToString();
        txtProcSubject.Text = dtable.Rows[0]["Subject"].ToString();
        txtRequisitionType.Text = dtable.Rows[0]["Type"].ToString();
        txtDeliveryLocation.Text = dtable.Rows[0]["Location"].ToString();
        txtWareHouse.Text = dtable.Rows[0]["WareHouse"].ToString();
        txtRequisitioner.Text = dtable.Rows[0]["Requisitioner"].ToString();
        txtDateRequired.Text = dtable.Rows[0]["DateRequired"].ToString();
        txtDateRequisitioned.Text = dtable.Rows[0]["CreationDate"].ToString();
        txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
        lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
        lblScalaPR.Text = dtable.Rows[0]["ScalaPRNumber"].ToString();
        txtManager.Text = dtable.Rows[0]["Manager"].ToString();
        lblCreatedBy.Text = dtable.Rows[0]["CreatedBy"].ToString();
        lblCostCenterForBudget.Text = dtable.Rows[0]["CostCenterForBudget"].ToString();
        lblStatus.Text = dtable.Rows[0]["StatusID"].ToString();

        LoadPDItems();
    }
    
    private void LoadPDItems()
    {
        string PD_Code = lblPDCode.Text.Trim();
        lblPDDesc.Text = "List of Item(s) for Procurement Entitled: "+txtProcSubject.Text;
        dtable = Process.GetPD_CodeItems(PD_Code);
        dtable.Columns.Remove("StockCode"); dtable.Columns.Remove("StockName");
        dtable.Columns.Remove("IsStockItem"); dtable.Columns.Remove("NumberOfItems");
        GridItems.DataSource = dtable;
        GridItems.DataBind();
        if (dtable.Rows.Count > 0)
        {
            string Total = GetTotal(dtable);
            lblTotal.Visible = true;
            lblTotal.Text = "GRAND TOTAL AMOUNT : "+Total;
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
            Label2.Text = txtProcSubject.Text;
            int StatusID = Convert.ToInt32(lblStatus.Text.Trim());
            LoadReadOnlyDocuments();
            
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
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

    private void LoadReadOnlyDocuments()
    {
        MultiView1.ActiveViewIndex = 3;
        string PD_Code = lblPDCode.Text.Trim();
        dtable = ProcessOthers.GetPlanDocuments("", PD_Code);
        if (dtable.Rows.Count > 0)
        {
            GridView1.DataSource = dtable;
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
    
    private void GetGoBackPage(string PreviousStatus)
    {
        string Access = Session["AccessLevelID"].ToString();
        if (Access == "3")
        {
            Response.Redirect("Requisition_ProcViewItems.aspx?transferid=" + PreviousStatus, true);
        }
        else if (Access == "6")
        {
            Response.Redirect("Requisition_ManagerViewItems.aspx?transferid=" + PreviousStatus, true);
        }
        else
        {
            Response.Redirect("Requisition_LogisticViewItems.aspx?transferid=" + PreviousStatus, true);
        }
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
    private void PrintStatusReport()
    {
        LoadStatusReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Status");

    }
    private void LoadStatusReport()
    {
        string PD_Code = lblPDCode.Text.Trim();
        dtable = Process.GetReportLogs(PD_Code);

        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\PRStatus.rpt";

    }
    private void Hidetoolbar()
    {
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            PrintReport();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void PrintReport()
    {
        LoadReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Requisition");

    }
    private void LoadReport()
    {
        string PD_Code = lblPDCode.Text.Trim();
        dtable = Process.GetRequisitionDetailform20(PD_Code);
        if (dtable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 2;
            string appPath, physicalPath, rptName;
            appPath = HttpContext.Current.Request.ApplicationPath;
            physicalPath = HttpContext.Current.Request.MapPath(appPath);
            rptName = physicalPath + "\\Bin\\Reports\\Requisitioning.rpt";
            btnPrint.Enabled = true;
        }
        else
        {
            btnPrint.Enabled = false;
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
                lblPD_Code.Text = PD_Code;
                LoadReport();
            }
            else if (e.CommandName == "btnStatus")
            {
                lblPD_Code.Text = PD_Code;
                LoadLogs();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btnViewStatus_Click(object sender, EventArgs e)
    {
        LoadLogs();
    }

    private void LoadLogs()
    {
        MultiView1.ActiveViewIndex = 1;
        string PD_Code = lblPDCode.Text.Trim();
        dtable = Process.GetLogs(PD_Code);
        DataGrid2.DataSource = dtable;
        DataGrid2.DataBind();
    }

    protected void btnPrintPR_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
    protected void btnPrintReturn_Click(object sender, EventArgs e)
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
                ProcessOthers.RemoveDocument(FileCode);
                LoadReadOnlyDocuments();
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView1.DataKeys[intIndex].Value);
                string Path = ProcessOthers.GetDocumentPath(FileCode);
                DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnReturn_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Requisition_Search.aspx", true);
    }
    protected void btnReturn_Click2(object sender, EventArgs e)
    {
        Response.Redirect("Requisition_Search.aspx", true);
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
