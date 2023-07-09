using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Orders;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<DeleteOrderCommandHandler> _logger;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, ILogger<DeleteOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<bool> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        if (!await _orderRepository.ExistsAsync(command.OrderId))
        {
            _logger.LogError("Order {OrderId} is not found", command.OrderId);
            throw new OrderNotFoundException(command.OrderId);
        }

        try
        {
            await _orderRepository.DeleteAsync(command.OrderId);
            _logger.LogInformation("Order {OrderId} is successfully deleted", command.OrderId);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}