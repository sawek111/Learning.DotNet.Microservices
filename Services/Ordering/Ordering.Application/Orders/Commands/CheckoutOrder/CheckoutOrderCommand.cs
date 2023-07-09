using MediatR;

namespace Ordering.Application.Orders.Commands.CheckoutOrder;

public sealed record CheckoutOrderCommand(double Price, string UserName) : IRequest<Guid>;