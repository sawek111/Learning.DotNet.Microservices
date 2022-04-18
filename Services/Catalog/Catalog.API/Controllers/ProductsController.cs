using Catalog.Application.Products;
using Catalog.Application.Products.GetProduct;
using Catalog.Application.Products.GetProducts;
using Catalog.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<GetProductsQueryResponse> GetProducts()
    {
        return _mediator.Send(new GetProductsQuery());
    }

    [HttpGet("{id:guid}")]
    public Task<GetProductQueryResponse> GetProduct(Guid id)
    {
        return _mediator.Send(new GetProductQuery(id));
    }  

    [HttpPost]
    public CreateProductQueryResponse CreateProduct(Product product)
    {
        productRepository.CreateProduct(product);
    }
}