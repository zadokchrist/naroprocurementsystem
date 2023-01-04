using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
/// <summary>
/// Summary description for ProcessUsers
/// </summary>
public class ProcessUsers
{
    DataLogin data = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    BusinessPlanning bllPlanning = new BusinessPlanning();
    BusinessRequisition bllRequsition = new BusinessRequisition();

    SendMail mailer = new SendMail();
    DataTable dTable = new DataTable();
	public ProcessUsers()
	{
		
	}
    public string SaveSystemUser(string FirstName,string MiddleName, string LastName, string Disgnation,string Email, string PhoneNumber,
        int AreaID, int CostCenterID, bool IsPDUMember, bool IsPDUSupervisor, int AccessLevelID, string ModArray, int CapturedBy, FileUpload imgUpload)
    {
        string output = "";

        ProcessUsers _user = new ProcessUsers();
        DataTable dTable = new DataTable();
        dTable = _user.FindEmail(Email);
        if (FirstName == "" )
        {
            output = "Please Enter First Name";
        } else if (LastName == "") {

            output = "Please Enter Last Name";
        }
        else if (AreaID == 0)
        {
            output = "Please Select Area for attachment";
        }
        else if (CostCenterID == 0)
        {
            output = "Please Select Cost Center";
        }
        else if (AccessLevelID == 0)
        {
            output = "Please Select User Access Level";
        }
        else if (Disgnation == "")
        {
            output = "Please Enter User's Position";
        }
        else if (!bll.IsValidEmailAddress(Email))
        {
            output = "Please Enter a valid User's Email Address";
        } else if (dTable.Rows.Count>0)
        {
            output = "Email Address already exists in system";
        }
        else
        {
            string Username = MakeUserName(FirstName, LastName).Trim().ToLower();
            string Password = bll.EncryptString(Username);
            //if (bll.IsUserNameUsed(Username))
            //{
            //    Username = AlterUserName(FirstName, LastName).Trim().ToLower();
            //    Password = bll.EncryptString(Username);
            //}
            if (bll.IsUserNameUsed(Username))
            {
                output = "System User with Username " + Username + " exists already in the system";
            }
            else
            {
                // Call Methods to Save modules and Signature for the created user
                string Name = FirstName + ' ' + LastName;
                NotifyUser(Email, Username, Name);
                string SaveUserID = data.SaveUserDetails(FirstName, MiddleName, LastName, Username, Password, Disgnation,
                                    Email, PhoneNumber, CostCenterID, IsPDUMember, IsPDUSupervisor, AccessLevelID, CapturedBy);
                //SaveUserModules(SaveUserID, ModArray);
                SaveSignature(SaveUserID, imgUpload);

                output = "Access for " + Name + " has been successfully created ( Username " + Username + " )";
            }
        }
        return output;
    }

    public void UpdateAccessLevelDetails(string text, string levelName, string description, bool active)
    {
        data.UpdateAccessLevelDetails(text, levelName, description, active);
    }

    public void SaveAccessLevel(string levelName, string description, bool active)
    {
        data.SaveAccessLevel(levelName, description, active);
    }

    public void UpdateWorkFlowDetails(string name, bool active, string flowid)
    {
        data.UpdateWorkFlowDetails(name, active, flowid);
    }

    private void NotifyUser(string Email, string Username, string Name)
    {
        string message = "<p>Hello " + Name.ToUpper() + ", " + Environment.NewLine + "</p><p> Access the E-Procurement System through http://192.168.8.110:4070/procurement/ </p>" + Environment.NewLine;
        message += "<p>Your Username is " + Username + ". (Password is the same as the username). </p>" + Environment.NewLine;
        
        mailer.SendEmail("Admin", Email, "NARO CMS Account Profile", message);
    }

    private void NotifyChange(string Email, string Username, string Name)
    {
        string message = "<p>Hello " + Name.ToUpper() + ", " + Environment.NewLine + "Your Password has Been Reset" + Environment.NewLine;
        message += "<p>Your Username is " + Username + ". (Password is the same as the username). </p>" + Environment.NewLine;
        message += "<p>In case of any issue(s), Please Contact Israel Adekanmbi (israel.adekanmbi@lagoswater.org) or Segun (segun.adeniran@lagoswater.org) or Chidozie Agbakwuru (caagbakwuru@lagoswater.org) .</p>";

        mailer.SendEmail("Admin", Email, "E-Procurement Account Password Reset", message);
    
    }

    public string UpdateSystemUser(string UserCode, string Username, string FirstName, string MiddleName, string LastName,
        string Disgnation, string Email, string PhoneNumber, int AreaID, int CostCenterID,
        bool IsPDUMember, bool IsPDUSupervisor, bool IsInventoryStaff, int AccessLevelID, int reset, FileUpload imgUpload, bool isRemoved)
    {
        string output = "";
        if (FirstName == "" || LastName == "")
        {
            output = "Please Enter First and Last Name";
        }
        else if (AreaID == 0)
        {
            output = "Please Select Area for attachment";
        }
        else if (CostCenterID == 0)
        {
            output = "Please Select Cost Center";
        }
        else if (AccessLevelID == 0)
        {
            output = "Please Select User Access Level";
        }
        else if (Disgnation == "")
        {
            output = "Please Enter User's Position";
        }
        else if (!bll.IsValidEmailAddress(Email))
        {
            output = "Please Enter a valid User's Email Address";
        }
        else
        {
            int removed = 0;
            if (isRemoved == true) {
                removed = 1;
            }
           // string Username = MakeUserName(FirstName,LastName);
           string Password = bll.EncryptString(Username);
           int UserID = Convert.ToInt32(UserCode);
           data.UpdateUserDetails(UserID, FirstName, MiddleName, LastName, Username, Password, Disgnation, Email, PhoneNumber, CostCenterID, IsPDUMember, IsPDUSupervisor, IsInventoryStaff, AccessLevelID, reset,removed);

            // Call Methods to Save modules and Signature for the created user
           if (AccessLevelID != 1 && AccessLevelID != 16)
           {
               WithdrawModule(UserCode, "1");
           }
           if (reset == 1) {
               string NAME = FirstName +" "+ MiddleName + " "+ LastName;
               NotifyChange(Email, Username,NAME);
           }
            //SaveSignature(SaveUserID, imgUpload);
            output = "Details for " + FirstName + " have been successfully updated";
        
        }
        return output;
    }

    public void ConfigureContract(string contractname, string contracttype, string workflow, bool active)
    {
        data.ConfigureContract(contractname, contracttype, workflow, active);
    }

    internal DataTable FindEmail(string sEmail)
    {
        dTable= data.FindEmail(sEmail);
        return dTable;
    }

    public void resetUserPassword(string username, string password)
    {
        data.resetUserPassword(username, password);
    }
    private void SaveUserModules(string UserCode, string StrArray)
    {
        int UserID = Convert.ToInt32(UserCode);
        int Mod = 0;
        string[] arr = StrArray.Split(',');
        int i = 0;
        for (i = 0; i < arr.Length; i++)
        {
            //Response.Write(myArr[i] + " ");
            Mod = Convert.ToInt32(arr[i]);
            if (Mod != 0)
            {
                data.SaveUserModule(UserID, Mod);
                if (i == 1)
                {
                    data.UpdateUsersLogins(UserID, Mod);
                }
            }
        }
    }
    public void AddModule(string UserCode, string Module)
    {
        int UserID = Convert.ToInt32(UserCode);
        int ModuleID = Convert.ToInt32(Module);
        data.SaveUserModule(UserID, ModuleID);
    }
    private void SaveSignature(string UserCode, FileUpload imgUpload)
    {
        int UserID = Convert.ToInt32(UserCode);
        FileUpload img = (FileUpload)imgUpload;
        Byte[] imgByte = null;
        if (img.HasFile && img.PostedFile != null)
        {
            //To create a PostedFile
            HttpPostedFile File = imgUpload.PostedFile;
            //Create byte Array with file len
            imgByte = new Byte[File.ContentLength];
            //force the control to load data in array
            File.InputStream.Read(imgByte, 0, File.ContentLength);
            data.SaveUserSigniture(UserID, imgByte);
        }
    }
    private string MakeUserName(string FName, string LName)
    {
        string MadeUserName = FName.Substring(0, 1) + LName;
        //if (bll.IsUserNameUsed(MadeUserName))
        //    MadeUserName = FName.Substring(0, 2) + LName;
        return MadeUserName.ToLower();
    }
    private string AlterUserName(string FName, string LName)
    {
        string MadeUserName = LName.Substring(0, 1) + FName;
        return MadeUserName;
    }
    public DataTable GetSystemUsers(string SearchString, string AreaCode, int CostCenter)
    {
        int AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetSystemUsers(SearchString, AreaID, CostCenter);
        return dTable;
    }
    public DataTable GetUserDetails(string UserCode)
    {
        dTable = data.GetUserDetails(UserCode);
        return dTable;
    }
    public DataTable GetSearchUsers(string SearchString)
    {
        dTable = data.GetSearchUsers(SearchString);
        return dTable;
    }
    public DataTable GetModulesAllocation(int UserCode)
    {
        dTable = data.GetUserModules(UserCode);
        return dTable;
    }
    public DataTable GetUserModules(string UserCode)
    {
        int UserID = Convert.ToInt32(UserCode);
        dTable = data.GetModulesByUserID(UserID);
        return dTable;
    }
    public DataTable GetOtherModules(string UserCode, string LevelCode)
    {
        int UserID = Convert.ToInt32(UserCode);
        int LevelID = Convert.ToInt32(LevelCode);
        dTable = data.GetOtherModules(UserID, LevelID);
        return dTable;
    }
    public DataTable GetUserWelcome(int UserCode)
    {
        dTable = data.GetUserWelcome(UserCode);
        return dTable;
    }
    public DataTable GetMultiCostCenters(int UserCode)
    {
        dTable = data.GetMultiCostCenters(UserCode);
        return dTable;
    }
    public string ChangeUserStatus(string Usercode, string Status)
    {
        bool status;
        string output = "";
        if (Status == "YES")
        {
            status = false;
            output = "User(" + Usercode + ") has been disabled Successfully";
        }
        else
        {
            status = true;
            output = "User(" + Usercode + ") has been enabled Successfully";
        }
        data.ChangeUserStatus(Usercode, status);
        return output;

    }
    public string ChangeDocTypeStatus(string doctypid, bool Status,string doctypename)
    {
        bool status;
        string output = "";
        if (Status)
        {
            status = false;
            output = "Doctype (" + doctypename + ") has been disabled Successfully";
        }
        else
        {
            status = true;
            output = "User(" + doctypename + ") has been enabled Successfully";
        }
        data.ChangeDocTypeStatus(doctypid, status);
        return output;

    }
    public string ChangeAccessLevelStatus(string levelid, string Status)
    {
        bool status;
        string output = "";
        if (Status == "True")
        {
            status = false;
            output = "User(" + levelid + ") has been disabled Successfully";
        }
        else
        {
            status = true;
            output = "User(" + levelid + ") has been enabled Successfully";
        }
        data.ChangeLevelStatus(levelid, status);
        return output;

    }
    public void UpdateUserLogins(int UserID, int modID)
    {
        data.UpdateUsersLogins(UserID, modID);
    }
    public string ChangeUserPassword(string UserCode, string OldPassword, string NewPassword, string Confirm)
    {
        string ouput = "";
       if (NewPassword == "")
        {
            ouput = "Please Enter New Password";
        }
        else if (Confirm == "")
        {
            ouput = "Please Confirm Password";
        }
        else if (NewPassword != Confirm)
        {
            ouput = "Passwords do not match";
        }
        else if (!bll.IsUserAccessAllowed(HttpContext.Current.Session["UserName"].ToString(), OldPassword))
        {
            ouput = "Invalid Old Password";
        }
        //else if (!bll.IsPasswordStrong(NewPassword))
        //{
        //    ouput = "Please Enter A Password With 8 Characters Long and Contains Capital and Small Letters and Numbers";
        //}
        else
        {
            string EncryptedPassword = bll.EncryptString(NewPassword);
            int UserID = Convert.ToInt32(UserCode);
            data.UpdatePassword(UserID, EncryptedPassword);
            ouput = "System User Password has been Changed Successfully";
        }
        return ouput;
    }
    public void SaveCostCenter(string CostCenterId, string CostCenterCode, string CostCenterName, 
        string AreaCode, string Initial, bool IsMultiCostCenter, bool Active)
    {
        int CostCenterID = Convert.ToInt32(CostCenterId);
        int AreaID = Convert.ToInt32(AreaCode);
        int CreatedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        data.SaveCostCenterDetails(CostCenterID, CostCenterCode, CostCenterName, AreaID, Initial, IsMultiCostCenter, Active, CreatedBy);

    }

    public void SaveLocationDetails(int areaID, string areaName)
    {

        data.SaveLocationDetails(areaID, areaName);

    }

    public void SaveAreaDetails(int areaID, string areaName, int category, int status)
    {

        data.SaveAreaDetails(areaID, areaName, category, status);

    }

    public void SaveWorkFlowDetails(string workFlowname, bool status)
    {

        data.SaveWorkFlowDetails(workFlowname, status);

    }

    public void SaveWareHouseDetails(int warehouseid, string Name, int areaID)
    {

        data.SaveWarehoseDetails(warehouseid, Name, areaID);

    }


    public void WithdrawModule(string UserCode,string Module)
    {
        int UserID = Convert.ToInt32(UserCode);
        int ModuleID = Convert.ToInt32(Module);
        data.RemoveModule(UserID, ModuleID);
    }
    public string SaveFinancialYear(string Record,string StartDate, string EndDate, bool Active)
    {
        string output = "";
        if (StartDate == "")
        {
            output = "Please Enter Start Date of the Financial Year";
        }
        else if (EndDate == "")
        {
            output = "Please Enter End Date of the Financial Year";
        }
        else
        {
            DateTime Startdate = bllRequsition.ReturnDate(StartDate, 1);
            DateTime Enddate = bllRequsition.ReturnDate(EndDate, 2);
            int RecordID = Convert.ToInt32(Record);
            int firstYear = Startdate.Year;
            int SecondYear = Enddate.Year;
            int Diff = SecondYear - firstYear;
            if (bll.YearExists(Startdate, Enddate) && RecordID == 0)
            {
                output = "Financial Year for the Period Specified exists";
            }
            else if (Diff != 1)
            {
                output = "Duration for a financial year must be one year";
            }
            else
            {
                data.SaveFinancialYear(RecordID,Startdate, Enddate, Active);
                if (RecordID == 0)
                {
                    output = "Financial Year " + Startdate.Year.ToString() + " - " + Enddate.Year.ToString() + " has been captured Successfully";
                }
                else
                {
                    output = "Financial Year " + Startdate.Year.ToString() + " - " + Enddate.Year.ToString() + " has been updated Successfully";
                }

            }
        }
        return output;
    }
    public DataTable GetCostCentersfromScala(string CategoryCode, string Code)
    {
        int CategoryID = Convert.ToInt32(CategoryCode);
        dTable = data.GetCostCentersfromScala(CategoryID, Code);
        return dTable;
    }

    internal string getUserAccessLevel(string sendTo)
    {
        string a = "0";
       dTable = data.getUserAccessLevel(sendTo);
        if (dTable.Rows.Count > 0)
        {
            a = dTable.Rows[0]["AccessLevelID"].ToString();
        }
        return a;
    }


}
