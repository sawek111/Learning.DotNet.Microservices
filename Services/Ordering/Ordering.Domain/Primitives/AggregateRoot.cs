namespace Ordering.Domain.Primitives;

public abstract class AggregateRoot : Entity
{
    public AggregateRoot(Guid id) : base(id)
    {
    }
}