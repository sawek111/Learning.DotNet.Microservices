namespace Basket.Core.Domain.Basket;

public class ShoppingCart
{
    private ShoppingCart()
    {
    }
    
    public string UserName { get; private set; }
    public decimal TotalPrice => Items.Sum(x => x.TotalPrice);
    public IReadOnlyCollection<ShoppingCartItem> Items { get; private set; } = new List<ShoppingCartItem>();
}