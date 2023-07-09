using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain;
using Ordering.Domain.Email;
using Ordering.Domain.Orders;

namespace Ordering.Application.Orders.Commands.CheckoutOrder;

public sealed class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;
    private readonly ILogger<CheckoutOrderCommandHandler> _logger;

    public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IUserService userService, IEmailService emailService, ILogger<CheckoutOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository;
        _userService = userService;
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<Guid> Handle(CheckoutOrderCommand command, CancellationToken cancellationToken)
    {
        // TODO verify flow
        var userName = _userService.GetCurrentUserName();
        // TODO verify why namespace issue
        var order = Ordering.Domain.Orders.Order.Create(command.Price, userName);
        await _orderRepository.AddAsync(order);

        _logger.LogInformation("Order {OrderId} is created successfully", order.Id);

        await _emailService.SendEmailAsync(new Email("sawek111@gmail.com", "Test", $"Test message{order.Id} + {order.Price}"));
        
        return order.Id;
    }
}