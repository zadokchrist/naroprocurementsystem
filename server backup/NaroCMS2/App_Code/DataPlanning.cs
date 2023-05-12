using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

public class DataPlanning
{
    private Database Proc_DB;
    private Database scala_DB;
    private DbCommand mycommand;
    private DataSet returnDataset;
    private DataTable returnDatatable;

    DataLogin con = new DataLogin();
	public DataPlanning()
	{
        try
        {
            Proc_DB = con.ShareProc_Con();
            scala_DB = con.ShareScala_Con();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #region Scala Methods
    public DataTable GetAccountingCodes4Stock(string StockCode)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_ViewAccountingCodes", StockCode);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetStockNameByCode(string StockCode, string CompanyCode)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetStockNameByCode_NewFinal", StockCode, CompanyCode);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetStockCodeByName(string StockName, string CompanyCode)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetStockCodeByName_NewFinal", StockName, CompanyCode);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable GetCostCenterBudgets(int costcenter, int fyear)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetFYCostCenterBudget", costcenter, fyear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion
    public DataTable GetPlanningQuarters()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetQuaters");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcurementMethods()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetProcMethods");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcurementTypes()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetProcurementTypes");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcurementTypes(int TypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetProcurementTypesByTypeID", TypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable GetCostCenterCodes()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetCostCenterCodes");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetCostCentersByName(string Search, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetCostCenterByName", Search, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetProcurementDetails(string referencenum)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetProcurementDetails", referencenum);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetSuppplierbidDetails(string referenceno)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetSupplierBiddetails", referenceno);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetCostCenterDetails(string Search)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetCostCenterDetails", Search);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetNonStockItemCategoryTypes()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetNonStockItemCategoryTypes");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAreas()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralGetAreas");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAreaManagers(int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetAreaManagers", AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetDefaultCCManager(int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetDefaultCCManager", CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetUserPlanStatus(int CostCenterID, int UserID, int YearID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPlansStatusNumbers", CostCenterID, UserID, YearID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetNonStockItemCategoriesByCategoryTypeCode(int CategoryTypeCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetNonStockItemCategoriesByCategoryTypeCode", CategoryTypeCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Get Non Category id by id and CategoryTypeCode
    /// </summary>
    /// <param name="CategoryTypeCode"></param>
    /// <param name="CategoryId"></param>
    /// <returns></returns>
    public DataTable GetNonStockItemCategoriesByCategoryTypeCodeBy(int CategoryTypeCode,int CategoryId)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetNonStockItemCategoriesByCategoryTypeCodeAndNonStockItemCatId", CategoryTypeCode, CategoryId);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetItemTypes()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetItemTypes");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }  
    public DataTable GetItems(int TypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetItems", TypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetItemsByProcTypeAndId(int TypeID,int itemID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetItemsByProcTypeAndItemID", TypeID, itemID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetItemUnits()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetUnits");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetFundSources()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetFundSources");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCurrencies()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetCurrencies");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCurrenciesByCode(string currencycode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetCurrenciesByCode", currencycode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCurrency(int Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetExchangeRate", Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCostCenter(string CostCenterName)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_CostCenterDetails", CostCenterName);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlanItemLogs(string PlanCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetLogs", PlanCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void saveCostcenterBudget(int budgetId, string budgetCode, string costcenterCode, string amount, int fyear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_SaveUpdateCostCenterBudget", budgetId,budgetCode,costcenterCode, amount, fyear);
            Proc_DB.ExecuteNonQuery(mycommand);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable CheckIsStockCostCenter(int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_PlanningGetStockCostCenters", CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable CheckIsUserInInventory(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_CheckIfUserInInventory", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcMethodByAmount(int ProcTypeID, double Amount)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetProcMethodByAmount", ProcTypeID, Amount);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcMethodForBig(int ProcTypeID, double Amount)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetProcMethodsForBig", ProcTypeID, Amount);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcAuthorityLevel(double Amount)
    {
        mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetAuthority", Amount);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;

    }
    public DataTable GetProcurmentMethodLength(int MethodID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetProcMethodLength", MethodID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetConsolidatedPlan(int FinancialYearCode, int AreaID, int CostCenterID, int QuarterID, String proctype)
    {
        try
        {
            if (proctype.Equals("0"))
            {
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_New_Consolidated", FinancialYearCode, AreaID, CostCenterID, QuarterID);
                returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            }
            else if (proctype.Equals("1"))
            {
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_New_Consolidated_NonConsultancy", FinancialYearCode, AreaID, CostCenterID, QuarterID);
                returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];

            }

            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetConsolidatedSummaryPlan(int FinancialYearCode, int AreaID, int CostCenterID, int QuarterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetConsolidateSummary", FinancialYearCode, AreaID, CostCenterID, QuarterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private int GetCostCenterIDByCode(string Code, int CostCenterID)
    {
        int returnCenter = 0;
        mycommand = Proc_DB.GetStoredProcCommand("Proc_GetCostCenterIDByCode", Code);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        if (returnDatatable.Rows.Count > 1)
        {
            returnCenter = CostCenterID;
        }
        else if (returnDatatable.Rows.Count == 0)
        {
            returnCenter = CostCenterID;
        }
        else
        {
            returnCenter = Convert.ToInt32(returnDatatable.Rows[0]["CostCenterID"]);
        }
        return returnCenter;
    }
    public void SaveItemCategory(int RecordID, string Name, int ProcTypeID, int RankNumber, bool Active)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_SaveCategory", RecordID, Name, ProcTypeID ,RankNumber, Active);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #region Plan
    public string SavePlanItem(string PlanCode, int ProcTypeID, int ProcMethodID, int FinID, bool IsOperational,
        string CapexCode, bool IsStockItem, string StockCode, string StockName, string OpexBudgetCode,int ItemCategoryID, string Desc, string Justify,bool IsGroup,
        int CostCenterID, int BudgetCostCenterID, int NonStockItemCategoryID, int FundingID, bool Planned, long PlannedByID, int IsFramework)
    {
        string SavePlanCode = "0";
        try
        {
            //int BudgetCostCenterID = GetCostCenterIDByCode(BudgetCostCenter, CostCenterID);
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_SavePlanItem", PlanCode, ProcTypeID, ProcMethodID
                         , FinID, IsOperational, CapexCode, IsStockItem, StockCode, StockName, OpexBudgetCode, ItemCategoryID, Desc, Justify, IsGroup,
                         CostCenterID, BudgetCostCenterID, NonStockItemCategoryID, FundingID, Planned, PlannedByID, IsFramework);

            System.Data.DataSet ds = Proc_DB.ExecuteDataSet(mycommand);
            int recordCount = ds.Tables[0].Rows.Count;

            if (recordCount != 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                 SavePlanCode = dr[0].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return SavePlanCode;
   }
    public void SavePlanItemDetails(string PlanCode, int UnitCode, double Unitcost, double Quantity, int AuthorityID, int QuarterID,
                                     DateTime Date4PP20, DateTime DateNeeded, int PayPeriod, int PaymentMonth, double MarketPrice)
    {

        try
        {
            //int BudgetCostCenterID = GetCostCenterIDByCode(BudgetCostCenter, CostCenterID);
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_SavePlanItemDetails", PlanCode, UnitCode, Unitcost
                         , Quantity, AuthorityID, QuarterID, Date4PP20, DateNeeded, PayPeriod, PaymentMonth,MarketPrice);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void SavePlanDoc(string PlanCode, string FilePath, string FileName, bool Requisition,string uploadedby)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_SavePlanDoc", PlanCode, FilePath, FileName, Requisition, uploadedby);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SavePlanDocWithDoctype(string PlanCode, string FilePath, string FileName, bool Requisition, string uploadedby,string doctype)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_SavePlanDocWith_doc_type", PlanCode, FilePath, FileName, Requisition, uploadedby, doctype);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveMileStoneDocuments(string PlanCode, string FilePath, string FileName,string completeddate)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("SaveMileStoneDocuments", PlanCode, FilePath, FileName, completeddate);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SavePlanAction(string PlanCode, int Status, string Remark, int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_LogTransaction", PlanCode, Status, Remark, UserID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
   public DataTable GetManagerToAlert(int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralGetManagerToAlert", CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlannerToAlert(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetPlannerToAlert", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAreaPDUOfficerToAlert(int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetAreaPDUOfficerToAlert", AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPMToAlert(int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetPMToAlert");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetActing(int Delegator)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetActingManager", Delegator);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable CheckDelegation(int DelegatorID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_CheckDelegation", DelegatorID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPendingPlanItems(string Search, int ProcTypeID, int CostCenterID, int LoggedIn, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPendingPlanItems", Search, ProcTypeID, CostCenterID, LoggedIn, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlanItemsToSubmit(string Search, int ProcTypeID, int CostCenterID, int LoggedIn, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPlanItemsToSubmit", Search, ProcTypeID, CostCenterID, LoggedIn, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetAllPlanItems(string Search, int ProcTypeID, int CostCenterID, int LoggedIn, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetAllPlanItems", Search, ProcTypeID, CostCenterID, LoggedIn, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetApprovedPlanItems(string Search, int ProcTypeID, int CostCenterID, int LoggedIn, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetApprovedPlanItems", Search, ProcTypeID, CostCenterID, LoggedIn, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
     public DataTable GetConsolidatedPlanItems(string Search,int ProcTypeID, int CostCenterID, int LoggedIn, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetConsolidatedPlanItems", Search, ProcTypeID, CostCenterID, LoggedIn, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRejectedPlanItems(string Search, int ProcTypeID, int CostCenterID, int LoggedIn, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_PLanning_RejectedPlanItems",Search, ProcTypeID, CostCenterID, LoggedIn, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlanItem(string PlanCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPlanItemAllDetails",PlanCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRejectedPlanItem(string PlanCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetRejectItemStatus", PlanCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlanDocuments(string Plancode, string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetDocuments",Plancode, PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetManagerPlanItem(string PlanCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetPlanItemsSummary", PlanCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetManagerPlanItems(string Search, int ProcTypeID, int QuarterID, int CostCenterID, int ManagerID, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetItemsForManagers", Search, ProcTypeID, QuarterID, CostCenterID, ManagerID, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }


    public DataTable GetMDPlanItems(string Search, int ProcTypeID, int QuarterID, int CostCenterID, int ManagerID, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetItemsForMD", Search, ProcTypeID, QuarterID, CostCenterID, ManagerID, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAreaPDUOfficerPlanItems(string Search, int ProcTypeID, int CostCenterID, int AreaID, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetItemsForAreaPDUOfficers", Search, ProcTypeID, CostCenterID, AreaID, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlannerAndCCManagerByPlanCode(string PlanCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPlannerAndCCManager", PlanCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetPlanItemsForPM(int AreaID, int ProcTypeID, int CostCenterID, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_PlanningGetItemForProcManager", AreaID, ProcTypeID, CostCenterID, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlanItemsForDeletePM(string plancode, int AreaID, int ProcTypeID, int CostCenterID, int finYear, int deleted)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_PlanningGetDeleteItemForProcManager", plancode, AreaID, ProcTypeID, CostCenterID, finYear, deleted);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetPlanItemsForOperations(int AreaID, int ProcTypeID, int CostCenterID, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_PlanningGetItemForOperations", AreaID, ProcTypeID, CostCenterID, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPendingPlanItemsForPM(string Search, int ProcTypeID, int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetPendingPlanItemsForPM", Search, ProcTypeID, CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetItemCategories(int ProcTypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetItemCatgories", ProcTypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetFinancialYears(int RecordID)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetFinancialYears", RecordID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable CheckFinancialYear(DateTime StartDate, DateTime EndDate)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_CheckYear", StartDate, EndDate);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetItemCategoryDetails(int RecordID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetCategoryDetails", RecordID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPMPlanItemsByCostCenter(int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetPMPlanItemsByCostCenter", CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetDocumentPath(long FileID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetDocPath", FileID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SubmitPlanItems(string PlanCode, int StatusID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_SubmitPlanItem", PlanCode, StatusID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SubmitPlanItems(string PlanCode, int CCManager, int StatusID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_SubmitPlanItemToCCManager", PlanCode, CCManager, StatusID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagPlanItems(string PlanCode, int delete)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_DeletePlanItem", PlanCode);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SubmitPlanItemForDeletion(string PlanCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_SubmitPlanItemForDeletion", PlanCode);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveFinancialYear(int RecordID, DateTime StartDate, DateTime EndDate, bool Active)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_SaveYear", RecordID,StartDate, EndDate, Active);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void RemoveDocument(long FileID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_DeleteDocument", FileID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBudgetCodes(int CostCenterID, bool IsCapex)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetCostCenterBudget", CostCenterID, IsCapex);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetBudgetCodeTotal(string BudgetCode, string CostCenterCode, string CompanyCode)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetBudgetForPlanning", BudgetCode, CostCenterCode, CompanyCode);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlannedTotal(int CostCenterID, string BudgetCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPlannedTotalAmount", CostCenterID, BudgetCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable CheckBudgetConsolidation(int CostCenterID, string BudgetCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_CheckBudgetConsolidation", CostCenterID, BudgetCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetQuarterRange(int QuarteID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetQuarterRanger", QuarteID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    public DataTable GetPlanItemForViewing(string PlanCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPlanItemForViewing", PlanCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetExpectedExpenditure(int FinancialYearCode, int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetExpectedExpenditureReport", FinancialYearCode, CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlannedCashFlow(int FinancialYearCode, int AreaID, int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPlannedCashFlowReport", FinancialYearCode, AreaID, CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPlannedCashFlowByQuarter(int FinancialYearCode, int AreaID, int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPlannedCashFlowByQuarterReport", FinancialYearCode, AreaID, CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetUserDeptPlan(int FinancialYearCode, int AreaID, int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetUserDeptPlan", FinancialYearCode, AreaID, CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetPPDAProcPlan(int FinancialYearCode, int AreaID, int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetPPDAProcPlan", FinancialYearCode, AreaID, CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable IsDateInQuarter(int Month, int Quarter)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_CheckDateIfInQuarter", Quarter, Month);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetUsersByNames(string Value)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetUsersByNames", Value);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetUserByNames(string Name)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetUserByName", Name);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidderByName(string CompanyName)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderByName", CompanyName);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBiddersByNames(string Value)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBiddersByName", Value);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBiddersByNamesWithContextKey(string Company, int CategoryID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBiddersByNameWithContextKey", Company, CategoryID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
