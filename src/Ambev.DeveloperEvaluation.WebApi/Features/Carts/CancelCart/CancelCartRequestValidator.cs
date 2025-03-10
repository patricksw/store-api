using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CancelCart;

public class CancelCartRequestValidator : AbstractValidator<CancelCartRequest>
{
    public CancelCartRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Cart ID is required");
    }
}