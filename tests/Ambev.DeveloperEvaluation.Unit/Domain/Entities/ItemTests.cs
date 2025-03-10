using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class ItemTests
    {
        [Theory(DisplayName = "Given a item cart when apply discount must specification rule")]
        [InlineData(1, 1, 0)]
        [InlineData(10, 2, 0)]
        [InlineData(50, 3, 0)]
        [InlineData(100, 4, 40)] // 10% discount
        [InlineData(300, 10, 600)] // 20% discount
        [InlineData(500, 20, 2000)] // 20% discount
        public void Given_ItemCart_When_ApplyDiscout_Then_ShouldRule(decimal unitPrice, int quantity, decimal discount)
        {
            // Arrange
            var itemCart = new ItemCart()
            {
                UnitPrice = unitPrice,
                Quantity = quantity
            };

            // Act
            itemCart.CalculateDiscounts();

            // Assert
            itemCart.Discount.Should().Be(discount);
        }
    }
}