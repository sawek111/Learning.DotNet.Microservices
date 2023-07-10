using Ordering.Domain.Primitives;

namespace Ordering.Domain.Orders;

public class OrderNotFoundException : DomainException
{
    public OrderNotFoundException(Guid orderId) : base("Order not found with id " + orderId)
    {
    }
}