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

public partial class Requisition_UpdatePRNumber : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    private void LoadControls(string RecordID)
    {
        MultiView1.ActiveViewIndex = 0;
        string Access = Session["AccessLevelID"].ToString();
        
        dtable = Process.GetRequisitions(RecordID, "0", "", "", "0");
        lblEntity.Text = dtable.Rows[0]["PD_EntityCode"].ToString();
        txtProcType.Text = dtable.Rows[0]["ProcurementType"].ToString();
        txtProcSubject.Text = dtable.Rows[0]["Subject"].ToString();
        txtRequisitionType.Text = dtable.Rows[0]["Type"].ToString();
        txtDeliveryLocation.Text = dtable.Rows[0]["Location"].ToString();
        txtWareHouse.Text = dtable.Rows[0]["WareHouse"].ToString();
        txtRequisitioner.Text = dtable.Rows[0]["Requisitioner"].ToString();
        txtDateRequired.Text = Convert.ToDateTime(dtable.Rows[0]["DateRequired"]).ToString("dd MMMM, yyyy");
        txtDateRequisitioned.Text = Convert.ToDateTime(dtable.Rows[0]["CreationDate"]).ToString("dd MMMM, yyyy");
        txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
        lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
        lblCostCenter.Text = dtable.Rows[0]["CostCenterCode"].ToString();
        lblCostCenterID.Text = dtable.Rows[0]["CostCenterID"].ToString();
        lblAreaID.Text = dtable.Rows[0]["AreaID"].ToString();
        txtManager.Text = dtable.Rows[0]["Manager"].ToString();
        lblCreatedBy.Text = dtable.Rows[0]["CreatedBy"].ToString();
        lblCostCenterForBudget.Text = dtable.Rows[0]["CostCenterForBudget"].ToString();
        lblStatus.Text = dtable.Rows[0]["StatusID"].ToString();

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
    protected void btnSubmitRequistn_Click(object sender, EventArgs e)
    {
        string PDCode = lblPDCode.Text.Trim();
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
        string WareHouse = txtWareHouse.Text.Trim();

        string WareHouseCode = "";
        if (WareHouse != "")
            WareHouseCode = Process.GetNewWareHouseID(WareHouse);

        Process.LogInScala(lblPDCode.Text, Subject, Location, WareHouseCode, amount, DateRequired, 
            CostCenterCode, CostCenterForBudget);

        ShowMessage("Procurement Has Been Changed Successfully");

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtPDCode.Text.Trim()))
        {
            LoadControls(txtPDCode.Text.Trim());
        }
        else
        {
            ShowMessage("Please Enter Record Code");
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
