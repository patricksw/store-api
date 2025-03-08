using AutoMapper;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        CreateMap<Guid, Application.Products.GetProduct.GetProductCommand>()
            .ConstructUsing(id => new Application.Products.GetProduct.GetProductCommand(id));

        CreateMap<Application.Products.GetProduct.GetProductResult, GetProductResponse>();
    }
}