using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Email;
using Ordering.Domain.Orders;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public sealed class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<UpdateOrderCommandHandler> _logger;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, ILogger<UpdateOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(command.OrderId);
        
        if (order is null)
        {
            _logger.LogError("Order {OrderId} is not found", command.OrderId);
            throw new OrderNotFoundException(command.OrderId);
        }
        order.UpdateBase(command.Price, command.UserName);
        return await UpdateOrder(order);
    }

    private async Task<bool> UpdateOrder(Domain.Orders.Order order)
    {
        try
        {
            await _orderRepository.UpdateAsync(order);
            _logger.LogInformation("Order {OrderId} is successfully updated", order.Id);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}