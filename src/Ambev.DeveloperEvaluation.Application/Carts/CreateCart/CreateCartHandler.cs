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

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateCartHandler(ICartRepository cartRepository,
                             IMapper mapper,
                             IUserRepository userRepository,
                             IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartValidator();
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

        var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
        var result = _mapper.Map<CreateCartResult>(createdCart);
        return result;
    }
}