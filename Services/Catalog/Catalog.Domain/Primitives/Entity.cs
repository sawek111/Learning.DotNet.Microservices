namespace Catalog.Domain.Primitives;

public abstract class Entity
{
    private const int PrimeNumber = 37;

    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private init; }

    public static bool operator ==(Entity? first, Entity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Entity? first, Entity? second)
    {
        return !(first == second);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }

    protected bool Equals(Entity other)
    {
        return other.GetType() == GetType() && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * PrimeNumber;
    }
}