using Basket.API.Domain.Basket;

namespace Basket.API.Presentation;

public sealed record BasketRequest( decimal TotalPrice, IList<ShoppingCartItem> Items)
{
}