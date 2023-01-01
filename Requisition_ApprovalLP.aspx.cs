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

public partial class Requisition_ApprovalLP : System.Web.UI.Page
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
            DisableBtnsOnClick();
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
    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        btnSubmitRequistn.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnSubmitRequistn, "").ToString());
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
        dtable = Process.GetRequisitions(RecordID, "0", "", "", "105");
        lblEntity.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtProcType.Text = dtable.Rows[0]["ProcurementType"].ToString();
        txtProcSubject.Text = dtable.Rows[0]["Subject"].ToString();
        txtRequisitionType.Text = dtable.Rows[0]["Type"].ToString();
        txtDeliveryLocation.Text = dtable.Rows[0]["Location"].ToString();
        txtWareHouse.Text = dtable.Rows[0]["WareHouse"].ToString();
        lblWareHouse.Text = dtable.Rows[0]["WareHouseScalaCode"].ToString();
        txtRequisitioner.Text = dtable.Rows[0]["Requisitioner"].ToString();
        txtDateRequired.Text = Convert.ToDateTime(dtable.Rows[0]["DateRequired"]).ToString("dd MMMM, yyyy");
        txtDateRequisitioned.Text = Convert.ToDateTime(dtable.Rows[0]["CreationDate"]).ToString("dd MMMM, yyyy");
        txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
        lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
        lblScalaPR.Text = dtable.Rows[0]["ScalaPRNumber"].ToString();
        lblCostCenter.Text = dtable.Rows[0]["CostCenterCode"].ToString();
        lblCostCenterID.Text = dtable.Rows[0]["CostCenterID"].ToString();
        lblAreaID.Text = dtable.Rows[0]["AreaID"].ToString();
        txtManager.Text = dtable.Rows[0]["Manager"].ToString();
        lblCreatedBy.Text = dtable.Rows[0]["CreatedBy"].ToString();
        lblCostCenterForBudget.Text = dtable.Rows[0]["CostCenterForBudget"].ToString();
        lblStatus.Text = dtable.Rows[0]["StatusID"].ToString();
        lblIsProject.Text = dtable.Rows[0]["IsProject"].ToString();
        //tony 08/03
        //string marketprice = txtMarketPrice.

        if ((Session["AccessLevelID"].ToString() == "6" || Session["AccessLevelID"].ToString() == "1026") && txtRequisitionType.Text.ToLower().Contains("emergency"))
            MultiView3.ActiveViewIndex = 0;

        if (Session["AccessLevelID"].ToString() == "5")
        {
            MultiView2.ActiveViewIndex = -1;
            btnSubmitRequistn.Visible = false;
        }
        else
        {
            MultiView2.ActiveViewIndex = 0;
        }

        if (Session["AccessLevelID"].ToString() == "1026" || Session["AccessLevelID"].ToString() == "9")
        {
            cboSendTo.Enabled = true;
        }
        else
        {
            cboSendTo.Enabled = false;
        }
        LoadDestinations();
        LoadPDItems();
        ToggleDestinations();
    }
    private void ToggleDestinations()
    {
        if (Session["AccessLevelID"].ToString() == "1026" || Session["AccessLevelID"].ToString() == "9")
        {
            lblDestination.Visible = true;
            cboSendTo.Visible = true;
            cboSendTo.Enabled = false;
        }
        else
        {
            lblDestination.Visible = false;
            cboSendTo.Visible = false;
        }
    }
    private void LoadDestinations()
    {
        if (Session["AccessLevelID"].ToString() == "10226")
        {
            dtable = Process.GetProcOfficers();//Change to large proc officers
            cboSendTo.DataSource = dtable;
            cboSendTo.DataValueField = "UserID";
            cboSendTo.DataTextField = "FullName";
            cboSendTo.DataBind();
        }
        else
        {

            dtable = Process.GetLogisticsDestinations();
            cboSendTo.DataSource = dtable;
            cboSendTo.DataValueField = "LevelID";
            cboSendTo.DataTextField = "LevelName";
            cboSendTo.DataBind();
        }

    }
    private void AssignStatus(string Access)
    {
        if (Access == "9")
        {
            Status = "16";
        }
        else if (Access == "8")
        {
            Status = "18";
        }
        else if (Access == "3")
        {
            Status = "20";
        }
        else if (Access == "5" || Access == "1")
        {
            Status = "0";
        }
        else if (Access == "36")
        {
            Status = "0";
        }
        else
        {
            Status = "11";
        }
    }
    private void LoadPDItems()
    {
        string PD_Code = lblPDCode.Text.Trim();
        Boolean IsProject = Convert.ToBoolean(lblIsProject.Text.ToString().Trim());
        lblPDDesc.Text = "List of Item(s) for Procurement Entitled: "+txtProcSubject.Text;
        //MultiView1.ActiveViewIndex = 3;
        dtable = Process.GetPD_CodeItems(PD_Code);
        dtable.Columns.Remove("StockCode"); dtable.Columns.Remove("StockName");
        dtable.Columns.Remove("IsStockItem"); dtable.Columns.Remove("NumberOfItems");
        foreach (DataRow dr in dtable.Rows)
        {
            dr["MarketPrice"] = Convert.ToDouble(dr["MarketPrice"]).ToString("#,##0");
        }

        if (IsProject)
        {
            GridItems.Columns[5].HeaderText = "Project Amount";
            GridItems.Columns[6].HeaderText = " Requisitioned Amount";
            GridItems.Columns[7].Visible = false;
        }

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
            lblHeaderMsg.Text = txtProcSubject.Text;
            Label2.Text = txtProcSubject.Text;
            int StatusID = Convert.ToInt32(lblStatus.Text.Trim());
            if (StatusID > 11)
                LoadReadOnlyDocuments();
            else
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
            string selectedstatus = GetSelectedStatus();
            string SendTo = cboSendTo.SelectedValue.ToString();
            if (selectedstatus == "0")
            {
                ShowMessage("Please select the Approval Option.......");
            }
            else if (selectedstatus != "1" && txtComment.Text.Trim() == "")
            {
                ShowMessage("Please enter your Comment.......");
            }
            else if (Session["AccessLevelID"].ToString() == "1026" && selectedstatus == "1" && SendTo == "0")
            {
                ShowMessage("Please Select Destination of the requisition");
            }
            else if (Session["AccessLevelID"].ToString() == "1")
            {
                ShowMessage("Administrative Account cannot approve any requisition in the system");
            }
            else if (Session["AccessLevelID"].ToString() == "9" && selectedstatus == "1" && SendTo == "0")
            {
                ShowMessage("Please Select Destination of the requisition");
            }
            else if (Session["AccessLevelID"].ToString() == "6" && selectedstatus == "1" 
                && String.IsNullOrEmpty(FCKeditor1.Text.Trim()) && txtRequisitionType.Text.ToLower().Contains("emergency"))
                ShowMessage("Please Enter Memo Text (Why the requisition is an emmergency)");
            else
            {
                string PDCode = lblPDCode.Text.Trim();
                string remark = txtComment.Text.Trim();
                string CostCenterID = lblCostCenterID.Text.Trim();
                string CostCenterName = txtBudgetCostCenter.Text.Trim();
                string AreaCode = lblAreaID.Text.Trim();
                string Subject = txtProcSubject.Text.Trim();
                string DateRequired = txtDateRequired.Text.Trim();
                string Location = txtDeliveryLocation.Text.Trim();
                string CostCenterCode = lblCostCenter.Text.Trim();
                string CostCenterForBudget = lblCostCenterForBudget.Text.Trim();
                string amount = GetRequisitionAmount().ToString();
                string PRNumber = lblScalaPR.Text.Trim();
                string WareHouse = lblWareHouse.Text.Trim(); //txtWareHouse.Text.Trim();
                string EmmergencyMemo = FCKeditor1.Text.Trim();
                //tony 8/3
                //string Marketprice = txtMarketPrice.Text.Trim();
                
                // For Backward WareHouses, include AreaCode
                string returned = Process.ManagerAction(PDCode, selectedstatus, remark, SendTo, CostCenterID,
                    CostCenterName,AreaCode, WareHouse,amount,"","","","",CostCenterForBudget,Subject,DateRequired, Location, CostCenterCode, PRNumber, EmmergencyMemo);
                ShowMessage(returned);
                MultiView1.ActiveViewIndex = 2;
            }
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
    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            //string Plancode = lblPlanCode.Text.Trim();
            string PD_Code = lblPDCode.Text.Trim();
            UploadFiles(PD_Code);
            LoadDocuments();
            LoadReadOnlyDocuments();
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
                LoadReadOnlyDocuments();
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
        dtable = ProcessOthers.GetPlanDocuments("",PD_Code);
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
    private void LoadReadOnlyDocuments()
    {
        MultiView1.ActiveViewIndex = 5;
        string PD_Code = lblPDCode.Text.Trim();
        dtable = ProcessOthers.GetPlanDocuments("", PD_Code);
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
        string Access = Session["AccessLevelID"].ToString();
        if (Access == "1026")
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
    protected void cboSendTo_DataBound(object sender, EventArgs e)
    {
        cboSendTo.Items.Insert(0, new ListItem("- - Select Destination - -", "0"));
    }
    protected void rbnApproval_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbnApproval.SelectedIndex == 0)
            cboSendTo.Enabled = true;
        else
            cboSendTo.Enabled = false;
    }
    protected void cboSendTo_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        //doc.Load(rptName);
        //doc.SetDataSource(dtable);
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
            MultiView1.ActiveViewIndex = 4;
            string appPath, physicalPath, rptName;
            appPath = HttpContext.Current.Request.ApplicationPath;
            physicalPath = HttpContext.Current.Request.MapPath(appPath);
            rptName = physicalPath + "\\Bin\\Reports\\Requisitioning.rpt";
            //doc.Load(rptName);
            //doc.SetDataSource(dtable);
            //Hidetoolbar();
            //CrystalReportViewer1.ReportSource = doc;
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
        MultiView1.ActiveViewIndex = 3;
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string PreviousStatus = Session["Status"].ToString();
        GetGoBackPage(PreviousStatus);
        //Response.Redirect(Session["PreviousPage"].ToString() + "?transferStatus=1", true);
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
                LoadDocuments();
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

    protected void Page_Unload(object sender, EventArgs e)
    {
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //}
    }
    protected void GridItems_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridItems.PageIndex = newPageIndex;
            LoadPDItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
}
