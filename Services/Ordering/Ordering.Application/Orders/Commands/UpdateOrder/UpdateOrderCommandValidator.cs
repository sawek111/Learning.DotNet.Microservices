using FluentValidation;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public sealed class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
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