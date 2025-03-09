using Ambev.DeveloperEvaluation.WebApi.Features.ItemCarts;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartResponse
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public IEnumerable<ItemCartResponse> Products { get; set; } = [];
}