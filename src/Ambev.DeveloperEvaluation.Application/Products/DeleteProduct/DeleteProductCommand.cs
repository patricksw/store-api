using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

public record DeleteProductCommand : IRequest<DeleteProductResponse>
{
    public Guid Id { get; }

    public DeleteProductCommand(Guid id) { Id = id; }
}