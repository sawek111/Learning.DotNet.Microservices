namespace Catalog.Domain.Common.Exception;

public abstract class DomainException : System.Exception
{
    protected DomainException(string message) : base(message)
    {
    }
}