using Core.Primitives;

namespace Ordering.Domain.Orders.DomainEvents;

public sealed record OrderCreatedDomainEvent(Guid OrderId) : IDomainEvent
{
}