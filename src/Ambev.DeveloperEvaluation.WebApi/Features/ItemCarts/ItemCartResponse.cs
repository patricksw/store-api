using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ItemCarts
{
    public class ItemCartResponse
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalItemAmount { get; set; }
    }
}