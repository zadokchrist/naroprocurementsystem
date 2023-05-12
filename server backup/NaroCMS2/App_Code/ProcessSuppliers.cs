using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ProcessSuppliers
/// </summary>
public class ProcessSuppliers
{
    DataLogin data = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    DataTable dTable = new DataTable();
    DataSuppliers ds = new DataSuppliers();
   
    public ProcessSuppliers()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string SaveSupplierRequest(string FullName, string Designation, string Email, string PhoneNumber, string address, string PPACode)
    {
        string output = "";
        
            string Username = Email;
            string Password = bll.EncryptString(Username);

        if (IsUserNameUsed(Username))
            {
                output = "Supplier with Username " + Username + " exists already in the system";
            }
            else
            {
                // Call Methods to Save modules and Signature for the created user
                string Name = FullName;

                ds.SaveBidderApplication(FullName,address,PhoneNumber,Email, Password,false, Designation, PPACode);
               
                output = "Account for " + Name + " has been successfully registered ( Username " + Username + " )";
            }
        
        return output;
    }

    public bool IsUserNameUsed(string UserName)
    {
        dTable = ds.CheckUsername(UserName);
        int foundRows = dTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsUserAccessAllowed(string UserName, string Passwd)
    {
        string Password = EncryptString(Passwd);
        dTable = ds.GetSupplierAccessibility(UserName, Password);
        int foundRows = dTable.Rows.Count;
        if (foundRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
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

    public string ChangeSupplierPassword(string UserCode, string OldPassword, string NewPassword, string Confirm)
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
        else if (!IsUserAccessAllowed(UserCode, OldPassword))
        {
            ouput = "Invalid Old Password";
        }
        //else if (!bll.IsPasswordStrong(NewPassword))
        //{
        //    ouput = "Please Enter A Password With 8 Characters Long and Contains Capital and Small Letters and Numbers";
        //}
        else
        {
            string EncryptedPassword = EncryptString(NewPassword);
            int UserID = Convert.ToInt32(HttpContext.Current.Session["BidderID"]);
            ds.UpdatePassword(UserID, EncryptedPassword);
            ouput = "Password has been Change Successfully";
        }
        return ouput;
    }
}