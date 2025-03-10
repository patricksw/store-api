using Ambev.DeveloperEvaluation.Application.ItemCarts;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommand : IRequest<CreateCartResult>
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int Branch { get; set; } = 0;
    public decimal TotalSaleDiscounts { get; set; }
    public decimal TotalSaleAmount { get; set; }

    public IEnumerable<ItemCartCommand> Products { get; set; } = [];
}