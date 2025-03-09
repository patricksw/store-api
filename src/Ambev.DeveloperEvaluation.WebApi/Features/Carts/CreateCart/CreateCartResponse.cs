using Ambev.DeveloperEvaluation.WebApi.Features.ItemCarts;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartResponse
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int Branch { get; set; } = 0;
    public bool Cancelled { get; set; }
    public decimal TotalSaleDiscounts { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public IEnumerable<ItemCartResponse> Products { get; set; } = [];
}