using AutoMapper;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<Guid, Application.Carts.GetCart.GetCartCommand>()
            .ConstructUsing(id => new Application.Carts.GetCart.GetCartCommand(id));

        CreateMap<Application.Carts.GetCart.GetCartResult, GetCartResponse>();
    }
}