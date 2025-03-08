using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(e => e.UserId).NotEmpty();
        RuleFor(e => e.Products.Count()).GreaterThan(0);
    }
}