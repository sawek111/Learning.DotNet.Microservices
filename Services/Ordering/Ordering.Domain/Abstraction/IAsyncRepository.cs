using Ordering.Domain.Primitives;

namespace Ordering.Domain.Abstraction;

public interface IAsyncRepository<T> : IReadOnlyRepository<T> where T : AggregateRoot
{
    public Task<T> AddAsync(T entity);
    public Task<bool> UpdateAsync(T entity);
    public Task<bool> DeleteAsync(Guid id);
    public Task<T> GetAsync(Guid id);
} 