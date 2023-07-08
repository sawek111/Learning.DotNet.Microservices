namespace Ordering.Domain.Email;

public sealed record EmailSettings(string ApiKey, string FromAddress, string FromName);