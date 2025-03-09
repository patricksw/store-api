using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ItemCarts
{
    public class ItemCartResponse
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}