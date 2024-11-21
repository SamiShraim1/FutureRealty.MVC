using System.Net.Mail;
using System.Net;
using FutureRealty.DAL.Models;

namespace FutureRealty.PL.Helpers
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("samialnser@gmail.com", "avpp gput ksrz ftiy");

            client.Send("tariqshreem000@gmail.com", email.Receivers, email.Subject, email.Body);
        }
    }

}
