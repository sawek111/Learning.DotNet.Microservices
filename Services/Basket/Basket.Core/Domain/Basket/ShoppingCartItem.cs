namespace Basket.Core.Domain.Basket;
public class ShoppingCartItem
{
    public decimal TotalPrice => Quantity * Price;
    public int Quantity { get; private set; }
    public string Color { get; private set; }
    public decimal Price { get; private set; }
    public string ProductId { get; private set; }
    public string ProductName { get; private set; }
    
    
    public static ShoppingCartItem Create(string productId, string productName, decimal price, string color, int quantity)
    {
        return new ShoppingCartItem
        {
            ProductId = productId,
            ProductName = productName,
            Price = price,
            Color = color,
            Quantity = quantity
        };
    }
}