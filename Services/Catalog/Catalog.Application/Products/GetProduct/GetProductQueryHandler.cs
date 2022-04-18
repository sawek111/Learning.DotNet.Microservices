using Catalog.Application.Abstraction.Repositories;
using MediatR;

namespace Catalog.Application.Products.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductQueryHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }


    public Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return _productsRepository.GetAsync<GetProductQueryResponse>(request.Id);
    }
}