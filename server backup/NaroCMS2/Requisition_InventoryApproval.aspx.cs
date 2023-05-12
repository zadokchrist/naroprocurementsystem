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
        dtable = Process.GetRequisitions(RecordID, "0", "", "", Status);
        lblEntity.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtEntityCode.Text  = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtProcType.Text = dtable.Rows[0]["ProcurementType"].ToString();
        txtProcSubject.Text = dtable.Rows[0]["Subject"].ToString();
        txtRequisitionType.Text = dtable.Rows[0]["Type"].ToString();
        txtDeliveryLocation.Text = dtable.Rows[0]["Location"].ToString();
        txtRequisitioner.Text = dtable.Rows[0]["Requisitioner"].ToString();
        txtDateRequired.Text = dtable.Rows[0]["DateRequired"].ToString();
        txtDateRequisitioned.Text = dtable.Rows[0]["CreationDate"].ToString();
        txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
        lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
        lblScalaPR.Text = dtable.Rows[0]["ScalaPRNumber"].ToString();
        lblCostCenter.Text = dtable.Rows[0]["CostCenterCode"].ToString();
        lblCostCenterID.Text = dtable.Rows[0]["CostCenterID"].ToString();
        lblAreaID.Text = dtable.Rows[0]["AreaID"].ToString();
        txtManager.Text = dtable.Rows[0]["Manager"].ToString();
        lblCostCenterForBudget.Text = dtable.Rows[0]["CostCenterForBudget"].ToString();
        txtBudgetCode.Text = dtable.Rows[0]["BudgetCode"].ToString();
        txtExpenditure.Text = Convert.ToDouble(dtable.Rows[0]["Expenditure"]).ToString("#,##0");
        txtBalanceOnBudet.Text = Convert.ToDouble(dtable.Rows[0]["BudgetBalance"]).ToString("#,##0");
        txtAmountApproved.Text = Convert.ToDouble(dtable.Rows[0]["ApprovedAmount"]).ToString("#,##0");
        txtRequisition.Text = Convert.ToDouble(dtable.Rows[0]["RequisitionToDate"]).ToString("#,##0");
        lblIsGroup.Text = dtable.Rows[0]["IsGrouped"].ToString();
       
        if (Session["AccessLevelID"].ToString() == "5")
        {
            MultiView2.ActiveViewIndex = -1;
            btnSubmitRequistn.Visible = false;
        }
        else
        {
            MultiView2.ActiveViewIndex = 0;
        }
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
                string PDCode = lblPDCode.Text.Trim();
                string remark = txtComment.Text.Trim();
                string CostCenterID = lblCostCenterID.Text.Trim();
                string CostCenterName = txtBudgetCostCenter.Text.Trim();
                string AreaCode = lblAreaID.Text.Trim();
                string Subject = txtProcSubject.Text.Trim();
                string DateRequired = txtDateRequired.Text.Trim();
                string Location = txtDeliveryLocation.Text.Trim();
                string WareHouse = "";
                string CostCenterCode = lblCostCenter.Text.Trim();
                string CostCenterForBudget = lblCostCenterForBudget.Text.Trim();
                string amount = GetRequisitionAmount().ToString();
                string PRNumber = lblScalaPR.Text.Trim();
                string returned = Process.ManagerAction(PDCode, selectedstatus, remark, "", CostCenterID,
                    CostCenterName,AreaCode, WareHouse, amount,"","","","",CostCenterForBudget,Subject,DateRequired, Location, CostCenterCode, PRNumber, "");
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
        if (Access == "3")
        {
            Response.Redirect("Requisition_ProcViewItems.aspx?transferid=" + PreviousStatus, true);
        }
        else if (Access == "6")
        {
            Response.Redirect("Requisition_ManagerViewItems.aspx?transferid=" + PreviousStatus, true);
        }
        else if (Access == "8")
        {
            Response.Redirect("Requisition_LogisticViewItems.aspx?transferid=" + PreviousStatus, true);
        }
        else if (Access == "9")
        {
            Response.Redirect("Requisition_InventoryViewItems.aspx?transferid=" + PreviousStatus, true);
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
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
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
    protected void btnEditPRItems_Click(object sender, EventArgs e)
    {
        string PD_Code = lblPDCode.Text.Trim();
        bool IsGrouped = Convert.ToBoolean(lblIsGroup.Text.Trim());
        if (!IsGrouped)
            dtable = Process.GetPD_CodeItems(PD_Code);
        else
            dtable = Process.GetGroupPD_CodeItems(PD_Code);

        
        DataGrid1.DataSource = dtable;
        DataGrid1.DataBind();
        if (dtable.Rows.Count > 0)
        {
            string Total = GetTotal(dtable);
            lblAttachStockCodeTotal.Visible = true;
            lblAttachStockCodeTotal.Text = "GRAND TOTAL AMOUNT : " + Total;
        }
        else
        {
            lblAttachStockCodeTotal.Visible = false;
            lblAttachStockCodeTotal.Text = ".";
        }
        MultiView1.ActiveViewIndex = 5;
    
    }
    protected void btnCancelEditItems_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    private string ValidateItemsForEditing()
    {
        string invalidPlanCodes = "";
        foreach (DataGridItem items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(items.FindControl("chbAdd")));
            if (chk.Checked)
            {
                string plancode = items.Cells[2].Text;
                int remainingQty = int.Parse(items.Cells[5].Text);
                int currentQty = int.Parse(items.Cells[4].Text);
                string reqQty = ((TextBox)items.FindControl("txtQtyRequired")).Text;
                int requiredQty = int.Parse(reqQty);

                if (requiredQty == currentQty)
                    continue;
                else if ((requiredQty == 0) || (remainingQty + currentQty < requiredQty))
                    invalidPlanCodes += plancode + ",";

                string StockName = ((TextBox)items.FindControl("txtStockName")).Text;
                if (!String.IsNullOrEmpty(StockName.Trim()))
                {
                    string CompanyCode = Session["ScalaCode"].ToString();
                    dtable = ProcessOthers.GetStockCodeByName(StockName.Trim(), CompanyCode);
                    if (dtable.Rows.Count == 0)
                        invalidPlanCodes += plancode + ",";
                }
            }
        }
        if (String.IsNullOrEmpty(invalidPlanCodes))
            return invalidPlanCodes;
        else
            return invalidPlanCodes.TrimEnd(new char[] { ',' });
    }
    private bool AreAnyItemsSelected(Control control)
    {
        foreach (DataGridItem items in ((DataGrid)control).Items)
        {
            CheckBox chk = ((CheckBox)(items.FindControl("chbAdd")));
            if (chk.Checked)
                return true;
        }
        return false;
    }
    protected void btnEditItems_Click(object sender, EventArgs e)
    {
        if (!AreAnyItemsSelected(DataGrid1))
            ShowMessage("Please Select Requisition Item(s) to be edited ");
        else
        {
            bool IsGroupedReq = Convert.ToBoolean(lblIsGroup.Text.Trim().ToString());
            if (IsGroupedReq == false)
            {
                if (!String.IsNullOrEmpty(ValidateItemsForEditing()))
                    ShowMessage("One / More Requisition Item(s) has a Required Quantity As Zero (0) OR Greater than its Remaining Quantity OR Stock Name Was Invalid");
                else
                {
                    EditIndividualRequisitionItems(lblPD_Code.Text.Trim());
                    ShowMessage("Requisition Item has been successfully Edited");
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }
    }
    private string EditIndividualRequisitionItems(string PD_Code)
    {
        string output = "";
        foreach (DataGridItem items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(items.FindControl("chbAdd")));
            if (chk.Checked)
            {
                string plancode = items.Cells[2].Text;
                long RecordId = long.Parse(items.Cells[1].Text);

                int planBalance = int.Parse(items.Cells[5].Text);
                int origPlan = planBalance;
                string reqQty = items.Cells[8].Text;
                int requiredQty = int.Parse(reqQty);
                string stockquantity = ((TextBox)items.FindControl("txtStockQty")).Text;
                int stock = int.Parse(stockquantity);
                int prevStock = stock;
                string curr = ((TextBox)items.FindControl("txtQtyRequired")).Text;
                int new_amount = requiredQty;
                int currentQty = int.Parse(reqQty);
                if (curr != "" && stockquantity != "0")
                {
                    currentQty = int.Parse(curr);

                    planBalance = origPlan - requiredQty;
                    if (stock > requiredQty)
                    {
                        new_amount = 0;
                        stock = stock - requiredQty;
                    }
                    else if(stock < requiredQty)
                    {
                        new_amount = requiredQty - stock;
                        stock = 0;
                    }
                    else if (stock == requiredQty)
                    {
                        new_amount = 0;
                        stock = 0;
                    }

                }


                double unitCost = Convert.ToDouble(items.Cells[10].Text);

                //int PrevQty, BalQty;
                //if (requiredQty > currentQty)
                //    BalQty = (currentQty + stockquantity) - requiredQty;
                //else
                //    BalQty = currentQty - requiredQty;
                //PrevQty = (currentQty + stockquantity) - requiredQty; 

                double RequisitionedAmount = unitCost * new_amount;
                double PreviousAmount = unitCost * origPlan;
                double RemainingAmount = planBalance * unitCost;
                TextBox stockName = ((TextBox)items.FindControl("txtStockName"));
                string s = stockName.Text;
                bool IsStock = false;
                if (stock > 0)
                {
                    IsStock = true;
                }
                string StockCode = "";
                string StockName = ((TextBox)items.FindControl("txtStockName")).Text;
                //if (!String.IsNullOrEmpty(StockName.Trim()))
                //{
                //    IsStock = true;
                //    string CompanyCode = Session["ScalaCode"].ToString();
                //    dtable = ProcessOthers.GetStockCodeByName(StockName.Trim(), CompanyCode);
                //    if (dtable.Rows.Count > 0)
                //        StockCode = dtable.Rows[0]["StockCode"].ToString(); 
                //}

                Process.UpdateRequisitionItem(RecordId, plancode, origPlan, PreviousAmount, new_amount, RequisitionedAmount, planBalance, RemainingAmount, IsStock, StockCode, StockName);
                output = "Requisition Items have been updated Successfully";
            }
        }
        return output;
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //}
    }

    protected void txtQtyRequired_TextChanged(object sender, EventArgs e)
    {

        foreach (DataGridItem items in DataGrid1.Items)
        {
            try
            {
                TextBox qty = ((TextBox)items.FindControl("txtStockQty"));
                string sqty = qty.Text;
                int stkqty = int.Parse(sqty);
                int reqamt = int.Parse(items.Cells[8].Text);
                int newqty = reqamt;
                if (stkqty >= reqamt) {
                    reqamt = 0;
                } else {
                    reqamt = reqamt - stkqty;
                }
                TextBox nqty = ((TextBox)items.FindControl("txtQtyRequired"));
                nqty.Text = reqamt.ToString();

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
    }
}
