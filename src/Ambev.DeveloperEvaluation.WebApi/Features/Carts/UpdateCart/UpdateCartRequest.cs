using Ambev.DeveloperEvaluation.WebApi.Features.ItemCarts;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartRequest
{
    public Guid Id { get; private set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int Branch { get; set; } = 0;
    public decimal TotalSaleDiscounts { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public IEnumerable<ItemCartRequest> Products { get; set; } = [];

    public void SetId(Guid id) { Id = id; }
}