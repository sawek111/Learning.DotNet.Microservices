using Catalog.Domain.Common.Primitives;

namespace Catalog.Domain.Product;

public sealed class Product : Entity
{
    public Product(Guid id, string name, string category, string summary, string description, string imageFile,
        decimal price) : base(id)
    {
        Name = name;
        Category = category;
        Summary = summary;
        Description = description;
        ImageFile = imageFile;
        Price = price;
    }

    public string Name { get; private set; }
    public string Category { get; private set; }
    public string Summary { get; private set; }
    public string Description { get; private set; }
    public string ImageFile { get; private set; }
    public decimal Price { get; private set; }
}