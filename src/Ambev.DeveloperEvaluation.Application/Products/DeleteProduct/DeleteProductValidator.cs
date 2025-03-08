using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
    }
}