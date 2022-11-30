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

public partial class Requisition_Welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FullName"].ToString() != null)
        {
            string FullName = Session["FullName"].ToString();
            string CostCenter = Session["CostCenterName"].ToString();
            string Role = Session["AccessLevel"].ToString();
            lblWelcome.Text = "Welcome " + FullName;

            lblCostCenterInfo.Text = "You are currently logged in as " + Role + Environment.NewLine;
            lblUsage.Text = "Use the Links above to access your system functionalities";
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}
