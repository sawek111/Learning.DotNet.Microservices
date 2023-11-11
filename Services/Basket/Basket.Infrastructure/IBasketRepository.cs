using Basket.Contracts;
using Basket.Core.Domain.Basket;

namespace Basket.Infrastructure;

public interface IBasketRepository
{
    Task<BasketResponse> GetBasketAsync(string userName);
    Task<BasketResponse> UpdateBasketAsync(ShoppingCart basket);
    Task<bool> DeleteBasketAsync(string userName);
}