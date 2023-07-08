using Mapster;
using Ordering.Contracts;
using Ordering.Domain.Order;

namespace Ordering.Infrastructure.Mapping;

public class OrderRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Order, OrderResponse>();
    }
}