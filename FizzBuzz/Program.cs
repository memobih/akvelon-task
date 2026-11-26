namespace FizzBuzz;

internal class Program {
  private static int Main() {
    Console.Write("Enter text: ");
    string? input = Console.ReadLine();

    try {
      FizzBuzzInputValidator.Validate(input!);
    } catch (ArgumentException ex) {
      Console.Error.WriteLine($"Invalid input: {ex.Message}");
      return 1;
    }

    var detector = new FizzBuzzDetector();
    FizzBuzzResult result = detector.GetOverlappings(input!);

    Console.WriteLine($"Output: {result.Output}");
    Console.WriteLine($"Fizz: {result.FizzCount}");
    Console.WriteLine($"Buzz: {result.BuzzCount}");
    Console.WriteLine($"FizzBuzz: {result.FizzBuzzCount}");

    return 0;
  }
}
