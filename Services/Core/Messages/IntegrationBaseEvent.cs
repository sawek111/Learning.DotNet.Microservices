namespace Core.Messages;

public abstract record IntegrationBaseEvent : IIntegrationEvent
{
    protected IntegrationBaseEvent()
    {
    }
    
    public Guid EventId { get; protected set; } 
    public DateTime CreatedAtUtc { get; protected set; }
}