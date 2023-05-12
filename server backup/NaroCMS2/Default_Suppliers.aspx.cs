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
    ProcessSuppliers supp = new ProcessSuppliers();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    DataTable dTable = new DataTable();
    DataTable dtLevels = new DataTable();
    DataSet dataSet = new DataSet();
    DataSuppliers ds = new DataSuppliers();
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
            //Login();

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
            else if (!supp.IsUserAccessAllowed(UserName, Passwd))
            {
                ShowMessage("System Access Failed");
            }
            else
            {
                AssignSessions(UserName, Passwd);
                Access(UserName, Passwd);
            }



            //string UserName = txtUsername.Text.Trim();
            //Session["SupplierName"] = UserName;
            //string Passwd = txtpassword.Text.Trim();
            //if(UserName=="supplier1@gmail.com" && Passwd == "sup1pass")
            //{
            //    Session["FullName"] = UserName;
            //    Session["Name"] = "Supplier1";
            //    Session["supplierId"] = 1;
            //    Session["UserID"] = 1;
            //    Response.Redirect("Suppliers_Items.aspx");
            //}else if(UserName == "supplier2@gmail.com" && Passwd == "sup2pass")
            //{
            //    Session["FullName"] = UserName;
            //    Session["Name"] = "Supplier2";
            //    Session["supplierId"] = 2;
            //    Response.Redirect("Suppliers_Items.aspx");
            //    Session["UserID"] = 2;
            //}
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
            string returned = supp.ChangeSupplierPassword(UserCode, OldPassword, Password, Confirm);
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
        dataTable = ds.GetSupplierAccessibility(UserName, EcryptedPassword);
        string UserID = dataTable.Rows[0]["EmailAddress"].ToString();
        Session["BidderID"] = Convert.ToInt32(dataTable.Rows[0]["BidderID"].ToString());
        if (txtUsername.Text.Trim() == txtpassword.Text.Trim())
        {
            RequestToChangePassword();
            Label1.Text = UserID.ToString();
            Label2.Text = UserName;
        }
        else
        {
            
            Response.Redirect("Suppliers_Items.aspx",false);
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
        string EcryptedPassword = supp.EncryptString(Password);
        dataTable = ds.GetSupplierAccessibility(UserName, EcryptedPassword);
        Session["BidderID"] = dataTable.Rows[0]["BidderID"].ToString();
        Session["CompanyName"] = dataTable.Rows[0]["CompanyName"].ToString();
        Session["designation"] = dataTable.Rows[0]["designation"].ToString();
        Session["Username"] = UserName;
        Session["PhysicalAddress"] = dataTable.Rows[0]["PhysicalAddress"].ToString();
        Session["CategoryName"] = dataTable.Rows[0]["CategoryName"].ToString();
        Session["PPACode"] = dataTable.Rows[0]["PPACode"].ToString();


     
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

    protected void BtnSignUp_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (TxtFname.Text.Length < 1)
        {
            ShowMessage("Please enter full name");
        }
        else if (txtemail.Text.Length < 1)
        {
            ShowMessage("Please enter email");
        }
        if (txtphone.Text.Length < 1)
        {
            ShowMessage("Please enter phone number");
        }
        else if (txtDesignation.Text.Length < 1)
        {
            ShowMessage("Please enter designation");
        }
        else if (txtAddress.Text.Length < 1)
        {
            ShowMessage("Please enter address");
        }
        else
        {
            string fullname = TxtFname.Text.Trim();
            string designation = txtDesignation.Text.Trim();
            string email = txtemail.Text.Trim();
            string phoneNumber = txtphone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string ppaCode = txtxPPA.Text.Trim();
            supp.SaveSupplierRequest(fullname,designation,email,phoneNumber,address,ppaCode);
            ClearControls();
        }


    }

    private void ClearControls()
    {
        TxtFname.Text = "";
        txtDesignation.Text = "";
        txtemail.Text = "";
        txtphone.Text = "";
        txtxPPA.Text = "";
        txtAddress.Text = "";

    }
}