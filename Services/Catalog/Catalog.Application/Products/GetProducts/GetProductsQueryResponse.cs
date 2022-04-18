using Catalog.Domain;

namespace Catalog.Application.Products.GetProducts;

public class GetProductsQueryResponse {
    public Product[] Products { get; private set; }
}
