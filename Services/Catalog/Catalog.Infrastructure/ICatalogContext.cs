using Catalog.Domain;
using Catalog.Domain.Product;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public interface ICatalogContext
{
    public IMongoCollection<Product> Products { get; }
}