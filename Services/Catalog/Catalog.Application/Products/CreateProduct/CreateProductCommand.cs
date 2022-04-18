using MediatR;

namespace Catalog.Application.Products.CreateProduct;

public class CreateProductCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}