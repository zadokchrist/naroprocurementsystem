﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenericMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if ((Session["FullName"] == null))
            {
                Response.Redirect("Default.aspx");
            }
            Label msg = (Label)this.FindControl("lbllevel");
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";
            msg.Text = "USER ACCOUNT: " + Session["FullName"].ToString() +" -- ACCESS LEVEL: " + Session["AccessLevel"].ToString() +" --  COST CENTER: " + Session["CostCenterName"].ToString() +" (" + Session["PFinancialYear"].ToString() + " )";
        }
        catch (NullReferenceException ex)
        {
            Response.Redirect("Default.aspx", false);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
        
    }
}
