using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ItemCart : BaseEntity
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalItemAmount { get; set; }

    public void CalculateTotalItemAmount() { TotalItemAmount = UnitPrice * Quantity; }
    public void CalculateDiscounts()
    {
        Discount = Quantity switch
        {
            >= 10 and <= 20 => 0.20m * UnitPrice * Quantity,
            >= 4 => 0.10m * UnitPrice * Quantity,
            _ => 0
        };
    }

    public virtual Product Product { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new ItemCartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}