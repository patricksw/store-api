using FluentValidation;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartValidator()
    {
        RuleFor(e => e.UserId).NotEmpty();
        RuleFor(e => e.Products.Count()).GreaterThan(0);
    }
}