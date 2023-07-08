using MediatR;
using Ordering.Contracts;

namespace Ordering.Application.Order.Query.GetOrders;

public sealed record GetOrdersQuery(string Name) : IRequest<IReadOnlyList<OrderResponse>>;