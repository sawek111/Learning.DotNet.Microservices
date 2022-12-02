using Catalog.Domain;
using Catalog.Domain.Product;

namespace Catalog.Application.Products.GetProducts;

public class GetProductsQueryResponse {
    public Product[] Products { get; private set; }
}
