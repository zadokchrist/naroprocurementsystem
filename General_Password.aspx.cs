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

public partial class GeneralPassword : System.Web.UI.Page
{
    ProcessUsers Process = new ProcessUsers();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                //LoadUsers();
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

    private void ClearControls()
    {
        txtConfirm.Text = "";
        txtNewPassword.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string SelectedUser = Session["UserID"].ToString();
            string OldPassword = txtOldPassword.Text.Trim();
            string NewPassword = txtNewPassword.Text.Trim();
            string Confirm = txtConfirm.Text.Trim();
            string returned = Process.ChangeUserPassword(SelectedUser, OldPassword, NewPassword, Confirm);
            if (returned.Contains("Successfully"))
            {
                ClearControls();
            }
            ShowMessage(returned);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

}
