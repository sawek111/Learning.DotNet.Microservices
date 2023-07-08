using Ordering.Domain.Primitives;

namespace Ordering.Domain.Abstraction;

public interface IAsyncRepository<T> : IReadOnlyRepository<T> where T : AggregateRoot
{
    protected Task<T> AddAsync(T entity);
    protected Task<bool> UpdateAsync(T entity);
    protected Task<bool> DeleteAsync(Guid id);
} 