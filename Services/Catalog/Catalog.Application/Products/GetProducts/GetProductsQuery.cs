using MediatR;

namespace Catalog.Application.Products.GetProducts;

public class GetProductsQuery : IRequest<GetProductsQueryResponse>
{
}