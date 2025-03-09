using Ambev.DeveloperEvaluation.Application.ItemCarts;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<ItemCartResult> Products { get; set; }
        public int Branch { get; set; }
        public bool Cancelled { get; set; }
        public decimal TotalSaleDiscounts { get; set; }
        public decimal TotalSaleAmount { get; set; }
    }
}