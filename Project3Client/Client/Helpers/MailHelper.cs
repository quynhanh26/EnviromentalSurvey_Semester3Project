using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Client.Helpers
{
    public class MailHelper
    {
        private static string host = "smtp.gmail.com";
        private static int port = 587;
        private static bool enableSSL = true;
        private static string email = "quynhanh2606201@gmail.com";
        private static string pass = "Nhokhung26";
        public static bool Send(string to, string subject, string content, bool isHTML)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enableSSL,
                    Credentials = new NetworkCredential
                    {
                        UserName = email,
                        Password = pass
                    }
                };
                MailMessage mailMessage = new MailMessage(email, to);
                mailMessage.Subject = subject;
                mailMessage.Body = content;
                mailMessage.IsBodyHtml = isHTML;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static bool Send(string to, string subject, string content, bool isHTML, string[] fileNames)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enableSSL,
                    Credentials = new NetworkCredential
                    {
                        UserName = email,
                        Password = pass
                    }
                };
                MailMessage mailMessage = new MailMessage(email, to);
                mailMessage.Subject = subject;
                mailMessage.Body = content;
                mailMessage.IsBodyHtml = isHTML;
                if (fileNames != null && fileNames.Length > 0)
                {
                    foreach (var item in fileNames)
                    {
                        mailMessage.Attachments.Add(new Attachment(item));

                    }
                }
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}
