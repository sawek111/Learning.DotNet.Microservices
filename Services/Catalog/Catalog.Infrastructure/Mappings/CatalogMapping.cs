using Catalog.Application.Abstraction;
using Catalog.Domain;
using Catalog.Domain.Product;
using MongoDB.Bson.Serialization;

namespace Catalog.Infrastructure.Mappings;

public class CatalogMapping : IMongoMapper
{
    public void Configure()
    {
        BsonClassMap.RegisterClassMap<Product>(cm =>
        {
            cm.AutoMap();
            cm.MapCreator(p => new Product(p.Id, p.Name, p.Category, p.Summary, p.Description, p.ImageFile, p.Price));
        });
    }
}