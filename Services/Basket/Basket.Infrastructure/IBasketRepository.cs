using Basket.Contracts;
using Basket.Core.Domain.Basket;

namespace Basket.Infrastructure;

public interface IBasketRepository
{
    Task<BasketResponse> GetBasket(string userName);
    Task<BasketResponse> UpdateBasket(ShoppingCart basket);
    Task<bool> DeleteBasket(string userName);
}