using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Services;
using System.Web.Services.Protocols;
using AjaxControlToolkit;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CarData
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class CascadingddlService : System.Web.Services.WebService
{
    DataPlanning dacPlanning = new DataPlanning();
    DataRequisition data = new DataRequisition();
    DataBidding dataBidding = new DataBidding();

    public CascadingddlService()
    {
 
    }

    [WebMethod]
    public string[] GetUsersByNames(string prefixText)
    {
        DataTable dt = dacPlanning.GetUsersByNames(prefixText);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Name"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetProfilesByNames(string prefixText)
    {
        DataTable dt = dataBidding.GetProfilesByNames(prefixText);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Name"].ToString(), i);
            i++;
        }
        return items;
    }
    //[WebMethod]
    //public string[] GetUsersByNames(string prefixText, string contextKey)
    //{
    //    DataTable dt = dacPlanning.GetUsersByNames(prefixText, contextKey);

    //    string[] items = new string[dt.Rows.Count];
    //    int i = 0;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        items.SetValue(dr["FullName"].ToString(), i);
    //        i++;
    //    }
    //    return items;
    //}
    [WebMethod]
    public string[] GetBiddersByNames(string prefixText)
    {
        DataTable dt = dacPlanning.GetBiddersByNames(prefixText);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["CompanyName"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetBiddersByNamesWithContext(string prefixText, int count, string contextKey)
    {
        int cont = Int32.Parse(contextKey);
        DataTable dt = dacPlanning.GetBiddersByNamesWithContextKey(prefixText, cont);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["CompanyName"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetAccountingCodes(string prefixText)
    {
        DataTable dt = dacPlanning.GetAccountingCodes4Stock(prefixText);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["accountingCodes"].ToString(), i);
            i++;
        }
        return items;
    }

    #region .Scala Items (Stock/Non Stock)

    [WebMethod]
    public string[] GetAccountingCodes4Stock(string prefixText)
    {
        DataTable dt = dacPlanning.GetAccountingCodes4Stock(prefixText);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["accountingCodes"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetNonStockItemsByCode(string prefixText)
    {
        int count = 10;

        DataTable dt = data.GetNonStockItemsByCode(prefixText);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["item"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetStockItemsByName(string prefixText)
    {
        int count = 10;

        DataTable dt = data.GetStockItemsByName(prefixText);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Item"].ToString(), i);
            i++;
        }
        return items;
    }
    [WebMethod]
    public string[] GetStockItemsByCode(string prefixText, int count, string contextKey)
    {
        //count = 10;
        DataTable dt = data.GetStockNameByCode(prefixText, contextKey);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["STOCKNAME"].ToString(), i);
            i++;
        }
        return items;
    }

    //[WebMethod]
    //public string[] GetUsersByNames(string prefixText)
    //{
    //    DataTable dt = data.GetUsersByNames(prefixText);

    //    string[] items = new string[dt.Rows.Count];
    //    int i = 0;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        items.SetValue(dr["Name"].ToString(), i);
    //        i++;
    //    }
    //    return items;
    //}

    [WebMethod]
    public string[] GetCostCenterItems(string prefixText) //, int count, string contextKey)
    {
        int AreaID = 0;
        //if (Session["IsAreaProcess"].ToString() == "1")
        //    AreaID = Convert.ToInt32(Session["AreaCode"].ToString());
        DataTable dt = data.GetCostCenterItems(prefixText, AreaID);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["item"].ToString(), i);
            i++;
        }
        return items;
    }

    [WebMethod]
    public string[] GetCostCenters(string prefixText)
    {
        DataTable dt = data.GetCostCenterDetails(prefixText);

        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["CostCenterName"].ToString(), i);
            i++;
        }
        return items;
    }

    #endregion
}