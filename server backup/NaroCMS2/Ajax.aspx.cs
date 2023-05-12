using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ajax : System.Web.UI.Page
{
   // private DataStore dh = new DataStore();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["cmd"] != null)
        {
            string cmd = Request.Form["cmd"].ToString().Trim();
            if(cmd.Equals("getCollection"))
            {
                DateTime from = DateTime.Now.AddDays(-1);
           //     DateTime to = LordMayer.getDate("",1);
           //     DataTable dt = dh.EW_getCollectionReport("0",
           //from, to, "0");
               // Response.Write(JsonConvert.SerializeObject(dt));
            }
           
        }

        else
        {

        }
    }
}