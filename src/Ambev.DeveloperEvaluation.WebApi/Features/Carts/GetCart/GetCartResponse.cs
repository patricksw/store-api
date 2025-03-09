using Ambev.DeveloperEvaluation.WebApi.Features.ItemCarts;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

public class GetCartResponse
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public int Branch { get; set; }
    public bool Cancelled { get; set; }
    public decimal TotalSaleDiscounts { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public IEnumerable<ItemCartResponse> Products { get; set; }
}