using Ordering.Domain.Abstraction;
using Ordering.Domain.Primitives;

namespace Ordering.Domain.Orders;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<IReadOnlyList<TResponse>> GetOrdersByUserNameAsync<TResponse>(string userName) where TResponse : IResponse;
}