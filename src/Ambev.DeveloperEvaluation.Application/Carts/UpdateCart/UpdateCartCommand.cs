using Ambev.DeveloperEvaluation.Application.ItemCarts;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartCommand : IRequest<UpdateCartResult>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public int Branch { get; set; }
    public IEnumerable<ItemCartCommand> Products { get; set; }
}