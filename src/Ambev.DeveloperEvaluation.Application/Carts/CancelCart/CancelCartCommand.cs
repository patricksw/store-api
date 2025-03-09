using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.CancelCart;

public record CancelCartCommand : IRequest<CancelCartResponse>
{
    public Guid Id { get; }

    public CancelCartCommand(Guid id) { Id = id; }
}