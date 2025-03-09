using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ItemCarts
{
    public class ItemCartRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}