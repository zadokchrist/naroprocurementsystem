using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Planning : System.Web.UI.MasterPage
{
    BusinessLogin Biz = new BusinessLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if ((Session["FullName"] == null))
            {
                Response.Redirect("Default.aspx");
            }

            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";

            lbllevel.Text = "USER ACCOUNT: " + Session["FullName"].ToString() +
                    " -- ACCESS LEVEL: " + Session["AccessLevel"].ToString() +
                    " --  COST CENTER: " + Session["CostCenterName"].ToString() +
                    " (" + Session["PFinancialYear"].ToString() + " )";
        }
        catch (NullReferenceException exe)
        {
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
    private void Logout()
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    private void SwitchBoard()
    {

        Session.Remove("StartPage");
        Session["StartPage"] = "Planning_Welcome.aspx";
        Response.Redirect("SwitchBoard.aspx");

    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Logout();
    }
}
