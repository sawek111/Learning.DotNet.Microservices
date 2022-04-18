namespace Catalog.Infrastructure;

public class MongoDbOptions
{ 
    public const string MongoDb = "MongoDb";
    public string ConnectionString { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public string Collection { get; set; } = string.Empty;
}
    