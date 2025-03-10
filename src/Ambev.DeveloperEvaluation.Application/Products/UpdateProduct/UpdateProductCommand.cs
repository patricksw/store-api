using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdateProductResult>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Rating Rating { get; set; }
}