namespace Core.Messages;

public abstract class IntegrationBaseEvent : IIntegrationEvent
{
    protected IntegrationBaseEvent()
    {
    }
    
    public static Guid Id { get; protected set; } 
    public static DateTime CreatedAtUtc { get; protected set; }
}