namespace Ordering.Domain.Email;

public interface IEmailService
{
    Task<bool> SendEmailAsync(Email email);
}