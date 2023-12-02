using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailHelper
{
    public class EmailManager
    {
       
        public bool SendEnquiryConfirmation(string userEmail,string msg)
        {

            bool emailStatus = false;
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(userEmail);
            mail.From = new System.Net.Mail.MailAddress("bhartisatankar1502@gmail.com");
            mail.Subject = "Mail From Wellness Wave";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = msg;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("bhartisatankar1502@gmail.com", "qilz sjky infy qkcg");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {

                client.Send(mail);
                emailStatus = true;
                return emailStatus;
            }
            catch (Exception ex)
            {
                return emailStatus;
                //Exception ex2 = ex;
                //string errorMessage = string.Empty;

                //while (ex2 != null)
                //{
                //    errorMessage += ex2.ToString();
                //    ex2 = ex2.InnerException;
                //}
            }

        }
    }
}
