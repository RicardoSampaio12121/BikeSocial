using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialBLL.Utils
{
    public static class SendEmail
    {
        public static void sendEmail(string to, int code)
        {
            string from = "bikesocialhelp@outlook.pt";

            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, "#qwertyuiop1"),
                EnableSsl = true,
            };

            smtpClient.Send(from, to, "Password recovery code", code.ToString());
        }
    }
}
