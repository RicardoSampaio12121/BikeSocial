using System.Net;
using System.Net.Mail;

namespace BikeSocialBLL.Utils
{
    public static class SendEmail
    {
        public static void sendEmail(string to, int code)
        {
            //string from = "bikesocialhelp@outlook.pt";

            //var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            //{
            //    Port = 587,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(from, "#qwertyuiop1"),
            //    EnableSsl = true,
            //};

            //smtpClient.Send(from, to, "Password recovery code", code.ToString());

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("bikesocialhelp@outlook.pt");
            message.To.Add(new MailAddress(to));
            message.Subject = "Password recovery code";
            message.IsBodyHtml = false; //to make message body as html  
            message.Body = $"Código: {code}";
            smtp.Port = 587;
            smtp.Host = "smtp-mail.outlook.com"; //for outlook host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("bikesocialhelp@outlook.pt", "#qwertyuiop1");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
