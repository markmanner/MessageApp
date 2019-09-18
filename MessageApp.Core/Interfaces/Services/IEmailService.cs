using System.Threading.Tasks;

namespace MessageApp.Core.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
