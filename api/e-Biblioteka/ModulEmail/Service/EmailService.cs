using e_Biblioteka.ModulEmail.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using static Org.BouncyCastle.Math.EC.ECCurve;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;


namespace e_Biblioteka.ModulEmail.Service
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration Config;

        public EmailService(IConfiguration config)
        {
            Config = config;
        }
        [HttpPost]
        public ActionResult<bool> SendEmail(EmailModel request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(Config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();

            smtp.Connect(Config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(Config.GetSection("EmailUsername").Value, Config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

            return true;
        }
    }
}
