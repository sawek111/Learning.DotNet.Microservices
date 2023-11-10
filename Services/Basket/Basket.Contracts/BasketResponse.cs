using Basket.Core.Domain.Basket;

namespace Basket.Contracts;

public sealed record BasketResponse(string UserName, decimal TotalPrice, IList<ShoppingCartItem> Items)
{
}