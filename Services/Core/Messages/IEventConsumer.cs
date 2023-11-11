using MassTransit;

namespace Core.Messages;

public interface IEventConsumer<in TMessage> : IConsumer<TMessage> where TMessage : IntegrationBaseEvent
{
}