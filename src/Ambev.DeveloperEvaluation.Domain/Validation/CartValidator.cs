using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(e => e.Products.Count()).GreaterThan(0);
        RuleFor(e => e.Branch).GreaterThan(0);
        RuleFor(e => e.TotalSaleAmount).GreaterThanOrEqualTo(0);
        RuleForEach(e => e.Products).SetValidator(new ItemCartValidator());
    }
}