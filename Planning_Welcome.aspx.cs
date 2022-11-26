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

public partial class Planning_Welcome : System.Web.UI.Page
{
    ProcessPlanning Process = new ProcessPlanning();

    protected void Page_Load(object sender, EventArgs e)
    {
        string FullName = Session["FullName"].ToString();
        string CostCenter = Session["CostCenterName"].ToString();
        string Role = Session["AccessLevel"].ToString();
        lblWelcome.Text = "Welcome " + FullName;
        
        lblCostCenterInfo.Text = "You are currently logged in as " + Role + Environment.NewLine;
        lblCostCenterInfo.Text += Environment.NewLine + " attached to Cost Center: " + CostCenter;
        
        lblUsage.Text = "Use the Links above to access your system functionalities";

        int UserID = Convert.ToInt32(Session["UserID"].ToString());
        int CostCenterID = Convert.ToInt32(Session["CostCenterID"].ToString());
        int FinYearID = Convert.ToInt32(Session["PFinYearCode"].ToString());
    
    }
}
