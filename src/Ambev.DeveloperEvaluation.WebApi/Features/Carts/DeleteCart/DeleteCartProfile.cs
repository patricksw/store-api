using AutoMapper;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

public class DeleteCartProfile : Profile
{
    public DeleteCartProfile()
    {
        CreateMap<Guid, Application.Carts.DeleteCart.DeleteCartCommand>()
            .ConstructUsing(id => new Application.Carts.DeleteCart.DeleteCartCommand(id));
    }
}