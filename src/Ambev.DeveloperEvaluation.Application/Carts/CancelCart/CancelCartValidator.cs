using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CancelCart;

public class CancelCartValidator : AbstractValidator<CancelCartCommand>
{
    public CancelCartValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Cart ID is required");
    }
}