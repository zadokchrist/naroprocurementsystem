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
/// Summary description for BusinessRequisition
/// </summary>
public class BusinessRequisition
{
    DataRequisition data = new DataRequisition();
    DataTable DTable = new DataTable();
    DataSet dataSet = new DataSet();
	public BusinessRequisition()
	{
		
	}
    public bool IsGroupItem(string Plancode)
    {
        DTable = data.CheckIsGroup(Plancode);
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
    public DateTime ReturnDate(string date, int type)
    {
        DateTime dates;

        if (type == 1)
        {

            if (date == "")
            {
                dates = DateTime.Parse("July 1, 2011");
            }
            else
            {
                dates = DateTime.Parse(date);
            }
        }
        else
        {
            if (date == "")
            {
                dates = DateTime.Now;
            }
            else
            {
                dates = DateTime.Parse(date);
            }
        }

        return dates; 
    }

    public bool RankItemToApprove(int UserID)
    {
        int fin = Convert.ToInt32(HttpContext.Current.Session["RFinYearCode"]);
        DTable = data.GetThreholdRankings(UserID);
        if (DTable.Rows.Count > 0)
        {
            double MinAmount = Convert.ToDouble(DTable.Rows[0]["MinThreshold"].ToString());
            double MaxAmount = Convert.ToDouble(DTable.Rows[0]["MaxThreshold"].ToString());
            DataTable dt = data.GetRankItems(MinAmount, MaxAmount,fin);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
    public bool SentToRankApproval(string PD_Code)
    {
        DTable = data.CheckRanking(PD_Code);
        if (DTable.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
   }

    public bool ScheduleExists(string PRNumber)
    {
        bool exists = false;

        DataTable dtSchedule = data.GetActivitySchedule(PRNumber);
        if (dtSchedule.Rows.Count > 0)
            exists = true;

        return exists;
    }

    public bool UserIsSupervisor(string UserID)
    {
        bool IsSupervisor = false;

        DataTable dtSupervisors = data.CheckIfSupervisor(UserID);
        if (dtSupervisors.Rows.Count > 0)
            return true;

        return IsSupervisor;
    }

    public bool CheckIfUserInConsolidationCenter(string UserID)
    {
        DataTable dtConsolidate = data.CheckIfUserInConsolidationCenter(UserID);
        if (dtConsolidate.Rows.Count > 0)
            return true;
        else
            return false;
    }

    public bool IsApproved(string RefNo)
    {
        bool approved = false;

        DataTable dtApproved = data.GetApprovedPR(RefNo);
        if (dtApproved.Rows.Count > 0)
            approved = true;

        return approved;
    }
}
