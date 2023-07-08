using Ordering.Domain.Primitives;

namespace Ordering.Domain.Order;

public class Order : Entity
{
    public double Price { get; private set; }
    
    public Order(Guid id) : base(id)
    {
    }
}  