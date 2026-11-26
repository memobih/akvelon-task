namespace FizzBuzz;

public static class FizzBuzzInputValidator {
  public const int MinLength = 7;
  public const int MaxLength = 100;

  public static void Validate(string input) {
    if (input is null) {
      throw new ArgumentNullException(nameof(input));
    }

    if (input.Length < MinLength || input.Length > MaxLength) {
      throw new ArgumentOutOfRangeException(
          nameof(input),
          input.Length,
          $"Input length must be between {MinLength} and {MaxLength} characters.");
    }
  }
}
