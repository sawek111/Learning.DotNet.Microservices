using Catalog.Domain;
using Catalog.Domain.Product;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public class CatalogContext : ICatalogContext
{
    public CatalogContext(IOptions<MongoDbOptions> mongoDbOptions)
    {
        var options = mongoDbOptions.Value;
        var client = new MongoClient(options.ConnectionString);
        var database = client.GetDatabase(options.Database);

        Products = database.GetCollection<Product>(options.Collection);


        if (Products.Find(p => true).Any())
        {
            return;
        }
        MongoSeedData.SeedData(Products);       
    }

    public IMongoCollection<Product> Products { get; }
}