namespace Core.Messages;

public interface IIntegrationEvent
{
    public Guid EventId { get; }
    public DateTime CreatedAtUtc { get; }
}