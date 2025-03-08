using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public record DeleteCartCommand : IRequest<DeleteCartResponse>
{
    public Guid Id { get; }

    public DeleteCartCommand(Guid id) { Id = id; }
}