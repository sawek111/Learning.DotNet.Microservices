using FluentValidation;

namespace Ordering.Application.Orders.Commands.CheckoutOrder;

public sealed class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required")
            .NotNull()
            .MinimumLength(50).WithMessage("Username must be at least 50 characters long");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .NotNull();
    }
}