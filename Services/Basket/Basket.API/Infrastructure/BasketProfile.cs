using AutoMapper;
using Basket.API.Domain.Basket;

namespace Basket.API.Infrastructure;

public sealed class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<ShoppingCart, BasketResponse>();
        CreateMap<BasketRequest, ShoppingCart>();
        CreateMap<(string name, BasketRequest request), ShoppingCart>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.name));
    }
}