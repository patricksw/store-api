using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(r => r.Title).NotEmpty().Length(3, 50);
        RuleFor(r => r.Price).GreaterThan(0);
        RuleFor(r => r.Description).NotEmpty().Length(3, 200);
        RuleFor(r => r.Category).NotEmpty().Length(3, 50);
    }
}