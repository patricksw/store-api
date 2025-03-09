﻿using Ambev.DeveloperEvaluation.Application.ItemCarts;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommand : IRequest<CreateCartResult>
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int Branch { get; set; } = 0;
    public decimal TotalSaleDiscounts { get; set; }
    public decimal TotalSaleAmount { get; set; }

    public IEnumerable<ItemCartCommand> Products { get; set; } = [];

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}