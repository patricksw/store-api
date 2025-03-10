using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class ItemCartTestData
{
    private static readonly Faker<ItemCart> ItemCartFaker = new Faker<ItemCart>()
        .RuleFor(u => u.ProductId, f => f.Random.Uuid())
        .RuleFor(u => u.Quantity, f => f.Random.Number(1, 20))
        .RuleFor(u => u.UnitPrice, f => f.Random.Decimal(0, 999999999))
        .RuleFor(u => u.TotalItemAmount, f => f.Random.Decimal(0, 999999999));


    public static ItemCart GenerateValidItemCart()
    {
        return ItemCartFaker.Generate();
    }

    public static IEnumerable<ItemCart> GenerateValidItemCartList(int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return ItemCartFaker.Generate();
        }
    }
}
