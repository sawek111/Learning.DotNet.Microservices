namespace Core.Primitives;

public abstract class AggregateRoot : Entity
{
    public AggregateRoot(Guid id) : base(id)
    {
    }
}