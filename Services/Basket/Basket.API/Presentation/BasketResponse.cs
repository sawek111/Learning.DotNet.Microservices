using Basket.API.Domain.Basket;

namespace Basket.API.Presentation;

public sealed record BasketResponse(string UserName, decimal TotalPrice, IList<ShoppingCartItem> Items)
{
}