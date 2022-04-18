using Catalog.Application.Abstraction.Repositories;
using MediatR;

namespace Catalog.Application.Products.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsQueryResponse>
{
    private readonly IProductsRepository _productsRepository;
    
    public GetProductsQueryHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public Task<GetProductsQueryResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return _productsRepository.GetAllAsync<GetProductsQueryResponse>();
    }
}