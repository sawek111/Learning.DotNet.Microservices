using MediatR;

namespace Catalog.Application.Products.GetProduct;

public class GetProductQuery : IRequest<GetProductQueryResponse>
{
    public GetProductQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}