using Basket.Contracts;
using Core.Messages;
using MassTransit;

namespace Ordering.WebApi.Consumers;

public class BasketCheckedOutEventConsumer : IEventConsumer<BasketCheckedOutEvent>
{
    public Task Consume(ConsumeContext<BasketCheckedOutEvent> context)
    {
        throw new NotImplementedException();
    }
}