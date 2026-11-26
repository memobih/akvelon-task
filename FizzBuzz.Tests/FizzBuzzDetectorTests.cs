using Xunit;

namespace FizzBuzz.Tests;

public class FizzBuzzDetectorTests {
  private readonly FizzBuzzDetector _detector = new();

  // Tests that input with less than three words stays unchanged.
  [Fact]
  public void GetOverlappings_LessThanThreeWords_ReturnsOriginal() {
    var result = _detector.GetOverlappings("a b");

    Assert.Equal("a b", result.Output);
    Assert.Equal(0, result.FizzCount);
    Assert.Equal(0, result.BuzzCount);
    Assert.Equal(0, result.FizzBuzzCount);
  }

  // Tests that every third word is replaced with Fizz.
  [Fact]
  public void GetOverlappings_ThirdWord_ReturnsFizz() {
    var result = _detector.GetOverlappings("a b c");

    Assert.Equal("a b Fizz", result.Output);
    Assert.Equal(1, result.FizzCount);
  }

  // Tests that every fifth word is replaced with Buzz.
  [Fact]
  public void GetOverlappings_FifthWord_ReturnsBuzz() {
    var result = _detector.GetOverlappings("a b c d e");

    Assert.Equal("a b Fizz d Buzz", result.Output);
    Assert.Equal(1, result.FizzCount);
    Assert.Equal(1, result.BuzzCount);
  }

  // Tests that the fifteenth word is replaced with FizzBuzz.
  [Fact]
  public void GetOverlappings_FifteenthWord_ReturnsFizzBuzz() {
    var result = _detector.GetOverlappings("a b c d e f g h i j k l m n o");

    Assert.Equal("a b Fizz d Buzz Fizz g h Fizz Buzz k Fizz m n FizzBuzz", result.Output);
    Assert.Equal(4, result.FizzCount);
    Assert.Equal(2, result.BuzzCount);
    Assert.Equal(1, result.FizzBuzzCount);
  }

  // Tests that replacements and counters work correctly for multiple words.
  [Fact]
  public void GetOverlappings_MultipleWords_ReturnsCorrectCounts() {
    var result = _detector.GetOverlappings("a b c d e f g h i j");

    Assert.Equal("a b Fizz d Buzz Fizz g h Fizz Buzz", result.Output);
    Assert.Equal(3, result.FizzCount);
    Assert.Equal(2, result.BuzzCount);
    Assert.Equal(0, result.FizzBuzzCount);
  }

  // Tests that punctuation is preserved after replacing a word.
  [Fact]
  public void GetOverlappings_PreservesPunctuation() {
    var result = _detector.GetOverlappings("a, b! c?");

    Assert.Equal("a, b! Fizz?", result.Output);
    Assert.Equal(1, result.FizzCount);
  }

  // Tests that spaces, tabs, and new lines are preserved.
  [Fact]
  public void GetOverlappings_PreservesWhitespace() {
    var result = _detector.GetOverlappings("a  b\tc\nd");

    Assert.Equal("a  b\tFizz\nd", result.Output);
    Assert.Equal(1, result.FizzCount);
  }

  // Tests that an apostrophe inside a word does not split it.
  [Fact]
  public void GetOverlappings_HandlesApostrophes() {
    var result = _detector.GetOverlappings("a b don't c");

    Assert.Equal("a b Fizz c", result.Output);
    Assert.Equal(1, result.FizzCount);
  }

  // Tests that curly apostrophes inside a word are handled correctly.
  [Fact]
  public void GetOverlappings_HandlesSmartApostrophes() {
    var result = _detector.GetOverlappings("a b don’t c");

    Assert.Equal("a b Fizz c", result.Output);
    Assert.Equal(1, result.FizzCount);
  }

  // Tests that numbers are counted as words.
  [Fact]
  public void GetOverlappings_HandlesDigits() {
    var result = _detector.GetOverlappings("a b 123 d 456");

    Assert.Equal("a b Fizz d Buzz", result.Output);
    Assert.Equal(1, result.FizzCount);
    Assert.Equal(1, result.BuzzCount);
  }

  // Tests that a hyphen separates two words.
  [Fact]
  public void GetOverlappings_HandlesHyphens() {
    var result = _detector.GetOverlappings("a-b c d");

    Assert.Equal("a-b Fizz d", result.Output);
    Assert.Equal(1, result.FizzCount);
  }

  // Tests that input containing only spaces remains unchanged.
  [Fact]
  public void GetOverlappings_HandlesEmptyWords() {
    var result = _detector.GetOverlappings("       ");

    Assert.Equal("       ", result.Output);
    Assert.Equal(0, result.FizzCount);
    Assert.Equal(0, result.BuzzCount);
    Assert.Equal(0, result.FizzBuzzCount);
  }
}