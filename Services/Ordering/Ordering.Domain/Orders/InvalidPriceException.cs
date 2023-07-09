namespace Ordering.Domain.Orders;

public class InvalidPriceException : Exception  
{
    public InvalidPriceException(double price) : base($"Invalid price: {price}")
    {
    }
}