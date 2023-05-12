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

public partial class General_ViewUsers : System.Web.UI.Page
{
    ProcessUsers Process = new ProcessUsers();
    DataLogin data = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
               LoadAreas();
               LoadUsers();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            LoadUsers();
         }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadUsers()
    {
        int CostCenter = 0;
        string Search = txtSearch.Text.Trim();
        string Area = cboAreas.SelectedValue;
        if (cboCostCenter.Text == "")
        {
            CostCenter = 0;
        }
        else
        {
            CostCenter = Convert.ToInt32(cboCostCenter.SelectedValue);
        }
        dataTable = Process.GetSystemUsers(Search, Area, CostCenter);
        GridData.DataSource = dataTable;
        GridData.DataBind();
    }
    protected void GridData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnenable")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string Code = Convert.ToString(GridData.DataKeys[intIndex].Value);
                string strCmdArg = Convert.ToString(e.CommandArgument);
                string Status = GridData.Rows[Convert.ToInt32(strCmdArg)].Cells[8].Text;
                string returned = Process.ChangeUserStatus(Code, Status);
                ShowMessage(returned);
                LoadUsers();
            }
            else if (e.CommandName == "btnEdit")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string Code = Convert.ToString(GridData.DataKeys[intIndex].Value);
                Response.Redirect("./General_EditUser.aspx?transferid=" + Code, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }

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
    private void LoadAreas()
    {
        dataTable = data.GetAreas();
        cboAreas.DataSource = dataTable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();
    }
    private void LoadCostCenters(int AreaID)
    {
        dataTable = data.GetCostCenters(AreaID);
        cboCostCenter.DataSource = dataTable;
        cboCostCenter.DataValueField = "CostCenterID";
        cboCostCenter.DataTextField = "CostCenterName";
        cboCostCenter.DataBind();
    }
    protected void cboAreas_DataBound(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem("- - Select Area - -", "0"));
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int AreaID = Convert.ToInt32(cboAreas.SelectedValue);
            LoadCostCenters(AreaID);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboCostCenter_DataBound(object sender, EventArgs e)
    {
        cboCostCenter.Items.Insert(0, new ListItem("- - Select Cost Center - -", "0"));
    }
    protected void GridData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridData.PageIndex = newPageIndex;
            LoadUsers();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
}
