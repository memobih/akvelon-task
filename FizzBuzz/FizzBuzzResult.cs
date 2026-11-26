namespace FizzBuzz;

public sealed class FizzBuzzResult {
  public FizzBuzzResult(string output, int fizzCount, int buzzCount, int fizzBuzzCount) {
    ArgumentNullException.ThrowIfNull(output);
    ArgumentOutOfRangeException.ThrowIfNegative(fizzCount);
    ArgumentOutOfRangeException.ThrowIfNegative(buzzCount);
    ArgumentOutOfRangeException.ThrowIfNegative(fizzBuzzCount);

    Output = output;
    FizzCount = fizzCount;
    BuzzCount = buzzCount;
    FizzBuzzCount = fizzBuzzCount;
  }

  public string Output { get; }

  public int FizzCount { get; }

  public int BuzzCount { get; }

  public int FizzBuzzCount { get; }
}
