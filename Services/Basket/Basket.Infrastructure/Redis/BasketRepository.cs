using AutoMapper;
using Basket.Contracts;
using Basket.Core.Domain.Basket;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Redis;

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
    
    public async Task<BasketResponse> GetBasketAsync(string userName)
    {
        var basket = await _cache.GetStringAsync(userName);
        if (basket is null)
        {
            return null;
        }

        return JsonConvert.DeserializeObject<BasketResponse>(basket);
    }
    
    public async Task<BasketResponse> UpdateBasketAsync(ShoppingCart basket)
    {
        var basketJson = JsonConvert.SerializeObject(basket);
        await _cache.SetStringAsync(basket.UserName, basketJson);
        return _mapper.Map<BasketResponse>(basket);
    }
    
    public async Task<bool> DeleteBasketAsync(string userName)
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