using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BusinessPlanning
/// </summary>
public class BusinessPlanning
{
    DataPlanning data = new DataPlanning();
    DataTable DTable = new DataTable();
    DataSet dataSet = new DataSet();
	public BusinessPlanning()
	{

	}
    public bool isStockCostCenter(string strCostCenterID)
    {
        int CostCenterID = Convert.ToInt32(strCostCenterID);
        DTable = data.CheckIsStockCostCenter(CostCenterID);
        int foundRows = DTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
  
    }
    public bool isSpecificMethod(int ProcTypeID, double Amount)
    {
        DTable = data.GetProcMethodByAmount(ProcTypeID, Amount);
        int found = DTable.Rows.Count;
        if (found > 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool IsDelegated(int UserID)
    {
        DTable = data.CheckDelegation(UserID);
        int found = DTable.Rows.Count;
        if (found > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsBudgetConsolidated(string BudgetCode, int CostCenterID)
    {
        DTable = data.CheckBudgetConsolidation(CostCenterID, BudgetCode);
        int found = DTable.Rows.Count;
        if (found > 0)
            return true;
        else
            return false;
    }
    public bool DateWhenNeededIsValid(DateTime DateNeeded, DateTime DateForPP20, int ProcurementLength)
    {
        bool valid = true;
        int result = DateTime.Compare(DateForPP20, DateNeeded);

        if (!(result < 0) || (DateForPP20.AddMonths(ProcurementLength) > DateNeeded))
            valid = false;

        return valid;
    }

    public bool IsDateWhenNeededWithinFinYear(DateTime DateNeeded, string FinYear)
    {

        string startYear = FinYear;
            //.Trim().Split('-');

        DateTime StartFinDate = new DateTime(Convert.ToInt32(startYear), 1, 1);
        DateTime EndFinDate = StartFinDate.AddYears(1);
            
           // new DateTime(Convert.ToInt32(Years[1]), 1, 1);

        if (StartFinDate <= DateNeeded && EndFinDate > DateNeeded)
            return true;
        else
            return false;
    }

    public bool DateForPP20IsValid(DateTime DateForPP20)
    {
        bool valid = true;
        int result = DateTime.Compare(DateTime.Now, DateForPP20);

        if (!(result < 0))
            valid = false;

        return valid;
    }

    public bool IsDateInQuarter(DateTime Date, int Quarter)
    {
        int Month = Date.Month;
        DTable = data.IsDateInQuarter(Month, Quarter);
        int found = DTable.Rows.Count;
        if (found > 0)
            return true;
        else
            return false;
    }
}
