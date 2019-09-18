using MessageApp.Core.Interfaces.Services;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MessageApp.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("fteszt4@gmail.com", "123456aA!");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("fteszt4@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Body = htmlMessage;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            client.Send(mailMessage);

            return Task.CompletedTask;
        }
    }
}
