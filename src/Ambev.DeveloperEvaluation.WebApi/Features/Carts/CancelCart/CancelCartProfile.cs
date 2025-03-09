using AutoMapper;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CancelCart;

public class CancelCartProfile : Profile
{
    public CancelCartProfile()
    {
        CreateMap<Guid, Application.Carts.CancelCart.CancelCartCommand>()
            .ConstructUsing(id => new Application.Carts.CancelCart.CancelCartCommand(id));
    }
}