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

public partial class Requisition_finance : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    BusinessPlanning bllPlanning = new BusinessPlanning();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();
    private string Status = "14";
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
                    Response.Redirect("Requisition_FinanceViewItems.aspx", true);
                }
            }

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
            //string PreviousStatus = Session["Status"].ToString();
            //Response.Redirect("Requisition_FinanceViewItems.aspx?transferid=" + PreviousStatus, true);
            Response.Redirect("Requisition_FinanceViewItems.aspx", true);
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
            string RecordID = lblRecordCode.Text.Trim();
            LoadControls(RecordID);
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
            ComputeReqBalance(selectedstatus);
            if (selectedstatus == "0")
            {
                ShowMessage("Please select the Approval Option.......");
            }
            else if (selectedstatus != "1" && txtComment.Text.Trim() == "")
            {
                ShowMessage("Please enter your Comment.......");
            }
            else if (txtCostCenterForBudget.Text == "0" && Session["IsAreaProcess"].ToString() == "1")
                ShowMessage("Please Enter The Cost Center For Budget");
            else if (selectedstatus == "1" && txtBugetCode.Text == "")
            {
                ShowMessage("Please Enter Budget Code......");
                txtBugetCode.Focus();
            }
            else
            {
                string PDCode = lblPDCode.Text.Trim();
                string remark = txtComment.Text.Trim();
                string CostCenterID = lblCostCenterID.Text.Trim();
                string CostCenterName = txtBudgetCostCenter.Text.Trim();
                string AreaCode = lblAreaID.Text.Trim();
                string ApprovedAmount = txtbudgetAmount.Text.Trim();
                string RequisitionToDate = txtRequisitionAmount.Text.Trim().Replace(",", "");
                string Expenditure = txtExpenditure.Text.Trim().Replace(",", "");
                string balance = txtBalance.Text.Trim().Replace(",", "");
                string BudgetCode = "";
                string CostCenterForBudget = "";
                //string MarketPrice = txtMarketPrice.Text.Trim();
                int dashPosition = txtCostCenterForBudget.Text.Trim().IndexOf("-");
                if (txtCostCenterForBudget.Text.Trim().Contains("-"))
                    CostCenterForBudget = txtCostCenterForBudget.Text.Trim().Substring(0, dashPosition).Trim();
                else
                    CostCenterForBudget = txtCostCenterForBudget.Text.Trim();

                dashPosition = txtBugetCode.Text.Trim().IndexOf("-");
                if (txtBugetCode.Text.Trim().Contains("-"))
                    BudgetCode = txtBugetCode.Text.Trim().Substring(0, dashPosition).Trim();
                else
                    BudgetCode = txtBugetCode.Text.Trim();



                if (remark == "" && selectedstatus == "1")
                {
                    remark = "Funds available";
                }
                string returned = Process.ManagerAction(PDCode, selectedstatus, remark, "0", CostCenterID, CostCenterName, AreaCode, "", ApprovedAmount, Expenditure, RequisitionToDate, balance, BudgetCode, CostCenterForBudget, "", "", "", "", "", "");
                ShowMessage(returned);
                if (returned.Contains("failed"))
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    MultiView1.ActiveViewIndex = 2;
                }

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
    private void LoadPDItems()
    {
        string PD_Code = lblPDCode.Text.Trim();

        //MultiView1.ActiveViewIndex = 3;
        dtable = Process.GetPD_CodeItems(PD_Code);
        dtable.Columns.Remove("StockCode"); dtable.Columns.Remove("StockName");
        dtable.Columns.Remove("IsStockItem"); dtable.Columns.Remove("NumberOfItems");

        bool isProject1 = Convert.ToBoolean(Session["IsProject"].ToString());
        if (!isProject1)
        {

            GridItems.Columns[7].Visible = false;
        }

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
        dtable = Process.GetRequisitions(RecordID, "0", "", "", Status);
        lblEntity.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtEntityCode.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtProcType.Text = dtable.Rows[0]["ProcurementType"].ToString();
        txtProcSubject.Text = dtable.Rows[0]["Subject"].ToString();
        txtRequisitionType.Text = dtable.Rows[0]["Type"].ToString();
        txtDeliveryLocation.Text = dtable.Rows[0]["Location"].ToString();
        txtRequisitioner.Text = dtable.Rows[0]["Requisitioner"].ToString();
        txtDateRequired.Text = Convert.ToDateTime(dtable.Rows[0]["DateRequired"]).ToString("dd MMM yyyy");
        txtDateRequisitioned.Text = Convert.ToDateTime(dtable.Rows[0]["CreationDate"]).ToString("dd MMM yyyy");
        txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
        TextBox1.Text = dtable.Rows[0]["CostCenterName"].ToString();
        lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
        lblCostCenter.Text = dtable.Rows[0]["CostCenterCode"].ToString();
        lblCostCenterID.Text = dtable.Rows[0]["CostCenterID"].ToString();
        lblAreaID.Text = dtable.Rows[0]["AreaID"].ToString();

        txtCostCenterForBudget.Text = dtable.Rows[0]["CostCenterName"].ToString();
        txtBugetCode.Text = dtable.Rows[0]["BudgetCode"].ToString();

        txtbudgetAmount.Text = dtable.Rows[0]["BudgetAmount"].ToString();

        double BudgetAmount, Expenditure;
        BudgetAmount = Convert.ToDouble(dtable.Rows[0]["BudgetAmount"].ToString());
        Expenditure = Convert.ToDouble(dtable.Rows[0]["AmountSpent"].ToString());
        double Balance = BudgetAmount - Expenditure;

        double Requisitioned = GetRequisitionAmount();

        double RemBalance = Balance - Requisitioned;
        txtExpenditure.Text = Expenditure.ToString("#,##0");
        txtbudgetAmount.Text = BudgetAmount.ToString("#,##0");
        txtBalance.Text = RemBalance.ToString("#,##0");


        if (Session["AccessLevelID"].ToString() != "5")
        {
            btnSubmitRequistn.Enabled = true;
        }
        else
        {
            btnSubmitRequistn.Enabled = false;
        }
        LoadPDItems();
       Requisitioned = GetRequisitionAmount();

            txtRequisitionAmount.Text = Requisitioned.ToString("#,##0");
       
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
    protected void BtnGetBudget_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        try
        {
            lblmsgBudget.Text = "";
            if (txtBugetCode.Text == "")
            {
                Label2.Text = "Please Enter Budget Code.....";
                txtBugetCode.Focus();
                txtbudgetAmount.Text = "";
                txtExpenditure.Text = "";
                txtRequisitionAmount.Text = "";
                txtBalance.Text = "";
            }
            else if (Session["IsAreaProcess"].ToString() == "1" && txtCostCenterForBudget.Text == "0")
            {
                Label2.Text = "Please Enter Cost Center For The Budget ...";
                txtCostCenterForBudget.Text = "";
            }
            else if (txtCostCenterForBudget.Text == "")
            {
                Label2.Text = "Please Enter Cost Center for the Budget....";
                txtCostCenterForBudget.Text = "";
            }
            else
            {
                Getamounts();
                Label2.Text = ".";
            }
        }
        catch (Exception ex)
        {
            Label2.Text = ex.Message;
        }
    }

    private void Getamounts()
    {
        Label2.Text = "Please Wait...";
        string BudgetCode = txtBugetCode.Text.Trim();
        string CostCenterCode = lblCostCenter.Text.Trim();

        string CostCenterForBudget = "";

        int dashPosition = txtCostCenterForBudget.Text.Trim().IndexOf("-");
        if (txtCostCenterForBudget.Text.Trim().Contains("-"))
            CostCenterForBudget = txtCostCenterForBudget.Text.Trim().Substring(0, dashPosition).Trim();
        else
            CostCenterForBudget = txtCostCenterForBudget.Text.Trim();

        if (CostCenterForBudget != "0" && CostCenterForBudget.Length != 6)
            throw new Exception("Cost Center Code Should Be Six (6) Digits. Please Re-enter Code");

        string BugetCode = "";
        dashPosition = txtBugetCode.Text.Trim().IndexOf("-");
        if (txtBugetCode.Text.Trim().Contains("-"))
            BugetCode = txtBugetCode.Text.Trim().Substring(0, dashPosition).Trim();
        else
            BugetCode = txtBugetCode.Text.Trim();

        string FinancialYear = Session["RFinancialYear"].ToString();
        string FinYear = FinancialYear.Trim().Remove(0, 9);

        string from = "No All";
        // In Future, Attach Consolidated Budget Codes to Cost Center
        if (bllPlanning.IsBudgetConsolidated(BugetCode, 0))
            from = "Consolidated";
        else if (CostCenterForBudget == "0")
            from = "ALL";
        else
            from = "CostCenter";

        double BudgetAmount = Process.GetBudgetAmount(BudgetCode, CostCenterCode, CostCenterForBudget, from, FinYear);
        double Expenditure = Process.GetExpenditureOnBudget(BudgetCode, CostCenterCode, CostCenterForBudget, from, FinYear);
        if (BudgetAmount == 0 && Expenditure == 0)
        {
            DataTable dtCheckIfBudgetExists = Process.CheckIfCostCenterBudgetExists(BudgetCode, CostCenterForBudget, FinYear);

            if (dtCheckIfBudgetExists.Rows.Count > 0)
                ResetBudgetValues(true, FinancialYear);
            else
                ResetBudgetValues(false, FinancialYear);
        }
        else
        {
            dtable = Process.GetBudgetCodeTotalAmount(txtBugetCode.Text.Trim(), CostCenterForBudget, Session["RFinYearCode"].ToString());
            if (dtable.Rows.Count > 0)
            {
                double TotalAmountRequisitioned = 0;
                if (dtable.Rows[0]["TotalRequisitioned"].ToString() != "")
                    TotalAmountRequisitioned = Convert.ToDouble(dtable.Rows[0]["TotalRequisitioned"].ToString());

                    txtPendingSum.Text = TotalAmountRequisitioned.ToString("#,##0");
             




            }
            else
                txtPendingSum.Text = "0";
            double Balance = BudgetAmount - Expenditure;

            double Requisitioned = GetRequisitionAmount();

            double RemBalance = Balance - Requisitioned;
            txtExpenditure.Text = Expenditure.ToString("#,##0");
            txtbudgetAmount.Text = BudgetAmount.ToString("#,##0");
            txtBalance.Text = RemBalance.ToString("#,##0");

           
                txtRequisitionAmount.Text = Requisitioned.ToString("#,##0");
            
        }
    }

    private void ResetBudgetValues(bool IsBudgetExists, string FinancialYear)
    {
        txtBalance.Text = "";
        txtbudgetAmount.Text = "";
        txtExpenditure.Text = "";
        lblmsgBudget.Visible = true;
        if (IsBudgetExists)
            lblmsgBudget.Text = "MESSAGE: " + "NO BUDGET ON THIS ACCOUNT FOR THE COST CENTER........";
        else
            lblmsgBudget.Text = "MESSAGE: " + "NO BUDGET ON THIS ACCOUNT FOR THE FINANCIAL YEAR (" + FinancialYear + ")";
    }

    protected void txtBalance_TextChanged(object sender, EventArgs e)
    {
        if (txtRequisitionAmount.Text.Trim() != "" && txtBalance.Text.Trim() != "")
        {
            double BalBudget = Convert.ToDouble(txtBalance.Text.Trim());
            double CurReqAmount = Convert.ToDouble(txtRequisitionAmount.Text.Trim());
            double BalAfterReq = BalBudget - CurReqAmount;
            // txtBalanceAfterRequisition.Text = BalAfterReq.ToString();;
        }
    }

    protected void btnFinalReturn_Click(object sender, EventArgs e)
    {
        Session["IsProject"] = false;
        Session["CurrentYearRequsition"] = "0";
        Response.Redirect("Requisition_FinanceViewItems.aspx", true);
    }
    private void ComputeReqBalance(string status)
    {
        if (status == "2")
            return;
        if (txtExpenditure.Text.Trim() != "" && txtbudgetAmount.Text.Trim() != "")
        {
            double Expenditure = Convert.ToDouble(txtExpenditure.Text.Trim().Replace(",", ""));
            double BudgetAmount = Convert.ToDouble(txtbudgetAmount.Text.Trim().Replace(",", ""));
            double RequisitionedAmount = Convert.ToDouble(txtRequisitionAmount.Text.Trim().Replace(",", ""));

            double RemBalance = BudgetAmount - Expenditure - RequisitionedAmount;
            txtBalance.Text = RemBalance.ToString("#,##0");
            lblmsgBudget.Text = "MESSAGE: BALANCE ON BUDGET CAN NOT BE NEGATIVE...";
            if (RemBalance < 0)
                throw new Exception("BALANCE ON BUDGET CAN NOT BE NEGATIVE...");
        }
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
