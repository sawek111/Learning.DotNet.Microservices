
using Core.Application;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public sealed record DeleteOrderCommand(Guid OrderId) : IRequest<bool>;