using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductCategory;

public class GetProductCategoryRequestValidator : AbstractValidator<GetProductCategoryRequest>
{
    public GetProductCategoryRequestValidator()
    {
        RuleFor(x => x.Category).NotEmpty().WithMessage("Product Category is required");
    }
}