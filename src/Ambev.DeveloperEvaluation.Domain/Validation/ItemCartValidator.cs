using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ItemCartValidator : AbstractValidator<ItemCart>
{
    public ItemCartValidator()
    {
        RuleFor(e => e.ProductId).NotEmpty();
        RuleFor(e => e.Quantity).InclusiveBetween(1, 20);
        RuleFor(e => e.UnitPrice).GreaterThan(0);
        RuleFor(e => e.TotalItemAmount).GreaterThan(0);
    }
}