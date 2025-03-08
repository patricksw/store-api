using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductCategory;

public class GetProductCategoryProfile : Profile
{
    public GetProductCategoryProfile()
    {
        CreateMap<string, Application.Products.GetProductCategory.GetProductCategoryCommand>()
            .ConstructUsing(category => new Application.Products.GetProductCategory.GetProductCategoryCommand(category));
    }
}