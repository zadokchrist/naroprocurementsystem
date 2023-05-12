using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
/// <summary>
/// Summary description for DataSuppliers
/// </summary>
public class DataSuppliers
{

    private Database Proc_DB;
    private Database scala_DB;
    private DbCommand mycommand;
    private DataSet returnDataset;
    private DataTable returnDatatable;

    public DataSuppliers()
    {
        try
        {
            Proc_DB = DatabaseFactory.CreateDatabase("LWPROC");
            //scala_DB = DatabaseFactory.CreateDatabase(ReturnScalaConsring());
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
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_CheckSupplierUserName", UserName);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveBidderApplication(string CompanyName, string PhysicalAddress, string PhoneNumbers,
      string EmailAddress, string password, bool IsActive,string designation, string PPACode)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveBidderApplication", CompanyName,PhysicalAddress, PhoneNumbers, EmailAddress,0,designation,PPACode,password );
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetSupplierAccessibility(string UserName, string Password)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetSupplierAccess", UserName, Password);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
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
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GeneralChangeSupplierPassword", UserID, NewPassword);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}