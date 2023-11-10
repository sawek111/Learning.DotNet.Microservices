using Basket.Core.Domain.Basket;

namespace Basket.Contracts;

public sealed record BasketRequest( decimal TotalPrice, IList<ShoppingCartItem> Items)
{
}