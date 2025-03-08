using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateCartCommand>
{
    public CreateProductValidator()
    {
        RuleFor(c => c.Title).NotEmpty().Length(3, 50);
        RuleFor(c => c.Price).GreaterThan(0);
        RuleFor(c => c.Description).NotEmpty().Length(3, 200);
        RuleFor(c => c.Category).NotEmpty().Length(3, 50);
    }
}