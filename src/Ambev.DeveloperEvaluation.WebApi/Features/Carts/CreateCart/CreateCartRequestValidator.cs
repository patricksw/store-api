using FluentValidation;
using System.Linq;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(e => e.UserId).NotEmpty();
        RuleFor(e => e.Products.Count()).GreaterThan(0);
        RuleFor(e => e.Branch).GreaterThan(0);
    }
}