using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateCartCommand : IRequest<CreateProductResult>
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Rating Rating { get; set; }
}