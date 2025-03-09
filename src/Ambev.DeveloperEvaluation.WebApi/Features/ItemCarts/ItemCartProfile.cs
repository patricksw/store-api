using Ambev.DeveloperEvaluation.Application.ItemCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ItemCarts;

public class ItemCartProfile : Profile
{
    public ItemCartProfile()
    {
        CreateMap<ItemCartRequest, ItemCartCommand>();
        CreateMap<ItemCartResult, ItemCartResponse>();
    }
}