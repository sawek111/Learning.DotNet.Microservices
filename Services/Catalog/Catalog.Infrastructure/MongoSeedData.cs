using Catalog.Domain;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public class MongoSeedData
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        var products = new List<Product>()
        {
            new Product(Guid.NewGuid(), "Product1", "Common", "Summary1", "Description1", "Product1.png", 1.0M),
            new Product(Guid.NewGuid(), "Product2", "Common", "Summary2", "Description2", "Product2.png", 2.0M),
            new Product(Guid.NewGuid(), "Product3", "Common", "Summary3", "Description3", "Product3.png", 3.0M),
            new Product(Guid.NewGuid(), "Product4", "Common", "Summary4", "Description4", "Product4.png", 4.0M),
            new Product(Guid.NewGuid(), "Product5", "Common", "Summary5", "Description5", "Product5.png", 5.0M),
            new Product(Guid.NewGuid(), "Product6", "Common", "Summary6", "Description6", "Product6.png", 6.0M),
        };
        productCollection.InsertMany(products);
    }
}