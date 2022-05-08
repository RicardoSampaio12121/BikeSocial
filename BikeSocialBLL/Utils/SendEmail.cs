using System.Net;
using System.Net.Mail;

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
