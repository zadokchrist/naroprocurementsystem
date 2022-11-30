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

public class DataLogin
{
    private Database Proc_DB;
    private Database scala_DB;
    private DbCommand mycommand;
    private DataSet returnDataset;
    private DataTable returnDatatable;

    public string ReturnConsring()
    {
        string constring = "LWPROC";
        return constring;
    }
    public string ReturnScalaConsring()
    {
        string constring = "SCALAMACHINE";
        return constring;
    }
	public DataLogin()
	{
        try
        {
            Proc_DB = DatabaseFactory.CreateDatabase(ReturnConsring());
            //scala_DB = DatabaseFactory.CreateDatabase(ReturnScalaConsring());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public Database ShareProc_Con()
    {
        return Proc_DB;
    }
    public Database ShareScala_Con()
    {
        return scala_DB;
    }

    #region General Data Methods
    public DataTable GetUserAccessibility(string UserName, string Password)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetUserAccess", UserName, Password);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable CheckIfModActive(int ModID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_IsModuleActive", ModID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void NextContractStatus(string uploadedContract,string Workflowid,string Remark,string UserID,string statusID)
    {
        mycommand = Proc_DB.GetStoredProcCommand("Proc_UploadedContract_LogTransaction", uploadedContract, Workflowid, Remark, UserID, statusID);
        Proc_DB.ExecuteNonQuery(mycommand);
    }

    public DataTable GetStatusesByWorkflowid(string workflowid)
    {
        mycommand = Proc_DB.GetStoredProcCommand("GetStatusesByWorkflowid", workflowid);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    public DataTable InsertUploadedContract(string contract_id, string subject)
    {
        mycommand = Proc_DB.GetStoredProcCommand("InsertUploadedContract", contract_id, subject);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    public DataTable GetActiveFinancialYear()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetActiveFinancialYear");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetFinancialYears()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetFinancialYears");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void UpdateAccessLevelDetails(string levelid, string levelName, string description, bool active)
    {
        mycommand = Proc_DB.GetStoredProcCommand("UpdateAccessLevelDetails", levelid, levelName, description, active);
        Proc_DB.ExecuteNonQuery(mycommand);
    }

    internal void SaveAccessLevel(string levelName, string description, bool active)
    {
        mycommand = Proc_DB.GetStoredProcCommand("SaveAccessLevel", levelName, description, active);
        Proc_DB.ExecuteNonQuery(mycommand);
    }

    public DataTable GetSystemModules(string AccessLevel)
    {
        try
        {
            if (AccessLevel == "Admin" || AccessLevel == "Proc. Officer - Admin")
            {
                mycommand = Proc_DB.GetStoredProcCommand("Proc_GetSystemModulesForAdmin");
                returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            }
            else
            {
                mycommand = Proc_DB.GetStoredProcCommand("Proc_GetSystemModules");
                returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            }
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetStartPage(int AccessLevel, int ModuleID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetDefaultPage", AccessLevel, ModuleID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void UpdateWorkFlowDetails(string name, bool active, string flowid)
    {
        mycommand = Proc_DB.GetStoredProcCommand("UpdateWorkflow", name, active, flowid);
        Proc_DB.ExecuteNonQuery(mycommand);
    }

    public object GetMileStonesByContractId(string contractid)
    {
        mycommand = Proc_DB.GetStoredProcCommand("GetMileStonesByContractId", contractid);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    public DataTable GetLastAccessedModule(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetLastAccessedModule", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMultiCostCenters(int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetMultiCostCenters", CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetUserModules(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetUserModules", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetModulesByUserID(int UserID)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetUserModulesByID", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAccessLevelsByID(string levelid)
    {
        mycommand = Proc_DB.GetStoredProcCommand("GetAccessLevelsByID", levelid);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    public DataTable GetOtherModules(int UserID, int LevelID)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetOtherModules", UserID, LevelID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetUserWelcome(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetUserDefaultPage", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetNumberOfModules(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetModulesAssigned", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetContractStatus(string pDCode)
    {
        mycommand = Proc_DB.GetStoredProcCommand("GetUploadedContractbyId", pDCode);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    public DataTable GetModules()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetModules");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable NextStatus(string statusid, string workflowid,bool approved)
    {
        mycommand = Proc_DB.GetStoredProcCommand("NextStatus", statusid, workflowid,approved);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    internal DataTable FindEmail(string sEmail)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_FindEmail", sEmail);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void ConfigureContract(string contractname, string contracttype, string workflow, bool active)
    {
        mycommand = Proc_DB.GetStoredProcCommand("ConfigureContract", contractname, contracttype, workflow, active);
        Proc_DB.ExecuteNonQuery(mycommand);
    }

    public DataTable GetModulesAllocation(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralGetUserModules", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSearchUsers(string names)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralGetSearchUsers", names);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable CheckUsername(string UserName)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_CheckUserName", UserName);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRandomModules(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetRandomModule", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetDelegation(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetDelegatingUser", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetDelegatedLevels(int DelegatorID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetDelegatedLevel", DelegatorID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveWorkflowItems(string workflowid, string Status, string FromRoleid,string ToRoleid, bool CanDownload,bool CanApprove,string description)
    {
        mycommand = Proc_DB.GetStoredProcCommand("Saveworkflowsteps", workflowid, Status, FromRoleid, ToRoleid, CanDownload, CanApprove, description);
        Proc_DB.ExecuteNonQuery(mycommand);
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
    public DataTable GetAllAreas()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralGetAllAreas");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllWorkFlows(string workflowid)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetAllWorkFlows", workflowid);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllConfiguredContracts(string contractid)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetConfiguredContracts", contractid);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable CheckIsUserActive(int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralIsUserEnabled", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSystemUsers(string names, int AreaID, int CostCenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetSystemUsers", names, AreaID, CostCenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void updateBidderPassword(int bidder, string code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_updateBidderPassword", bidder, code);
            Proc_DB.ExecuteNonQuery(mycommand);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    internal DataTable getSupplierDetailsByEmail(string text)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_getSupplierDetailsByEmail", text);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable getSupplierByEmail(string text)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_getSupplierByEmail", text);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    public DataTable GetCostCenters(int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralGetCostCenters", AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetMilestonById(string recordID)
    {
        mycommand = Proc_DB.GetStoredProcCommand("GetMilestonById", recordID);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    public DataTable GetAccessLevels()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetAccessLevels");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void SaveWorkFlowDetails(string workFlowname, bool status)
    {
        mycommand = Proc_DB.GetStoredProcCommand("SaveWorkflow", workFlowname, status);
        Proc_DB.ExecuteNonQuery(mycommand);
    }

    public DataTable GetUserDetails(string UserCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetUserDetails", UserCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCostCenterDetails(int CenterID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralGetCenterDetails", CenterID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetAreaDetails(int areaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetAreaData", areaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetAreasByCategory(int CategoryID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetAreasByCategory", CategoryID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAreaCategories()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetAreaCategories");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable CheckCostCenter(string CostCenterCode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_CheckCostCenter", CostCenterCode);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetConfiguration(int Config_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetConfig", Config_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable SaveMileStone(string contractid, string milstonename, string daterequired)
    {
        mycommand = Proc_DB.GetStoredProcCommand("SaveMileStone", contractid, milstonename, daterequired);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    public DataTable UpdateMileStone(string milestoneid, string milstonename, string daterequired,string contractid)
    {
        mycommand = Proc_DB.GetStoredProcCommand("UpdateMileStone", milestoneid, milstonename, daterequired, contractid);
        returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
        return returnDatatable;
    }

    #endregion
    #region DataInsertions
    public string SaveUserDetails(string FirstName, string MiddleName, string LastName,
        string UserName, string Password, string Designation, string Email, string PhoneNumber,
        int CostCenterID, bool IsPDUMember, bool IsPDUSupervisor, int AccessLevelID, int CapturedBy)
    {
         string SavedUserID = "";
         try
         {
             mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralSaveUser", FirstName, MiddleName, LastName,
                 UserName, Password, PhoneNumber, Email, Designation, CostCenterID, IsPDUMember, IsPDUSupervisor, AccessLevelID, CapturedBy);
            System.Data.DataSet ds = Proc_DB.ExecuteDataSet(mycommand);
             int recordCount = ds.Tables[0].Rows.Count;
             if (recordCount != 0)
             {
                 DataRow dr = ds.Tables[0].Rows[0];
                 SavedUserID = dr[0].ToString();
             }
         }
         catch (Exception ex)
         {
             throw ex;
         }
         return SavedUserID;
    }

    internal DataTable getUserAccessLevel(string sendTo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetUserAccessLvl", sendTo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable getAllUserAccessLevel()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetAllAccessLevels");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateUserDetails(int UserID,string FirstName, string MiddleName, string LastName,
        string UserName, string Password, string Designation, string Email, string PhoneNumber,
        int CostCenterID, bool IsPDUMember, bool IsPDUSupervisor, bool IsInventoryStaff, int AccessLevelID, int reset, int removed)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_UpdateUser",UserID, FirstName, MiddleName, LastName,
            UserName, Password, PhoneNumber, Email, Designation, CostCenterID, IsPDUMember, IsPDUSupervisor, IsInventoryStaff, AccessLevelID, reset, removed);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveUserModule(int UserID, int ModuleID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_SaveUserModules", UserID, ModuleID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
         {
             throw ex;
         }
    }

    public void resetUserPassword(string username, string password)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_resetUserPassword", username,password);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void ChangeUserStatus(string Usercode, bool Status)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralChangeUserStatus", Usercode, Status);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ChangeLevelStatus(string LevelId, bool Status)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralChangeLevelStatus", LevelId, Status);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveUserSigniture(int UserID, object SignImage)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_SaveUserSigniture", UserID, SignImage);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
         {
             throw ex;
         }
    }
    public void UpdateUsersLogins(int UserID, int ModuleLoggedIn)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralUpdateUserLogins", UserID, ModuleLoggedIn);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void SaveCostCenterDetails(int CostCenterID, string CostCenterCode, string CostCenterName, int AreaID, string Initial, bool IsMultiCostCenter, bool Active, int CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_SaveCostCenter", CostCenterID, CostCenterCode,CostCenterName, AreaID,Initial, IsMultiCostCenter, Active, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    public void SaveAreaDetails(int areaID, string areaName, int category, int status)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_SaveArea", areaID, areaName, category, status);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    public void SaveLocationDetails(int areaID, string areaName)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_SaveLocation", areaID, areaName);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void SaveWarehoseDetails(int warehouseid, string areaName, int areaid)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_SaveWareHouse", warehouseid, areaName, areaid);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void UpdatePassword(int UserID, string NewPassword)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralChangePassword", UserID, NewPassword);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void RemoveModule(int UserID, int ModuleID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_RemoveModule", UserID, ModuleID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveFinancialYear(int RecordID, DateTime Startdate, DateTime Enddate, bool Active)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_SaveYear", RecordID, Startdate, Enddate, Active);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region Scala Methods
    public DataTable GetCostCentersfromScala(int CategoryID, string Code)
    {
        try
        {
            mycommand = scala_DB.GetStoredProcCommand("Procurement_GetCostCentersByCategory", CategoryID, Code);
            returnDatatable = scala_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion


    public DataTable GetProcurementPlanType()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetProcurementPlanForms");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllUsers()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetAllUsers");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void insertMailException(string to, string from, string displayname, string subject ,string body, string exception, int status)
    {


        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralInsertMailException", to, from, displayname, subject, body, exception, status);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public void UpdateProcMethod(string PrNumber, string method)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_UpdateProcMethod", PrNumber, Convert.ToInt32(method));
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
}
