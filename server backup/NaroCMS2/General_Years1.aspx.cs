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

public partial class General_Years : System.Web.UI.Page
{
    ProcessUsers Process = new ProcessUsers();
    ProcessPlanning PlanningProcess = new ProcessPlanning();
    DataLogin data = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadItems()
    {
        MultiView1.ActiveViewIndex = 0;
        string record = "0";
        dataTable = PlanningProcess.GetFinancialYears(record);
        GridData.DataSource = dataTable;
        GridData.DataBind();
    }
    private void ShowMessage(string Message)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        if (Message == ".")
        {
            msg.Text = ".";
        }
        else
        {
            msg.Text = "MESSAGE: " + Message;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void GridData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnEdit")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Label1.Text = Convert.ToString(GridData.DataKeys[intIndex].Value);
                loadForm();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void loadForm()
    {
        MultiView1.ActiveViewIndex = 1;
        string Record = Label1.Text.Trim();
        dataTable = PlanningProcess.GetFinancialYears(Record);
        txtStartDate.Text = dataTable.Rows[0]["Start Date"].ToString();
        txtEndDate.Text  = dataTable.Rows[0]["End Date"].ToString();
        bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["Active"].ToString());
        CheckBox2.Checked = IsActive;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string StartDate = txtStartDate.Text.Trim();
            string EndDate = txtEndDate.Text.Trim();
            string Record = Label1.Text.Trim();
            bool Active = CheckBox2.Checked;
            string returned = Process.SaveFinancialYear(Record,StartDate, EndDate, Active);
            ShowMessage(returned);
            if (returned.Contains("Successfully"))
            {
                ClearControls();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ClearControls()
    {
        txtStartDate.Text = "";
        txtEndDate.Text = "";
        CheckBox2.Checked = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            MultiView1.ActiveViewIndex = 0;
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridData.PageIndex = newPageIndex;
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
}
