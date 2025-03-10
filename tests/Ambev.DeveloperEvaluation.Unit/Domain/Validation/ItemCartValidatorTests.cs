using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class ItemCartValidatorTests
{
    private readonly ItemCartValidator _validator;

    public ItemCartValidatorTests()
    {
        _validator = new ItemCartValidator();
    }

    [Fact(DisplayName = "Valid item cart should pass validation")]
    public void Given_ValidItemCart_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var itemCart = ItemCartTestData.GenerateValidItemCart();

        // Act
        var result = _validator.TestValidate(itemCart);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}