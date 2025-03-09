using System;

namespace Ambev.DeveloperEvaluation.Application.ItemCarts
{
    public class ItemCartResult
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalItemAmount { get; set; }
    }
}