using Core.Primitives;

namespace Ordering.Domain.Orders;

public class Order : AggregateRoot
{
    public double Price { get; private set; }
    public string UserName { get; private set; }

    private Order(Guid id) : base(id)
    {
    }
    
    public void UpdateBase(double price, string userName)
    {
        ChangePrice(price);
        ChangeName(userName);
    }
    
    public void ChangeName(string name)
    {
        UserName = name;
    }
    
    public void ChangePrice(double price)
    {
        if (price <= 0)
        {
            throw new InvalidPriceException(price);
        }
        
        Price = price;
    }

    public static Order Create(double price, string name)
    {
        var order = new Order(Guid.NewGuid())
        {
            Price = price,
            UserName = name
        };
        
        return order;
    }
}