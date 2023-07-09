namespace Ordering.Domain.Orders;

public class OrderNotFoundException : Exception
{
    public OrderNotFoundException(Guid orderId) : base("Order not found with id " + orderId)
    {
    }
}