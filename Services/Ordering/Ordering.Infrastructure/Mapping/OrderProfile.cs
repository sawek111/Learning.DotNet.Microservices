using AutoMapper;
using Mapster;
using Ordering.Contracts;
using Ordering.Domain.Orders;

namespace Ordering.Infrastructure.Mapping;

public class OrderProfile : Profile 
{
    public OrderProfile()
    {
        CreateMap<Order, OrderResponse>();
    }
}