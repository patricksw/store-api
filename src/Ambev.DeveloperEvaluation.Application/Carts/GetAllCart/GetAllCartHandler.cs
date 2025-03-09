using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart;

public class GetAllCartHandler : IRequestHandler<GetAllCartCommand, IEnumerable<GetCartResult>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public GetAllCartHandler(ICartRepository productRepository, IMapper mapper)
    {
        _cartRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetCartResult>> Handle(GetAllCartCommand request, CancellationToken cancellationToken)
    {
        var product = await _cartRepository.GetAllAsync(cancellationToken) ??
            throw new KeyNotFoundException($"Carts not found");

        return _mapper.Map<IEnumerable<GetCartResult>>(product);
    }
}