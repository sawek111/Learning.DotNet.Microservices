using MediatR;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public sealed record UpdateOrderCommand(Guid OrderId, double Price, string UserName) : IRequest<bool>;