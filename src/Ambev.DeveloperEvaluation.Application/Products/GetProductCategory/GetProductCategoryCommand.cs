using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using MediatR;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductCategory;

public class GetProductCategoryCommand : IRequest<IEnumerable<GetProductResult>>
{
    public string Category { get; set; }

    public GetProductCategoryCommand(string category)
    {
        Category = category;
    }
}