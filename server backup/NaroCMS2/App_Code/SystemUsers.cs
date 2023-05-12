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


public class SystemUsers
{
    private Database Proc_DB;
    private Database scala_DB;
    private DbCommand mycommand;
    private DataSet returnDataset;
    private DataTable returnDatatable;

    public string ReturnConsring()
    {
        string constring = "JABMACHINE";
        //string constring = "APPSERVERMACHINE";
        return constring;
    }

    public string ReturnScalaConsring()
    {
        //string constring = "Scala_ANDREWMACHINE";
        string constring = "SCALAMACHINE";
        return constring;
    }

	public SystemUsers()
	{
        try
        {
            Proc_DB = DatabaseFactory.CreateDatabase(ReturnConsring());
            scala_DB = DatabaseFactory.CreateDatabase(ReturnScalaConsring());
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
}
