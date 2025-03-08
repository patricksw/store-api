using Ambev.DeveloperEvaluation.Domain.Entities;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductRequest
{
    public Guid Id { get; private set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Rating Rating { get; set; }

    public void SetId(Guid id) { Id = id; }
}