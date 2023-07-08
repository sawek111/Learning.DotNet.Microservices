using System.Linq.Expressions;
using Ordering.Domain.Primitives;

namespace Ordering.Domain.Abstraction;

public interface IReadOnlyRepository<T> where T : Entity
{
    protected Task<IReadOnlyList<T>> GetAllAsync();
    protected Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    protected Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);
    protected Task<T> GetAsync(Guid id);
}