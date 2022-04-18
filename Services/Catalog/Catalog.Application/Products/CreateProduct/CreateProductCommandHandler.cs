using Catalog.Application.Abstraction.Repositories;
using MediatR;

namespace Catalog.Application.Products.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IProductsRepository _productsRepository;

    public CreateProductCommandHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _productsRepository.AddAsync(request);
        return Unit.Value;
    }
}