using Microsoft.Extensions.Logging;
using Ordering.Domain.Email;

namespace Ordering.Infrastructure;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public Task<bool> SendEmailAsync(Email email)
    {
        //TODO 
        _logger.LogInformation("Email send", email);
        return Task.FromResult(true);
    }
}