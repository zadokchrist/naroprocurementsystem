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

public class ProcessRequisition
{
    DataRequisition data = new DataRequisition();
    DataPlanning dataPlanning = new DataPlanning();
    DataLogin main = new DataLogin();
    BusinessRequisition bll = new BusinessRequisition();
    BusinessPlanning bllPlanning = new BusinessPlanning();
    ProcessPlanning Process = new ProcessPlanning();
    SendMail mailer = new SendMail();
    DataSet dataSet = new DataSet();
    DataTable dTable = new DataTable();

	public ProcessRequisition()
	{

	}
    private string PDCode;
    public string PDCodeReturned
    {
        get
        {
            return PDCode;
        }
        set
        {
            PDCode = value;
        }
    }

    public DataTable GetReport(string prnumber,string budgetCode, string CostCenter, string FinYearID, string level)
    {

      int  costcenterID  =  Convert.ToInt32(CostCenter);
      int  yearID        =  Convert.ToInt32(FinYearID);
      int  levelID       =  Convert.ToInt32(level);

      dTable = data.GetReport(prnumber, budgetCode,costcenterID,yearID,levelID);
        return dTable;
    }
    public DataTable GetRequisitionQuarters()
    {
        dTable = data.GetPlanningQuarters();
        return dTable;
    }
    public DataTable GetRequisitionProcurementTypes()
    {
        dTable = data.GetProcurementTypes();
        return dTable;
    }
    public DataTable GetLocations()
    {
        dTable = data.GetDelieveryLocations();
        return dTable;
    }

    public DataTable GetAllConfiguredContracts(string contractid)
    {
        dTable = main.GetAllConfiguredContracts(contractid);
        return dTable;
    }

    public DataTable GetWareHouses(string AreaCode)
    {
        dTable = data.GetWareHouses(AreaCode);
        return dTable;
    }
    public DataTable GetProcurementMethods()
    {
        dTable = dataPlanning.GetProcurementMethods();
        return dTable;
    }
    public DataTable GetStockBalances(string StockCode, string CompanyCode, string WareHouseNo)
    {
        dTable = data.GetStockBalanceByCode(StockCode, CompanyCode, WareHouseNo);
        return dTable;
    }
    public DataTable GetRequisitionerAndCCManager(string PD_Code)
    {
        dTable = data.GetRequisitionerAndCCManager(PD_Code);
        return dTable;
    }
    public DataTable GetRequisitionEmailDetailsByRecordID(string RecordCode)
    {
        dTable = data.GetRequisitionEmailDetailsByRecordID(RecordCode);
        return dTable;
    }
    public DataTable GetItemDetails(string Plancode)
    {
        dTable = data.GetPlanItemDetails(Plancode);
        return dTable;
    }
    public string GetRequisitionNumber()
    {
        dTable = data.GetRequisitionSerialNumber();
        string Number = dTable.Rows[0]["SerialNumber"].ToString();
        return Number;
    }
    public DataTable GetItemForRequisition(string PlanCode,string Desc, string ProcTypeID,string QuarterCode, string Planned, bool IsConsolidatedChecked)
    {
        int ProcTypeCode = Convert.ToInt32(ProcTypeID);
        int CostCenterID = 0;
        if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "0")
            CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
        int AreaID = Convert.ToInt32(HttpContext.Current.Session["AreaCode"]);
        int QuarterID = Convert.ToInt32(QuarterCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        bool PlannedItem = true;
        if (Planned != "1")
        {
            PlannedItem = false;
        }
        dTable = data.GetItems(PlanCode, Desc, ProcTypeCode, CostCenterID, AreaID, QuarterID, FinID, PlannedItem, IsConsolidatedChecked);
        return dTable;
    }
    public DataTable GetPD_CodeItems(string PD_Code)
    {
        dTable = data.GetPDItems(PD_Code);
        return dTable;
    }
    public DataTable GetGroupPD_CodeItems(string PD_Code)
    {
        dTable = data.GetGroupPDItems(PD_Code);
        return dTable;
    }
    public DataTable GetGroupPDItem(long RecordID)
    {
        dTable = data.GetGroupPDItem(RecordID);
        return dTable;
    }
    public DataTable GetPD_ItemByRecord(string RecordCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        dTable = data.GetItemDetailsByRecord(RecordID);
        return dTable;
    }
    public DataTable GetProcOfficers()
    {
        dTable = data.GetProcOfficers();
        return dTable;
    }

    public DataTable GetProcLPOfficers()
    {
        dTable = data.GetProcLPOfficers();
        return dTable;
    }

    public DataTable GetProcSPOfficers()
    {
        dTable = data.GetProcSPOfficers();
        return dTable;
    }
    public DataTable GetProcLPHead()
    {
        dTable = data.GetProcLPHead();
        return dTable;
    }
    public DataTable GetProcSPHead()
    {
        dTable = data.GetProcSPHead();
        return dTable;
    }

    public DataTable GetProcPMOfficers()
    {
        dTable = data.GetProcPMOfficers();
        return dTable;
    }
    public DataTable GetProcPManagers()
    {
        dTable = data.GetProcPManagers();
        return dTable;
    }

    public DataTable GetLogisticsDestinations()
    {
        dTable = data.GetLogisticsDestinations();
        return dTable;
    }

    public DataTable GetMDDestination()
    {
        dTable = data.GetMDDestinations();
        return dTable;
    }
    public DataTable GetLogs(string PD_Code)
    {
        dTable = data.GetRequisitionLogs(PD_Code);
        return dTable;
    }
    public DataTable GetReportLogs(string PD_Code)
    {
        dTable = data.GetRequisitionReportLogs(PD_Code);
        return dTable;
    }
    public DataTable GetRequisitionDetailform20(string PD_Code)
    {
        dTable = data.GetRequisitionformDetails(PD_Code);
        return dTable;
    }
    public DataTable GetRequisitionDetailsByRecordID(string RecordID)
    {
        dTable = data.GetRequisitionDetailsByRecordID(RecordID);
        return dTable;
    }
    public string GetDocPath()
    {
        string Path = "D:\\NaroContracts\\UploadedContracts\\";
        dTable = main.GetConfiguration(1);
        if (dTable.Rows.Count > 0)
        {
            Path = dTable.Rows[0]["Details"].ToString();
        }
        CheckPath(Path);
        return Path;
    }

    public DataTable GetDatesForFinancialYear(int ModuleID)
    {
        dTable = data.GetDatesForFinancialYear(ModuleID);
        return dTable;
    }
    private void CheckPath(string Path)
    {
        if (!Directory.Exists(Path))
        {
            Directory.CreateDirectory(Path);
        }
    }
    private string GetAccountingCode(string Input)
    {
        string output = Input;
        int dashPosition = Input.Trim().IndexOf("-");
        if (Input.Trim().Contains("-"))
        {
            output = Input.Substring(0, dashPosition).Trim();
        }
        return output;
    }
    public DataTable CheckIfCostCenterBudgetExists(string Code, string CostCenterCode, string FinYear)
    {
        string CompanyCode = CostCenterCode.Substring(0, 2).ToString();
        string CenterCode = "0";
        if (CostCenterCode != "0")
            CenterCode = CostCenterCode.Remove(0, 2);
        string AccountingCode = GetAccountingCode(Code).Trim();
        dTable = data.CheckIfCostCenterBudgetExists(AccountingCode, CenterCode, CompanyCode, FinYear);
        return dTable;
    }

    public DataTable GetBidRemainingTime(string pRNumber)
    {
        dTable = data.GetBidRemainingTime(pRNumber);
        return dTable;
    }

    public double GetBudgetAmount(string Code, string CostCenterCode, string CostCenterForBudget, string from, string FinYear)
    {
        string CompanyCode = CostCenterCode.Substring(0, 2).ToString();
        string CenterCode = "0";
        if (CostCenterForBudget != "0")
            CenterCode = CostCenterForBudget.Remove(0, 2);
            
        string AccountingCode = GetAccountingCode(Code).Trim();

        if (CenterCode == "0")
            dTable = data.Scala_GetAllBudget(AccountingCode, CenterCode, CompanyCode, FinYear);
        else if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "1")
            dTable = data.Scala_GetBudgetforNonConsolidated(AccountingCode, CenterCode, CompanyCode, FinYear);
        else if (from == "Consolidated")
            //dTable = data.Scala_GetAllBudget(AccountingCode, CenterCode, CompanyCode, FinYear);
            dTable = data.Scala_GetBudgetforConsolidated(AccountingCode, CenterCode, CompanyCode, FinYear);
        else if (from == "CostCenter")
            dTable = data.Scala_GetBudgetforNonConsolidated(AccountingCode, CenterCode, CompanyCode, FinYear);
        else if (from == "ALL")
            dTable = data.Scala_GetAllBudget(AccountingCode, CenterCode, CompanyCode, FinYear);

        double amount = 0;
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow dr in dTable.Rows)
            {
                string RecordType = dr["recordtype"].ToString();
                if (RecordType == "1")
                {
                    double AmountGot = Convert.ToDouble(dr["FINAL_VALUES"].ToString());
                    amount += AmountGot;
                }
            }
        }
        return amount;
    }
    public double GetExpenditureOnBudget(string Code, string CostCenterCode, string CostCenterForBudget, string from, string FinYear)
    {
        string CompanyCode = CostCenterCode.Substring(0, 2).ToString();
        string CenterCode = "0";
        if (CostCenterForBudget != "0")
            CenterCode = CostCenterForBudget.Remove(0, 2);
        string AccountingCode = GetAccountingCode(Code).Trim();

        if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "1")
            dTable = data.Scala_GetBudgetforNonConsolidated(AccountingCode, CenterCode, CompanyCode, FinYear);
        else if (from == "Consolidated")
            //dTable = data.Scala_GetAllBudget(AccountingCode, CenterCode, CompanyCode, FinYear);
            dTable = data.Scala_GetBudgetforConsolidated(AccountingCode, CenterCode, CompanyCode, FinYear);
        else if (from == "CostCenter")
            dTable = data.Scala_GetBudgetforNonConsolidated(AccountingCode, CenterCode, CompanyCode, FinYear);
        else if (from == "ALL")
            dTable = data.Scala_GetAllBudget(AccountingCode, CenterCode, CompanyCode, FinYear);

        double amount = 0;
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow dr in dTable.Rows)
            {
                string RecordType = dr["recordtype"].ToString();
                if (RecordType == "0")
                {
                    double AmountGot = Convert.ToDouble(dr["FINAL_VALUES"].ToString());
                    amount += AmountGot;
                }
            }
        }
        return amount;
    }
    public DataTable GetBudgetCodeTotalAmount(string BudgetCode, string CostCenterForBudget, string FinancialYear)
    {
        dTable = data.GetBudgetCodeTotalAmount(BudgetCode, CostCenterForBudget, FinancialYear);
        return dTable;
    }

    public DataTable GetUploadedContractsForApproval(string contracttype,string fromdate,string todate) 
    {
        dTable = data.GetUploadedContractsForApproval(contracttype, fromdate, todate);
        return dTable;
    }
    public DataTable GetUploadedContractsForApprovalById(string contractid)
    {
        dTable = data.GetUploadedContractsForApprovalById(contractid);
        return dTable;
    }
    public DataTable GetRequisitions(string RecordCode, string ProcTypeCode, string StartDate, string EndDate,string Status)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int ProcTypeID = Convert.ToInt32(ProcTypeCode);
        int CostCenterID = 0;
        int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        int AreaID = Convert.ToInt32(HttpContext.Current.Session["AreaCode"]);
        string Access = HttpContext.Current.Session["AccessLevelID"].ToString();
        if (Access == "6")//CC manager
        {
            CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
        }



        if (!String.IsNullOrEmpty(RecordCode) && RecordCode != "0")
        {
            CostCenterID = 0;
            Status = "0";
            UserID = 0; AreaID = 0;
        }
        
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        int StatusID = Convert.ToInt32(Status);
        
        dTable = data.GetRequisitionItems(RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, UserID, AreaID, StatusID,FinID);
        return dTable;
    }
    public DataTable GetRankItems(string RecordCode, string ProcTypeCode, string StartDate, string EndDate, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int ProcTypeID = Convert.ToInt32(ProcTypeCode);
        int AreaID = Convert.ToInt32(AreaCode);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        int StatusID = Convert.ToInt32(Status);
        string[] array = GetThresholds().Split(',');
        double Min = Convert.ToDouble(array[0]);
        double Max = Convert.ToDouble(array[1]);
        dTable = data.GetRequisitionsforRankApproval(RecordID, ProcTypeID, Startdate, Enddate, AreaID, CostCenterID,
            StatusID, FinID, UserID, Min, Max);
        return dTable;
    }
    public DataTable GetAreaThresholds(int AreaID)
    {
        dTable = data.GetAreaThresholds(AreaID);
        return dTable;
    }
    private string GetThresholds()
    {
        string array = "";
        int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        dTable = data.GetThreholdRankings(UserID);
        double MinAmount = Convert.ToDouble(dTable.Rows[0]["MinThreshold"].ToString());
        double MaxAmount = Convert.ToDouble(dTable.Rows[0]["MaxThreshold"].ToString());
        array = MinAmount.ToString() + "," + MaxAmount.ToString();
        return array;
    }
    public DataTable GetAllCentersRequisitionItems(string RecordCode, string ProcTypeCode, string StartDate, string EndDate, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int ProcTypeID = Convert.ToInt32(ProcTypeCode);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        int AreaID = Convert.ToInt32(AreaCode);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        int StatusID = Convert.ToInt32(Status);
        dTable = data.GetRequisitionItemsforAll(RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
        return dTable;
    }

    public DataTable GetAllCentersProjectRequisitionItems(string RecordCode, string ProcTypeCode, string StartDate, string EndDate, string Status, string AreaCode, string CostCenterCode, string PrNumber)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int ProcTypeID = Convert.ToInt32(ProcTypeCode);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        int AreaID = Convert.ToInt32(AreaCode);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        int StatusID = Convert.ToInt32(Status);
        dTable = data.GetRequisitionProjectItemsforAll(RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID,PrNumber);
        return dTable;
    }

    public DataTable GetAllCentersRequisitionItemsFramework(string RecordCode, string ProcTypeCode, string StartDate, string EndDate, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int ProcTypeID = Convert.ToInt32(ProcTypeCode);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        int AreaID = Convert.ToInt32(AreaCode);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        int StatusID = Convert.ToInt32(Status);
        dTable = data.GetRequisitionItemsforAllFramework(RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
        return dTable;
    }

    public DataTable GetOfficerItems(string RecordCode,string PrNumber, string StartDate, string EndDate, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        int AreaID = Convert.ToInt32(AreaCode);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        int StatusID = Convert.ToInt32(Status);
        dTable = data.GetRequisitionItemsforOfficer(RecordID,PrNumber, OfficerID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
        return dTable;
    }
    public DataTable GetPDUSupervisorItems(string RecordCode, string PrNumber, string StartDate, string EndDate, string PDUCategory, string ProcMethod)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        long PDUSupervisorID = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        int PDUCategoryID = Convert.ToInt32(PDUCategory);
        int ProcMethodID = Convert.ToInt32(ProcMethod);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        dTable = data.GetActivitySchedulesForPDUSupervisor(RecordID, PrNumber, PDUSupervisorID, Startdate, Enddate, PDUCategoryID, ProcMethodID);
        return dTable;
    }

    public DataTable GetPDUSupervisorItems2(string RecordCode, string PrNumber, string StartDate, string EndDate, string PDUCategory, string ProcMethod)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        long PDUSupervisorID = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        int PDUCategoryID = Convert.ToInt32(PDUCategory);
        int ProcMethodID = Convert.ToInt32(ProcMethod);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        dTable = data.GetActivitySchedulesForPDUSupervisor2(RecordID, PrNumber, PDUSupervisorID, Startdate, Enddate, PDUCategoryID, ProcMethodID);
        return dTable;
    }

    public DataTable GetProcurementsSentToSuppliers(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);

        int status = 0;
        if (Status != "")
            status = Convert.ToInt32(Status);
        dTable = data.GetProcurementsSentToSuppliers(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, status, FinID, AreaID);
        return dTable;
    }

    /// <summary>
    /// Gets approved activity schedule by the md
    /// </summary>
    /// <param name="RecordCode"></param>
    /// <param name="PrNumber"></param>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    /// <param name="PDUCategory"></param>
    /// <param name="ProcMethod"></param>
    /// <param name="statusid"></param>
    /// <returns></returns>
    public DataTable GetGetActivityPlansApprovedByMd(string RecordCode, string PrNumber, string StartDate, string EndDate, string PDUCategory, string ProcMethod,int statusid)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        long PDUSupervisorID = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        int PDUCategoryID = Convert.ToInt32(PDUCategory);
        int ProcMethodID = Convert.ToInt32(ProcMethod);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        dTable = data.GetActivitySchedulesApprovedByMD(RecordID, PrNumber, PDUSupervisorID, Startdate, Enddate, PDUCategoryID, ProcMethodID, statusid);
        return dTable;
    }

    public void UpdateRecordAssignment(string assignee, string assignedto, string refNo)
    {
        data.UpdateRecordAssignment(assignee, assignedto, refNo);
    }

    public DataTable GetRequisitionAssignmentRecord(string refNo)
    {
        DataTable dataTable = data.GetRequisitionAssignmentRecord(refNo);
        return dataTable;
    }

    public DataTable GetPDUSupervisorItems3(string RecordCode, string PrNumber, string StartDate, string EndDate, string PDUCategory, string ProcMethod)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        long PDUSupervisorID = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        int PDUCategoryID = Convert.ToInt32(PDUCategory);
        int ProcMethodID = Convert.ToInt32(ProcMethod);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        dTable = data.GetActivitySchedulesForPDUSupervisor3(RecordID, PrNumber, PDUSupervisorID, Startdate, Enddate, PDUCategoryID, ProcMethodID);
        return dTable;
    }
    public DataTable GetRankApproversList()
    {

        dTable = data.GetRankApproversList();
        return dTable;
    }
    
    public string SaveRequisition(string RecordCode, string EntityCode, string Subject, string LocationCode, string WareHouseCode, string TypeCode, string DateRequired, string ProcType, int ManagerCode,string MarketPrice,bool IsFrameWork,bool IsProject)
    {
        int LocationID = Convert.ToInt32(LocationCode);
        int WareHouseID = Convert.ToInt32(WareHouseCode);
        int TypeID = Convert.ToInt32(TypeCode);
        int ProcTypeID = Convert.ToInt32(ProcType);
        int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
        DateTime Date = Convert.ToDateTime(DateRequired);
        int CreatedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        int YearID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        string CostCenterCode = HttpContext.Current.Session["CostCenterCode"].ToString();
        string UserCode = HttpContext.Current.Session["UserCode"].ToString();
        long RecordID = Convert.ToInt64(RecordCode);
        //string Marketpricex = HttpContext.Current.Session["MarketPrice"].ToString();
        string PDCodeSaved = data.SaveRequisition(RecordID, EntityCode, Subject, LocationID, WareHouseID, CostCenterCode, CostCenterID, ProcTypeID, YearID, Date, TypeID, ManagerCode, false, UserCode, CreatedBy,MarketPrice,IsFrameWork,IsProject);
        return PDCodeSaved;
    }

    
    
    /* public string  SaveRequisition(string RecordCode,string PD_Code,string RequisitionCode,string Plancode,string EntityCode, string Subject, string LocationCode, string WareHouseCode, string TypeCode,
        string DateRequired,string ItemDescription, string Qty, string TotalCost, double BalAmount, int BalQuantity, string ProcType, int ManagerCode, int UnitCode,string MarketPrice)
    {
        string output = "";
        
        int LocationID = Convert.ToInt32(LocationCode);
        int WareHouseID = Convert.ToInt32(WareHouseCode);
        int TypeID = Convert.ToInt32(TypeCode);
        int ProcTypeID = Convert.ToInt32(ProcType);
        int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
        DateTime Date = Convert.ToDateTime(DateRequired);
        int CreatedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        int YearID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        string CostCenterCode = HttpContext.Current.Session["CostCenterCode"].ToString();
        string UserCode = HttpContext.Current.Session["UserCode"].ToString();
        //string Marketpricex = HttpContext.Current.Session["MarketPrice"].ToString();

        string ItemPD_Code = "";
        string PDCodeSaved = "0";
        double Cost = Convert.ToDouble(TotalCost.Replace(",", ""));
        int Quantity = Convert.ToInt32(Qty);
        long RecordID = Convert.ToInt64(RecordCode);
        if (PD_Code == "0")
        {
            PDCodeSaved = data.SaveRequisition(RecordID,EntityCode, Subject, LocationID, WareHouseID, CostCenterCode, CostCenterID, ProcTypeID, YearID, Date, TypeID, ManagerCode, false, UserCode, CreatedBy,MarketPrice);
            //PDCode = PDCodeSaved;
            PDCodeReturned = PDCodeSaved;
        }
        else
        {
            PDCodeSaved = PD_Code;
        }
        
        DataTable dtPlan = dataPlanning.GetPlanItem(PDCodeSaved);
        string StockCode = ""; string StockName = ""; int StockBalance = 0; bool IsStock = false;
        if (dtPlan.Rows.Count > 0)
        {
            IsStock = Convert.ToBoolean(dtPlan.Rows[0]["IsStockItem"].ToString()); 
            StockCode = dtPlan.Rows[0]["StockCode"].ToString(); 
            StockName = dtPlan.Rows[0]["StockName"].ToString();
            StockBalance = Convert.ToInt32(dtPlan.Rows[0]["StockBalance"].ToString());
        }
        SaveRequisitionItems(RequisitionCode,PDCodeSaved,Plancode, ItemDescription,Quantity,Cost, false, BalAmount, BalQuantity, IsStock, StockCode, StockName, StockBalance, UnitCode,MarketPrice);
        return PDCodeSaved;     
    }*/


    public void UpdateGroupRequisition(string RecordCode, string PD_Code, string RequisitionCode, string EntityCode, string Subject, string LocationCode, string TypeCode,
        string DateRequired, string ProcType, string WareHouse,bool IsFrameWork,bool IsProject)
    {
        int LocationID = Convert.ToInt32(LocationCode);
        int TypeID = Convert.ToInt32(TypeCode);
        int ProcTypeID = Convert.ToInt32(ProcType);
        DateTime Date = Convert.ToDateTime(DateRequired);
        int WareHouseID = Convert.ToInt32(WareHouse);
        data.UpdateMainRequisitionDetails(PD_Code, Subject, LocationID, Date, TypeID, WareHouseID, IsFrameWork,IsProject);
    }
    public void UpdateGroupRequisitionItems(string PD_Code, string PlanCode, string PlanAmount, DataTable dtItems)
    {
        double BalAmount = Convert.ToDouble(PlanAmount);
        foreach (DataRow dr in dtItems.Rows)
        {
            string RecordID = dr["RecordID"].ToString(); double Cost = Convert.ToDouble(dr["TotalCost"].ToString().Replace(",", ""));
            int Quantity = Convert.ToInt32(dr["Quantity"].ToString().Replace(",", "")); double UnitCost = Convert.ToDouble(dr["UnitCost"].ToString().Replace(",", ""));
            string ItemDesc = dr["ItemDesc"].ToString(); bool IsStockItem = Convert.ToBoolean(dr["IsStockItem"].ToString());
            string StockCode = dr["StockCode"].ToString(); string StockName = dr["StockName"].ToString(); int StockBalance = 0;
            //double MarketPrice = Convert.ToDouble(dr["MarketPrice"].ToString().Replace(",", ""));
            string MarketPrice = dr["MarketPrice"].ToString().Replace(",", "");
            if (dr["StockBalance"].ToString() != "")
                StockBalance = Convert.ToInt32(dr["StockBalance"].ToString());
            int UnitCode = Convert.ToInt32(dr["UnitCode"].ToString());

            SaveRequisitionItems(RecordID, PD_Code, PlanCode, ItemDesc, Quantity, Cost, true, BalAmount, 1, IsStockItem, StockCode, StockName, StockBalance, UnitCode,MarketPrice);
            BalAmount = BalAmount - Cost;
        }
    }
    public string SaveRequisition(string RecordCode, string PD_Code, string RequisitionCode, string Plancode, string EntityCode, string Subject, string LocationCode, string WareHouseCode, string TypeCode,
        string DateRequired, string PlanAmount, string ProcType, int ManagerCode, DataTable dtPlanItems, string MarketPrice, bool IsFrameWork, bool IsProject)
    {
        string output = "";

        int LocationID = Convert.ToInt32(LocationCode); int WareHouseID = Convert.ToInt32(WareHouseCode);
        int TypeID = Convert.ToInt32(TypeCode);
        int ProcTypeID = Convert.ToInt32(ProcType);
        int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
        DateTime Date = Convert.ToDateTime(DateRequired);
        int CreatedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        int YearID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        string CostCenterCode = HttpContext.Current.Session["CostCenterCode"].ToString();
        string UserCode = HttpContext.Current.Session["UserCode"].ToString();
        //string Marketpricex = HttpContext.Current.Session["MarketPrice"].ToString();

        string ItemPD_Code = "";
        string PDCodeSaved = "0";
        //bool IsProject = false;
        long RecordID = Convert.ToInt64(RecordCode);
        if (PD_Code == "0")
        {
            PDCodeSaved = data.SaveRequisition(RecordID, EntityCode, Subject, LocationID, WareHouseID, CostCenterCode, CostCenterID, ProcTypeID, YearID, Date, TypeID, ManagerCode, true, UserCode, CreatedBy, MarketPrice, IsFrameWork, IsProject);
            PDCodeReturned = PDCodeSaved;
        }
        else
        {
            PDCodeSaved = PD_Code;
        }

        double BalAmount = Convert.ToDouble(PlanAmount);
        foreach (DataRow dr in dtPlanItems.Rows)
        {
            double Cost = Convert.ToDouble(dr["TotalCost"].ToString().Replace(",", ""));
            int Quantity = Convert.ToInt32(dr["Quantity"].ToString().Replace(",", ""));
            double UnitCost = Convert.ToDouble(dr["UnitCost"].ToString().Replace(",", ""));
            //double MarketPrice = Convert.ToDouble(dr["MarketPrice"].ToString().Replace(",", ""));
            string Marketprice = dr["MarketPrice"].ToString().Replace(",", "");
            int UnitCode = Convert.ToInt32(dr["UnitCode"].ToString());
            string ItemDesc = dr["ItemDesc"].ToString();
            string StockCode = dr["StockCode"].ToString();
            string StockName = dr["StockName"].ToString();
            int StockBalance = Convert.ToInt32(dr["StockBalance"].ToString());
            bool IsStock = false;
            if (!String.IsNullOrEmpty(StockName))
                IsStock = true;
            //{
            //    IsStock = true;
            //    string CompanyCode = HttpContext.Current.Session["ScalaCode"].ToString();
            //    dTable = Process.GetStockCodeByName(StockName, CompanyCode);
            //    if (dTable.Rows.Count == 0)
            //        throw new Exception("Please enter stock name or select from drop down returned after typing more than two letters");
            //    else
            //        StockCode = dTable.Rows[0]["StockCode"].ToString(); 
            //}
            
            SaveRequisitionItems(RequisitionCode, PDCodeSaved, Plancode, ItemDesc, Quantity, Cost, true, BalAmount,1,IsStock,StockCode,StockName,StockBalance,UnitCode,Marketprice);
            BalAmount = BalAmount - Cost;
        }
        return PDCodeSaved;
    }
    public void EditRequisition(string ReqCode, string PD_Code, string Plancode, string Description, int Quantity, double Cost, bool IsGroup, double BalanceAmount, int RemQuantity, bool IsStockItem, string StockCode, string StockName, int StockBalance, int UnitCode, string MarketPrice)
    {
        long RecordID = Convert.ToInt64(ReqCode);

        double RemainingAmount;
        int RemainingQty;
        if (IsGroup)
        {
            RemainingAmount = Convert.ToDouble(BalanceAmount);
            RemainingQty = 1;
        }
        else
        {
            RemainingAmount = Convert.ToDouble(BalanceAmount);
            RemainingQty = RemQuantity;
        }
        int BalQty = 0;
        double BalAmount = RemainingAmount - Cost;
        if (RemainingAmount == Cost)
        {
            // Now Flag Plan 
           
            BalQty = 0;
            data.FlagItemAsRequisitioned(Plancode, true);
        }
        else
        {
            if (bll.IsGroupItem(Plancode))
            {
                BalQty = 1;
            }
            else
            {
                BalQty = RemainingQty - Quantity;
            }
        }
        data.SaveRequisitionItem(RecordID, Plancode, PD_Code, Description, RemainingQty, Quantity, BalQty, RemainingAmount
        , Cost, BalAmount, IsStockItem, StockCode, StockName, StockBalance, UnitCode,MarketPrice);
    }
    
    public void SaveRequisitionItems(string ReqCode, string PD_Code, string Plancode, string Description, int Quantity, double Cost, bool IsGroup, double RemainingAmount, int RemQuantity, bool IsStockItem, string StockCode, string StockName, int StockBalance, int UnitCode,string MarketPrice)
    {
        long RecordID = Convert.ToInt64(ReqCode);
        int PrevQty;
        if (IsGroup)
           PrevQty = 1;
        else
            PrevQty = RemQuantity + Quantity;

        int BalQty = 0;
        double BalAmount = RemainingAmount - Cost;
        if (RemainingAmount == Cost){
            // Now Flag Plan Item as Requisitioned
            BalQty = 0;
            data.FlagItemAsRequisitioned(Plancode, true);
        }else{
            if (bll.IsGroupItem(Plancode)){
                BalQty = 1;
            }else{
                BalQty = RemQuantity;
            }
        }
        data.SaveRequisitionItem(RecordID, Plancode, PD_Code, Description, PrevQty, Quantity, BalQty, RemainingAmount
        , Cost, BalAmount,IsStockItem,StockCode, StockName, StockBalance, UnitCode,MarketPrice);
    }
    public string ForwardRequisition(string PD_Code, int StatusID, string Remark, int ManagerID, string Manager)
    {
        string output = "";
        data.ForwardRequisition(PD_Code, ManagerID);
        output = "Requisition ( " + PD_Code + " ) has been successfully forwarded to Cost Center Manager ( " + Manager + " )";
        LogandCommitRequisition(PD_Code, StatusID, Remark);
        
        return output;
    }
    public string DeleteRequisition(string PD_Code,string planCode, int StatusID, string Remark)
    {
        string output = "";
        data.SubmitRequisitionForDeletion(PD_Code, planCode);
        output = "Requisition ( " + PD_Code + " ) Has Been Successfully Removed ...";
        LogandCommitRequisition(PD_Code, StatusID, Remark);

        return output;
    }
    public void UpdateRequisitionItem(long RecordId, string PlanCode, int PrevQty, double PreviousAmount, int RequiredQty, double RequisitionedAmount, int BalQty, double RemainingAmount)
    {
        if (BalQty == 0)
            data.FlagItemAsRequisitioned(PlanCode, true);
        else
            data.FlagItemAsRequisitioned(PlanCode, false);
        data.UpdatePlanAmounts(PlanCode, RequiredQty, BalQty);
        data.UpdateRequisitionItemQtyAndAmounts(RecordId, PrevQty, RequiredQty, BalQty, PreviousAmount, RequisitionedAmount, RemainingAmount);
    }
    public void UpdateRequisitionItem(long RecordId, string PlanCode, int PrevQty, double PreviousAmount, int RequiredQty, double RequisitionedAmount, int BalQty, double RemainingAmount, bool IsStock, string StockCode, string StockName)
    {
        if (BalQty == 0)
            data.FlagItemAsRequisitioned(PlanCode, true);
        else
            data.FlagItemAsRequisitioned(PlanCode, false);
        data.UpdatePlanAmounts(PlanCode, RequiredQty, BalQty);
        data.UpdateRequisitionItem(RecordId, PrevQty, RequiredQty, BalQty, PreviousAmount, RequisitionedAmount, RemainingAmount, IsStock, StockCode, StockName);
    }
    public void RemoveRequisitionItem(long RecordId, string PlanCode, int RequiredQty, int BalQty, bool IsRemove)
    {
        if (BalQty == 0)
            data.FlagItemAsRequisitioned(PlanCode, true);
        else
            data.FlagItemAsRequisitioned(PlanCode, false);
        data.UpdatePlanAmounts(PlanCode, RequiredQty, BalQty);
        data.FlagRequisitionItem(RecordId, true);
    }

    // For Group Requisition Items
    public void RemoveRequisitionItem(long RecordId, bool IsRemove)
    {
        data.FlagRequisitionItem(RecordId, true);
    }
    public string EditRequisition(string PD_Code, string Subject, string LocationCode, string Date, string Type, string WareHouse, bool IsFrameWork)
    {
        string output = "";
        if (Subject == "")
        {
            output = "Please Enter Subject of Procurement";
        }
        else if (LocationCode == "0")
        {
            output = "Please Select Location of Delivery";
        }
        else if (Date == "")
        {
            output = "Invalid Date Required";
        }
        else if (Type == "0")
        {
            output = "Please Select Requisition Type(Normal or Emergency)";

        }
        else
        {
            int LocationID = Convert.ToInt32(LocationCode);
            int TypeID = Convert.ToInt32(Type);
            DateTime DateRequired = bll.ReturnDate(Date, 1);
            int WareHouseID = Convert.ToInt32(WareHouse);
            data.UpdateMainRequisitionDetails(PD_Code, Subject, LocationID, DateRequired, TypeID, WareHouseID, IsFrameWork,false);
            output = "Requisition has been updated successfully";
        }
        return output;

    }
    public string NotifyFinance(string SenderName, string Subject, string PD_Code, double RequisitionAmount, string Message, string AreaCode)
    {
        string Name = "";
        string Email = "";
        int AreaID = 0;
        if (AreaCode == "0")
            AreaID = Convert.ToInt32(HttpContext.Current.Session["AreaCode"].ToString());
        else
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetFinanceManager(RequisitionAmount, AreaID);
        if (dTable.Rows.Count > 0)
        {
            int FinanceAreaID = Convert.ToInt32(dTable.Rows[0]["AreaID"].ToString());
            data.UpdateRequisitionWithFinanceAreaID(PD_Code, FinanceAreaID);
            foreach (DataRow dr in dTable.Rows)
            {
                if (String.IsNullOrEmpty(dr["UserID"].ToString()))
                    continue;
                int NotifyeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
                if (bllPlanning.IsDelegated(NotifyeeID))
                {
                    dTable = dataPlanning.GetActing(NotifyeeID);
                    Name = dTable.Rows[0]["FullName"].ToString();
                    Email = dTable.Rows[0]["Email"].ToString();
                }
                else
                {
                    Name = dr["FullName"].ToString();
                    Email = dr["Email"].ToString();
                }
                string Msg = "<p>Hello " + Name.ToUpper() + " , </p>" + Message;
                mailer.SendEmail(SenderName, Email, Subject, Msg);
            }
        }        
        return Name;
    }
    private string NotifyRankApproval(string SenderName, string Subject, string Message, string PD_Code)
    {
        string PriorityApprovers = "";
        string Name = "";
        string Email = "";
        int AreaCode = Convert.ToInt32(HttpContext.Current.Session["AreaCode"].ToString());

        dTable = data.GetRankApprovers(PD_Code, AreaCode);
        if (dTable.Rows.Count > 0)
        {
            int RankCategoryID = Convert.ToInt32(dTable.Rows[0]["AreaID"].ToString());
            data.UpdateRequisitionWithRankCategory(PD_Code, RankCategoryID);

            foreach (DataRow dr in dTable.Rows)
            {
                int NotifyeeID = Convert.ToInt32(dr["UserID"].ToString());
                if (bllPlanning.IsDelegated(NotifyeeID))
                {
                    dTable = dataPlanning.GetActing(NotifyeeID);
                    Name = dTable.Rows[0]["FullName"].ToString();
                    Email = dTable.Rows[0]["Email"].ToString();
                }
                else
                {
                    Name = dr["FullName"].ToString();
                    Email = dr["Email"].ToString();
                }
                PriorityApprovers += Name + ", ";
                string Msg = "<p>Hello " + Name.ToUpper() + " , </p>" + Message;
                mailer.SendEmail(SenderName, Email, Subject, Msg);
            }
        }
        return PriorityApprovers.Trim().TrimEnd(new char[] { ',' });
    }
    public string NotifyLogistics(string SenderName, string Subject, string Message, string AreaID)
    {
        string Name = "";
        string Email = "";
        int AreaCode = Convert.ToInt32(AreaID);
        dTable = data.GetLogisticManager(AreaCode);
        if (dTable.Rows.Count > 0)
        {
            int NotifyeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
            if (bllPlanning.IsDelegated(NotifyeeID))
            {
                dTable = dataPlanning.GetActing(NotifyeeID);
                Name = dTable.Rows[0]["FullName"].ToString();
                Email = dTable.Rows[0]["Email"].ToString();
            }
            else
            {
                Name = dTable.Rows[0]["FullName"].ToString();
                Email = dTable.Rows[0]["Email"].ToString();
            }
            string Msg = "<p>Hello " + Name.ToUpper() + " , </p> " + Message;
            mailer.SendEmail(SenderName, Email, Subject, Msg);
        }
        return Name;

    }
    public string NotifyInventory(string SenderName, string Subject, string Message, string AreaID)
    {
        string Name = "";
        string Email = "";
        int AreaCode = Convert.ToInt32(AreaID);
        dTable = data.GetInventoryManager(AreaCode);
        if (dTable.Rows.Count > 0)
        {
            int NotifyeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
            if (bllPlanning.IsDelegated(NotifyeeID))
            {
                dTable = dataPlanning.GetActing(NotifyeeID);
                Name = dTable.Rows[0]["FullName"].ToString();
                Email = dTable.Rows[0]["Email"].ToString();
            }
            else
            {
                Name = dTable.Rows[0]["FullName"].ToString();
                Email = dTable.Rows[0]["Email"].ToString();
            }
            string Msg = "<p>Hello " + Name.ToUpper() + " , </p>" + Message;
            mailer.SendEmail(SenderName, Subject, Email, Msg);
        }
        return Name;
    }
    public string NotifyProcurement(string SenderName, string Subject, string Message, string AreaID)
    {
        string Name = "";
        string Email = "";
        int AreaCode = Convert.ToInt32(AreaID);
        dTable = data.GetProcurementManager(AreaCode);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow dr in dTable.Rows)
            {
                int NotifyeeID = Convert.ToInt32(dr["UserID"].ToString());
                if (bllPlanning.IsDelegated(NotifyeeID))
                {
                    dTable = dataPlanning.GetActing(NotifyeeID);
                    Name = dTable.Rows[0]["FullName"].ToString();
                    Email = dTable.Rows[0]["Email"].ToString();
                }
                else
                {
                    Name = dr["FullName"].ToString();
                    Email = dr["Email"].ToString();
                }
                string Msg = "<p>Hello " + Name.ToUpper() + " , </p> " + Message;
                mailer.SendEmail(SenderName, Email, Subject, Msg);
            }
        }
        return Name;
    }
    public string ManagerAction(string PD_Code, string Status, string remark, string SendTo, string CostCenterID, string CostCenterName, string AreaCode, string WareHouse, string ApprovedAmount, 
        string Expense, string RequisitionToDate, string balance, string BudgetCode, string CostCenterForBudget, string Subject, string DateRequired, string Location, string CostCenterCode, string PrNumber, string EmmergencyMemo)
    {
        string output = "";
        string Access = HttpContext.Current.Session["AccessLevelID"].ToString();
        if (ApprovedAmount == "")
        {
            ApprovedAmount = "0";
        }
        double Amount = Convert.ToDouble(ApprovedAmount);
        
        //double Marketprice = Convert.ToDouble(MarketPrice);
        if (Access == "6")// CC Manager
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
            output += " to the Managing Director";
        }
        else if (Access == "17")//MD
        {
            // Call for Budget Committee
            output = CostCenterManagerAction2(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "7") //Finance
        {
            // Call for Finance
            output = FinanceManagerAction(PD_Code, Status, remark, CostCenterID, CostCenterName, CostCenterForBudget, AreaCode, ApprovedAmount, Expense, RequisitionToDate, balance, BudgetCode);
           
        }
        else if (Access == "8") //Inventory
        {
            // Call for Inventory
            output = InventoryManagerAction(PD_Code, Status, Amount, remark, CostCenterName, AreaCode, EmmergencyMemo);
        }
        else if (Access == "9") //Logistics
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "24")//RPM
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "25")//RDM
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "26")//RCM
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "19")//HOD Prod
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "20")//HOD Dist
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "1024")//HOD Comm
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "21")// ED Prod
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "22")//ED Dist
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else if (Access == "23")//COO
        {
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        }
        else
        {
            // Call for Proc
            output = ProcurementManagerAction(PD_Code, Status, remark, SendTo, PrNumber, CostCenterCode, Location, ApprovedAmount, WareHouse, DateRequired, CostCenterForBudget);
        }
        return output;
    }
    private string InventoryManagerAction(string PD_Code, string Status, double Amount, string remark, string CostCenterName, string AreaCode, string EmmergencyMemo)
    {
        string output = "";
        string Message = "";
        int StatusID = 0;
        
        DataTable dtAlert = GetRequisitionerAndCCManager(PD_Code);
        string By = HttpContext.Current.Session["FullName"].ToString();
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        string Subject = dtAlert.Rows[0]["Subject"].ToString();
        string RequisitionType = dtAlert.Rows[0]["RequisitionType"].ToString();
        int PrevStatusID = Convert.ToInt32(dtAlert.Rows[0]["StatusID"].ToString());

        if (PrevStatusID < 14)
            output = CostCenterManagerAction(PD_Code, Status, Amount, remark, EmmergencyMemo);
        else
        {
            if (Status == "1")
            {
                StatusID = 16;
                if (RequisitionType.Contains("EMERGENCY"))
                {
                    Message = "<p><strong>EMERGENCY REQUISITION</strong></p>";
                    Message += "<p>You have been sent an emergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in " + CostCenterName + " for approval from Inventory ( "
                            + By + " ) </p>";
                }
                else
                {
                    Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in " + CostCenterName + " for approval from Inventory ( "
                            + By + " ) </p>";
                }

                Message += "<p>Comment: " + remark + "</p>";
                Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

                //NotifyLogistics(By, Subject, Message, AreaCode);

                // Notify Requisitioner
                Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Inventory ( " + By + " ) ";
                Message += " and Sent To Managing Director With Comment: " + remark + "</p>";
                Message += "<p>For more details, please access the link: <a href='<a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>'><a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a></a> to login.</p>";

                Process.NotifyPlanner(By, Subject, Requisitioner, Message);

                output = "Requisition(" + Subject + ") has been successfully submitted to Managing Director";
            }
            else
            {
                StatusID = 19;
                string ManagerName = HttpContext.Current.Session["FullName"].ToString();

                Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been rejected by Inventory ( " + ManagerName + " ) ";
                Message += "<p>Comment: " + remark + "</p>";
                Message += "<p>For more details, please access the link: <a href='<a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>'><a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a></a> to login.</p>";

               Process.NotifyPlanner(ManagerName, Subject, Requisitioner, Message);

                output = "Requisition(" + Subject + ") has been rejected and sent back to requisitioner(s)";
            }

            LogandCommitRequisition(PD_Code, StatusID, remark);
        }
        return output;
    }
    public string RankApproving(string PD_Code, double Amount, string Status, string remark, string CenterID, string CostCenterName, string AreaCode)
    {
        string output = "";
        string Message = "";
        int StatusID = 0;
        string By = HttpContext.Current.Session["FullName"].ToString();
        DataTable dtAlert = GetRequisitionerAndCCManager(PD_Code);
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        string Subject = dtAlert.Rows[0]["Subject"].ToString();
        string RequisitionType = dtAlert.Rows[0]["RequisitionType"].ToString();

        if (Status == "1")
        {
            StatusID = 14;
            string ManagerName = HttpContext.Current.Session["FullName"].ToString();

            if (RequisitionType.Contains("EMERGENCY"))
            {
                Message = "<p><strong>EMERGENCY REQUISITION</strong></p>";
                Message += "<p>You have been sent an emergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in " + CostCenterName + " for Fund Approval from Rank Approver ( "
                    + ManagerName + " ) </p>";
            }
            else
            {
                Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in " + CostCenterName + " for Fund Approval from Rank Approver ( "
                    + ManagerName + " ) </p>";
            }

            Message += "<p>Comment: " + remark + "</p>";
            Message += "<p>Please access the link: <a href='<a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

            string FA = NotifyFinance(By, Subject, PD_Code, Amount, Message, AreaCode);

            // Notify Requisitioner
            Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Rank Approver ( " + By + " ) ";
            Message += " and Sent To Finance For Fund Approval ( " + FA + " ) With Comment: " + remark + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

            Process.NotifyPlanner(By, Subject, Requisitioner, Message);

            output = "Requisition(" + Subject + ") Has Been Successfully Submitted";
        }
        else
        {
            StatusID = 25;
            string ManagerName = HttpContext.Current.Session["FullName"].ToString();

            Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been rejected by Rank Approver ( " + ManagerName + " ) </p>";
            Message += "<p>Comment: " + remark + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

            Process.NotifyPlanner(ManagerName, Subject, Requisitioner, Message);

            output = "Requisition ( " + Subject + " ) has been rejected and sent back to requisitioner(s)";
        }
        int ManagerID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        data.RankApproving(PD_Code, ManagerID);
        LogandCommitRequisition(PD_Code, StatusID, remark);
        return output;
    }
    private string FinanceManagerAction(string PD_Code, string Status, string remark, string CenterID, string CostCenterName, string CostCenterForBudget, string AreaCode, string amount, string Expenses, string RequisitionToDate, string Balance, string BudgetCode)
    {
        string output = "";
        string Message = "";
        int StatusID = 15;
        string By = HttpContext.Current.Session["FullName"].ToString();
        DataTable dtAlert = GetRequisitionerAndCCManager(PD_Code);
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        string Subject = dtAlert.Rows[0]["Subject"].ToString();
        string RequisitionType = dtAlert.Rows[0]["RequisitionType"].ToString();

        if (Status == "1")
        {
            ProcessRequisition p = new ProcessRequisition();
            DataTable t = dTable = data.GetAccountingString(PD_Code);
            string AccString = "";
            string ProcType = "";
            if (dTable.Rows.Count > 0)
            {
                AccString = dTable.Rows[0]["String"].ToString();
                ProcType = dTable.Rows[0]["ProcurementType"].ToString();
            }
            string destination = "Managing Director";
            if (ProcType == "4")
            {
                destination = "Inventory";
                StatusID = 18;
            }
            else
            {
                StatusID = 16;
            }
            double amountApproved = Convert.ToDouble(amount);
            double requisitionedAmount = Convert.ToDouble(RequisitionToDate);
            double expenditure = Convert.ToDouble(Expenses);
            double balance = Convert.ToDouble(Balance);
            if (balance < 0)
            {
                output = "Funds Approval Failed Because Of Insufficient Funds on Budget Code ( " + BudgetCode + " ) ";
                return output;
            }
            else
            {
                int ManagerID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);

                if (RequisitionType.Contains("EMERGENCY"))
                {
                    Message = "<p><strong>EMERGENCY REQUISITION</strong></p>";
                    Message += "<p>You have been sent an emergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in " + CostCenterName + " for Approval from Finance ( "
                        + By + " ) </p>";
                }
                else
                {
                    Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in " + CostCenterName + " for Approval from Finance ( "
                        + By + " ) </p>";
                }

                Message += "<p>Comment: " + remark + "</p>";
                Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

                data.FinanceApproving(PD_Code, ManagerID, amountApproved, expenditure, requisitionedAmount, balance, BudgetCode, CostCenterForBudget);


                if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "0")
                {
                   // NotifyLogistics(By, Subject, Message, AreaCode);

                    // Notify Requisitioner
                    Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Finance ( " + By + " ) ";
                    Message += " and Sent To Inventory Manager For Approval With Comment: " + remark + "</p>";
                    Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                    output = "Requisition(" + Subject + ") has been successfully submitted to "+destination;
                }
                else
                {
                    int AreaID = Convert.ToInt32(AreaCode);
                  //  Process.NotifyAreaPDUOfficer(By, Subject, AreaID, Message);

                    // Notify Requisitioner
                    Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Finance ( " + By + " ) ";
                    Message += " and Sent To Area PDU Officer For Approval With Comment: " + remark + "</p>";
                    Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                    output = "Requisition(" + Subject + ") has been successfully submitted to "+destination;
                }

                Process.NotifyPlanner(By, Subject, Requisitioner, Message);
            }
        }
        else
        {
            string ManagerName = HttpContext.Current.Session["FullName"].ToString();
            Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been rejected by Finance ( " + ManagerName + " ) ";
            Message += "<p>Comment: " + remark + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

            Process.NotifyPlanner(ManagerName, Subject, Requisitioner, Message);

            output = "Requisition(" + Subject + ") has been rejected and sent back to requisitioner(s)";
        }
        if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "0")
            LogandCommitRequisition(PD_Code, StatusID, remark);
        else
        {
            // Assign to StatusID 33 for Area PDU Officer
            LogandCommitRequisition(PD_Code, StatusID, remark);
        }
        return output;
    }
    private string CostCenterManagerAction(string PD_Code, string Status, double Amount, string remark, string EmmergencyMemo)
    {
        string output = "";
        string Message = "";

        DataTable dtAlert = GetRequisitionerAndCCManager(PD_Code);
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        string Subject = dtAlert.Rows[0]["Subject"].ToString();
        string RequisitionType = dtAlert.Rows[0]["RequisitionType"].ToString();
        string Access = HttpContext.Current.Session["AccessLevelID"].ToString();
        string costcenterID = HttpContext.Current.Session["CostCenterID"].ToString();
        int StatusID = 0;
        if (Status == "1")
        {
            int ManagerID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
            string By = HttpContext.Current.Session["FullName"].ToString();
            data.ManagerApproving(PD_Code, ManagerID, EmmergencyMemo);

            if (bll.SentToRankApproval(PD_Code))
            {
                //Check for cost center to find appropriate next approval

                if (Access == "6") // CC Manager
                {

                    //Check if Area process and contains 'ww'
                    // Or if is major water work
                    if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "1")
                    {
                        if (HttpContext.Current.Session["CostCenterName"].ToString().ToLower().Contains("ww")) //Mini water works manager
                        {
                            StatusID = 107;

                        }
                        else  // Area manager
                        {
                            StatusID = 11;

                        }
                    }
                    else if (int.Parse(HttpContext.Current.Session["AreaCode"].ToString()) > 1000) // Major Water works managers
                    {
                        StatusID = 109;

                    }
                    else // HQ manager
                    {

                        StatusID = 105;
                    }
                }
                else if (Access == "17") // MD
                {
                    StatusID = 14;
                }
                else if (Access == "3") // Proc Manager
                {
                    StatusID = 20;
                }
                else if (Access == "5" || Access == "1") // Requisitioner/admin
                {
                    StatusID = 0;
                }
                else if (Access == "24") // RPM
                {
                    StatusID = 109;
                }
                else if (Access == "25") // RDM
                {
                    StatusID = 119;
                }
                else if (Access == "26") //RCM
                {
                    StatusID = 121;
                }
                else if (Access == "19") // HOD Prod
                {
                    StatusID = 111;
                }
                else if (Access == "20") // HOD Dist
                {
                    StatusID = 123;
                }
                else if (Access == "1024") // HOD Comm
                {
                    StatusID = 113;
                }
                else if (Access == "21") // ED Prod
                {
                    StatusID = 105;
                }
                else if (Access == "22") // ED Dist
                {
                    StatusID = 105;
                }
                else if (Access == "23") // COO
                {
                    StatusID = 105;
                }
                else //HQ Departments
                {
                    StatusID = 105;
                }
                
                if (RequisitionType.Contains("EMERGENCY"))
                {
                    Message = "<p><strong>EMERGENCY REQUISITION</strong></p>";
                    Message += "<p>You have been sent an emergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in "
                        + CostCenterName + " to Managing Director By Cost Center Manager ( " + By + " </p>";
                }
                else
                {
                    Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in "
                        + CostCenterName + " to Managing Director By Cost Center Manager ( " + By + " </p>";
                }

                Message += "<p>Comment: " + remark + "</p>";
                Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

                //string RA = NotifyRankApproval(By, Subject, Message, PD_Code);

                //if (String.IsNullOrEmpty(remark))
                //    remark = "Assigned To Rank Approver(s) (" + RA + ")";
                //else
                //    remark = "Assigned To Rank Approver(s) (" + RA + ") With Comment " + remark;

                // Notify Requisitioner
                Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Cost Center Manager ( " + By + " ) ";
                Message += " and Sent to Managing Director With Comment: " + remark + "</p>";
                Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                Process.NotifyPlanner(By, Subject, Requisitioner, Message);

                output = "Requisition(" + Subject + ") has been successfully submitted for approval";
            }
            else
            {
                //Added for Items with Rankang 1:...to be ignored in future

                //StatusID = 14;
                StatusID = 24;
                if (RequisitionType.Contains("EMERGENCY"))
                {
                    Message = "<p><strong>EMERGENCY REQUISITION</strong></p>";
                    Message += "<p>You have been sent an emergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in " + CostCenterName
                                + " for Rank Approval By Cost Center Manager ( " + By + " ) </p>";
                }
                else
                {
                    Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in " + CostCenterName
                                + " for Rank Approval By Cost Center Manager ( " + By + " ) </p>";
                }

                Message += "<p>Comment: " + remark + "</p>";
                Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";
                //sas
                //string FA = NotifyFinance(Requisitioner, Subject, PD_Code, Amount, Message, "0");
                // notify MD
                string MD = NotifyManagingDirector(By, Subject, PD_Code, Amount, Message, "0");
                
                Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Cost Center Manager ( " + By + " ) ";
                //Message += " and Sent For Fund Approval ( " + FA + " ) With Comment: " + remark + "</p>";
                //Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                Process.NotifyPlanner(By, Subject, Requisitioner, Message);

                //output = "Requisition(" + Subject + ") has been successfully submitted to Finance ( " + FA + " )";
                Message += " and Sent For Rank Approval ( " + MD + " ) With Comment: " + remark + "</p>";
                Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                Process.NotifyPlanner(By, Subject, Requisitioner, Message);

                output = "Requisition(" + Subject + ") has been successfully submitted to Managing Director ( " + MD + " )";
            }
        }
        else
        {
            StatusID = 13;
            string ManagerName = HttpContext.Current.Session["FullName"].ToString();

            Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been rejected by Cost Center Manager ( " + ManagerName + " ) ";
            Message += "<p>Comment: " + remark + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

            Process.NotifyPlanner(ManagerName, Subject, Requisitioner, Message);

            output = "Requisition(" + Subject + ") has been rejected and sent back to requisitioner(s)";
        }
        LogandCommitRequisition(PD_Code, StatusID, remark);
        return output;
    }


    private string CostCenterManagerAction2(string PD_Code, string Status, double Amount, string remark, string EmmergencyMemo)
    {
        string output = "";
        string Message = "";

        DataTable dtAlert = GetRequisitionerAndCCManager(PD_Code);
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        string Subject = dtAlert.Rows[0]["Subject"].ToString();
        string RequisitionType = dtAlert.Rows[0]["RequisitionType"].ToString();

        int StatusID = 0;
        if (Status == "1")
        {
            int ManagerID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
            string By = HttpContext.Current.Session["FullName"].ToString();
            data.ManagerApproving(PD_Code, ManagerID, EmmergencyMemo);

       
                StatusID = 14;
                if (HttpContext.Current.Session["StatusID"].ToString() == "105")
                {
                

                    if (RequisitionType.Contains("EMERGENCY"))
                {
                    Message = "<p><strong>EMERGENCY REQUISITION</strong></p>";
                    Message += "<p>You have been sent an emergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in "
                        + CostCenterName + " by Managing Director </p>";
                }
                else
                {
                    Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in "
                        + CostCenterName + " by Managing Director </p>";
                }

                Message += "<p>Comment: " + remark + "</p>";
                Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

                    string RA = NotifyRankApproval(By, Subject, Message, PD_Code);

                    //if (String.IsNullOrEmpty(remark))
                    //    remark = "Assigned To Rank Approver(s) (" + RA + ")";
                    //else
                    //    remark = "Assigned To Rank Approver(s) (" + RA + ") With Comment " + remark;

                    // Notify Requisitioner
                    Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Managing Director ( " + By + " ) ";
                    Message += " and Sent to Budget Committee with Comment: " + remark + "</p>";
                    Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                    Process.NotifyPlanner(By, Subject, Requisitioner, Message);

                    output = "Requisition(" + Subject + ") has been successfully submitted to Budgetting Committee";

                    StatusID = 14;
                }
                else if (HttpContext.Current.Session["StatusID"].ToString() == "16")
                {

                   
                    // Notify Requisitioner
                    Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Managing Director ( " + By + " ) ";
                    Message += " and Sent to Procurement for commencement with comment: " + remark + "</p>";
                    Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                    Process.NotifyPlanner(By, Subject, Requisitioner, Message);

                    output = "Requisition(" + Subject + ") has been successfully submitted to Procurement for commencement";
                    StatusID = 20;


                }
             
          
        }
        else
        {
            StatusID = 13;
            string ManagerName = HttpContext.Current.Session["FullName"].ToString();

            Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been rejected by Managing Director ( " + ManagerName + " ) ";
            Message += "<p>Comment: " + remark + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

            Process.NotifyPlanner(ManagerName, Subject, Requisitioner, Message);

            output = "Requisition(" + Subject + ") has been rejected and sent back to requisitioner(s)";
        }
        LogandCommitRequisition(PD_Code, StatusID, remark);
        return output;
    }

    private string NotifyManagingDirector(string Requisitioner, string Subject, string PD_Code, double RequisitionAmount, string Message, string AreaCode)
    {
        string Name = "";
        string Email = "";
        int AreaID = 0;
        if (AreaCode == "0")
            AreaID = Convert.ToInt32(HttpContext.Current.Session["AreaCode"].ToString());
        else
            AreaID = Convert.ToInt32(AreaCode);
        //dTable = data.GetFinanceManager(RequisitionAmount, AreaID);
        dTable = data.GetManagingDirector(RequisitionAmount, AreaID);
        if (dTable.Rows.Count > 0)
        {
            int MDAreaID = Convert.ToInt32(dTable.Rows[0]["AreaID"].ToString());
            //data.UpdateRequisitionWithFinanceAreaID(PD_Code, FinanceAreaID);
            data.UpdateRequisitionWithManagingDirectorAreaID(PD_Code, MDAreaID);
            foreach (DataRow dr in dTable.Rows)
            {
                if (String.IsNullOrEmpty(dr["UserID"].ToString()))
                    continue;
                int NotifyeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
                if (bllPlanning.IsDelegated(NotifyeeID))
                {
                    dTable = dataPlanning.GetActing(NotifyeeID);
                    Name = dTable.Rows[0]["FullName"].ToString();
                    Email = dTable.Rows[0]["Email"].ToString();
                }
                else
                {
                    Name = dr["FullName"].ToString();
                    Email = dr["Email"].ToString();
                }
                string Msg = "<p>Hello " + Name.ToUpper() + " , </p>" + Message;
                mailer.SendEmail(Name, Email, Subject, Msg);
            }
        }
        return Name;
    }
    private string LogisticsManagerAction(string PD_Code, string Status, string remark,string SendTo, string CenterID, string CostCenterCode, string CostCenterName, string amount, string Subject, string Location, string AreaCode, string WareHouse, string DateRequired, string CostCenterForBudget)
    {
        string output = "";
        string Message = "";
        int StatusID = 17;

        DataTable dtAlert = GetRequisitionerAndCCManager(PD_Code);
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        string CCManager = dtAlert.Rows[0]["CCManagerID"].ToString();
        string By = HttpContext.Current.Session["FullName"].ToString();
        CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        Subject = dtAlert.Rows[0]["Subject"].ToString();
        string RequisitionType = dtAlert.Rows[0]["RequisitionType"].ToString();

        if (Status == "1")
        {
            if (SendTo == "3")
            {
                StatusID = 21;

                if (RequisitionType.Contains("EMERGENCY"))
                {
                    Message = "<p><strong>EMERGENCY REQUISITION</strong></p>";
                    Message += "<p>You have been sent an emergency requisition entitled <strong>" + Subject + "</strong> by " + RequisitionerName + " in " 
                                + CostCenterName + " for Approval By Logistics Manager ( " + By + " ) </p>";
                }
                else
                {
                    Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + "</strong> by " + RequisitionerName + " in "
                                + CostCenterName + " for Approval By Logistics Manager ( " + By + " ) </p>";
                }

                Message += "<p>Comment: " + remark + "</p>";
                Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

                NotifyProcurement(By, Subject, Message, "0");

                // Notify Requisitioner
                Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Logistics Manager ( " + By + " ) ";
                Message += " and Sent To Procurement With Comment: " + remark + "</p>";
                Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                Process.NotifyPlanner(By, Subject, Requisitioner, Message);

                output = "Requisition(" + Subject + ") Has Been Successfully Submitted To Procurement";
            }
            else
            {
                StatusID = 18;

                if (RequisitionType.Contains("EMERGENCY"))
                {
                    Message = "<p><strong>EMERGENCY REQUISITION</strong></p>";
                    Message += "<p>You have been sent an emergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in "
                                + CostCenterName + " for Inventory Verification from Logistics Manager ( " + By + " ) </p>";
                }
                else
                {
                    Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in "
                                + CostCenterName + " for Inventory Verification from Logistics Manager ( " + By + " ) </p>";
                }

                int RequisitionerID = Convert.ToInt32(Requisitioner);
                if (Process.IsUserInInventory(RequisitionerID))
                    Process.NotifyPlanner(By, Subject, Requisitioner, Message);
                else
                    NotifyInventory(By, Subject, Message, AreaCode);

                // Notify Requisitioner
                Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been approved by Logistics Manager ( " + By + " )";
                Message += " and Sent To Inventory For Approval With Comment: " + remark + "</p>";
                Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

                Process.NotifyPlanner(By, Subject, Requisitioner, Message);

                output = "Requisition(" + Subject + ") has been successfully submitted to Inventory";
            }

            if (StatusID == 21)
            {
                string WareHouseCode = "";
                if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "1")
                {
                    WareHouseCode = "01";
                }
                else if (WareHouse != "")
                    WareHouseCode = WareHouse; //GetNewWareHouseID(WareHouse);
                else
                    WareHouseCode = GetWareHouseID(Location);

                 //LogInScala(PD_Code, Subject, Location, WareHouseCode, amount, DateRequired, CostCenterCode, CostCenterForBudget);
            }
        }
        else
        {
            StatusID = 17;
            string ManagerName = HttpContext.Current.Session["FullName"].ToString();

            Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been rejected by Logistics Manager ( " + ManagerName + " ) ";
            Message += "<p>Comment: " + remark + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

            Process.NotifyPlanner(ManagerName, Subject, Requisitioner, Message);
            Process.NotifyPlanner(ManagerName, Subject, CCManager, Message);

            output = "Requisition(" + Subject + ") has been rejected and sent back to requisitioner(s)";

        }
        LogandCommitRequisition(PD_Code, StatusID, remark);
        return output;
    }
    private string ProcurementManagerAction(string PD_Code, string Status, string remark, string SendTo, string ScalaNumber, string CostCenterCode, string Location, string amount, string WareHouse, string DateRequired, string CostCenterForBudget)
    {
        string output = "";
        string Message = "";
        int StatusID = 22;
        string By = HttpContext.Current.Session["FullName"].ToString();
        string Access = HttpContext.Current.Session["AccessLevelID"].ToString();
        DataTable dtAlert = GetRequisitionerAndCCManager(PD_Code);
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        string Subject = dtAlert.Rows[0]["Subject"].ToString();
        string RequisitionType = dtAlert.Rows[0]["RequisitionType"].ToString();

        ProcessUsers usr = new ProcessUsers();

        String lvl = usr.getUserAccessLevel(SendTo);
        if (Status == "1")
        {
            ProcessRequisition processreq = new ProcessRequisition();
            DataTable dtable = processreq.GetLogs(PD_Code);
            string reqstatus = dtable.Rows[0]["StatusID"].ToString();
            if (reqstatus.Equals("45"))// activity approved by md and waiting to be assigned by the procurement manager
            {
                StatusID = 47;
            }
            else
            {
                StatusID = 23;
            }
            

            if (lvl == "1025")
            {
                StatusID = 36;
            }
            else if (lvl == "1027")
            {
                StatusID = 37;
            }

            if (Access.Equals("3") && reqstatus.Equals("20")) 
            {
                string assignee = HttpContext.Current.Session["UserID"].ToString();
                string assignedto = SendTo;
                string requisition = ScalaNumber;
               // processreq.TrackReqAssignment(assignee, assignedto, requisition);
            }


          //if (Access == "4")
          //  {
          //      // If Area PDU Officer, Log in Scala
          //      SendTo = HttpContext.Current.Session["UserID"].ToString();

          //      string WareHouseCode = "";
          //      if (WareHouse != "")
          //          WareHouseCode = WareHouse; //GetNewWareHouseID(WareHouse);
          //      else
          //          WareHouseCode = GetWareHouseID(Location);

          //      LogInScala(PD_Code, Subject, Location, WareHouseCode, amount, DateRequired, CostCenterCode, CostCenterForBudget);
          //      dtAlert = GetRequisitionerAndCCManager(PD_Code);
          //      ScalaNumber = dtAlert.Rows[0]["ScalaPRNumber"].ToString();
          //  }
           
            if (RequisitionType.Contains("EMERGENCY"))
            {
                Message = "<p><strong>EMERGENCY REQUISITION</strong></p>";
                Message += "<p>You have been assigned an emergency requisition ( " + ScalaNumber + " ) entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in "
                            + CostCenterName + " by Procurement ( " + By + " ) </p>";
            }
            else
            {
                Message = "<p>You have been sent a normal requisition ( " + ScalaNumber + " ) entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> in "
                            + CostCenterName + " by Procurement ( " + By + " ) </p>";
            }

            // Notify Officer
            LogandCommitRequisition(PD_Code, StatusID, remark);
            data.ProcManagerApproving(PD_Code, SendTo);
            string Officer = NotifyOfficer(By, Subject, SendTo, Message);
          
            if (remark == "")
                remark = "Requisition Assigned To " + Officer;

            // Notify Requisitioner
            Message = "<p>Your Requisition ( " + ScalaNumber + " : " + Subject + " ) for your Cost Center has been approved by Procurement Manager ( " + By + " ) ";
            Message += " and Assigned to Procurement Officer ( " + Officer + " ) With Comment : " + remark + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

            Process.NotifyPlanner(By, Subject, Requisitioner, Message);

            output = "Requisition ( " + ScalaNumber + " ) has been successfully assigned to " + Officer;
        }
        else
        {
            if (Access == "4")
                StatusID = 34;

            Message = "<p>Your Requisition ( " + Subject + " ) for your Cost Center has been rejected by Procurement ( " + By + " ) ";
            Message += "<p>Comment: " + remark + "</p>";
            Message += "<p>For more details, please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login.</p>";

            Process.NotifyPlanner(By, Subject, Requisitioner, Message);

            output = "Requisition(" + Subject + ") has been rejected and sent back to requisitioner(s)";

        }
        
        return output;
    }

    private void TrackReqAssignment(string assignee, string assignedto, string requisition)
    {
        data.TrackReqAssignment( assignee,  assignedto,  requisition);
    }

    public string NotifyOfficer(string SenderName, string Subject, string SendTo, string Message)
    {
        string Name = "";
        string Email = "";
        int UserID = Convert.ToInt32(SendTo);
        dTable = data.GetProcurementOfficer(UserID);
        if (dTable.Rows.Count > 0)
        {
            int NotifyeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
            if (bllPlanning.IsDelegated(NotifyeeID))
            {
                dTable = dataPlanning.GetActing(NotifyeeID);
                Name = dTable.Rows[0]["FullName"].ToString();
                Email = dTable.Rows[0]["Email"].ToString();
            }
            else
            {
                Name = dTable.Rows[0]["FullName"].ToString();
                Email = dTable.Rows[0]["Email"].ToString();
            }
            string Msg = "<p>Hello " + Name.ToUpper() + " , </p>" + Message;
            mailer.SendEmail(SenderName, Email, Subject, Msg);
        }
        return Name;
    }
    public void LogandCommitRequisition(string PD_Code, int Status, string remark)
    {
        int CreatedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        data.LogandCommit(PD_Code, Status, CreatedBy, remark);
    }
    public void UpdateAdvertType(string PD_Code, string adverttype)
    {
        data.UpdateAdvertType(PD_Code, adverttype);
    }

    public void InsertBidAwards(string bidderid, string referenceno, string awardedby)
    {
        data.InsertBidAwards(bidderid, referenceno, awardedby);
    }
    public DataTable GetRequisitionDetailsByReference(string referenceno)
    {
        dTable = data.GetProcurementDetails(referenceno);
        return dTable;
    }

    public DataTable GetSelectedBidderDetails(string referenceno)
    {
        dTable = data.GetSelectedBidderDetails(referenceno);
        return dTable;
    }
    public DataTable GetRequisitionItems(string RecordID, string ProcType, string StartDate, string EndDate, string Level)
    {
        int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        dTable = data.GetLowlevelItems(RecordID, ProcType,CostCenterID, Startdate, Enddate,FinID, Level);
        return dTable;
    }
    public DataTable GetAssignedRequisitions(string AreaCode, string ProcOfficer, string SearchStartDate, string SearchEndDate)
    {
        int AreaID = Convert.ToInt32(AreaCode); int ProcOfficerID = Convert.ToInt32(ProcOfficer);
        DateTime StartDate = bll.ReturnDate(SearchStartDate, 1); DateTime EndDate = bll.ReturnDate(SearchEndDate, 2);
        int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        return data.GetAssignedRequisitions(AreaID, ProcOfficerID, StartDate, EndDate);
    }
    public DataTable GetRequisitionforPrinting(string PRNumber, string ProcType, string StartDate, string EndDate,string AreaCode, string CostCenterCode)
    {
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        int ProcTypeID = Convert.ToInt32(ProcType);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        int AreaID = Convert.ToInt32(AreaCode);
        DateTime Startdate = bll.ReturnDate(StartDate, 1);
        DateTime Enddate = bll.ReturnDate(EndDate, 2);
        dTable = data.GetRequisitionforPrint(PRNumber, ProcTypeID, CostCenterID, Startdate, Enddate, AreaID, FinID);
        return dTable;
    }

    public DataTable GetAdvertisedBids()
    {
        dTable = data.GetAdvertisedBids();
        return dTable;
    }
    public string ResubmitRequisitionItems(string ItemArr, string Comment)
    {
        string output = "";
        if (ItemArr != "")
        {
            string[] arr = ItemArr.Split(',');
            int i = 0;
            string RecordID = "";
            int forManager = 0, forFinance = 0, forLogistic = 0, forRank = 0, forInventory = 0, forProcurement = 0;
            for (i = 0; i < arr.Length; i++)
            {
                RecordID = arr[i].ToString();
                if (RecordID != "")
                {
                    int NewStatus = ResubmitRequisitionItem(RecordID);
                    if (NewStatus == 11)
                    {
                        // Notify Manager
                        DataTable dtDetails = GetRequisitionEmailDetailsByRecordID(RecordID);

                        int ManagerID = Convert.ToInt32(dtDetails.Rows[0]["CCManagerID"].ToString()); 
                        string CostCenterName = dtDetails.Rows[0]["CostCenterName"].ToString();
                        string RequisitionerName = dtDetails.Rows[0]["Requisitioner"].ToString();
                        string Subject = dtDetails.Rows[0]["Subject"].ToString();

                        string By = HttpContext.Current.Session["FullName"].ToString();
                        string Message = "<p>Requisition <strong>" + Subject + "</strong> has been resubmitted to you for approval by " + By + " </p>";
                        Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";
                        if (String.IsNullOrEmpty(Comment))
                            Process.NotifyManager(By, "Re-submitting " + Subject, ManagerID, Message);
                        else
                            Process.NotifyManager(By, "Re-submitting with comment : " + Comment, ManagerID, Message);
                    }
                    else if (NewStatus == 14)
                        forFinance++;
                    else if (NewStatus == 16)
                        forLogistic++;
                    else if (NewStatus == 18)
                        forInventory++;
                    else if (NewStatus == 24)
                        forRank++;
                    else if (NewStatus == 21)
                        forProcurement++;
                }
            }
            /// All
            NotifyAll(forManager, forFinance, forLogistic, forInventory, forProcurement, forRank, Comment);
            
            output = i + " Requisition items have been resubmitted Successfully";
        }
        else
        {
            output = "Please Select The Requisition Item(s) to Resubmit";
        }
        return output;
    }
    private void NotifyAll(int forManager, int forFinance, int forLogistic, int forInventory, int forProcurement, int forRank, string Comment)
    {
        string FullName = HttpContext.Current.Session["FullName"].ToString();
        string CostCenter = HttpContext.Current.Session["CostCenterName"].ToString();
        string AreaCode = HttpContext.Current.Session["AreaCode"].ToString();
        string Subject = "Re-submitting Requisitions from " + CostCenter;

        if (forManager != 0)
        {
            // Notify Manager
            string Message = "<p> " + forManager + " requisition item(s) have been resubmitted to you for approval from Cost Center: " + CostCenter;
            if (!String.IsNullOrEmpty(Comment))
                Message += "<p>With Comment: " + Comment + "</p>";
            Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

            //DataTable dtDetails = GetRequisitionDetailsByRecordID(
            // TODO: Notify Manager
           // Process.NotifyManager(CostCenterID, message);
        }
        if (forFinance != 0)
        {
            // Notify Finance
            string Message = "<p> " + forFinance + " requisition item(s) have been resubmitted to you for approval from Cost Center: " + CostCenter;
            if (!String.IsNullOrEmpty(Comment))
                Message += "<p>With Comment: " + Comment + "</p>";
            Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

            // TODO: Re-submitting to Finance
          //NotifyFinance(FullName, Subject, Message, "0");
            
        }
        if (forRank != 0)
        {
            string Message = "<p> " + forFinance + " requisition item(s) have been resubmitted to you for approval from Cost Center: " + CostCenter;
            if (!String.IsNullOrEmpty(Comment))
                Message += "<p>With Comment: " + Comment + "</p>";
            Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

            //NotifyRankApproval(FullName, Subject, Message, 
            NotifyRankApproval(FullName, Subject, Message, "");
            //NotifyFinance(FullName, Subject, Message);
        }
        if (forLogistic != 0)
        {
            // Notify Logistic
            string Message = "<p> " + forLogistic + " requisition item(s) have been resubmitted to you for approval from Cost Center: " + CostCenter;
            if (!String.IsNullOrEmpty(Comment))
                Message += "<p>With Comment: " + Comment + "</p>";
            Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

            NotifyLogistics(FullName, Subject, Message, AreaCode);
        }

        if (forInventory != 0)
        {
            // Notify Inventory
            string Message = "<p> " + forInventory + " requisition item(s) have been resubmitted to you for approval from Cost Center: " + CostCenter;
            if (!String.IsNullOrEmpty(Comment))
                Message += "<p>With Comment: " + Comment + "</p>";
            Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

            NotifyInventory(FullName, Subject, Message, AreaCode);
        }
        if (forProcurement != 0)
        {
            // Notify Procurement
            string Message = "<p> " + forProcurement + " requisition item(s) have been resubmitted to you for approval from Cost Center: " + CostCenter;
            if (!String.IsNullOrEmpty(Comment))
                Message += "<p>With Comment: " + Comment + "</p>";
            Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a>  to login. </p> ";

            NotifyProcurement(FullName, Subject, Message, "0");
        }
    }
    private int ResubmitRequisitionItem(string RecordCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        DateTime Startdate = bll.ReturnDate("",1);
        DateTime Enddate = bll.ReturnDate("",2);
        int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        int AreaID = Convert.ToInt32(HttpContext.Current.Session["AreaCode"]);
        int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        dTable = data.GetRequisitionItems(RecordID, 0, Startdate, Enddate, CostCenterID, UserID, AreaID, 0, FinID);
        string StatusCode = dTable.Rows[0]["StatusID"].ToString();
        string PD_Code = dTable.Rows[0]["PD_Code"].ToString();
        int NewStatus = 21;
        if (StatusCode == "13")
        {
            NewStatus = 11;
        }
        else if (StatusCode == "15")
        {
            NewStatus = 14;
        }
        else if (StatusCode == "17")
        {
            NewStatus = 16;
        }
        else if (StatusCode == "19")
        {
            NewStatus = 18;
        }
        else if (StatusCode == "25")
        {
            NewStatus = 24;
        }
        else if (StatusCode == "11")
        {
            NewStatus = 24;
        }
        else if (StatusCode == "22")
            NewStatus = 21;
        LogandCommitRequisition(PD_Code, NewStatus, "Re-submitted Requisition");
        return NewStatus;
    }
    public string ScalaDateFormat(DateTime datetime)
    {
        return String.Format("{0}-{1}-{2} {3}:{4}:{5}", datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
    }
    public void LogInScala(string PD_Code,string Subject, string DeliveryLocation, string WareHouse, string amount, string DateRequired, string CostCenterCode, string CostCenterForBudget)
    {
        double OrderValue = Convert.ToDouble(amount);
        DateTime OrderDate = Convert.ToDateTime(DateRequired);
        string AccountString = GetAcountingString(PD_Code);

        string CompanyCode, PurchaseOrderNumber;
        if (CostCenterForBudget != "0" && CostCenterForBudget.Length == 6)
        {
            //CompanyCode = CostCenterForBudget.Substring(0, 2).ToString();
            //PurchaseOrderNumber = GetPurchaseOrderNumber(CostCenterForBudget);
            CompanyCode = CostCenterCode.Substring(0, 2).ToString();
            PurchaseOrderNumber = GetPurchaseOrderNumber(CostCenterCode);
        }
        else
        {
            CompanyCode = CostCenterCode.Substring(0, 2).ToString();
            PurchaseOrderNumber = GetPurchaseOrderNumber(CostCenterCode);
        }

        data.SavePurchaseOrder(CompanyCode, PurchaseOrderNumber, 0, "00015", "+", Subject, "01",
            0, 0, 0, "0", "0", 0, 0, 0, OrderDate, OrderDate, DeliveryLocation, "Adminstration", 0.00000000, OrderValue,
            "ENG", 0, WareHouse, "", "", "", "", "", "", "", 1.00000000, "", AccountString, "", DateTime.Now, DateTime.Now, "", "", 0, 0,
            "", "", "", "", "", "", 1.00000000, "*", "0", "", "", "", 0, 0, 0, "", "", "", "", Subject,
            "", "", 0, 0, 0, "", "", "0", "", "", "", "", "APPSERVER", "", "", "", "", "", DateTime.Now, "", 0.00000000, 0.00000000,
            0.00000000, "", "", "", "", 0.00000000, 0.00000000, 0.00000000, 0.00000000, 0.00000000, "", "", "", "", "", "", "", 0,"",DateTime.Now);
        LogProcurementItemsInScala(CompanyCode, PD_Code, PurchaseOrderNumber, WareHouse, AccountString);
        LogisticAction(PD_Code, PurchaseOrderNumber);
    }
    private string GetWareHouseID(string DeliveryLocation)
    {
        string WareHouse = "";
        if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "1")
            WareHouse = "01";
        else
        {
            dTable = data.GetDeliveryLocationID(DeliveryLocation);
            if (dTable.Rows.Count > 0)
                WareHouse = dTable.Rows[0]["ScalaCode"].ToString();
        }
        return WareHouse;
    }
    private string GetCostCenterScalaCode(int CostCenterID)
    {
        string AreaScalaCode = "";
        dTable = data.GetCostCenterAreaDetails(CostCenterID);
        if (dTable.Rows.Count > 0)
            AreaScalaCode = dTable.Rows[0]["ScalaCode"].ToString();
        return AreaScalaCode;
    }
    public string GetNewWareHouseID(string WareHouse)
    {
        string WareHouseCode = "";
        if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "1")
            WareHouseCode = "01";
        else
        {
            dTable = data.GetNewWareHouseID(WareHouse);
            if (dTable.Rows.Count > 0)
                WareHouseCode = dTable.Rows[0]["ScalaCode"].ToString();
        }
        return WareHouseCode;
    }
    private void LogProcurementItemsInScala(string AreaCode, string PD_Code, string PurchaseOrderNumber, string WareHouse, string AccountingString)
    {
        dTable = GetPD_CodeItems(PD_Code);
        int number = 0; int numberLength = 0;
        string LineNumber = ""; string StockType = "";
        string StockCode = ""; int line = 1;
        foreach (DataRow dr in dTable.Rows)
        {
            bool IsStock = Convert.ToBoolean(dr["IsStockItem"].ToString());
            number = (line * 10);
            numberLength = number.ToString().Length;
            LineNumber = AppendZeros(6 - numberLength) + number.ToString();

            if (IsStock)
            {
                StockCode = dr["StockCode"].ToString();
            }
            else
            {
                number = (line * 5);
                numberLength = number.ToString().Length;
                StockCode = AppendZeros(4 - numberLength) + number.ToString();
                StockCode = "ZZ" + StockCode;
            }
            string ItemDesc = dr["Description"].ToString();
            double UnitCost = Convert.ToDouble(dr["UnitCost"].ToString());
            double QtyOrdered = Convert.ToDouble(dr["NumberOfItems"].ToString());
            DateTime CurrentDate = DateTime.Now;
            String SCurrentDate = ScalaDateFormat(CurrentDate);
            DateTime OtherDate = Convert.ToDateTime("01/01/1900");
            String SOtherDate = ScalaDateFormat(OtherDate);
            data.SavePRItems(AreaCode, PurchaseOrderNumber, LineNumber, "000000", 0, StockCode, ItemDesc,
                "", UnitCost, 15, QtyOrdered, 0.00000000, 0.00000000, "0", "0", 0.00000000, SCurrentDate,
                SCurrentDate, 1.00000000, 1.00000000, "", 0, "", 0, SCurrentDate, 1.00000000, "", "0", "",
                "0", SCurrentDate, SCurrentDate, 0.00000000,
                0.00000000, 0.00000000, WareHouse, AccountingString, "", 0.00000000, "",
                "03", "", 1.00000000, 0.00000000, 0.00000000, "", 0.00000000, 0.00000000, "",
                0.00000000, "", "", "", "", 1.00000000, "*", 0, "", 0.00000000, 0.00000000, "", 0,
                0.00000000, "", "", "", 0.00000000, "", "", "", "", 0.00000000, "", "", 0.00000000,
                0.00000000, 0.00000000, 0.00000000, "", "", "", "", "", "", SOtherDate, 0, "", SOtherDate,0,"0","","","",SOtherDate,"");
            line++;
        }
    }
    private string TrimSubject(string Subject)
    {
        string ProcSubject = Subject;
        string ProcurementSubject2 = "";
        string output = "";
        if (Subject.Length > 25)
        {
            int length = Subject.Length;
            int OtherStringLength = (length - 25);
            string OriginalSubject = Subject;
            ProcSubject = Subject.Substring(0, 25);
            ProcurementSubject2 = OriginalSubject.Substring(25, OtherStringLength);
        }
        output = Subject + "-" + ProcurementSubject2;
        return output;
    }
    private void LogisticAction(string PD_Code, string PR_Number)
    {
        int ManagerID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        data.LogisticApproving(PD_Code, ManagerID, PR_Number);
    }
    private string GetPurchaseOrderNumber(string CostCenter)
    {
        string OrderNumber = "";
        string CompanyCode = CostCenter.Substring(0, 2).ToString();
        string CenterCode = CostCenter.Remove(0, 2);
        dTable = data.GetLastPurchaseOrderCode(CompanyCode);
        string PreviousNumber = dTable.Rows[0]["PurchaseOrderCode"].ToString();
        OrderNumber = ReturnRealPurchaseCode(PreviousNumber);
        return OrderNumber;
    }
    private string ReturnRealPurchaseCode(string code)
    {
        string PurchaseCode = "";
        int codelength = code.Length;
        int ActualCodeLength = 10;
        int BalanceLength = ActualCodeLength - codelength;

        string LeadingZeros = AppendZeros(BalanceLength);
        PurchaseCode = LeadingZeros + code;

        return PurchaseCode;
    }
    private string AppendZeros(int BalanceLength)
    {
        string Zeros = "";
        for (int i = 0; i < BalanceLength; i++)
        {
            Zeros = Zeros + "0";
        }
        return Zeros;
    }
    private string GetAcountingString(string PD_Code)
    {
        string AccString = ""; string ProcType = "";
        dTable = data.GetAccountingString(PD_Code);
        if (dTable.Rows.Count > 0)
        {
            AccString = dTable.Rows[0]["String"].ToString();
            ProcType = dTable.Rows[0]["ProcurementType"].ToString();
        }
        return AccString + "        " + ProcType;
    }
    private string GetWareHouse(string AreaID)
    {
        string WareHouse = "";
        if (AreaID == "16")
        {
            WareHouse = "02"; // HQ
        }
        else if (AreaID == "2")
        {
            WareHouse = "01"; // KW
        }
        else
        {
            WareHouse = "03"; // Others
        }
        return WareHouse;

    }
    public DataTable GetOtherPlanItems(string ProcTypeCode, string PlanCode, string Desc)
    {
        int ProcTypeID = Convert.ToInt32(ProcTypeCode);
        int CostCenterID = Convert.ToInt32(HttpContext.Current.Session["CostCenterID"]);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        bool IsConsolidate = Convert.ToBoolean(HttpContext.Current.Session["IsConsolidate"]);
        int QuarterID = 0;
        dTable = data.GetOtherPlanItems(PlanCode, Desc, ProcTypeID, CostCenterID, QuarterID, FinID, IsConsolidate);
        return dTable;
    }
    public DataTable GetRequisitionDetailsByPRNo(string PRNumber)
    {
        dTable = data.GetRequisitionDetailsByPRNo(PRNumber);
        return dTable;
    }
    public DataTable GetRequisitionDetailsByPDCode(string PRNumber)
    {
        dTable = data.GetRequisitionDetailsByPDCode(PRNumber);
        return dTable;
    }
    public DataTable GetActivitySchedule(string PRNumber)
    {
        dTable = data.GetActivitySchedule(PRNumber);
        return dTable;
    }
    public DataTable GetActivityScheduleDetails(string PRNumber)
    {
        dTable = data.GetActivityScheduleDetails(PRNumber);
        return dTable;
    }
    public DataTable GetActivityScheduleComment(string PRNumber, string ColumnNo)
    {
        dTable = data.GetActivityScheduleComment(PRNumber, ColumnNo);
        return dTable;
    }
    public DataTable GetPDUMembers()
    {
        dTable = data.GetPDUMembers();
        return dTable;
    }
    public DataTable GetPDUSupervisors()
    {
        dTable = data.GetPDUSupervisors();
        return dTable;
    }
    public bool IsRequisitionInAreaThreshold(double Amount)
    {
        bool IsInAreaThreshold = true;
        if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "1")
        {
            int AreaID = Convert.ToInt32(HttpContext.Current.Session["AreaCode"].ToString());
            dTable = GetAreaThresholds(AreaID);

            double AreaThreshold = Convert.ToDouble(dTable.Rows[0]["Pdu_Threshold"].ToString());
            if (AreaThreshold < Amount)
                IsInAreaThreshold = false;
        }
        return IsInAreaThreshold;
    }
    public void SaveEditActivityScheduleHead(string ReferenceNo, string SubjectOfProcurement, double EstimatedCost, int ProcurementMethod, 
        int FundingSource, int PreparedBy, int PDUHead, DateTime DateAssigned, DateTime DatePrepared, int ResponsibleOfficer, int PDUCategory, bool PlanSubmitted, string CumulativePeriod)
    {
        int CreatedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        data.SaveEditActivityScheduleHead(ReferenceNo, SubjectOfProcurement, EstimatedCost, ProcurementMethod, FundingSource, PreparedBy, PDUHead, DateAssigned,
            DatePrepared, ResponsibleOfficer, CreatedBy, PDUCategory, PlanSubmitted, CumulativePeriod);
    }


    public void SaveEditActivitySchedule2(string ReferenceNo, int Planned, DateTime BidInvitationDate, DateTime BidSubmissionDate, DateTime BidOpeningDate, double ContractAmount, DateTime startDate, DateTime eoistart, DateTime eoiend)
    {
        int CreatedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        data.SaveEditActivitySchedule2(ReferenceNo, Planned, BidInvitationDate, BidSubmissionDate, BidOpeningDate, ContractAmount, CreatedBy, startDate,eoistart, eoiend);
    }



    public void SaveEditActivitySchedule(string RefNo, bool Planned, DateTime BIDDocPrepDate, DateTime MethodApprovalDate, DateTime BidInvitationDate, DateTime BidSubmissionDate,
        DateTime BidOpeningDate, DateTime BidValidityExpiryDate, DateTime BidSecurityExpiryDate, DateTime EvalReportReadyDate, DateTime CCERApprovalDate, DateTime NegotnReportReadyDate,
        DateTime CCNRApprovalDate, DateTime BEBNoticeDate, DateTime BoardPaperSubmissionDate, DateTime BoardApprovalDate, DateTime SGPaperSubmissionDate, DateTime SGApprovalDate, DateTime FundsAvailableDate,
        DateTime BidAcceptanceLPODate, DateTime ContractPreparationDate, DateTime ContractSigningDate, DateTime PerfSecurityExpDate, double ContractAmount, DateTime ContractCompletionDate, DateTime PaymentDocReceiptDate,
        DateTime FinanceSubmissionDate, DateTime PaymentDate, DateTime FileClosureDate, DateTime prebidmeeting)
    {
        int CreatedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        data.SaveEditActivitySchedule(RefNo, Planned, BIDDocPrepDate, MethodApprovalDate, BidInvitationDate, BidSubmissionDate, BidOpeningDate, BidValidityExpiryDate, BidSecurityExpiryDate,
            EvalReportReadyDate, CCERApprovalDate, NegotnReportReadyDate, CCNRApprovalDate, BEBNoticeDate, BoardPaperSubmissionDate, BoardApprovalDate, SGPaperSubmissionDate, SGApprovalDate,
            FundsAvailableDate, BidAcceptanceLPODate, ContractPreparationDate, ContractSigningDate, PerfSecurityExpDate, ContractAmount, ContractCompletionDate, PaymentDocReceiptDate, FinanceSubmissionDate,
            PaymentDate, FileClosureDate, CreatedBy,prebidmeeting);
    }
    public DataTable GetActivitySchedulesToApproval(int PDUCategory, int ProcurementMethod, DateTime StartDate, DateTime EndDate)
    {
        dTable = data.GetActivityScheduleForApproval(PDUCategory, ProcurementMethod, StartDate, EndDate);
        return dTable;
    }
    public DataTable GetMainScheduleActivityDetails(int PDUCategory, string ProcurementOfficer, string FinYear)
    {
        dTable = data.GetMainScheduleActivityDetails(PDUCategory, ProcurementOfficer, FinYear);
        return dTable;
    }
    public DataTable GetActivityScheduleForSubReport(int PDUCategory, string ProcurementOfficer)
    {
        dTable = data.GetActivityScheduleForSubReport(PDUCategory, ProcurementOfficer);
        return dTable;
    }
    public void SaveUpdateScheduleStatus(string RefNo, string UserID, string Status, string Comment)
    {
        data.SaveUpdatedScheduleStatus(RefNo, UserID, Status, Comment);
    }

    public void DeleteCCRequisition(int ScalaPR, string PD_Code, int StatusID, string Remark)
    {


        data.DeleteCCRequisition(PD_Code);
        LogandCommitRequisition(PD_Code, StatusID, Remark);
    }

    public DataTable getCCRequisitions(string PrNumber, string startDate, string endDate, string proctypeID, string CostCenterID, string AreaID)
    {


        int areaID = Convert.ToInt32(AreaID);
        int costcenterID = Convert.ToInt32(CostCenterID);
        int ProcTypeID = Convert.ToInt32(proctypeID);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        DateTime Startdate = bll.ReturnDate(startDate, 1);
        DateTime Enddate = bll.ReturnDate(endDate, 2);


        dTable = data.getCCRequisitions(PrNumber, Startdate, Enddate, ProcTypeID, costcenterID, FinID, areaID);
        return dTable;
    }



    public DataTable getCancelledDeleteCCRequisitions(string PrNumber, string startDate, string endDate, string proctypeID, string CostCenterID, string AreaID, int assignedto)
    {

        int areaID = Convert.ToInt32(AreaID);
        int costcenterID = Convert.ToInt32(CostCenterID);
        int ProcTypeID = Convert.ToInt32(proctypeID);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        DateTime Startdate = bll.ReturnDate(startDate, 1);
        DateTime Enddate = bll.ReturnDate(endDate, 2);


        dTable = data.getCancelledDeletedCCRequisitions(PrNumber, Startdate, Enddate, ProcTypeID, costcenterID, FinID, areaID,assignedto);
        return dTable;


    }

    public void UpdateRankApproverList(int recordID, decimal minthreshhold, decimal maxthreshhold, int newApproverID,int change)
    {
        data.UpdateRankApproverList(recordID, minthreshhold, maxthreshhold, newApproverID, change);
        
    }

    public void SaveProjectItems(string pdCode, DataTable dtProject)
    {
      
       foreach (DataRow dr in dtProject.Rows)
       {

           string FinYear         = dr["FinYear"].ToString().Replace(",", "");
           string ItemDesc        =  dr["ItemDesc"].ToString().Replace(",", "");
           Double projectItemCost = Convert.ToDouble(dr["TotalCost"].ToString().Replace(",", ""));

           data.SaveProjectItems(pdCode, FinYear, ItemDesc, projectItemCost);

       }
 
    }


    public void SaveProjectCurrentFinYearCost(string PD_CODE,string CurrentFinYearCost)
    {
        Double projectCost = Convert.ToDouble(CurrentFinYearCost);

        data.SaveProjectCurrentFinYearCost(PD_CODE,projectCost);
    }

    public DataTable GetProjects(string PD_Code)
    {
        dTable = data.GetProjects(PD_Code);
        return dTable;
    }
}
