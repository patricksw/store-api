using System;

namespace Ambev.DeveloperEvaluation.Application.ItemCarts
{
    public class ItemCartCommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}