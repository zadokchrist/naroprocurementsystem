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
public class DataRequisition
{
    private Database Proc_DB;
    private Database scala_DB;
    private DbCommand mycommand;
    private DataSet returnDataset;
    private DataTable returnDatatable;

    DataLogin con = new DataLogin();
	public DataRequisition()
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
    #region DATA CALLING METHODS
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
    public DataTable GetDatesForFinancialYear(int ModuleID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetDatesForFinancialYear", ModuleID);
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
    public DataTable GetDelieveryLocations()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetDelieveryLocations");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetWareHouses(string AreaCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetWareHouses", AreaCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable CheckIfUserInConsolidationCenter(string UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_CheckIfUserInConsolidationCenter", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetNewWareHouseID(string WareHouse)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetWareHouseID", WareHouse);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetCostCenterAreaDetails(int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetAreaDetails", CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetDeliveryLocationID(string DeliveryLocation)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetDeliveryLocationID", DeliveryLocation);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetRequisitionerAndCCManager(string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRequisitionerAndCCManager", PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetRequisitionEmailDetailsByRecordID(string RecordCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRequisitionEmailDetailsByRecordID", RecordCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetPlanItemDetails(string PlanCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetPlanItemDetails", PlanCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRequisitionSerialNumber()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetRequisitionSerialNumber");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetItemToRequisition(string Plancode, string Desc, int ProcType,int CostCenterID, int AreaID, int QuarterID, bool Planned)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetItems", Plancode, Desc, ProcType,CostCenterID,AreaID,QuarterID,Planned);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetItems(string Plancode, string Desc, int ProcType, int CostCenterID, int AreaID, int QuarterID,int FinID, bool Planned, bool IsConsolidatedChecked)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetItems", Plancode, Desc, ProcType, CostCenterID, AreaID, QuarterID,FinID, Planned, IsConsolidatedChecked);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetCostCenterItems(string Search, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetCostCenterItems", Search, AreaID);
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
    
    public  DataTable CheckIsGroup(string Plancode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_CheckGroupItem", Plancode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable GetBidRemainingTime(string pRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderOpenIFBsRemainingTime", pRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetItemsBalances(string Plancode, string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetItemBalances", Plancode, PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAssignedRequisitions(int AreaID, int ProcOfficerID, DateTime StartDate, DateTime EndDate)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetAssignedRequisitions", AreaID, ProcOfficerID, StartDate, EndDate);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetRequisitionItems(long RecordID,int ProcTypeID,DateTime StartDate, DateTime EndDate, int CostCenterID, int UserID, int AreaID,int Status,int FinCode)
    {
        try
        {
            if (Status == 20)
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforProc", RecordID, ProcTypeID, StartDate, EndDate, CostCenterID, Status, FinCode, AreaID);
            else if (Status == 11)
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetails", RecordID, ProcTypeID, StartDate, EndDate, CostCenterID, UserID, Status, FinCode, AreaID);
            else
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetails", RecordID, ProcTypeID, StartDate, EndDate, CostCenterID, 0, Status, FinCode, AreaID);
            
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPDItems(string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetPDItems", PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetGroupPDItems(String PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetGroupPDItems", PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBudgetCodeTotalAmount(string BudgetCode, string CostCenterForBudget, string FinancialYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetBudgetCodeTotalAmount", BudgetCode, CostCenterForBudget, FinancialYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetGroupPDItem(long RecordID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetGroupPDItem", RecordID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable GetUploadedContractsForApprovalById(string contractid)
    {
        mycommand = Proc_DB.GetStoredProcCommand("GetUploadedContractsForApprovalById", contractid);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    internal DataTable GetUploadedContractsForApproval(string contracttype, string fromdate, string todate)
    {
        mycommand = Proc_DB.GetStoredProcCommand("GetUploadedContractsForApproval", fromdate, todate,contracttype );
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    internal DataTable GetUploadedContractsRejected(string contracttype, string fromdate, string todate)
    {
        mycommand = Proc_DB.GetStoredProcCommand("GetUploadedContractsRejected", fromdate, todate, contracttype);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    public DataTable GetAreaThresholds(int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetAreaThresholds", AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRankApproval(int Company, string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRankApproval", Company, PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRankApprovers(string PD_Code, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRankApprovers", PD_Code, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetFinanceManager(double RequisitionAmount, int AreaCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetFinanceManager", RequisitionAmount, AreaCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetLogisticManager(int Company)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetLogisticsManager", Company);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetInventoryManager(int Company)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetInventoryManager", Company);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcurementManager(int Company)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetProcurementManager", Company);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcurementOfficer(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetOfficerDetails", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcOfficers()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetOfficers");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetProcLPOfficers()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetLPOfficers");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetProcSPOfficers()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetSPOfficers");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetProcLPHead()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetProcLPHead");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetProcSPHead()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetProcSPHead");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public DataTable GetProcPMOfficers()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetPMOfficers");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Get Procurement Managers
    /// </summary>
    /// <returns></returns>
    public DataTable GetProcPManagers()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetPManagers");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetLogisticsDestinations()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetForLogistic");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetMDDestinations()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetForMD");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetItemDetailsByRecord(long RecordID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetItemDetailsByID", RecordID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRequisitionformDetails(string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetformDetails", PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRequisitionDetailsByRecordID(string RecordID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRequisitionDetailsByRecordID", RecordID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRequisitionsforRankApproval(long RecordID, int ProcTypeID, DateTime Startdate, DateTime Enddate, int AreaID, int CostCenterID, int StatusID,
        int FinID, int UserID, double min, double max)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetItemforRanking", RecordID, ProcTypeID, Startdate, Enddate, AreaID, CostCenterID, StatusID,
                FinID, UserID, min, max);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRequisitionItemsforAll(long RecordID, int ProcTypeID, DateTime Startdate, DateTime Enddate, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            int UserID = 0;
            if (StatusID == 20)
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforProc", RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
            else if (StatusID == 16)
            {
                if (HttpContext.Current.Session["AccessLevelID"].ToString() != "9")
                    UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforLogistics", RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, UserID, AreaID);
            }
            else if (StatusID == 14)
            {
                UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforFinance2", RecordID, ProcTypeID, 
                    Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID, UserID);
            }
            else 
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforAllCenters", RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void UpdateRecordAssignment(string assignee, string assignedto, string refNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("UpdateRecordAssignment",  assignee,  assignedto,  refNo);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable GetRequisitionAssignmentRecord(string refNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetRequisitionAssignmentRecord", refNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetRequisitionProjectItemsforAll(long RecordID, int ProcTypeID, DateTime Startdate, DateTime Enddate, int CostCenterID, int StatusID, int FinID, int AreaID, string PrNumber)
    {
        try
        {
            int UserID = 0;
            if (StatusID == 20)
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforProc", RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
            else if (StatusID == 16)
            {
                if (HttpContext.Current.Session["AccessLevelID"].ToString() != "9")
                    UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforLogistics", RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, UserID, AreaID);
            }
            else if (StatusID == 14)
            {
                UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforProjectFinance", RecordID, ProcTypeID,
                    Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID, UserID, PrNumber);
            }
            else
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforAllCenters", RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRequisitionItemsforAllFramework(long RecordID, int ProcTypeID, DateTime Startdate, DateTime Enddate, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            int UserID = 0;
            if (StatusID == 20)
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforProc", RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
            else if (StatusID == 16)
            {
                if (HttpContext.Current.Session["AccessLevelID"].ToString() != "9")
                    UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforLogistics", RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, UserID, AreaID);
            }
            else if (StatusID == 14)
            {
                UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforFinance1", RecordID, ProcTypeID,
                    Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID, UserID);
            }
            else
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforAllCenters", RecordID, ProcTypeID, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }






    public DataTable GetRequisitionItemsforOfficer(long RecordID, string PrNumber, int Officer, DateTime Startdate, DateTime Enddate, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetDetailsforOfficer", RecordID,PrNumber, Officer, Startdate, Enddate, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetActivitySchedulesForPDUSupervisor(long RecordID, string PrNumber, long SupervisorID, DateTime StartDate, DateTime EndDate, int PDUCategoryID, int ProcMethodID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetActivityScheduleForApproval", RecordID, PrNumber, SupervisorID, StartDate, EndDate, PDUCategoryID, ProcMethodID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetActivitySchedulesForPDUSupervisor2(long RecordID, string PrNumber, long SupervisorID, DateTime StartDate, DateTime EndDate, int PDUCategoryID, int ProcMethodID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetActivityScheduleForApproval2", RecordID, PrNumber, SupervisorID, StartDate, EndDate, PDUCategoryID, ProcMethodID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetProcurementsSentToSuppliers(long RecordID, string PrNumber, int Officer, int ProcMethod, int CostCenterID, int Status, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetAssignedProcurements", RecordID, PrNumber, Officer, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Gets all plans that have been approved/rejected by the md
    /// </summary>
    /// <param name="RecordID"></param>
    /// <param name="PrNumber"></param>
    /// <param name="SupervisorID"></param>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    /// <param name="PDUCategoryID"></param>
    /// <param name="ProcMethodID"></param>
    /// <param name="statusid"></param>
    /// <returns></returns>
    public DataTable GetActivitySchedulesApprovedByMD(long RecordID, string PrNumber, long SupervisorID, DateTime StartDate, DateTime EndDate, int PDUCategoryID, int ProcMethodID,int statusid)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetProcMethodApprovedByMD", RecordID, PrNumber, SupervisorID, StartDate, EndDate, PDUCategoryID, ProcMethodID, statusid);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetActivitySchedulesForPDUSupervisor3(long RecordID, string PrNumber, long SupervisorID, DateTime StartDate, DateTime EndDate, int PDUCategoryID, int ProcMethodID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetActivityScheduleForApproval3", RecordID, PrNumber, SupervisorID, StartDate, EndDate, PDUCategoryID, ProcMethodID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetThreholdRankings(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRankings", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRequisitionLogs(string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetLogs", PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRequisitionReportLogs(string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetReportLogs", PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRankItems(double Min, double Max, int finYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_RanktoApprove", Min, Max, finYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable CheckRanking(string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_CheckRanking", PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetLowlevelItems(string RecordID, string ProcType,int CostCenter, DateTime StartDate, DateTime EndDate,int FinancialYear, string Level)
    {
         try
        {
        if (Level == "1")
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetApprovedItems", RecordID, ProcType, StartDate, EndDate, CostCenter, FinancialYear);
        }
        else if (Level == "2")
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRejecetedItems", RecordID, ProcType, StartDate, EndDate, CostCenter, FinancialYear);
        }
        else
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetPendingItems", RecordID, ProcType, StartDate, EndDate, CostCenter, FinancialYear);
        }
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }
    catch (Exception ex)
    {
        throw ex;
    }

    }
    public DataTable GetRequisitionforPrint(string PRNumber, int ProcType, int CostCenter, DateTime StartDate, DateTime EndDate, int AreaID, int FinancialYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetforPrinting", PRNumber, ProcType, StartDate, EndDate, CostCenter, AreaID, FinancialYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAdvertisedBids()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetAdvertisedBids");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAccountingString(string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetAccountingString", PD_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetOtherPlanItems(string PlanCode, string Desc, int ProcType, int CostCenterID, int QuarterID, int FinID, bool IsConsolidate)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetOtherPlanItems",PlanCode, Desc, ProcType, CostCenterID, QuarterID, FinID, IsConsolidate);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcurementDetails(string referenceno)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetProcurementDetails", referenceno);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSelectedBidderDetails(string referenceno)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetSelectedBidderDetails", referenceno);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetUsersByNames(string name)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetUsersByNames", name);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRequisitionDetailsByPRNo(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRequisitionDetailsByPRNo", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetRequisitionDetailsByPDCode(string pdcode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetRequisitionDetailsByPDCode", pdcode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetActivitySchedule(string PRNumber)
    {
        mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetActivitySchedule", PRNumber);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }
    public DataTable GetActivityScheduleDetails(string PRNumber)
    {
        mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetActivityScheduleDetails", PRNumber);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }
    public DataTable GetActivityScheduleComment(string PRNumber, string ColumnNo)
    {
        mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetActivityScheduleComment", PRNumber, ColumnNo);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }
    public DataTable GetPDUMembers()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetPDUUsers");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPDUSupervisors()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetPDUSupervisors");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable CheckIfSupervisor(string UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_CheckIfPDUSupervisor", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetApprovedPR(string RefNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetApprovedPR", RefNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetActivityScheduleForApproval(int PDUCategory, int ProcurementMethod, DateTime StartDate, DateTime EndDate)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetActivityScheduleForApproval", PDUCategory, ProcurementMethod, StartDate, EndDate);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMainScheduleActivityDetails(int PDUCategory, string ProcurementOfficer, string FinYear)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetMainActivityScheduleDetails", PDUCategory, ProcurementOfficer, FinYear);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetActivityScheduleForSubReport(int PDUCategory, string ProcurementOfficer)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetActivityScheduleDetailsForSubReport", PDUCategory, ProcurementOfficer);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region DATA INSERTION METHODS
    public string SaveRequisition(long RecordID,string EntityCode, string Subject, int LocationID, int WareHouseID, string CostCenterCode,int CostCenterID, int ProcTypeID,
        int YearID, DateTime Date, int TypeID, int ManagerCode, bool IsGrouped, string UserCode, int CreatedBy, string MarketPrice, bool IsFrameWork,bool IsProject)
    {
        string PDCODE = "";
        try
        {

            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_SaveRequisitionDetails",RecordID, EntityCode,ProcTypeID, Subject, LocationID, WareHouseID,
                CostCenterCode, CostCenterID, YearID, Date, TypeID, ManagerCode, IsGrouped, UserCode, CreatedBy, MarketPrice, IsFrameWork,IsProject);
            System.Data.DataSet ds = Proc_DB.ExecuteDataSet(mycommand);
            int recordCount = ds.Tables[0].Rows.Count;
            if (recordCount != 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                PDCODE = dr[0].ToString();
            }
            IncrementCounter();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return PDCODE;
    }
    private void IncrementCounter()
    {
        mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_UpdateCode");
        Proc_DB.ExecuteNonQuery(mycommand);
    }
    public  void ItemReduction(long RecordID,string Plancode, double Reduction, int ReducedQty)
    {
        try
        {

            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_ReduceItem",RecordID, Plancode, Reduction, ReducedQty);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ItemIncriment(long RecordID,string Plancode, double Incriment, int IncreasedQty)
    {
        try
        {

            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_IncreaseItem",RecordID, Plancode, Incriment, IncreasedQty);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SubmitRequisitionForDeletion(string PD_Code, string planCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_SubmitRequisitionForDeletion", PD_Code, planCode);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateMainRequisitionDetails(string PD_Code, string Subject, int LocationOfDelivery, DateTime DateRequired, int ReqType, int WareHouseID, bool IsFrameWork, bool IsProject)
    {
        mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_UpdateMainRequisitionDetails", PD_Code, Subject, LocationOfDelivery, ReqType, WareHouseID, DateRequired, IsFrameWork, IsProject);
        Proc_DB.ExecuteNonQuery(mycommand);
    }

    public void SaveRequisitionItem(long RecordID, string PlanCode,string PD_Code, string Desc,int PreviousQty, int Quantity, int RemainingQty,
         double PreviousBalance, double Amount, double RemainingBalance, bool Istock,string StockCode, string StockName, int StockBalance, int UnitCode,string MarketPrice)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_SaveRequisitionItem", RecordID, PD_Code, PlanCode, Desc, PreviousQty, Quantity, RemainingQty, PreviousBalance,
                                                      Amount, RemainingBalance, Istock, StockCode, StockName, StockBalance, UnitCode,MarketPrice);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void FlagItemAsRequisitioned(string PlanCode, bool IsRequisitioned)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_FlagAsRequisitioned", PlanCode, IsRequisitioned);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ForwardRequisition(string PD_Code, int ManagerID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_ForwardRequisition", PD_Code, ManagerID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public void LogandCommit(string PD_Code, int Status, int CreatedBy, string Remark)
    {
        // Changes Status and Logs in Transactions Table
         try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_LogTransaction", PD_Code, Status,Remark, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateAdvertType(string PD_Code, string adverttype)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("UpdateAdvertType", adverttype, PD_Code);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void InsertBidAwards(string bidderid, string referenceno, string awardedby)
    {
        // Changes Status and Logs in Transactions Table
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("RecordBidAwards", bidderid, referenceno, awardedby);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void ManagerApproving(string PD_Code, int ManagerID, string EmmergencyMemo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_ManagerAction", PD_Code, ManagerID, EmmergencyMemo);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ProcManagerApproving(string PD_Code, string SendTo)
    {
        try
        {
            int OfficerID = Convert.ToInt32(SendTo);
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_ProcAssigning", PD_Code, OfficerID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void FinanceApproving(string PD_Code, int ManagerID, double Amount, double Expenditure, double RequisitionedAmount, double Balance, string BudgetCode, string CostCenterForBudget)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_FinanceAction", PD_Code, Amount, Expenditure, RequisitionedAmount, Balance, BudgetCode, ManagerID, CostCenterForBudget);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void RankApproving(string PD_Code, int ManagerID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_RankApproving", PD_Code, ManagerID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LogisticApproving(string PD_Code, int ManagerID, string PR_Number)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_LogisticAction", PD_Code,PR_Number, ManagerID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UpdateRequisition(string PD_Code, string Subject, int LocationID, int RequisitionType, DateTime DateRequired)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_Update", PD_Code, Subject, LocationID,RequisitionType,DateRequired);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveEditActivityScheduleHead(string ReferenceNo, string SubjectOfProcurement, double EstimatedCost, int ProcurementMethod, 
        int FundingSource, int PreparedBy, int PDUHead, DateTime DateAssigned, DateTime DatePrepared, int ResponsibleOfficer, int CreatedBy, int PDUCategory, bool PlanSubmitted, string CumulativePeriod)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_SaveUpdateActivityScheduleHead", ReferenceNo, SubjectOfProcurement, EstimatedCost, ProcurementMethod, 
                FundingSource, PreparedBy, PDUHead, DateAssigned, DatePrepared, ResponsibleOfficer, CreatedBy, PDUCategory, PlanSubmitted, CumulativePeriod);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveEditActivitySchedule(string RefNo, bool Planned, DateTime BIDDocPrepDate, DateTime MethodApprovalDate, DateTime BidInvitationDate, DateTime BidSubmissionDate, 
        DateTime BidOpeningDate, DateTime BidValidityExpiryDate, DateTime BidSecurityExpiryDate, DateTime EvalReportReadyDate, DateTime CCERApprovalDate, DateTime NegotnReportReadyDate, 
        DateTime CCNRApprovalDate, DateTime BEBNoticeDate, DateTime BoardPaperSubmissionDate, DateTime BoardApprovalDate, DateTime SGPaperSubmissionDate, DateTime SGApprovalDate, DateTime FundsAvailableDate, 
        DateTime BidAcceptanceLPODate, DateTime ContractPreparationDate, DateTime ContractSigningDate, DateTime PerfSecurityExpDate, double ContractAmount, DateTime ContractCompletionDate, DateTime PaymentDocReceiptDate, 
        DateTime FinanceSubmissionDate, DateTime PaymentDate, DateTime FileClosureDate, int CreatedBy,DateTime prebidmeeting)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_SaveEditActivitySchedule", RefNo, Planned, BIDDocPrepDate, MethodApprovalDate, BidInvitationDate, BidSubmissionDate, BidOpeningDate, 
                BidValidityExpiryDate, BidSecurityExpiryDate, EvalReportReadyDate, CCERApprovalDate, NegotnReportReadyDate, CCNRApprovalDate, BEBNoticeDate, BoardPaperSubmissionDate, BoardApprovalDate, 
                SGPaperSubmissionDate, SGApprovalDate, FundsAvailableDate, BidAcceptanceLPODate, ContractPreparationDate, ContractSigningDate, PerfSecurityExpDate, ContractAmount, ContractCompletionDate,
                PaymentDocReceiptDate, FinanceSubmissionDate, PaymentDate, FileClosureDate, CreatedBy, prebidmeeting);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveEditActivitySchedule2(string ReferenceNo, int Planned,DateTime BidInvitationDate, DateTime BidSubmissionDate, DateTime BidOpeningDate, double ContractAmount, int CreatedBy, DateTime startDate, DateTime eoiStart, DateTime eoiEnd)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_SaveEditActivitySchedule2", ReferenceNo, Planned, BidOpeningDate , BidSubmissionDate, BidInvitationDate, ContractAmount, CreatedBy, startDate,eoiStart, eoiEnd);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveUpdatedScheduleStatus(string RefNo, string UserID, string Status, string Comment)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_SaveUpdateScheduleStatus", RefNo, UserID, Status, Comment);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UpdateRequisitionWithRankCategory(string PD_Code, int RankCategoryID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_UpdateRequisitionWithRankCategory", PD_Code, RankCategoryID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UpdateRequisitionWithFinanceAreaID(string PD_Code, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_UpdateRequisitionWithFinanceAreaID", PD_Code, AreaID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UpdatePlanAmounts(string PlanCode, int RequiredQty, int BalQty)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_UpdatePlanAmounts", PlanCode, RequiredQty, BalQty);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateRequisitionItemQtyAndAmounts(long RecordId, int PrevQty, int RequiredQty, int BalQty, double PreviousAmount, double RequisitionedAmount, double RemainingAmount)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_UpdateRequisitionItemQtyAndAmounts", RecordId, PrevQty, RequiredQty, BalQty, PreviousAmount, RequisitionedAmount, RemainingAmount);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateRequisitionItem(long RecordId, int PrevQty, int RequiredQty, int BalQty, double PreviousAmount, double RequisitionedAmount, double RemainingAmount, bool IsStock, string StockCode, string StockName)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_UpdateRequisitionItem", RecordId, PrevQty, RequiredQty, BalQty, PreviousAmount, RequisitionedAmount, RemainingAmount, IsStock, StockCode, StockName);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void FlagRequisitionItem(long RecordId, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_FlagRequisitionItem", RecordId, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    public string ScalaDateFormat(DateTime datetime)
    {
        return String.Format("{0}-{1}-{2} {3}:{4}:{5}", datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
    }

    #region Scala Methods
    public void SavePurchaseOrder(string AreaCode, string PurchaseOrderCode, int OrderType, string Supplier, string PC01004, string ProcSubject, string ProcType, int PC01007, int PC01008, int PC01009, string PC01010, string PC01011, int PC01012, int PC01013, int PC01014, DateTime OrderDate, DateTime DelDate, string DeliveryLocation,
     string YourRef, double PC01019, double OrderValue, string PC01021, int PC01022, string Warehouse, string PC01024, string PC01025, string PC01026, string PC01027, string PC01028, string PC01029, string PC01030, double PC01031, string PC01032, string PC01033, string PC01034, DateTime PC01035, DateTime PC01036, string PC01037,
     string PC01038, int PC01039, int PC01040, string PC01041, string PC01042, string PC01043, string PC01044, string PC01045, string AreaPurchaser, double PC01047, string PC01048, string PC01049, string PC01050, string PC01051,
     string PC01052, int PC01053, int PC01054, int PC01055, string ProjectNo, string PC01057, string PC01058, string PC01059, string PC01060, string ExternalRemark, string PC01062, int PC01063, int PC01064, int PC01065,
     string PC01066, string PC01067, string PC01068, string PC01069, string PC01070, string PC01071, string PC01072, string PC01073, string CustCode, string PC01075, string PC01076, string PC01077, string PC01078, DateTime PC01079,
     string PC01080, double PC01081, double PC01082, double PC01083, string PC01084, string PC01085, string PC01086, string PC01087, double PC01088, double PC01089, double PC01090, double PC01091, double PC01092,
     string PC01093, string PC01094, string PC01095, string PC01096, string PC01097, string PC01098, string PC01099, int PC01100, string PC01101, DateTime PC01102)
    {
        string SPC01019 = String.Format("{0:f8}", PC01019); string SOrderValue = String.Format("{0:f8}", OrderValue);
        string SPC01031 = String.Format("{0:f8}", PC01031); string SOrderDate = ScalaDateFormat(OrderDate);
        string SDelDate = ScalaDateFormat(DelDate); string SPC01035 = ScalaDateFormat(PC01035); string SPC01036 = ScalaDateFormat(PC01036);
        string SDelDate1 = ScalaDateFormat(PC01102);
        ProcSubject = ProcSubject.Replace('\"', ' ').Replace('\'', ' ');
        mycommand = scala_DB.GetStoredProcCommand("Procurement_Requisitioning_SavePurchaseOrderHead_NewFinal", AreaCode, PurchaseOrderCode, OrderType, Supplier, PC01004, ProcSubject, ProcType, PC01007, PC01008, PC01009, PC01010, PC01011, PC01012, PC01013, PC01014,
                      SOrderDate, SDelDate, DeliveryLocation, YourRef, SPC01019, SOrderValue, PC01021, PC01022, Warehouse, PC01024, PC01025, PC01026, PC01027, PC01028,
                      PC01029, PC01030, SPC01031, PC01032, PC01033, PC01034, SPC01035, SPC01036, PC01037, PC01038, PC01039, PC01040, PC01041, PC01042,
                      PC01043, PC01044, PC01045, AreaPurchaser, PC01047, PC01048, PC01049, PC01050, PC01051, PC01052, PC01053, PC01054, PC01055, ProjectNo,
                      PC01057, PC01058, PC01059, PC01060, ExternalRemark, PC01062, PC01063, PC01064, PC01065, PC01066, PC01067, PC01068, PC01069, PC01070,
                      PC01071, PC01072, PC01073, CustCode, PC01075, PC01076, PC01077, PC01078, PC01079, PC01080, PC01081, PC01082, PC01083, PC01084,
                      PC01085, PC01086, PC01087, PC01088, PC01089, PC01090, PC01091, PC01092, PC01093, PC01094, PC01095, PC01096, PC01097, PC01098, PC01099, PC01100,PC01101,SDelDate1);
        scala_DB.ExecuteNonQuery(mycommand);
    }

    public void SavePRItems(string AreaCode, string PC03001, string PC03002, string PC03003, int PC03004, string PC03005, string PC03006, string PC03007, double PC03008, int PC03009, double PC03010, double PC03011, double PC03012, string PC03013, string PC03014,
                      double PC03015, string PC03016, string PC03017, double PC03018, double PC03019, string PC03020, int PC03021, string PC03022, int PC03023, string PC03024, double PC03025, string PC03026, string PC03027, string PC03028,
                      string PC03029, string PC03030, string PC03031, double PC03032, double PC03033, double PC03034, string PC03035, string PC03036, string PC03037, double PC03038, string PC03039, string PC03040, string PC03041, double PC03042,
                      double PC03043, double PC03044, string PC03045, double PC03046, double PC03047, string PC03048, double PC03049, string PC03050, string PC03051, string PC03052, string PC03053, double PC03054, string PC03055, int PC03056,
                      string PC03057, double PC03058, double PC03059, string PC03060, int PC03061, double PC03062, string PC03063, string PC03064, string PC03065, double PC03066, string PC03067, string PC03068, string PC03069, string PC03070,
                      double PC03071, string PC03072, string PC03073, double PC03074, double PC03075, double PC03076, double PC03077, string PC03078, string PC03079, string PC03080, string PC03081, string PC03082, string PC03083, string PC03084,
                      int PC03085, string PC03086, string PC03087,int PC03088,string PC03089,string PC03090,string PC03091,string PC03092,string PC03093,string PC03094)
    {
        PC03006 = PC03006.Replace('\"', ' ').Replace('\'', ' ');
        mycommand = scala_DB.GetStoredProcCommand("Procurement_Requisitioning_SavePRItems_NewFinal", AreaCode, PC03001, PC03002, PC03003, PC03004, PC03005, PC03006, PC03007, PC03008, PC03009, PC03010, PC03011, PC03012, PC03013, PC03014,
                      PC03015, PC03016, PC03017, PC03018, PC03019, PC03020, PC03021, PC03022, PC03023, PC03024, PC03025, PC03026, PC03027, PC03028,
                      PC03029, PC03030, PC03031, PC03032, PC03033, PC03034, PC03035, PC03036, PC03037, PC03038, PC03039, PC03040, PC03041, PC03042,
                      PC03043, PC03044, PC03045, PC03046, PC03047, PC03048, PC03049, PC03050, PC03051, PC03052, PC03053, PC03054, PC03055, PC03056,
                      PC03057, PC03058, PC03059, PC03060, PC03061, PC03062, PC03063, PC03064, PC03065, PC03066, PC03067, PC03068, PC03069, PC03070,
                      PC03071, PC03072, PC03073, PC03074, PC03075, PC03076, PC03077, PC03078, PC03079, PC03080, PC03081, PC03082, PC03083, PC03084,
                      PC03085, PC03086, PC03087 , PC03088,PC03089, PC03090,PC03091, PC03092,PC03093,PC03094);
        scala_DB.ExecuteNonQuery(mycommand);
    }
    
    public DataTable Scala_GetBudgetforConsolidated(string accountingcode, string costcentre, string CompanyCode, string FinYear)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetBudgetForConsolidatedCode_NewFinal", accountingcode, costcentre, CompanyCode, FinYear);
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
    public DataTable GetStockBalanceByCode(string StockCode, string CompanyCode, string WareHouseNo)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetStockBalanceByCode_NewFinal", StockCode, CompanyCode, WareHouseNo);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetNonStockItemsByCode(string StockCode)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetNonStockItemsByCode", StockCode);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetNonStockItemsByName(string name)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetNonStockItemsByName", name);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetStockItemsByName(string value)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetStockItems_New", value);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable ViewAccountingCodes(string CostCenterCode)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_ViewAccountingCodes", CostCenterCode);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetLastPurchaseOrderCode(string CompanyCode)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetLastPurchaseOrderCode_NewFinal", CompanyCode);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable Scala_GetBudgetforNonConsolidated(string accountingcode, string costcentre, string CompanyCode, string FinYear)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetBudgetAmount_NewFinal", accountingcode, costcentre, CompanyCode, FinYear);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable Scala_GetAllBudget(string accountingcode, string costcentre, string CompanyCode, string FinYear)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetAllBudgetAmount_NewFinal", accountingcode, costcentre, CompanyCode, FinYear);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBudgetsByAccountAndCostCentre(string accountingcode, string costcentre, string CompanyCode, string FinancialYear)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetBudgetsByAccountAndCostCentreAndFYAll_New", accountingcode, costcentre, CompanyCode, FinancialYear);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable CheckIfCostCenterBudgetExists(string accountingcode, string costcentre, string CompanyCode, string FinYear)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_CheckIfBudgetsExistsForFYAll_New", accountingcode, costcentre, CompanyCode, FinYear);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion


    internal DataTable GetManagingDirector(double RequisitionAmount, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetManagingDirector", RequisitionAmount, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void UpdateRequisitionWithManagingDirectorAreaID(string PD_Code, int MDAreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_UpdateRequisitionWithRankCategory", PD_Code, MDAreaID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    internal void DeleteCCRequisition(string PD_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_FinanceAction2", PD_Code);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable getCCRequisitions(string PrNumber, DateTime Startdate, DateTime Enddate, int ProcTypeID, int costcenterID, int FinID, int areaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRequisitionToCancel", PrNumber, Startdate, Enddate, ProcTypeID, costcenterID, 0, areaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    internal DataTable GetReport(string prnumber, string budgetCode, int costcenterID, int yearID, int levelID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetReportForCostCenterExpenditure", budgetCode, costcenterID, yearID, levelID,prnumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    internal DataTable getCancelledDeletedCCRequisitions(string PrNumber, DateTime Startdate, DateTime Enddate, int ProcTypeID, int costcenterID, int FinID, int areaID, int assignedto)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_CancelledAndDeletedRequisitions", PrNumber, Startdate, Enddate, ProcTypeID, costcenterID,0 ,areaID, assignedto);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

   public DataTable GetRankApproversList()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetRankApproversList");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   public void UpdateRankApproverList(int recordID, decimal minthreshhold, decimal maxthreshhold, int newApproverID, int change)
   {
       try
       {
           mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_UpdateRankApproverList", recordID, minthreshhold, maxthreshhold, newApproverID, change);
           Proc_DB.ExecuteNonQuery(mycommand);
       }
       catch (Exception ex)
       {
           throw ex;
       }
   }

   public void SaveProjectCurrentFinYearCost(string PD_CODE, double projectCost)
   {
       try
       {
           mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_SaveProjectCurrentFinYearCost", PD_CODE , projectCost);
           Proc_DB.ExecuteNonQuery(mycommand);
       }
       catch (Exception ex)
       {
           throw ex;
       }
   }

   public void SaveProjectItems(string pdCode, string FinYear, string ItemDesc, double projectItemCost)
   {
       mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_SaveProjectItems", pdCode, FinYear, ItemDesc, projectItemCost);
       Proc_DB.ExecuteNonQuery(mycommand);
   }

   public DataTable GetProjects(string PD_Code)
   {
       try
       {
           mycommand = Proc_DB.GetStoredProcCommand("Proc_Requisition_GetProjects", PD_Code);
           returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
           return returnDatatable;
       }
       catch (Exception ex)
       {
           throw ex;
       }
   }




   public void UpdateVatColumn(string prNumber , bool p)
   {
       try
       {
           mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_UpdateVatColumn",prNumber, p);
           Proc_DB.ExecuteNonQuery(mycommand);
       }
       catch (Exception ex)
       {
           throw ex;
       }
   }

    internal void TrackReqAssignment(string assignee, string assignedto, string requisition)
    {
        mycommand = Proc_DB.GetStoredProcCommand("TrackRecordAssignment",  assignee,  assignedto,  requisition);
        Proc_DB.ExecuteNonQuery(mycommand);
    }
}
