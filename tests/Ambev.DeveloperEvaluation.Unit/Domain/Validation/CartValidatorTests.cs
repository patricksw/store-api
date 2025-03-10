using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class CartValidatorTests
{
    private readonly CartValidator _validator;

    public CartValidatorTests()
    {
        _validator = new CartValidator();
    }

    [Fact(DisplayName = "Valid cart should pass validation")]
    public void Given_ValidCart_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var cart = CartTestData.GenerateValidCart();

        // Act
        var result = _validator.TestValidate(cart);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
