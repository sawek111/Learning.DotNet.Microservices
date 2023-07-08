namespace Ordering.Domain.Email;

public sealed record Email(string To, string Subject, string Body);