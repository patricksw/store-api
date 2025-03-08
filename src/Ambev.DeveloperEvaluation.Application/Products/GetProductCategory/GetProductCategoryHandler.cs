using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductCategory;

public class GetProductCategoryHandler : IRequestHandler<GetProductCategoryCommand, IEnumerable<GetProductResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductCategoryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductResult>> Handle(GetProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByCategoryAsync(request.Category, cancellationToken) ??
            throw new KeyNotFoundException($"Products not found");

        return _mapper.Map<IEnumerable<GetProductResult>>(product);
    }
}