using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
        RuleFor(r => r.Title).NotEmpty().Length(3, 50);
        RuleFor(r => r.Price).GreaterThan(0);
        RuleFor(r => r.Description).NotEmpty().Length(3, 200);
        RuleFor(r => r.Category).NotEmpty().Length(3, 50);
    }
}