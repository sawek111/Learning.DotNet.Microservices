using Basket.API.Domain.Basket;

namespace Basket.API;

public sealed record BasketRequest( decimal TotalPrice, IList<ShoppingCartItem> Items)
{
}