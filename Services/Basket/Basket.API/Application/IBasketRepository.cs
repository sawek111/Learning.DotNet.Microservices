using Basket.API.Domain.Basket;
using Basket.API.Presentation;

namespace Basket.API.Application;

public interface IBasketRepository
{
    Task<BasketResponse> GetBasket(string userName);
    Task<BasketResponse> UpdateBasket(ShoppingCart basket);
    Task<bool> DeleteBasket(string userName);
}