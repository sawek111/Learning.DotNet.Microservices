using Catalog.Application.Products.CreateProduct;
using Catalog.Application.Products.GetProduct;
using Catalog.Application.Products.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Presentation;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<GetProductsQueryResponse> GetProducts(CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetProductsQuery(), cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public Task<GetProductQueryResponse> GetProduct(Guid id, CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetProductQuery(id), cancellationToken);
    }

    [HttpPost]
    public Task CreateProduct(CreateProductCommand product, CancellationToken cancellationToken)
    {
        return _mediator.Send(product, cancellationToken);
    }
}