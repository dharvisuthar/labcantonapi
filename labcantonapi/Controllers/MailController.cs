using labcantonapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace labcantonapi.Controllers
{
    public class MailController : ApiController
    {

        public string Post(EmailData emailData)
        {
            string msg = "Mail sent successfully.";
            try
            {
                Send(emailData.From, emailData.To, emailData.Subject, emailData.Username, emailData.Usermessage,  emailData.Userphone);

                return msg;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public void Send(string from, string to, string subject, string Username, string Usermessage, string Userphone)
        {
            try
            {

                string msg = "";
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.CC.Add("marc@thelabcanton.com");
                mail.From = new MailAddress(from);
                mail.Subject = subject;
                mail.Body = "<table style='background-color: #0085d3; color:#ffffff;' border='0' cellpadding='0' cellspacing='0'><tr><td><table width='100%' cellpadding='0' cellspacing='0' ><tr><td width='900px' height='69'><a href='http://www.thelabcanton.com/'><p style='font-family: Georgia, Helvetica, sans-serif; font-size: 22px; font-weight: bold; color: #ffffff; padding-left: 10px;'>LAB CANTON</p></a></td></tr></table><table width='900px' cellpadding='0' cellspacing='0' style='border: 1px solid #0085d3; background-color: #ffffff; padding:20px'><tr><td style='text-align:left;'><p style='font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #fbd03b;'>Dear client,</p><br/><p style='font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333; padding-left: 50px'>Hello,</p><p style='font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333; padding-left: 50px'>I am " + Username + ".</p><p style='font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333; padding-left: 50px'>" + Usermessage + ".</p><p style='font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333; padding-left: 50px'>Mo. No: " + Userphone + ".</p></td></tr></table></td></tr><tr style='background-color:#94c3df; color:#3f3e3e;'></tr></table>";
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("labcanton2021@gmail.com", "LabCanton@2021");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
                msg = "Mail Sent Successfully..";
            }
            catch (Exception exception)
            {
            }
        }
    }
}
