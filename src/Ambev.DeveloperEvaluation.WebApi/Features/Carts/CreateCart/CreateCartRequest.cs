using Ambev.DeveloperEvaluation.WebApi.Features.ItemCarts;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int Branch { get; set; } = 0;
    public IEnumerable<ItemCartRequest> Products { get; set; } = [];
}