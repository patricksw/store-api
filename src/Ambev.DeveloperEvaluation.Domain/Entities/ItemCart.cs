using System;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ItemCart
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}