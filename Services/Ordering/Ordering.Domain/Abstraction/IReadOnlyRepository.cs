using System.Linq.Expressions;
using Ordering.Domain.Primitives;

namespace Ordering.Domain.Abstraction;

public interface IReadOnlyRepository<T> where T : Entity
{
    public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    public Task<bool> ExistsAsync(Guid id);
    protected Task<IReadOnlyList<T>> GetAllAsync();
    protected Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    protected Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);
}