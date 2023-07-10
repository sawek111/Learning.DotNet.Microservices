using Ordering.Domain.Primitives;

namespace Ordering.Domain.Orders;

public class InvalidPriceException : DomainException  
{
    public InvalidPriceException(double price) : base($"Invalid price: {price}")
    {
    }
}