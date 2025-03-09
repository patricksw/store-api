using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public int Branch { get; set; }
    public bool Cancelled { get; set; }
    public decimal TotalSaleDiscounts { get; private set; }
    public decimal TotalSaleAmount { get; private set; }

    public IEnumerable<ItemCart> Products { get; set; }
    public virtual User User { get; set; }

    public Cart CalculateTotals()
    {
        GroupItemsByProductId();
        RecalculateItens();
        CalculateTotalSaleAmount();
        CalculateTotalSaleDiscounts();
        return this;
    }

    private void RecalculateItens()
    {
        Products = [.. Products
                  .Select(o =>
                  {
                      o.CalculateTotalItemAmount();
                      o.CalculateDiscounts();
                      return o;
                  })];
    }

    public void CalculateTotalSaleAmount() { TotalSaleAmount = Products.Sum(o => o.TotalItemAmount); }
    public void CalculateTotalSaleDiscounts() { TotalSaleDiscounts = Products.Sum(o => o.Discount); }

    public void GroupItemsByProductId()
    {
        Products = [.. Products
                   .GroupBy(p => p.ProductId)
                   .Select(g => new ItemCart
                   {
                       ProductId = g.Key,
                       Quantity = g.Sum(p => p.Quantity),
                       UnitPrice = g.First().UnitPrice
                   })];
    }

    public ValidationResultDetail Validate()
    {
        var validator = new CartValidator();
        var result = validator.ValidateAsync(this).GetAwaiter().GetResult();
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}