using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("Default.aspx", false);
        }
        catch (NullReferenceException ex)
        {
            Response.Redirect("Default.aspx", false);
        }catch(Exception ex)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}