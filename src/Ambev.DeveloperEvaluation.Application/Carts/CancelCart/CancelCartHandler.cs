using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.CancelCart;

public class CancelCartHandler : IRequestHandler<CancelCartCommand, CancelCartResponse>
{
    private readonly ICartRepository _cartRepository;

    public CancelCartHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CancelCartResponse> Handle(CancelCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new CancelCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _cartRepository.CancelAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

        return new CancelCartResponse { Success = true };
    }
}