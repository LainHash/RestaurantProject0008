using Restaurant.Application.Models.Messages;

namespace Restaurant.Application.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, EmailMessage message, CancellationToken cancellationToken = default);
    }
}
