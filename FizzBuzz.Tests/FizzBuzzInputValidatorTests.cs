using Xunit;

namespace FizzBuzz.Tests;

/// <summary>Validation tests for <see cref="FizzBuzzInputValidator"/>.</summary>
public class FizzBuzzInputValidatorTests {
  // Null input throws ArgumentNullException.
  [Fact]
  public void Validate_NullInput_ThrowsArgumentNullException() {
    Assert.Throws<ArgumentNullException>(() => FizzBuzzInputValidator.Validate(null!));
  }

  // Empty string is below minimum length and throws ArgumentOutOfRangeException.
  [Fact]
  public void Validate_EmptyString_ThrowsArgumentOutOfRangeException() {
    Assert.Throws<ArgumentOutOfRangeException>(() => FizzBuzzInputValidator.Validate(""));
  }

  // Input one character below minimum (6 chars) throws ArgumentOutOfRangeException.
  [Theory]
  [InlineData("abcdef")]
  [InlineData("short!")]
  [InlineData("      ")]
  public void Validate_InputShorterThanMinimum_ThrowsArgumentOutOfRangeException(string input) {
    Assert.Throws<ArgumentOutOfRangeException>(() => FizzBuzzInputValidator.Validate(input));
  }

  // Input at exactly the minimum length (7 chars) is accepted without throwing.
  [Fact]
  public void Validate_InputAtMinimumLength_DoesNotThrow() {
    var ex = Record.Exception(() => FizzBuzzInputValidator.Validate("abcdefg"));

    Assert.Null(ex);
  }

  // Input at exactly the maximum length (100 chars) is accepted without throwing.
  [Fact]
  public void Validate_InputAtMaximumLength_DoesNotThrow() {
    string input = new string('a', FizzBuzzInputValidator.MaxLength);

    var ex = Record.Exception(() => FizzBuzzInputValidator.Validate(input));

    Assert.Null(ex);
  }

  // Input one character above maximum (101 chars) throws ArgumentOutOfRangeException.
  [Fact]
  public void Validate_InputLongerThanMaximum_ThrowsArgumentOutOfRangeException() {
    string input = new string('a', FizzBuzzInputValidator.MaxLength + 1);

    Assert.Throws<ArgumentOutOfRangeException>(() => FizzBuzzInputValidator.Validate(input));
  }

  // A valid mid-range input passes without throwing.
  [Fact]
  public void Validate_ValidInput_DoesNotThrow() {
    var ex = Record.Exception(() => FizzBuzzInputValidator.Validate("Mary had a little lamb"));

    Assert.Null(ex);
  }

  // Verifies the public boundary constants carry the expected values.
  [Fact]
  public void Validate_Constants_HaveExpectedValues() {
    Assert.Equal(7, FizzBuzzInputValidator.MinLength);
    Assert.Equal(100, FizzBuzzInputValidator.MaxLength);
  }
}
