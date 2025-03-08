using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllCategoryProduct;

public class GetAllCategoryProductHandler : IRequestHandler<GetAllCategoryProductCommand, IEnumerable<string>>
{
    private readonly IProductRepository _productRepository;

    public GetAllCategoryProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<string>> Handle(GetAllCategoryProductCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllCategoriesAsync(cancellationToken);
    }
}