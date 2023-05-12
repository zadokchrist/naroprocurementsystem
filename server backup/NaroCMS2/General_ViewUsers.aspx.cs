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
            ShowMessage(ex.Message, true);
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".",false);
            LoadUsers();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
        }
    }

    private void LoadUsers()
    {
        int CostCenter = 0;
        string Search = txtSearch.Text.Trim();
        string Area = cboAreas.SelectedValue;
        dataTable = Process.GetSystemUsers(Search, Area, CostCenter);

        DataGrid1.DataSource = dataTable;
        DataGrid1.DataBind();
    }
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            string code = e.Item.Cells[0].Text;
            if (e.CommandName == "btnEdit")
            {
                Response.Redirect("./General_EditUser.aspx?transferid=" + code, true);
            }
            else if (e.CommandName.Equals("btnreset"))
            {
                ResetUserPassword(code);
            }
            else if (e.CommandName == "btnenable")
            {
                string Status = e.Item.Cells[5].Text;
                string returned = Process.ChangeUserStatus(code, Status);
                ShowMessage(returned,false);
                LoadUsers();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message,true);
        }
    }

    private void ResetUserPassword(string usercode)
    {
        try
        {
            dataTable = Process.GetUserDetails(usercode);
            string email = dataTable.Rows[0]["Email"].ToString();
            string firstname = dataTable.Rows[0]["FirstName"].ToString();
            string MiddleName = dataTable.Rows[0]["MiddleName"].ToString();
            string LastName = dataTable.Rows[0]["LastName"].ToString();
            string username = dataTable.Rows[0]["Username"].ToString();
            string name = firstname + " " + MiddleName + " " + LastName;
            string encryptpwd = bll.EncryptString(username);
            Process.resetUserPassword(username, encryptpwd);
            Process.NotifyChange(email, username, name);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
        }
    }


    private void ShowMessage(string Message, bool Color)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        if (Color)
        {
            msg.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            msg.ForeColor = System.Drawing.Color.Green;
        }
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
        dataTable = data.getAllUserAccessLevel();
        cboAreas.DataSource = dataTable;
        cboAreas.DataValueField = "LevelID";
        cboAreas.DataTextField = "LevelName";
        cboAreas.DataBind();
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
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
        }
    }

    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        DataGrid1.CurrentPageIndex = newPageIndex;
        LoadUsers();
    }
}
