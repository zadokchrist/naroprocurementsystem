using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataLogin dac = new DataLogin();
    ProcessUsers Usersdll = new ProcessUsers();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    DataTable dTable = new DataTable();
    DataTable dtLevels = new DataTable();
    DataSet dataSet = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                PageLoadMethod();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void PageLoadMethod()
    {
        lblmsg.Text = ".";
    }
    private void ShowMessage(string Message)
    {
        lblmsg.Text = "MESSAGE: " + Message + "..";
    }
    protected void Btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            Login();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SavePassword();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void SavePassword()
    {
        if (txtNewPassword.Text.Trim() == Label2.Text.Trim())
        {
            ShowMessage("You can not user the same Username as the Password. Please re-enter the Password.");

        }
        else
        {
            string UserCode = Label1.Text.Trim();
            string OldPassword = txtOldPassword.Text.Trim();
            string Password = txtNewPassword.Text.Trim();
            string Confirm = txtConfirmPassword.Text.Trim();
            string returned = Usersdll.ChangeUserPassword(UserCode, OldPassword, Password, Confirm);
            ShowMessage(returned);
            if (returned.Contains("Successfully"))
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    private void Login()
    {
        string UserName = txtUsername.Text.Trim();
        Session["UserName"] = UserName;
        string Passwd = txtpassword.Text.Trim();
        if (UserName == "")
        {
            ShowMessage("Please Enter your System Username");
            txtUsername.Focus();
        }
        else if (Passwd == "")
        {
            ShowMessage("Please Enter Your System Password");
            txtpassword.Focus();
        }
        else if (!bll.IsUserAccessAllowed(UserName, Passwd))
        {
            ShowMessage("System Access Failed");
        }
        else
        {
            Access(UserName, Passwd);
        }
    }
    private void Access(string UserName, string Password)
    {
        string EcryptedPassword = bll.EncryptString(Password);
        dataTable = dac.GetUserAccessibility(UserName, EcryptedPassword);
        int UserID = Convert.ToInt32(dataTable.Rows[0]["UserID"].ToString());
        if (txtUsername.Text.Trim() == txtpassword.Text.Trim())
        {
            RequestToChangePassword();
            Label1.Text = UserID.ToString();
            Label2.Text = UserName;
        }
        else
        {
            Redirection(UserID, UserName, Password);
        }
    }
    private void RequestToChangePassword()
    {
        MultiView1.ActiveViewIndex = 1;
    }
    private void Redirection(int Userid, string UserName, string Password)
    {
        if (!bll.IsUserDelegated(Userid))
        {
            dTable = Usersdll.GetUserWelcome(Userid);
            if (dTable.Rows.Count > 0)
            {
                string Page = dTable.Rows[0]["PageFath"].ToString();
                Usersdll.UpdateUserLogins(Userid, 1);
                AssignSessions(UserName, Password);
                Response.Redirect(Page);
            }
            else
            {
                ShowMessage("Sorry, there was no Genesis for the Module Selected, Please Contact System Admin");
            }
        }
        else
        {
            int DelegetedUserID = Userid;
            dTable = dac.GetDelegation(DelegetedUserID);
            int DelegatorID = Convert.ToInt32(dTable.Rows[0]["DelegatorID"].ToString());
            dTable = Usersdll.GetUserWelcome(DelegatorID);
            if (dTable.Rows.Count > 0)
            {
                string Page = dTable.Rows[0]["PageFath"].ToString();
                Usersdll.UpdateUserLogins(Userid, 1);
                AssignDelegatedSessions(UserName, Password, DelegatorID);
                Response.Redirect(Page);
            }
            else
            {
                ShowMessage("Sorry, there was no Genesis for the Module Selected, Please Contact System Admin");
            }
        }
    }
    private void AssignSessions(string UserName, string Password)
    {
        string EcryptedPassword = bll.EncryptString(Password);
        dataTable = dac.GetUserAccessibility(UserName, EcryptedPassword);
        Session["UserID"] = dataTable.Rows[0]["UserID"].ToString();
        Session["UserCode"] = dataTable.Rows[0]["UserCode"].ToString();
        Session["UserName"] = UserName;
        Session["FullName"] = dataTable.Rows[0]["FullName"].ToString();
        Session["ScalaCode"] = dataTable.Rows[0]["ScalaCode"].ToString();
        Session["CostCenterID"] = dataTable.Rows[0]["CostCenterID"].ToString();
        Session["CostCenterCode"] = dataTable.Rows[0]["CostCenterCode"].ToString();
        Session["CostCenterName"] = dataTable.Rows[0]["CostCenterName"].ToString();
        Session["AccessLevel"] = dataTable.Rows[0]["AccessLevel"].ToString();
        Session["AccessLevelID"] = dataTable.Rows[0]["AccessLevelID"].ToString();
        Session["AreaCode"] = dataTable.Rows[0]["AreaID"].ToString();
        Session["IsAreaProcess"] = dataTable.Rows[0]["IsAreaProcess"].ToString();

        DataTable dtYear = dac.GetActiveFinancialYear();
        foreach (DataRow dr in dtYear.Rows)
        {
            if (dr["ModuleName"].ToString() == "PLANNING")
            {
                Session["PFinancialYear"] = dr["FYear"].ToString();
                Session["PFinYearCode"] = dr["FYCode"].ToString();
            }
            else if (dr["ModuleName"].ToString() == "REQUISITION")
            {
                Session["RFinancialYear"] = dr["FYear"].ToString();
                Session["RFinYearCode"] = dr["FYCode"].ToString();
            }
            else if (dr["ModuleName"].ToString() == "BIDDING")
            {
                Session["BFinancialYear"] = dr["FYear"].ToString();
                Session["BFinYearCode"] = dr["FYCode"].ToString();
            }
        }
        int UserCode = Convert.ToInt32(dataTable.Rows[0]["UserID"]);
        Session["Pages"] = dac.GetUserModules(UserCode);
    }
    private void AssignDelegatedSessions(string UserName, string Password, int DelegatorID)
    {
        string EcryptedPassword = bll.EncryptString(Password);
        DataTable dataTable2 = dac.GetUserAccessibility(UserName, EcryptedPassword);
        Session["UserID"] = dataTable2.Rows[0]["UserID"].ToString();
        Session["UserCode"] = dataTable2.Rows[0]["UserCode"].ToString();
        Session["FullName"] = dataTable2.Rows[0]["FullName"].ToString();
        Session["ScalaCode"] = dataTable2.Rows[0]["ScalaCode"].ToString();
        Session["CostCenterID"] = dataTable2.Rows[0]["CostCenterID"].ToString();
        Session["CostCenterCode"] = dataTable2.Rows[0]["CostCenterCode"].ToString();
        Session["CostCenterName"] = dataTable2.Rows[0]["CostCenterName"].ToString();
        Session["AreaCode"] = dataTable2.Rows[0]["AreaID"].ToString();
        Session["IsAreaProcess"] = dataTable.Rows[0]["IsAreaProcess"].ToString();

        DataTable dtDelegator = dac.GetDelegatedLevels(DelegatorID);
        Session["DelegatorID"] = DelegatorID.ToString();
        Session["AccessLevel"] = dtDelegator.Rows[0]["LevelName"].ToString();
        Session["AccessLevelID"] = dtDelegator.Rows[0]["AccessLevelID"].ToString();
        DataTable dtYear = dac.GetActiveFinancialYear();
        foreach (DataRow dr in dtYear.Rows)
        {
            if (dr["ModuleName"].ToString() == "PLANNING")
            {
                Session["PFinancialYear"] = dr["FYear"].ToString();
                Session["PFinYearCode"] = dr["FYCode"].ToString();
            }
            else if (dr["ModuleName"].ToString() == "REQUISITION")
            {
                Session["RFinancialYear"] = dr["FYear"].ToString();
                Session["RFinYearCode"] = dr["FYCode"].ToString();
            }
            else if (dr["ModuleName"].ToString() == "BIDDING")
            {
                Session["BFinancialYear"] = dr["FYear"].ToString();
                Session["BFinYearCode"] = dr["FYCode"].ToString();
            }
        }
        Session["Pages"] = dac.GetUserModules(DelegatorID);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = TextBox1.Text.Trim();
        if (username != "")
        {
            try
            {
                string Password = bll.EncryptString(username);
                Usersdll.resetUserPassword(username, Password);
                ShowMessage("User password successfully reset. Check your email for more details");
                MultiView1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }

        }
    }
}