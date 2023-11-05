using Core.Primitives;
using Ordering.Domain.Abstraction;

namespace Ordering.Domain.Orders;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<IReadOnlyList<TResponse>> GetOrdersByUserNameAsync<TResponse>(string userName) where TResponse : IResponse;
}