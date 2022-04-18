using Catalog.Domain;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public interface ICatalogContext
{
    public IMongoCollection<Product> Products { get; }
}