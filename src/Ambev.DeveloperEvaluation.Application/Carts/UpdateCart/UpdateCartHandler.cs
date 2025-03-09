using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateCartHandler(ICartRepository cartRepository,
                             IMapper mapper,
                             IProductRepository productRepository,
                             IUserRepository userRepository)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public async Task<UpdateCartResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = _mapper.Map<Cart>(command);
        cart.CalculateTotals();

        var cartValidation = new CartValidator();
        var cartValidationResult = await cartValidation.ValidateAsync(cart, cancellationToken);
        if (!cartValidationResult.IsValid)
            throw new ValidationException(cartValidationResult.Errors);

        _ = await _userRepository.GetByIdAsync(cart.UserId, cancellationToken) ??
            throw new InvalidOperationException($"User does not exist");

        if (!await _productRepository.IsContainsProductIdsAsync(cart.Products.Select(o => o.ProductId), cancellationToken))
            throw new InvalidOperationException("There are products in the cart that do not exist in the database");

        var updatedCart = await _cartRepository.UpdateAsync(cart, cancellationToken);
        var result = _mapper.Map<UpdateCartResult>(updatedCart);
        return result;
    }
}