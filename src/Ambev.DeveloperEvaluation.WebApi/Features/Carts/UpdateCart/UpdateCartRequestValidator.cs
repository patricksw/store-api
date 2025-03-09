using FluentValidation;
using System.Linq;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
    public UpdateCartRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Cart ID is required");
        RuleFor(e => e.UserId).NotEmpty();
        RuleFor(e => e.Products.Count()).GreaterThan(0);
        RuleFor(e => e.Branch).GreaterThan(0);
    }
}