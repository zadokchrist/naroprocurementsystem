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

public partial class SwitchBoard : System.Web.UI.Page
{
    DataLogin dac = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    ProcessUsers Usersdll = new ProcessUsers();
    DataTable dataTable = new DataTable();
    DataTable dTable = new DataTable();
    DataSet dataSet = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadAreas();
                LoadCostCenters();
                string CostCenterID = Session["CostCenterID"].ToString();
                if (!bll.IsUserInMultiCostCenter(CostCenterID))
                {
                    cboAreas.Enabled = false;
                    cboCostCenters.Enabled = false;
                }
                else
                {
                    cboAreas.Enabled = true;
                    cboCostCenters.Enabled = true;
                }
                cboCostCenters.SelectedValue = CostCenterID;
                LoadFinancialYears();
                LoadModules();
                ShowMessage(".");
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadAreas()
    {
        dataTable = dac.GetAreas();
        cboAreas.DataSource = dataTable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();
        string AreaID = Session["AreaCode"].ToString();
        cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(AreaID));
    }

    private void LoadCostCenters()
    {
        int AreaID = Convert.ToInt32(cboAreas.SelectedValue.ToString());
        dataTable = dac.GetCostCenters(AreaID);
        cboCostCenters.DataSource = dataTable;
        cboCostCenters.DataValueField = "CostCenterID";
        cboCostCenters.DataTextField = "CostCenterName";
        cboCostCenters.DataBind();
    }

    private void LoadModules()
    {
        dataTable = dac.GetModules();
        cboModule.DataSource = dataTable;
        cboModule.DataValueField = "ModuleID";
        cboModule.DataTextField = "ModuleName";
        cboModule.DataBind();
    }

    private void LoadFinancialYears()
    {
        dataTable = dac.GetFinancialYears();
        cboFinancialYear.DataSource = dataTable;
        cboFinancialYear.DataValueField = "FYCode";
        cboFinancialYear.DataTextField = "FYear";
        cboFinancialYear.DataBind();

        //string ActiveFinYearCode = Session["FinYearCode"].ToString();
        //cboFinancialYear.SelectedIndex = cboFinancialYear.Items.IndexOf(cboFinancialYear.Items.FindByValue(ActiveFinYearCode));
    }
    private void ShowMessage(string Message)
    {
        if (Message == ".")
        {
            lblmsg.Text = ".";
        }
        else
        {
            lblmsg.Text = "MESSAGE: " + Message;
        }
    }
    protected void Btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            AccessAgain();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboModules_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("-- Select Module --", "0"));
    }
    private void Logout()
    {
        Session["Accesslevel"] = "";
        Session["UserName"] = "";
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    private void AccessAgain()
    {
        if (cboAreas.SelectedValue == "0")
            ShowMessage("Please Select Area");
        if (cboCostCenters.SelectedValue == "0")
            ShowMessage("Please Select Cost Center");
        else if (cboModule.SelectedValue == "0")
            ShowMessage("Please Select Module");
        else if (cboFinancialYear.SelectedValue == "0")
            ShowMessage("Please Select Financial Year");
        else
        {
            int Userid = Convert.ToInt32(Session["UserID"]);
            string NewCostCenterID = cboCostCenters.SelectedValue.ToString();
            string NewCostCenterName = cboCostCenters.SelectedItem.ToString();
            Session.Remove("CostCenterID");
            Session.Remove("CostCenterName");
            if (cboModule.SelectedItem.Text == "PLANNING")
            {
                Session.Remove("PFinancialYear");
                Session.Remove("PFinYearCode");
                Session["PFinancialYear"] = cboFinancialYear.SelectedItem.ToString();
                Session["PFinYearCode"] = cboFinancialYear.SelectedValue.ToString();
            }
            else if (cboModule.SelectedItem.Text == "REQUISITION")
            {
                Session.Remove("RFinancialYear");
                Session.Remove("RFinYearCode");
                Session["RFinancialYear"] = cboFinancialYear.SelectedItem.ToString();
                Session["RFinYearCode"] = cboFinancialYear.SelectedValue.ToString();
            }
            else if (cboModule.SelectedItem.Text == "BIDDING")
            {
                Session.Remove("BFinancialYear");
                Session.Remove("BFinYearCode");
                Session["BFinancialYear"] = cboFinancialYear.SelectedItem.ToString();
                Session["BFinYearCode"] = cboFinancialYear.SelectedValue.ToString();
            }
            Session["CostCenterID"] = NewCostCenterID;
            Session["CostCenterName"] = NewCostCenterName;

            dTable = Usersdll.GetUserWelcome(Userid);
            if (dTable.Rows.Count > 0)
            {
                string Page = dTable.Rows[0]["PageFath"].ToString();
                Response.Redirect(Page);
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        dTable = Usersdll.GetUserWelcome(Convert.ToInt32(Session["UserID"].ToString()));
        if (dTable.Rows.Count > 0)
        {
            string Page = dTable.Rows[0]["PageFath"].ToString();
            Response.Redirect(Page);
        }
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCostCenters();
    }
    protected void cboCostCenters_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("-- Select Cost Center --", "0"));
    }
    protected void cboModule_DataBound(object sender, EventArgs e)
    {
        cboModule.Items.Insert(0, new ListItem(" -- Select Module --", "0"));
    }
    protected void cboFinancialYear_DataBound(object sender, EventArgs e)
    {
        cboFinancialYear.Items.Insert(0, new ListItem("-- Select Fin. Year --", "0"));
    }
}
