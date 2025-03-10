using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class CartTestData
{
    private static readonly Faker<Cart> CartFaker = new Faker<Cart>()
        .RuleFor(u => u.Branch, f => f.Random.Number(1, 999))
        .RuleFor(u => u.TotalSaleAmount, f => f.Random.Decimal(0, 999999999))
        .RuleFor(u => u.Products, f => [.. ItemCartTestData.GenerateValidItemCartList(f.Random.Int(1, 10))]);

    public static Cart GenerateValidCart()
    {
        return CartFaker.Generate();
    }
}