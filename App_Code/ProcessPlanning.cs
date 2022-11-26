using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public class ProcessPlanning
{
    DataPlanning data = new DataPlanning();
    DataLogin main = new DataLogin();
    BusinessPlanning bll = new BusinessPlanning();
    DataSet dataSet = new DataSet();
    DataTable dTable = new DataTable();
    SendMail mailer = new SendMail();
	public ProcessPlanning()
	{
    }
    private string plancode;
    public string PlanCodeReturn
    {
        get
        {
            return plancode;
        }
        set
        {
            plancode = value;
        }
    }

    #region Scala Methods

    public DataTable GetStockItemsByCode(string StockCode, string CompanyCode)
    {
        return data.GetStockNameByCode(StockCode, CompanyCode);
    }

    public DataTable GetStockCodeByName(string StockName, string CompanyCode)
    {
        //StockName = StockName.Replace("'","''''");
        //StockName = StockName.Replace("\"","''''");
        StockName = StockName.Replace("'", "''");
        return data.GetStockCodeByName(StockName.Trim().ToUpper(), CompanyCode);
    }

    #endregion

    #region Data Table Methods

    public DataTable GetPlanningQuaters()
    {
        dTable = data.GetPlanningQuarters();
        return dTable;
    }
    public DataTable GetUserPlanStatuses(int CostCenterID, int UserID, int YearID)
    {
        return data.GetUserPlanStatus(CostCenterID, UserID, YearID);
    }

    public DataTable GetCostCenterBudgets(int costcenter, int fyear)
    {

        dTable = data.GetCostCenterBudgets(costcenter, fyear);
        return dTable;
    }

    public DataTable GetNonStockItemCategoryTypes()
    {
        dTable = data.GetNonStockItemCategoryTypes();
        return dTable;
    }
    public DataTable GetNonStockItemCategoriesByCategoryTypeCode(int CategoryTypeCode)
    {
        dTable = data.GetNonStockItemCategoriesByCategoryTypeCode(CategoryTypeCode);
        return dTable;
    }
    public DataTable GetNonStockItemCategoriesByCategoryTypeCodeBy(int CategoryTypeCode,int categoryid)
    {
        dTable = data.GetNonStockItemCategoriesByCategoryTypeCodeBy(CategoryTypeCode, categoryid);
        return dTable;
    }
    public DataTable GetItemCategoriesDatails(string ProcTypeCode)
    {
        int ProcTypeID = Convert.ToInt32(ProcTypeCode);
        dTable = data.GetItemCategories(ProcTypeID);
        return dTable;
    }
    public DataTable GetFinancialYears(string RecordCode)
    {
        int RecordID = Convert.ToInt32(RecordCode);
        dTable = data.GetFinancialYears(RecordID);
        return dTable;
    }
    public DataTable GetItemCategoryDatails(int RecordID)
    {
        dTable = data.GetItemCategoryDetails(RecordID);
        return dTable;
    }
    public DataTable GetProcurementTypes()
    {
        dTable = data.GetProcurementTypes();
        return dTable;
    }
    public DataTable GetProcurementTypes(string TypeCode)
    {
        int TypeID = Convert.ToInt32(TypeCode);
        dTable = data.GetProcurementTypes(TypeID);
        return dTable;
    }
    public DataTable GetProcurementMethods()
    {
        dTable = data.GetProcurementMethods();
        return dTable;
    }
    public DataTable GetProcMethods(int ProcTypeID, double amount)
    {
        dTable = data.GetProcMethodByAmount(ProcTypeID, amount);
        return dTable;
    }
    public DataTable GetProcMethodsForBig(int ProcTypeID, double amount)
    {
        dTable = data.GetProcMethodForBig(ProcTypeID, amount);
        return dTable;
    }
    public DataTable GetItemUnits()
    {
        dTable = data.GetItemUnits();
        return dTable;
    }
    public DataTable GetItemTypes()
    {
        dTable = data.GetItemTypes();
        return dTable;
    }

    public DataTable GetCostCenterCodes()
    {
        dTable = data.GetCostCenterCodes();
        return dTable;
    }

    public DataTable GetAreas()
    {
        dTable = data.GetAreas();
        return dTable;
    }
    public DataTable GetAreaManagers()
    {
        int AreaID = int.Parse(HttpContext.Current.Session["AreaCode"].ToString());
        return data.GetAreaManagers(AreaID);
    }
    public DataTable GetDefaultCCManager()
    {
        int CostCenterID = int.Parse(HttpContext.Current.Session["CostCenterID"].ToString());
        return data.GetDefaultCCManager(CostCenterID);
    }
    public DataTable GetItems(string TypeID)
    {
        int TypeCode = Convert.ToInt32(TypeID);
        dTable = data.GetItems(TypeCode);
        return dTable;
    }
    public DataTable GetItemsByProcTypeAndId(string TypeID, string itemid)
    {
        int TypeCode = Convert.ToInt32(TypeID);
        int iditem = Convert.ToInt32(itemid);
        dTable = data.GetItemsByProcTypeAndId(TypeCode, iditem);
        return dTable;
    }
    public DataTable GetQuarters()
    {
        dTable = data.GetPlanningQuarters();
        return dTable;
    }
    public DataTable GetFundSources()
    {
        dTable = data.GetFundSources();
        return dTable;
    }
    public int GetAuthority(double Cost)
    {
        dTable = data.GetProcAuthorityLevel(Cost);
        int AuthorityID = Convert.ToInt32(dTable.Rows[0]["AuthorityCode"]);
        return AuthorityID;
    }
    public DataTable GetCurrencies()
    {
        dTable = data.GetCurrencies();
        return dTable;
    }
    public DataTable GetCurrenciesByCode(string currencycode)
    {
        dTable = data.GetCurrenciesByCode(currencycode);
        return dTable;
    }
    public DataTable GetCurrency(string Code)
    {
        int CurrencyID = Convert.ToInt32(Code);
        dTable = data.GetCurrency(CurrencyID);
        return dTable;
    }
    public double GetBugetAmount(string CostCenterCode, string BudgetCode)
    {
        string Company = CostCenterCode.Substring(0, 2).ToString();
        string CostCenter = CostCenterCode.Remove(0, 2);
        int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
        if (bll.IsBudgetConsolidated(BudgetCode, CostCenterID))
        {
            CostCenter = "0";
        }
        double Amount = 0;
        dTable = data.GetBudgetCodeTotal(BudgetCode, CostCenter, Company);
        if (dTable.Rows.Count > 0)
        {
            Amount = Convert.ToDouble(dTable.Rows[0]["FINAL_VALUES"].ToString());
        }
        return Amount;
    }
    public double GetPlannedAmount(string CostCenterCode, string BudgetCode)
    {
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        dTable = data.GetPlannedTotal(CostCenterID, BudgetCode);
        double Amount = Convert.ToDouble(dTable.Rows[0]["TotalAmount"].ToString());
        return Amount;
    }
    public DataTable GetPMPlanItems(string Search, string ProcTypeID, string CostCenterCode)
    {
        int AreaID = Convert.ToInt32(Search);
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        dTable = data.GetPlanItemsForPM(AreaID, ProcTypeCode, CostCenterID, fin);
        return dTable;
    }
    public DataTable GetPlanItemsForDeletePM(string plancode, string Search, string ProcTypeID, string CostCenterCode, int deleted)
    {
        int AreaID = Convert.ToInt32(Search);
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        dTable = data.GetPlanItemsForDeletePM(plancode, AreaID, ProcTypeCode, CostCenterID, fin, deleted);
        return dTable;
    }
    public DataTable GetPlanItemsForOperations(string Search, string ProcTypeID, string CostCenterCode)
    {
        int AreaID = Convert.ToInt32(Search);
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        dTable = data.GetPlanItemsForOperations(AreaID, ProcTypeCode, CostCenterID, fin);
        return dTable;
    }

    public DataTable GetPendingPMPlanItems(string Search, string ProcTypeID, string CostCenterCode)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        dTable = data.GetPendingPlanItemsForPM(Search, ProcTypeCode, CostCenterID);
        return dTable;
    }
    public string  GetDocPath()
    {
        string Path = "D:\\Reports\\ProcurementAttachments\\";
        dTable = main.GetConfiguration(1);
        if (dTable.Rows.Count > 0)
        {
            Path = dTable.Rows[0]["Details"].ToString();
        }
        CheckPath(Path);
        return Path;
    }
    //public string ForwardPlanItem(string PlanCode, int StatusID, string Remark, int ManagerID, string Manager)
    //{
    //    string output = "";
    //    //data.ForwardRequisition(PD_Code, ManagerID);
    //    output = "Requisition ( " + PD_Code + " ) has been successfully forwarded to Cost Center Manager ( " + Manager + " )";
    //    LogandCommitRequisition(PD_Code, StatusID, Remark);

    //    return output;
    //}
    public bool IsUserInInventory()
    {
        int UserID = int.Parse(HttpContext.Current.Session["UserID"].ToString());
        dTable = data.CheckIsUserInInventory(UserID);
        int foundRows = dTable.Rows.Count;
        if (foundRows > 0)
            return true;
        else
            return false;
    }

    public bool IsUserInInventory(int UserID)
    {
        dTable = data.CheckIsUserInInventory(UserID);
        int foundRows = dTable.Rows.Count;
        if (foundRows > 0)
            return true;
        else
            return false;
    }

    private void CheckPath(string Path)
    {
        if (!Directory.Exists(Path))
        {
            Directory.CreateDirectory(Path);
        }
    }

    public DataTable GetAllPlanItems(string Search, string ProcTypeID, string CostCenterCode)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int UserID = 0;
        if (HttpContext.Current.Session["AccessLevelID"].ToString() == "5")
            UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"].ToString());
        dTable = data.GetAllPlanItems(Search, ProcTypeCode, CostCenterID, UserID, fin);
        return dTable;
    }

    public void saveCostcenterBudget(int budgetId, string budgetCode, string costcenterCode, string amount, int fyear)
    {
        data.saveCostcenterBudget(budgetId, budgetCode, costcenterCode, amount, fyear);
    }

    public DataTable GetPendingPlanItems(string Search, string ProcTypeID, string CostCenterCode)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int UserID = 0;
        if (HttpContext.Current.Session["AccessLevelID"].ToString() == "5")
            UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"].ToString());
        dTable = data.GetPendingPlanItems(Search, ProcTypeCode, CostCenterID, UserID, fin);
        return dTable; 
    }
        
    public DataTable GetApprovedPlanItems(string Search, string ProcTypeID, string CostCenterCode)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode); 
        int UserID = 0;
        if (HttpContext.Current.Session["AccessLevelID"].ToString() == "5")
            UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        dTable = data.GetApprovedPlanItems(Search, ProcTypeCode, CostCenterID, UserID, fin);
        return dTable;
    }
    public DataTable GetConsolidatedItems(string Search, string ProcTypeID, string CostCenterCode)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int UserID = 0;
        if (HttpContext.Current.Session["AccessLevelID"].ToString() == "5")
            UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString()); 
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        dTable = data.GetConsolidatedPlanItems(Search, ProcTypeCode, CostCenterID, UserID, fin);
        return dTable;
    }
    public DataTable GetPlanItemDetails(string PlanCode)
    {
        dTable = data.GetPlanItem(PlanCode);
        return dTable;
    }
    public DataTable GetPlanCosolidatedDetails(string FinCode, string AreaCode, string CostCenter, string Quarter, String proctypelevl)
    {
        int FinancialID = Convert.ToInt32(FinCode);
        int AreaID = Convert.ToInt32(AreaCode);
        int CostCenterID = Convert.ToInt32(CostCenter);
        int QuarterID = Convert.ToInt32(Quarter);
        dTable = data.GetConsolidatedPlan(FinancialID, AreaID, CostCenterID, QuarterID, proctypelevl);
        return dTable;
    }
    public DataTable GetPlanCosolidatedSummary(string FinCode, string AreaCode, string CostCenter, string Quarter)
    {
        int FinancialID = Convert.ToInt32(FinCode);
        int AreaID = Convert.ToInt32(AreaCode);
        int CostCenterID = Convert.ToInt32(CostCenter);
        int QuarterID = Convert.ToInt32(Quarter);
        dTable = data.GetConsolidatedSummaryPlan(FinancialID, AreaID, CostCenterID, QuarterID);
        return dTable;
    }
    public DataTable GetBudgetCodes(string CostCenterCode, bool IsCapex)
    {
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        dTable = data.GetBudgetCodes(CostCenterID, IsCapex);
        return dTable;
    }
    public DataTable GetRejectedPlanItems(string Search,string ProcTypeID, string CostCenterCode)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int UserID = 0;
        if (HttpContext.Current.Session["AccessLevelID"].ToString() == "5")
            UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        dTable = data.GetRejectedPlanItems(Search,ProcTypeCode, CostCenterID, UserID, fin);
        return dTable;
    }
    public DataTable GetPlanDocuments(string Plancode, string PD_Code)
    {
        dTable = data.GetPlanDocuments(Plancode, PD_Code);
        return dTable;
    }
    public DataTable GetCostCentersByName(string Search, string AreaCode)
    {
        int AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetCostCentersByName(Search, AreaID);
        return dTable;
    }

    public DataTable GetProcurementDetails(string referenceno)
    {
        dTable = data.GetProcurementDetails(referenceno);
        return dTable;
    }
    public DataTable GetSuppliersWithBiddDocuments(string referenceno)
    {
        dTable = data.GetSuppplierbidDetails(referenceno);
        return dTable;
    }
    public DataTable GetManagerPlanItem(string PlanCode)
    {
        dTable = data.GetManagerPlanItem(PlanCode);
        return dTable;
    }
    public DataTable GetPendingPlanItems(string Search, string ProcTypeID, string QuarterCode, string CostCenterCode, string LoggedIn)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int QuarterID = Convert.ToInt32(QuarterCode);
        int UserID = Convert.ToInt32(LoggedIn);
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        dTable = data.GetPendingPlanItems(Search, ProcTypeCode, CostCenterID, UserID, fin);
        return dTable;

    }
    public DataTable GetPlanItemsToSubmit(string Search, string ProcTypeID, string QuarterCode, string CostCenterCode, string LoggedIn)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int QuarterID = Convert.ToInt32(QuarterCode);
        int UserID = Convert.ToInt32(LoggedIn);
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        dTable = data.GetPlanItemsToSubmit(Search, ProcTypeCode, CostCenterID, UserID, fin);
        return dTable;

    }
    
    public DataTable GetManagerPlanItems(string Search, string ProcTypeID, string QuarterCode, string CostCenterCode)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int QuarterID = Convert.ToInt32(QuarterCode);
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        int ManagerID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        dTable = data.GetManagerPlanItems(Search, ProcTypeCode, QuarterID, CostCenterID, ManagerID, fin);
        return dTable;
    }

    public DataTable GetMDPlanItems(string Search, string ProcTypeID, string QuarterCode, string CostCenterCode)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int QuarterID = Convert.ToInt32(QuarterCode);
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        int ManagerID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        dTable = data.GetMDPlanItems(Search, ProcTypeCode, QuarterID, CostCenterID, ManagerID, fin);
        return dTable;
    }
    public DataTable GetAreaPDUOfficerPlanItems(string Search, string ProcTypeID, string CostCenterCode)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int fin = Convert.ToInt32(HttpContext.Current.Session["PFinYearCode"]);
        int AreaID = Convert.ToInt32(HttpContext.Current.Session["AreaCode"]);
        dTable = data.GetAreaPDUOfficerPlanItems(Search, ProcTypeCode, CostCenterID, AreaID, fin);
        return dTable;
    }
    public DataTable GetCostCenterDetails(string CostCenterName)
    {
        dTable = data.GetCostCenterDetails(CostCenterName);
        return dTable;
    }
    public string GetCostCenter(string SearchString)
    {
        dTable = data.GetCostCenter(SearchString);
        string CostCenter = "000000";
        if (dTable.Rows.Count > 0)
        {
            CostCenter = dTable.Rows[0]["CostCenterDetail"].ToString();
        }
        return CostCenter;
    }
    #endregion
    public string GetProcurementLengthstr(string ProcMethodCode)
    {
        string ProcLength = "-";
        int MethodID = Convert.ToInt32(ProcMethodCode);
        if (ProcMethodCode != "0")
        {
            dTable = data.GetProcurmentMethodLength(MethodID);
            if (dTable.Rows.Count > 0)
            {
                string ProcLengthGot = dTable.Rows[0]["MethodLength"].ToString();
                string mth = "Months";
                ProcLength = "This Procurement will take " + ProcLengthGot + " " + mth + " [Procurement Length]";
            }
        }
        return ProcLength;
    }
    public int GetProcurementLength(string ProcMethodCode)
    {
        int ProcLength = 0;
        int MethodID = Convert.ToInt32(ProcMethodCode);
        if (ProcMethodCode != "0")
        {
            dTable = data.GetProcurmentMethodLength(MethodID);
            if (dTable.Rows.Count > 0)
            {
                ProcLength = Convert.ToInt32(dTable.Rows[0]["MethodLength"].ToString());
            }
        }
         return ProcLength;
    }

    public double GetTotalCost(double Quantity, string strUnitCost, double ExchangeRate)
    {
      double UnitCost = double.Parse(strUnitCost.Replace(",", ""));
      double Amount = Quantity * UnitCost * ExchangeRate;
      return Amount;
    }
    public double GetMarketPrice(string strUnitCost)
    {
        double newUnitCost = double.Parse(strUnitCost.Replace(",", ""));
        return newUnitCost;

    }
    public int GetProcurementMethod(string ProcType, double amount)
    {
        int ProcTypeID = Convert.ToInt32(ProcType);
        dTable = data.GetProcMethodByAmount(ProcTypeID, amount);
        int ProcMethodID = 0;
        if (dTable.Rows.Count > 0)
            ProcMethodID = Convert.ToInt32(dTable.Rows[0]["ProcurementMethodCode"]);
        return ProcMethodID;

    }
    public string SavePlan(string PlanCode, string ProcTypeCode, string ProcMethodCode, string FinCode, bool IsOperational,
        bool IsStockItem, string StockCode, string StockName, string CapexCode, string OpexBudgetCode, string ItemCategoryCode, string Desc, string Justify, bool IsGroupItem,
        string CostCenterCode, string BudgetCostCenterCode, string NonStockItemCategoryCode, string FundingCode, string UnitCode, double Unitcost, string Quatity, string QuarterCode,
                                     string Date4PP20, string DateNeeded, string PayPeriod, string PaymentMonth, string ProcLength, string PlannedBy, bool Planned, double MarketPrice, bool IsFramework)
    {
        string output = "";
        int ProcTypeID = Convert.ToInt32(ProcTypeCode);
        int ProcMethodID = Convert.ToInt32(ProcMethodCode);
        int FinID = Convert.ToInt32(FinCode);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int BudgetCostCenterID = Convert.ToInt32(BudgetCostCenterCode);
        int FundingID = Convert.ToInt32(FundingCode);
        int ItemCategoryID = Convert.ToInt32(ItemCategoryCode); 
        int NonStockItemCategoryID = 0;
        if (!IsStockItem)
            NonStockItemCategoryID = Convert.ToInt32(NonStockItemCategoryCode);
        long PlannedByID = Convert.ToInt64(PlannedBy);
        DateTime DatePP20 = Convert.ToDateTime(Date4PP20);
        DateTime Date = Convert.ToDateTime(DateNeeded);
        int IsFrameworkValue = 0;
        if (IsFramework)
        {
            IsFrameworkValue = Convert.ToInt32(1);
        }
        else
        {
            IsFrameworkValue = Convert.ToInt32(0);
        }
        string PlanCodeSaved = data.SavePlanItem(PlanCode, ProcTypeID, ProcMethodID, FinID, IsOperational, CapexCode, IsStockItem,
                               StockCode, StockName, OpexBudgetCode, ItemCategoryID, Desc, Justify, IsGroupItem, CostCenterID,
                               BudgetCostCenterID, NonStockItemCategoryID, FundingID, Planned, PlannedByID, IsFrameworkValue);
        string PlanCodeReturned = "";
        if (PlanCode == "0")
        {
            PlanCodeReturned = PlanCodeSaved;
        }
        else
        {
            PlanCodeReturned = PlanCode;
        }
        SavePlanDetails(PlanCodeReturned, UnitCode, Unitcost, Quatity, QuarterCode, DatePP20, Date, PayPeriod, PaymentMonth,MarketPrice);
        plancode = PlanCodeSaved;
        if (PlanCode != "0")
        {
            
            output = "Plan Item has been updated Successfully";
        }
        else
        {
            output = "Plan Item(" + PlanCodeReturned + ") has been captured Successfully";
        }

        return output;
    }
    private void SavePlanDetails(string PlanCode, string UnitCode, double Unitcost, string Quatity, string QuarterCode,
                                     DateTime DatePP20, DateTime DateNeeded, string PayPeriod, string PaymentMonth, double MarketPrice)
    {
        int UnitID = Convert.ToInt32(UnitCode);
        double Quantity = Convert.ToDouble(Quatity);
        int QuarterID = Convert.ToInt32(QuarterCode);
        int PayPeriodID = Convert.ToInt32(PayPeriod);
        int PaymentMonthID = Convert.ToInt32(PaymentMonth);
        double TotalCost = Quantity * Unitcost;
        double Marketprice = Convert.ToDouble(MarketPrice);
        int Authorty = GetAuthority(TotalCost);
        data.SavePlanItemDetails(PlanCode, UnitID, Unitcost, Quantity, Authorty, QuarterID, DatePP20, DateNeeded,
                                 PayPeriodID, PaymentMonthID,Marketprice);

    }
    public void SavePlanDocuments(string PlanCode, string FilePath, string FileName, bool Requisition)
    {
        data.SavePlanDoc(PlanCode, FilePath, FileName, Requisition);
    }

    public void SaveMileStoneDocuments(string milestoneid, string FilePath, string FileName)
    {
        data.SaveMileStoneDocuments(milestoneid, FilePath, FileName);
    }

    private string GetBudgetCostCenter(string BudgetCostCenter)
    {
        int dashPosition = 0;
        dashPosition = BudgetCostCenter.IndexOf("-");
        string CostCenter = BudgetCostCenter.Substring(0, dashPosition).Trim();
        return CostCenter;

    }

    public string GetManagerNameByUserid(int UserID)
    {
        string name = "";
        dTable = data.GetManagerToAlert(UserID);
        int NotifeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
        if (bll.IsDelegated(NotifeeID))
        {
            dTable = data.GetActing(NotifeeID);
            name = dTable.Rows[0]["FullName"].ToString();
        }
        else
        {
            name = dTable.Rows[0]["FullName"].ToString();
        }
        return name;
    }
    public void NotifyManager(string SenderName, string Subject, int UserID, string Message)
    {
        string Name = "";
        string Email = "";
        dTable = data.GetManagerToAlert(UserID);
        int NotifeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
        if (bll.IsDelegated(NotifeeID))
        {
            dTable = data.GetActing(NotifeeID);
            Name = dTable.Rows[0]["FullName"].ToString();
            Email = dTable.Rows[0]["Email"].ToString();
        }
        else
        {
            Name = dTable.Rows[0]["FullName"].ToString();
            Email = dTable.Rows[0]["Email"].ToString();
        }
        string Msg = "<p>Hello " + Name.ToUpper() + ", </p>" + Message;
      mailer.SendEmail(SenderName, Email, Subject, Msg);
    }

    //send email
    public void NotifyBidder(string SenderName, string Subject,string bidderName,string bidderEmail, string Message)
    {
        string Name = "";
        string Email = "";
        string Msg = "<p>Hello " + bidderName.ToUpper() + ", </p>" + Message;
        mailer.SendEmail(SenderName, bidderEmail, Subject, Msg);
    }
    public void NotifyPlanner(string SenderName, string Subject, string UserCode, string Message)
    {
        string Name = "";
        string Email = "";
        int UserID = Convert.ToInt32(UserCode);
        dTable = data.GetPlannerToAlert(UserID);
        int NotifyeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
        if (bll.IsDelegated(NotifyeeID))
        {
            dTable = data.GetActing(NotifyeeID);
            Name = dTable.Rows[0]["FullName"].ToString();
            Email = dTable.Rows[0]["Email"].ToString();
        }
        else
        {
            Name = dTable.Rows[0]["FullName"].ToString();
            Email = dTable.Rows[0]["Email"].ToString();
        }

        string Msg = "<p>Hello " + Name.ToUpper() + ", </p> " + Message;
       mailer.SendEmail(SenderName, Email, Subject, Msg);
    }

    
    public void NotifyAreaPDUOfficer(string SenderName, string Subject, int AreaID, string Message)
    {
        string Name = ""; string Msg = "";
        string Email = "";
        dTable = data.GetAreaPDUOfficerToAlert(AreaID);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow dr in dTable.Rows)
            {
                int NotifyeeID = Convert.ToInt32(dr["UserID"]);
                if (bll.IsDelegated(NotifyeeID))
                {
                    dTable = data.GetActing(NotifyeeID);
                    Name = dr["FullName"].ToString();
                    Email = dr["Email"].ToString();
                }
                else
                {
                    Name = dr["FullName"].ToString();
                    Email = dr["Email"].ToString();
                }
                Msg = "<p>Hello " + Name + ", </p>" + Message;
             mailer.SendEmail(SenderName, Email, Subject, Msg);
            }
        }
    }
    public void NotifyProcurementManager(string SenderName, string Subject, int CostCenterID, string Message)
    {
        string Name = ""; string Msg = "";
        string Email = "";
        dTable = data.GetPMToAlert(CostCenterID);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow dr in dTable.Rows)
            {
                int NotifyeeID = Convert.ToInt32(dr["UserID"]);
                if (bll.IsDelegated(NotifyeeID))
                {
                    dTable = data.GetActing(NotifyeeID);
                    Name = dr["FullName"].ToString();
                    Email = dr["Email"].ToString();
                }
                else
                {
                    Name = dr["FullName"].ToString();
                    Email = dr["Email"].ToString();
                }
                Msg = "<p>Hello " + Name + ", </p>" + Message;
                mailer.SendEmail(SenderName, Email, Subject, Msg);
            }
        }
    }
    public string SubmitPlanItems(string StrArry, int CCManagerID, string CCManager, int Status)
    {
        string output = "";
        if (StrArry != "")
        {
            string[] arr = StrArry.Split(',');
            int i = 0;
            string PlanCode = "";
            for (i = 0; i < arr.Length; i++)
            {
                PlanCode = arr[i].ToString();
                if (PlanCode != "")
                {
                    data.SubmitPlanItems(PlanCode, CCManagerID, Status);
                    LogPlanItemTransaction(PlanCode, Status, "Plan item has been submitted to Cost Center Manager ( " + CCManager + ")");
                }
            }
            /// Notify Cost Center Manager
            string CostCenterName = HttpContext.Current.Session["CostCenterName"].ToString();
            int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
            string By = HttpContext.Current.Session["FullName"].ToString();
            string Subject = "Plan Item(s) For Approval";
            string MessageToSend = "<p>You have been sent " + i + " plan item(s) for approval from Cost Center/Department: " + CostCenterName +"</p>";
            MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
            NotifyManager(By, Subject, CCManagerID, MessageToSend);

            output = i + " plan items have been submitted to Cost Center Manager for approval";
        }
        else
        {
            output = "Please select plan item(s) to submit for approval";
        }
        return output;
    }

    //public string ConsolidatePlanItems(string StrArry, int Status)
    //{
    //    string output = "";
    //    if (StrArry != "")
    //    {
    //        string[] arr = StrArry.Split(',');
    //        int i = 0;
    //        string PlanCode = "";
    //        for (i = 0; i < arr.Length; i++)
    //        {
    //            //Response.Write(myArr[i] + " ");
    //            PlanCode = arr[i].ToString();
    //            if (PlanCode != "")
    //            {
    //                data.SubmitPlanItems(PlanCode, Status);
    //                LogPlanItemTransaction(PlanCode, Status, "Merge Consolidation");
    //            }
    //        }
    //        /// Notify Cost Center Manager
    //        output = i + " plan items have been Consoldated Successfully";
    //    }
    //    else
    //    {
    //        output = "Please Select Plan Item(s) to Consolidate";
    //    }
    //    return output;

    //}

    public string DeletePlanItemsByProcManager(string StrPlanCodes, int Status, string Comment)
    {

        string output = "";
        if (StrPlanCodes != "")
        {
            int noOfPlans = DeletePlanItems(StrPlanCodes, Status, Comment);
            string By = HttpContext.Current.Session["FullName"].ToString();
            string CostCenterName = HttpContext.Current.Session["CostCenterName"].ToString();
            int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
            output = noOfPlans + " Plan Item(s) have been successfully deleted";


        }
        else
        {
            output = "Please select plan item(s) to reject or delete.";
        }
        return output;


    }
    private int DeletePlanItems(string StrArry, int Status, string Comment)
    {

        string[] arr = StrArry.Split(',');
        int i = 0;
        string PlanCode = "";
        for (i = 0; i < arr.Length; i++)
        {
            PlanCode = arr[i].ToString();
            if (PlanCode != "")
            {
                data.FlagPlanItems(PlanCode, 1);
                LogPlanItemTransaction(PlanCode, Status, Comment);
            }
        }
        return i;
    }
    public string DeletePlanItems(string StrArry, int Status, string Comment, int RemoveLevel)
    {
        string output = "";
        string MessageToSend = "";
        string By = HttpContext.Current.Session["FullName"].ToString();
        if (StrArry != "")
        {
            string[] arr = StrArry.Split(',');
            int i = 0;
            string PlanCode = "";
            for (i = 0; i < arr.Length; i++)
            {
                PlanCode = arr[i].ToString();
                if (PlanCode != "")
                {
                    data.SubmitPlanItemForDeletion(PlanCode);
                    LogPlanItemTransaction(PlanCode, Status, Comment);
                }
            }

            foreach (string planCode in GetStringsFromArray(StrArry))
            {
                if (RemoveLevel == 1)
                    MessageToSend = "<p>Your Plan Item ( " + planCode + " ) Has Been Removed By Cost Center Manager ( " + By + " ) </p>";
                else
                    MessageToSend = "<p>Your Plan Item ( " + planCode + " ) Has Been Removed By Operations Department ( " + By + " ) </p>";
                MessageToSend += "<p>Comment : " + Comment + " </p>";
                dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
                string Planner = dTable.Rows[0]["PlannedBy"].ToString();
                string Subject = dTable.Rows[0]["Description"].ToString();
                NotifyPlanner(By, Subject, Planner, MessageToSend);
            }
            
            output = i + " Plan Items Have Been Deleted";
        }
        else
        {
            output = "Please Select Plan Item(s) For Deletion";
        }
        return output;
    }

    private string[] GetStringsFromArray(string strArray)
    {
        return strArray.Split(',');
    }

    public string SubmitPlanItemsForApproval(string StrPlanCodes, int Status, string Comment)
    {
        string output = "";
        if (StrPlanCodes != "")
        {
            string[] arr = StrPlanCodes.Split(',');
            int i = 0;
            string PlanCode = "";
            for (i = 0; i < arr.Length; i++)
            {
                PlanCode = arr[i].ToString();
                if (PlanCode != "")
                {
                    data.SubmitPlanItems(PlanCode, Status);
                    LogPlanItemTransaction(PlanCode, Status, Comment);
                }
            }
            string By = HttpContext.Current.Session["FullName"].ToString();
            string CostCenterName = HttpContext.Current.Session["CostCenterName"].ToString();
            int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
            string MessageToSend = ""; string Subject = "";
            switch (Status)
            {
                case 6:
                    MessageToSend = "<p>You have been sent " + i + " Plan Item(s) for approval from Cost Center/Department: " + CostCenterName + " </p>";
                    MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
                    Subject = "Plan Item(s) For Consolidation";
                    //NotifyProcurementManager(By, Subject, CostCenterID, MessageToSend);

                    output = i + " plan items have been approved and sent to Budget Committee for Consolidation";

                    foreach (string planCode in GetStringsFromArray(StrPlanCodes))
                    {
                        MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been sent to Budget Committee for consolidation</p>";
                        MessageToSend += "<p>Comment: " + Comment + " </p>";
                        MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
                        dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
                        string planner = dTable.Rows[0]["PlannedBy"].ToString();
                        Subject = dTable.Rows[0]["Description"].ToString();
                      NotifyPlanner(By, Subject, planner, MessageToSend);
                    }
                    break;
                case 103:
                    MessageToSend = "<p>You have been sent " + i + " Plan Item(s) for approval from Cost Center/Department: " + CostCenterName + " </p>";
                    MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
                    Subject = "Plan Item(s) For Approval";
                    int AreaID = Convert.ToInt32(HttpContext.Current.Session["AreaCode"].ToString());
                    NotifyManager(By, Subject, 3, MessageToSend);
                       output = i + " plan items have been approved and sent to the Managing Director";

                    foreach (string planCode in GetStringsFromArray(StrPlanCodes))
                    {
                        MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been sent to the Managing Director </p>";
                        MessageToSend += "<p>Comment: " + Comment + " </p>";
                        MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
                        dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
                        string planner = dTable.Rows[0]["PlannedBy"].ToString();
                        Subject = dTable.Rows[0]["Description"].ToString();
                        NotifyPlanner(By, Subject, planner, MessageToSend);
                    }
                    break;
                case 8:
                    output = i + " plan items have been approved by Managing Director";
                    foreach (string planCode in GetStringsFromArray(StrPlanCodes))
                    {
                        MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been approved by Managing Director </p>";
                        MessageToSend += "<p>Comment: " + Comment + " </p>";
                        MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
                        dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
                        string planner = dTable.Rows[0]["PlannedBy"].ToString();
                        Subject = dTable.Rows[0]["Description"].ToString();
                        NotifyPlanner(By, Subject, planner, MessageToSend);
                    }
                    break;
                case 3:
                    // Notify Planner about rejection
                    foreach (string planCode in GetStringsFromArray(StrPlanCodes))
                    {
                        MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been rejected by Cost Center Manager ( " + By + " ) </p> ";
                        MessageToSend += "<p>Comment: " + Comment + " </p>";
                        MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
                        dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
                        string planner = dTable.Rows[0]["PlannedBy"].ToString();
                        Subject = dTable.Rows[0]["Description"].ToString();
                        NotifyPlanner(By, Subject, planner, MessageToSend);
                    }
                    output = i + " plan items have been rejected and sent to the respective planner(s)";
                    break;
                case 32:
                    // Notify Planner about rejection
                    foreach (string planCode in GetStringsFromArray(StrPlanCodes))
                    {
                        MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been rejected by Managing Director ( " + By + " ) </p> ";
                        MessageToSend += "<p>Comment: " + Comment + " </p>";
                        MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
                        dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
                        string planner = dTable.Rows[0]["PlannedBy"].ToString();
                        Subject = dTable.Rows[0]["Description"].ToString();
                        NotifyPlanner(By, Subject, planner, MessageToSend);
                    }
                    output = i + ""/* plan items have been rejected and sent to the respective planner(s)*/;
                    break;
                default:
                    // Notify Planner about deletion
                    foreach (string planCode in GetStringsFromArray(StrPlanCodes))
                    {
                        MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been removed by Cost Center Manager ( " + By + " ) </p>";
                        MessageToSend += "<p>Comment: " + Comment + " </p>";
                        dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
                        string planner = dTable.Rows[0]["PlannedBy"].ToString();
                        Subject = dTable.Rows[0]["Description"].ToString();
                        NotifyPlanner(By, Subject, planner, MessageToSend);
                    }
                    output = i +"" /*" plan items have been removed"*/;
                    break;
            }
        }
        else
        {
            output = "Please select plan item(s) to approve or reject or delete.";
        }
        return output;
    }
    
    //public string SubmitPlanItemsByManager(string StrPlanCodes, int Status, string Comment)
    //{
    //    string output = "";
    //    if (StrPlanCodes != "")
    //    {
    //        string[] arr = StrPlanCodes.Split(',');
    //        int i = 0;
    //        string PlanCode = "";
    //        for (i = 0; i < arr.Length; i++)
    //        {
    //            PlanCode = arr[i].ToString();
    //            if (PlanCode != "")
    //            {
    //                data.SubmitPlanItems(PlanCode, Status);
    //                LogPlanItemTransaction(PlanCode, Status, Comment);
    //            }
    //        }
    //        string By = HttpContext.Current.Session["FullName"].ToString();
    //        string CostCenterName = HttpContext.Current.Session["CostCenterName"].ToString();
    //        int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
    //        string MessageToSend = "";
    //        switch (Status)
    //        {
    //            case 6:
    //                MessageToSend = "<p>You have been sent " + i + " Plan Item(s) for approval from Cost Center/Department: " + CostCenterName + " </p>";
    //                MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
    //                string Subject = "Plan Item(s) For Consolidation";
    //                NotifyProcurementManager(By, Subject, CostCenterID, MessageToSend);

    //                output = i + " plan items have been approved and sent to Procurement Manager";

    //                foreach (string planCode in GetStringsFromArray(StrPlanCodes))
    //                {
    //                    MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been sent to Procurement Manager for consolidation</p>";
    //                    MessageToSend += "<p>Comment: " + Comment + " </p>";
    //                    MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
    //                    dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
    //                    string planner = dTable.Rows[0]["PlannedBy"].ToString();
    //                    Subject = dTable.Rows[0]["Description"].ToString();
    //                    NotifyPlanner(By, Subject, planner, MessageToSend);
    //                }

    //                break;
    //            case 3:
    //                // Notify Planner about rejection
    //                foreach (string planCode in GetStringsFromArray(StrPlanCodes))
    //                {
    //                    MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been rejected by Cost Center Manager ( " + By + " ) </p> ";
    //                    MessageToSend += "<p>Comment: " + Comment + " </p>";
    //                    MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
    //                    dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
    //                    string planner = dTable.Rows[0]["PlannedBy"].ToString();
    //                    Subject = dTable.Rows[0]["Description"].ToString();
    //                    NotifyPlanner(By, Subject, planner, MessageToSend);
    //                }
    //                output = i + " plan items have been rejected and sent to the respective planner(s)";
    //                break;
    //            default:
    //                // Notify Planner about deletion
    //                foreach (string planCode in GetStringsFromArray(StrPlanCodes))
    //                {
    //                    MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been removed by Cost Center Manager ( " + By + " ) </p>";
    //                    MessageToSend += "<p>Comment: " + Comment + " </p>";
    //                    dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
    //                    string planner = dTable.Rows[0]["PlannedBy"].ToString();
    //                    Subject = dTable.Rows[0]["Description"].ToString();
    //                    NotifyPlanner(By, Subject, planner, MessageToSend);
    //                }
    //                output = i + " plan items have been removed";
    //                break;
    //        }  
    //    }
    //    else
    //    {
    //        output = "Please select plan item(s) to approve or reject or delete.";
    //    }
    //    return output;

    //}
    public DataTable GetPlannerAndCCManagerByPlanCode(string PlanCode)
    {
        dTable = data.GetPlannerAndCCManagerByPlanCode(PlanCode);
        return dTable;
    }

    public string SubmitPlanItemsByProcManager(string StrPlanCodes, int Status, string Comment)
    {
        string output = "";
        if (StrPlanCodes != "")
        {
            int noOfPlans = UpdatePlanItems(StrPlanCodes, Status, Comment);
            string By = HttpContext.Current.Session["FullName"].ToString();
            string CostCenterName = HttpContext.Current.Session["CostCenterName"].ToString();
            int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
            string MessageToSend = "";
            switch (Status)
            {
                case 103:
                    foreach (string planCode in GetStringsFromArray(StrPlanCodes))
                    {
                        MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been consolidated by Budget Committee( " + By + " ) and fowarded to Managing Director for approval ";
                        MessageToSend += "<p>Comment: " + Comment + "</p>";
                        MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                        dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
                        string planner = dTable.Rows[0]["PlannedBy"].ToString();
                        int manager = Convert.ToInt32(dTable.Rows[0]["SubmittedTo"].ToString());
                        string Subject = dTable.Rows[0]["Description"].ToString();

                        NotifyPlanner(By, Subject, planner, MessageToSend);
                       NotifyManager(By, Subject, manager, MessageToSend);
                    }
                    output = noOfPlans + " Plan Item(s) have been successfully consolidated and fowarded to Managing Director for approval";
                    break;
                case 7:
                    foreach (string planCode in GetStringsFromArray(StrPlanCodes))
                    {
                        MessageToSend = "<p>Your Plan Item ( " + planCode + " ) has been rejected by Budget Committee ( " + By + " ) </p>";
                        MessageToSend += "<p> Comment: " + Comment + "</p>";
                        MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                        dTable = data.GetPlannerAndCCManagerByPlanCode(planCode);
                        string planner = dTable.Rows[0]["PlannedBy"].ToString();
                        string Subject = dTable.Rows[0]["Description"].ToString();

                       NotifyPlanner(By, Subject, planner, MessageToSend);
                    }
                    output = noOfPlans + " plan items have been rejected and sent to Planner";
                    break;
                default:

                    output = noOfPlans + " plan items have been removed";
                    break;
            }
        }
        else
        {
            output = "Please select plan item(s) to approve or reject or delete.";
        }
        return output;
    }
    private int UpdatePlanItems(string StrArry, int Status, string Comment)
    {
        string[] arr = StrArry.Split(',');
        int i = 0;
        string PlanCode = "";
        for (i = 0; i < arr.Length; i++)
        {
            PlanCode = arr[i].ToString();
            if (PlanCode != "")
            {
                data.SubmitPlanItems(PlanCode, Status);
                LogPlanItemTransaction(PlanCode, Status, Comment);
            }
        }
        return i;
    }
    
    public string ManagerApprovesItems(string StrArry, int Status)
    {
        string output = "";
        if (StrArry != "")
        {
            string[] arr = StrArry.Split(',');
            int i = 0;
            string PlanCode = "";
            for (i = 0; i < arr.Length; i++)
            {
                //Response.Write(myArr[i] + " ");
                PlanCode = arr[i].ToString();
                if (PlanCode != "")
                {
                    data.SubmitPlanItems(PlanCode, Status);
                    LogPlanItemTransaction(PlanCode, Status, "Plan item approved by Cost Center Manager");
                }
            }
            /// Notify Procurement Manager
            string CostCenterName = HttpContext.Current.Session["CostCenterName"].ToString();
            string By = HttpContext.Current.Session["FullName"].ToString();
            int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
            string MessageToSend = "<p>You have been sent " + i + " Plan Item(s) for approval from Cost Center/Department: " + CostCenterName + "</p>";
            MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";
            string Subject = "Plan Item(s) For Consolidation";
            NotifyProcurementManager(By, Subject, CostCenterID, MessageToSend);
            output = i + " plan items have been added on a list of Items to approve";
        }
        else
        {
            output = "Please select plan item(s) to approve";
        }
        return output;

    }
    public string ResubmitPlanItems(string StrArry)
    {
        string output = "";
        if (StrArry != "")
        {
            string[] arr = StrArry.Split(',');
            int i = 0;
            string PlanCode = "";
            for (i = 0; i < arr.Length; i++)
            {
                PlanCode = arr[i].ToString();
                if (PlanCode != "")
                {
                    ResubmitPlanItem(PlanCode);                    
                }

            }
            /// Notify Cost Center Manager
            output = i + " plan items have been resubmitted successfully";
        }
        else
        {
            output = "Please Select Plan Item(s) to Resubmit";
        }
        return output;

    }
    private void ResubmitPlanItem(string PlanCode)
    {
        dTable = data.GetRejectedPlanItem(PlanCode);
        string StatusCode = dTable.Rows[0]["StatusID"].ToString();
        int NewStatus = 2;
        if (StatusCode == "7")
            NewStatus = 6;
        else if (StatusCode == "32")
            NewStatus = 6;

        data.SubmitPlanItems(PlanCode, NewStatus);
        if (NewStatus == 2)
            LogPlanItemTransaction(PlanCode, NewStatus, "Re-submitted to Cost Center Manager");
        else if (NewStatus == 31)
            LogPlanItemTransaction(PlanCode, NewStatus, "Re-submitted to Area Procurement Officer");
        else
            LogPlanItemTransaction(PlanCode, NewStatus, "Re-submitted to Procurement Manager");
    }

    public void LogPlanItemTransaction(string PlanCode, int StatusID, string Remark)
    {
        int UserLoggedIn = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        data.SavePlanAction(PlanCode, StatusID, Remark, UserLoggedIn);

    }
    public string PlanItemManagerAction(string Plancode, int Status, string Remark)
    {
        string output = "";
        if (Status == 4)
        {
            output = "Plan Item(" + Plancode + ") has been added on a list of Items to approve";

        }
        else
        {
            output = "Plan Item(" + Plancode + ") has been added on a list of Items to reject";
        }
        data.SubmitPlanItems(Plancode, Status);
        LogPlanItemTransaction(Plancode, Status, Remark);
        return output;
    }
    public string PlanItemPMAction(string Plancode, int Status, string Remarks)
    {
        string output = "";
        if (Status == 8)
        {
            output = "Plan Item(" + Plancode + ") has been Consolidated";

        }
        else
        {
            output = "Plan Item(" + Plancode + ") has been added on a list of Items to reject";
        }
        data.SubmitPlanItems(Plancode, Status);
        LogPlanItemTransaction(Plancode, Status, Remarks);
        return output;
    }
    //public string ProcessPendingPlanItems(string Search, string ProcTypeID, string QuarterCode, string CostCenterCode)
    //{
    //    string output = "";
    //    int ProcTypeCode = Convert.ToInt32(ProcTypeID);
    //    int QuarterID = Convert.ToInt32(QuarterCode);
    //    int CostCenterID = Convert.ToInt32(CostCenterCode);
    //    dTable = GetManagerPlanItemPending(Search, ProcTypeID, QuarterCode, CostCenterCode);
    //    int ApprovalCount = 0;
    //    int RejectedCount = 0;
    //    int NumberOdItems = dTable.Rows.Count;
    //    foreach (DataRow dr in dTable.Rows)
    //    {
    //        int StatusFrom = Convert.ToInt32(dr["StatusID"]);
    //        string Plancode = dr["PlanCode"].ToString();
    //        if (StatusFrom == 4)
    //        {
    //            int Status = 6;
    //            data.SubmitPlanItems(Plancode, Status);
    //            LogPlanItemTransaction(Plancode, Status, "");
    //            ApprovalCount++;
    //        }
    //        else
    //        {
    //            int Status = 3;
    //            data.SubmitPlanItems(Plancode, Status);
    //            LogPlanItemTransaction(Plancode, Status, "");
    //            RejectedCount++;
    //        }
    //    }
    //    if (ApprovalCount == NumberOdItems)
    //    {
    //        output = "Plan Items(s) has been Submitted as approved Items to PM";
    //    }
    //    else if (RejectedCount == NumberOdItems)
    //    {
    //        output = "Plan Items(s) has been Submitted as rejected Items to Planner";
    //    }
    //    else
    //    {
    //        output = ApprovalCount+" Plan Items(s) has been Submitted as approved and "+RejectedCount+" as rejected";
    //    }
    //    // Call Notification for both Approved and Rejected.
    //    string By = HttpContext.Current.Session["FullName"].ToString();
    //    string CostCenterName = HttpContext.Current.Session["CostCenterName"].ToString();
    //    if (RejectedCount != 0){
    //        // Notify
    //        string MessageToSend = RejectedCount + " of your Plan Item(s) have been rejected by "+By+"."+ Environment.NewLine;
    //        //MessageToSend += "Cost Center/Department: " + CostCenterName + "." + Environment.NewLine;
    //        MessageToSend += "Please Log onto the E-Procurement System, to view them through URL: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>";
    //        NotifyPlanner(CostCenterID, MessageToSend);            
    //    }
    //    if (ApprovalCount != 0){
    //        string MessageToSend = "You have been sent " + ApprovalCount + " Plan Item(s) for approval" + Environment.NewLine;
    //        MessageToSend += "Cost Center/Department: " + CostCenterName + "." + Environment.NewLine;
    //        MessageToSend += "Please Log onto the E-Procurement System through URL: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>";
    //        NotifyProcurementManager(CostCenterID, MessageToSend);
            
    //    }
    //    return output;
    //}
    public string ProcessPendingPMPlanItems(string Search, string ProcTypeID, string CostCenterCode)
    {
        string output = "";
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        string By = HttpContext.Current.Session["FullName"].ToString();
        dTable = GetPendingPMPlanItems(Search, ProcTypeID, CostCenterCode);
        DataTable dt = data.GetPMPlanItemsByCostCenter(0);
        int RejectedCount = 0;
        int RejectedCount2 = 0;
        int NumberOdItems = dTable.Rows.Count;
        string OldState = "";
        string NewState = "";
        foreach (DataRow dr in dTable.Rows)
        {
            int Status = 7;
            string Plancode = dr["PlanCode"].ToString();
            data.SubmitPlanItems(Plancode, Status);
            RejectedCount++;
           
        }
        AlertCostCenterPlanners(dt, By);      
        output = RejectedCount + " Plan Items(s) has been Submitted as rejected Items to Planner(s)";
        return output;
    }

    private void AlertCostCenterPlanners(DataTable dtCenters, string By)
    {
        foreach (DataRow dr in dtCenters.Rows)
        {
            int Count = Convert.ToInt32(dr["Number"]);
            int CostCenterID = Convert.ToInt32(dr["CostCenterID"]);
            string MessageToSend = Count + " Plan Item(s) of your Cost Center have been rejected by " + By + "." + Environment.NewLine;
            //MessageToSend += "Cost Center/Department: " + CostCenterName + "." + Environment.NewLine;
            MessageToSend += "Please Log onto the E-Procurement System, to view them through URL: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>";
            //NotifyPlanner(CostCenterID, MessageToSend);
        }
    }
    public void RemoveDocument(string FileCode)
    {
        long FileID = Convert.ToInt64(FileCode);
        string Path = GetDocumentPath(FileCode);
        File.Delete(Path);
        data.RemoveDocument(FileID);
        
    }
    public string GetDocumentPath(string FileCode)
    {
        long FileID = Convert.ToInt64(FileCode);
        dTable = data.GetDocumentPath(FileID);
        string Path = dTable.Rows[0]["FilePath"].ToString();
        return Path;

    }
    public string SaveItemCategory(string RecordCode, string ProcType, string Name, string Rank, bool Active)
    {
        string output = "";
        if (ProcType == "0")
        {
            output = "Please Select Procurement Type";
        }
        else if (Name == "")
        {
            output = "Please Enter name of the Category";
        }
        else if (Rank == "")
        {
            output = "Please enter Rank";
        }
        else
        {
            int RecordID = Convert.ToInt32(RecordCode);
            int RankNumber = Convert.ToInt32(Rank);
            int ProcTypeID = Convert.ToInt32(ProcType);
            data.SaveItemCategory(RecordID, Name, ProcTypeID, RankNumber, Active);
            if (RecordID == 0)
            {
                output = "Item Category (" + Name + ") Captured Successfully";
            }
            else
            {
                output = "Item Category (" + Name + ") updated Successfully";
            }
            
        }
        return output;
    }
    public string GetQuarterRange(string Quarter)
    {
        int QuarteID = Convert.ToInt32(Quarter);
        string output = "";
        dTable = data.GetQuarterRange(QuarteID);
        if (dTable.Rows.Count > 0)
        {
            output = dTable.Rows[0]["Range"].ToString();
        }
        return output;
    }

    public DataTable GetPlanItemForViewing(string PlanCode)
    {
        dTable = data.GetPlanItemForViewing(PlanCode);
        return dTable;
    }

    public DataTable GetPlanItemLogs(string PlanCode)
    {
        return data.GetPlanItemLogs(PlanCode);
    }

    public string DeletePlanItem(string PlanCode, int StatusID, string Comment)
    {
        data.SubmitPlanItemForDeletion(PlanCode);
        LogPlanItemTransaction(PlanCode, StatusID, Comment);
        return "Plan item " + PlanCode + " has been deleted";
    }
    public DataTable GetExpectedExpenditure(string FinancialYearCode, string CostCenter)
    {
        int FinancialID = Convert.ToInt32(FinancialYearCode);
        int CostCenterID = Convert.ToInt32(CostCenter);
        dTable = data.GetExpectedExpenditure(FinancialID, CostCenterID);
        return dTable;
    }
    public DataTable GetPlannedCashFlow(string FinancialYearCode, string AreaCode, string CostCenter)
    {
        int FinancialID = Convert.ToInt32(FinancialYearCode);
        int AreaID = Convert.ToInt32(AreaCode);
        int CostCenterID = Convert.ToInt32(CostCenter);
        dTable = data.GetPlannedCashFlow(FinancialID, AreaID, CostCenterID);
        return dTable;
    }
    public DataTable GetPlannedCashFlowByQuarter(string FinancialYearCode, string AreaCode, string CostCenter)
    {
        int FinancialID = Convert.ToInt32(FinancialYearCode);
        int AreaID = Convert.ToInt32(AreaCode);
        int CostCenterID = Convert.ToInt32(CostCenter);
        dTable = data.GetPlannedCashFlowByQuarter(FinancialID, AreaID, CostCenterID);
        return dTable;
    }
    public DataTable GetUserDeptPlan(string FinancialYearCode, string AreaCode, string CostCenter)
    {
        int FinancialID = Convert.ToInt32(FinancialYearCode);
        int AreaID = Convert.ToInt32(AreaCode);
        int CostCenterID = Convert.ToInt32(CostCenter);
        dTable = data.GetUserDeptPlan(FinancialID, AreaID, CostCenterID);
        return dTable;
    }
    public DataTable GetPPDAProcPlan(string FinancialYearCode, string AreaCode, string CostCenter)
    {
        int FinancialID = Convert.ToInt32(FinancialYearCode);
        int AreaID = Convert.ToInt32(AreaCode);
        int CostCenterID = Convert.ToInt32(CostCenter);
        dTable = data.GetPPDAProcPlan(FinancialID, AreaID, CostCenterID);
        return dTable;
    }
}
