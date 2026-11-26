using System.Text;

namespace FizzBuzz;

/// <summary>
/// Processes input text and replaces every third word with Fizz,
/// every fifth word with Buzz, and every fifteenth word with FizzBuzz.
/// Preserves the original punctuation and whitespace.
/// </summary>
public class FizzBuzzDetector {
  private const int _fizzDivisor = 3;
  private const int _buzzDivisor = 5;
  private const char _apostrophe = '\'';
  private const char _typographicApostrophe = '\u2019';

  /// <summary>
  /// Replaces words according to their position and returns the result with the replacement counts.
  /// </summary>
  public FizzBuzzResult GetOverlappings(string input) {
    var result = new StringBuilder(input.Length);
    var currentWord = new StringBuilder();
    char? pendingApostrophe = null;
    int wordPosition = 0;
    int fizzCount = 0;
    int buzzCount = 0;
    int fizzBuzzCount = 0;

    foreach (char ch in input) {
      if (IsWordChar(ch)) {
        if (pendingApostrophe.HasValue) {
          currentWord.Append(pendingApostrophe.Value);
          pendingApostrophe = null;
        }

        currentWord.Append(ch);
      } else if (IsInternalApostrophe(ch, currentWord, pendingApostrophe)) {
        pendingApostrophe = ch;
      } else {
        FlushWord(currentWord, result, ref wordPosition, ref fizzCount, ref buzzCount, ref fizzBuzzCount);

        if (pendingApostrophe.HasValue) {
          result.Append(pendingApostrophe.Value);
          pendingApostrophe = null;
        }

        result.Append(ch);
      }
    }

    FlushWord(currentWord, result, ref wordPosition, ref fizzCount, ref buzzCount, ref fizzBuzzCount);

    if (pendingApostrophe.HasValue) {
      result.Append(pendingApostrophe.Value);
    }

    return new FizzBuzzResult(result.ToString(), fizzCount, buzzCount, fizzBuzzCount);
  }

  /// <summary>
  /// Processes the current word, applies the appropriate replacement, and updates the counters.
  /// </summary>
  private static void FlushWord(StringBuilder currentWord, StringBuilder result, ref int wordPosition, ref int fizzCount, ref int buzzCount, ref int fizzBuzzCount) {
    if (currentWord.Length == 0) {
      return;
    }

    wordPosition++;

    bool isFizz = wordPosition % _fizzDivisor == 0;
    bool isBuzz = wordPosition % _buzzDivisor == 0;

    if (isFizz && isBuzz) {
      result.Append("FizzBuzz");
      fizzBuzzCount++;
    } else if (isFizz) {
      result.Append("Fizz");
      fizzCount++;
    } else if (isBuzz) {
      result.Append("Buzz");
      buzzCount++;
    } else {
      result.Append(currentWord);
    }

    currentWord.Clear();
  }

  /// <summary>
  /// Checks whether a character is a letter or a digit.
  /// </summary>
  private static bool IsWordChar(char ch) {
    return char.IsLetterOrDigit(ch);
  }

  /// <summary>
  /// Checks whether an apostrophe belongs inside the current word.
  /// </summary>
  private static bool IsInternalApostrophe(char ch, StringBuilder currentWord, char? pendingApostrophe) {
    return IsApostrophe(ch) && currentWord.Length > 0 && !pendingApostrophe.HasValue;
  }

  /// <summary>
  /// Checks whether a character is a regular or typographic apostrophe.
  /// </summary>
  private static bool IsApostrophe(char ch) {
    return ch == _apostrophe || ch == _typographicApostrophe;
  }
}