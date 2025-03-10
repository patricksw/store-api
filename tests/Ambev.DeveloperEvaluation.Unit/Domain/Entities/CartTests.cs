using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class CartTests
    {
        [Fact(DisplayName = "Given itens cart on cart must group identicals products")]
        public void Given_ItensCart_When_Calculation_Then_ShouldAggregateQuantities()
        {
            // Arrange
            var cart = new Cart()
            {
                Products =
                [
                    new() { ProductId = Guid.NewGuid(), Quantity = 1, UnitPrice = 10 },
                    new() { ProductId = new Guid("6C5183C7-4717-478F-B32B-A98308DE7CA7"), Quantity = 2, UnitPrice = 10 },
                    new() { ProductId = new Guid("6C5183C7-4717-478F-B32B-A98308DE7CA7"), Quantity = 1, UnitPrice = 10 }
                ],
            };

            // Act
            cart.CalculateTotals();

            // Assert
            cart.Products.Count().Should().Be(2);
            cart.Products.First().Quantity.Should().Be(1);
            cart.Products.Last().Quantity.Should().Be(3);
        }
    }
}