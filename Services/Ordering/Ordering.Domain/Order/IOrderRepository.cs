using Ordering.Domain.Abstraction;
using Ordering.Domain.Primitives;

namespace Ordering.Domain.Order;

public interface IOrderRepository : IReadOnlyRepository<Order>
{
    Task<IReadOnlyList<TResponse>> GetOrdersByUserNameAsync<TResponse>(string userName) where TResponse : IResponse;
}