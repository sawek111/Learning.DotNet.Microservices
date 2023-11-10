using System.Linq.Expressions;
using Core.Primitives;
using Ordering.Domain.Orders;

namespace Ordering.Infrastructure.Peristence;

public class OrderRepository : IOrderRepository
{
    public Task<bool> ExistsAsync(Expression<Func<Order, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetAsync(Expression<Func<Order, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetAsync(Expression<Func<Order, bool>> predicate, List<Expression<Func<Order, object>>> includes)
    {
        throw new NotImplementedException();
    }

    public Task<Order> AddAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<TResponse>> GetOrdersByUserNameAsync<TResponse>(string userName) where TResponse : IResponse
    {
        throw new NotImplementedException();
    }
}