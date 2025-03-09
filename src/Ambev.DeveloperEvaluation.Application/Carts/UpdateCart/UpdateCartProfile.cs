using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartProfile : Profile
{
    public UpdateCartProfile()
    {
        CreateMap<UpdateCartCommand, Cart>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        CreateMap<Cart, UpdateCartResult>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
    }
}