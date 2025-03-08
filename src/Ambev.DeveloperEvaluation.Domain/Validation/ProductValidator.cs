using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(e => e.Title).Length(3, 50);
        RuleFor(e => e.Price).GreaterThan(0);
        RuleFor(e => e.Description).Length(3, 200);
        RuleFor(e => e.Category).Length(3, 50);
    }
}