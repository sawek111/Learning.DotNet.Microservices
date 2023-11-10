namespace Core.Messages;

public interface IIntegrationEvent
{
    public static Guid Id { get; }
    public static DateTime CreatedAtUtc { get; }
}