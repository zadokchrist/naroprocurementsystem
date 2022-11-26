using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Net;

public class BusinessLogin
{
    DataLogin dac = new DataLogin();
    DataPlanning dataPlanning = new DataPlanning();
    DataTable DTable = new DataTable();
    DataSet dataSet = new DataSet();
    public BusinessLogin()
	{
	}
    public string EncryptString(string ClearText)
    {
        byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);
        System.Security.Cryptography.SymmetricAlgorithm done = SymmetricAlgorithm.Create();

        MemoryStream ms = new MemoryStream();
        byte[] key1 = Encoding.ASCII.GetBytes("ryojvlzmdalyglrj");
        byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbhczfeultgbskdmaunivmfuo");
        CryptoStream cs = new CryptoStream(ms, done.CreateEncryptor(key, key1), CryptoStreamMode.Write);

        cs.Write(clearTextBytes, 0, clearTextBytes.Length);

        cs.Close();
        return Convert.ToBase64String(ms.ToArray());
        //return ClearText;
    }
    public bool IsUserAccessAllowed(string UserName, string Passwd)
    {
        string Password = EncryptString(Passwd);
        DTable = dac.GetUserAccessibility(UserName, Password);
        int foundRows = DTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsPasswordStrong(string password)
    {
        return Regex.IsMatch(password, @"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$");
    }
    public bool IsOneModule(int UserID)
    {
        DTable = dac.GetNumberOfModules(UserID);
        int Modules = Convert.ToInt32(DTable.Rows[0]["Modules"].ToString());
        if (Modules == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsEmailAvailable(string inputEmail)
    {
        bool isReal = false;
            try
            {
                string[] host = (inputEmail.Split('@'));
                string hostname = host[1];

                IPHostEntry IPhst = Dns.GetHostEntry(hostname);
                IPEndPoint endPt = new IPEndPoint(IPhst.AddressList[0], 8080);
                Socket s = new Socket(endPt.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);
                s.Connect(endPt);
                s.Close();
                isReal = true;
            }
         catch(Exception ex)
            {
             isReal = false;
         }
           return isReal;

    }
    public string GetDefaultPageForModule(int AccessLevel, int Module)
    {
        string PageName = "";
        DTable = dac.GetStartPage(AccessLevel, Module);
        if (DTable.Rows.Count > 0)
        {
            PageName = DTable.Rows[0]["PageFath"].ToString();
            
        }
        return PageName;
    }
    public bool IsModuleActive(int ModuleID)
    {
        DTable = dac.CheckIfModActive(ModuleID);
        int foundRows = DTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool YearExists(DateTime StartDate, DateTime EndDate)
    {
        DTable = dataPlanning.CheckFinancialYear(StartDate, EndDate);
        int foundRows = DTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsCostCenter(string CostCenterCode)
    {
        DTable = dac.CheckCostCenter(CostCenterCode);
        int foundRows = DTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsUserDelegated(int UserID)
    {
        DTable = dac.GetDelegation(UserID);
        int foundRows = DTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsUserNameUsed(string UserName)
    {
        DTable = dac.CheckUsername(UserName);
        int foundRows = DTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsUserActive(int UserID)
    {
        DTable = dac.CheckIsUserActive(UserID);
        int foundRows = DTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsValidEmailAddress(string sEmail)
    {
        
        if (sEmail == null)
        {
            return false;
        }
        else
        {
            return Regex.IsMatch(sEmail, @"
               ^
               [-a-zA-Z0-9][-.a-zA-Z0-9]*
               @
               [-.a-zA-Z0-9]+
               (\.[-.a-zA-Z0-9]+)*
               \.
               (
               com|edu|info|gov|int|mil|net|org|biz|
               name|museum|coop|aero|pro
               |
               [a-zA-Z]{2}
               )
               $",
            RegexOptions.IgnorePatternWhitespace);
        }
    }
    public bool IsUserInMultiCostCenter(string CostCenterCode)
    {
        int CostCenterID = Convert.ToInt32(CostCenterCode);
        DTable = dac.GetMultiCostCenters(CostCenterID);
        int foundRows = DTable.Rows.Count;
        if (foundRows > 0)
            return true;
        else
            return false;
    }
}
