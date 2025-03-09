using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.ItemCarts;

public class ItemCartProfile : Profile
{
    public ItemCartProfile()
    {
        CreateMap<ItemCartCommand, ItemCart>();
        CreateMap<ItemCart, ItemCartResult>();
    }
}