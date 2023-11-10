using AutoMapper;
using Basket.API.Application;
using Basket.API.Domain.Basket;
using Basket.API.Presentation;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Infrastructure;

// TODO result pattern
public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _cache;
    private readonly IMapper _mapper;

    public BasketRepository(IDistributedCache cache, IMapper mapper)
    {
        _cache = cache;
        _mapper = mapper;
    }
    
    public async Task<BasketResponse> GetBasket(string userName)
    {
        var basket = await _cache.GetStringAsync(userName);
        if (basket is null)
        {
            return null;
        }
        
        return _mapper.Map<BasketResponse>(JsonConvert.DeserializeObject<ShoppingCart>(basket));
    }
    
    public async Task<BasketResponse> UpdateBasket(ShoppingCart basket)
    {
        var basketJson = JsonConvert.SerializeObject(basket);
        await _cache.SetStringAsync(basket.UserName, basketJson);
        return _mapper.Map<BasketResponse>(basket);
    }
    
    public async Task<bool> DeleteBasket(string userName)
    {
        try
        {
            await _cache.RemoveAsync(userName);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}