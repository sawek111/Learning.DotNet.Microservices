using Catalog.Domain.Common.Exception;

namespace Catalog.Domain.Product.Exceptions;

public sealed class ProductNotFoundException : DomainException
{
    public ProductNotFoundException(string message) : base(message)
    {
    }
}