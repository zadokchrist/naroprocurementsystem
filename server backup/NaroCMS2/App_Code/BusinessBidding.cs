using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class BusinessBidding
{
    DataBidding data = new DataBidding();
    DataTable DTable = new DataTable();

	public BusinessBidding()
	{
	}
    public bool IsContractCommitteeUser(string UserCode)
    {
        bool IsCCUser = false;
        long UserID = Convert.ToInt64(UserCode);
        DataTable dtCCUsers = data.CheckIfCCUser(UserID);
        if (dtCCUsers.Rows.Count > 0)
            return true;

        return IsCCUser;
    }
    public string GetUserContractsCommittee(string UserCode)
    {
        string CCID = "0";
        long UserID = Convert.ToInt64(UserCode);

        DTable = data.CheckIfCCUser(UserID);
        if (DTable.Rows.Count > 0)
            CCID = DTable.Rows[0]["CCID"].ToString();
        
        return CCID;
    }
    public bool IsContractsCommitteeChairman(string UserCode)
    {
        bool IsChairman = false;
        
        long UserID = Convert.ToInt64(UserCode);

        DTable = data.CheckIfCCUser(UserID);
        if (DTable.Rows.Count > 0)
            if (DTable.Rows[0]["PositionID"].ToString() == "1")
                IsChairman = true;

        return IsChairman;
    }
    public bool IsProcurementApprovedByAreaCC(string ReferenceNo)
    {
        DTable = data.ProcurementApprovedByAreaCC(ReferenceNo);
        if (DTable.Rows.Count > 0)
            return true;
        else
            return false;
    }
    public bool IsProcurementLotted(string ReferenceNo)
    {
        DTable = data.GetProcurementLotts(ReferenceNo);
        if (DTable.Rows.Count > 0)
            return true;
        else
            return false;
    }
    public bool IsProcurementFromArea(string ReferenceNo)
    {
        DTable = data.IsProcurementFromArea(ReferenceNo);
        if (DTable.Rows.Count > 0)
            return true;
        else
            return false;
    }
}
