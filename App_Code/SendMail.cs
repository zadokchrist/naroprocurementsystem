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
using System.Text.RegularExpressions;
using MailServiceLibrary;
using System.Net;
using System.Security.Cryptography.X509Certificates;

public class SendMail
{
    DataLogin main = new DataLogin();
    private const string smtpServer = "smtp.gmail.com";
    private const string smtpUsername = "lwcprocurement@gmail.com";
    private const string smtpPassword = "proc@lwc123";
    public SendMail()
    {

    }

    public void Alert(string Message, int Who)
    {
    }
    public void SendEmail(string Name, string emailAddress, string Subject, string Message)
    {
        try
        {
            string output = "";
            MailMessage message = new MailMessage();
            message.To.Clear();
            SmtpClient mailClient = new SmtpClient(smtpServer);
            MailAddress Email = new MailAddress(emailAddress);
            message.To.Add(emailAddress);
            message.CC.Add(new MailAddress(emailAddress));
            message.Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            message.Body = Message;
            message.IsBodyHtml = true;
            message.From = new MailAddress("lwcprocurement@gmail.com", "E-Proc - " + Name);
            //I USE GMAIL AS THE SMTP SERVER..for more info google
            mailClient.UseDefaultCredentials = false;
            NetworkCredential cred = new NetworkCredential(smtpUsername, smtpPassword);
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.Timeout = 1000 * 60 * 4;
            mailClient.Credentials = cred;
            mailClient.Port = 587;
            mailClient.EnableSsl = true;
            //SEND EMAIL
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(emailAddress))
                mailClient.Send(message);
            output = "Email successfully delivered";

        }
        catch (Exception ex)
        {
            // let us log the failed message
            string to = emailAddress;
            string from = "info@nwsc.co.ug";
            string displayname = "E-Proc - " + Name;
            string exception = ex.Message;
            string body = Message;
            string subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            //main.insertMailException(to, from, displayname, subject, body, exception, 0);
        }
    }
    public void SendBroadCastEmail(string Name,string supervisoremail, string[] emailAddress, string Subject, string Message)
    {
        try
        {
            string output = "";
            MailMessage message = new MailMessage();
            message.To.Clear();
            SmtpClient mailClient = new SmtpClient(smtpServer);
            //MailAddress Email = new MailAddress(emailAddress);
            message.To.Add(supervisoremail);
            for (int i = 0; i <= emailAddress.Length; i++)
            {
                if (!string.IsNullOrEmpty(emailAddress[0]))
                {
                    message.CC.Add(new MailAddress(emailAddress[0]));
                }
            }
            
            message.Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            message.Body = Message;
            message.IsBodyHtml = true;
            message.From = new MailAddress("lwcprocurement@gmail.com", "E-Proc - " + Name);
            //I USE GMAIL AS THE SMTP SERVER..for more info google
            mailClient.UseDefaultCredentials = false;
            NetworkCredential cred = new NetworkCredential(smtpUsername, smtpPassword);
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.Timeout = 1000 * 60 * 4;
            mailClient.Credentials = cred;
            mailClient.Port = 587;
            mailClient.EnableSsl = true;
            //SEND EMAIL
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(emailAddress[0]))
                mailClient.Send(message);
            output = "Email successfully delivered";

        }
        catch (Exception ex)
        {
            // let us log the failed message
            string to = emailAddress[0];
            string from = "info@nwsc.co.ug";
            string displayname = "E-Proc - " + Name;
            string exception = ex.Message;
            string body = Message;
            string subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            //main.insertMailException(to, from, displayname, subject, body, exception, 0);
        }
    }


    public void SendEmail2(string Name, string emailAddress, string Subject, string Message, string attachpath)
    {
        //MailService mailService = new MailService();
        //mailService.sendNWSCEmail("Eproc", "E-Proc - " + Name, emailAddress, Subject, Message);

        try
        {
            string output = "";
            MailMessage message = new MailMessage();

            //message.From = new MailAddress("lwcprocurement@gmail.com", "E-Proc - " + Name);
            //message.To.Add(emailAddress);
            //message.Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            //message.Body = Message;
            //message.BodyEncoding = System.Text.Encoding.ASCII;
            //message.IsBodyHtml = true;
            //message.Priority = MailPriority.Normal;


            ////SmtpClient smtp = new SmtpClient("10.0.0.9");
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            //if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(emailAddress))
            //   smtp.Send(message);
            //output = "Email successfully delivered";
            message.To.Clear();
            SmtpClient mailClient = new SmtpClient(smtpServer);
            MailAddress Email = new MailAddress(emailAddress);
            message.To.Add(emailAddress);
            Attachment att = new Attachment(attachpath);
            message.Attachments.Add(att);
            message.CC.Add(new MailAddress(emailAddress));
            message.Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            message.Body = Message;
            message.IsBodyHtml = true;
            message.From = new MailAddress("lwcprocurement@gmail.com", Name);


            //I USE GMAIL AS THE SMTP SERVER..for more info google
            mailClient.UseDefaultCredentials = false;
            NetworkCredential cred = new NetworkCredential(smtpUsername, smtpPassword);
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.Timeout = 1000 * 60 * 4;
            mailClient.Credentials = cred;
            mailClient.Port = 587;
            mailClient.EnableSsl = true;
            //SEND EMAIL
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(emailAddress))
                mailClient.Send(message);

            output = "Email successfully delivered";

        }
        catch (Exception ex)
        {
            // let us log the failed message
            string to = emailAddress;
            string from = "info@nwsc.co.ug";
            string displayname = "E-Proc - " + Name;
            string exception = ex.Message;
            string body = Message;
            string subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            //main.insertMailException(to, from, displayname, subject, body, exception, 0);
        }
    }
}

    //internal static void SendReciept(string email, string body, string recieptpath)
    //{
    //    try
    //    {
    //        string messageBody = body;
    //        MailMessage message = new MailMessage();
    //        message.To.Clear();
    //        SmtpClient mailClient = new SmtpClient(smtpServer);
    //        MailAddress Email = new MailAddress(email);
    //        message.To.Add(emailAddress);
    //       // Attachment att = new Attachment(recieptpath);
    //       // message.Attachments.Add(att);
    //        message.CC.Add(new MailAddress(email));
    //        message.Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
    //        message.Body = messageBody;
    //        message.IsBodyHtml = true;
    //        message.From = new MailAddress("lwcprocurement@gmail.com", "E-Proc - " + Name);


    //        //I USE GMAIL AS THE SMTP SERVER..for more info google
    //        mailClient.UseDefaultCredentials = false;
    //        NetworkCredential cred = new NetworkCredential(smtpUsername, smtpPassword);
    //        mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    //        mailClient.Timeout = 1000 * 60 * 4;
    //        mailClient.Credentials = cred;
    //        mailClient.Port = 587;
    //        mailClient.EnableSsl = true;
    //        //SEND EMAIL
    //        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };
    //        mailClient.Send(message);

           
    //    }
    //    catch (Exception up)
    //    {
            
    //        // throw up;
    //    }
    //}