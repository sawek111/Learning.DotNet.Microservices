using AutoMapper;
using Basket.Contracts;
using Basket.Core.Domain.Basket;

namespace Basket.Infrastructure;

public sealed class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<ShoppingCart, BasketResponse>();
        CreateMap<BasketResponse, BasketCheckedOutEvent>();
        CreateMap<BasketRequest, ShoppingCart>();
        CreateMap<(string name, BasketRequest request), ShoppingCart>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.name));
    }
}