using MediatR;
using Ordering.Contracts;
using Ordering.Domain.Orders;

namespace Ordering.Application.Orders.Query.GetOrders;

public sealed class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IReadOnlyList<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<IReadOnlyList<OrderResponse>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        return _orderRepository.GetOrdersByUserNameAsync<OrderResponse>(query.Name);
    }
}