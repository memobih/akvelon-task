# FizzBuzz Detector

A simple C# (.NET 8) console solution for the FizzBuzz word-replacement challenge.

## What It Does

- Reads an input string (7 to 100 characters) and validates it before processing.
- Replaces every **3rd** alphanumeric word with `Fizz`, every **5th** with `Buzz`, and every **15th** with `FizzBuzz`.
- Keeps all punctuation, whitespace, and internal apostrophes (`'` / `’`) intact.
- Counts `Fizz`, `Buzz`, and `FizzBuzz` occurrences independently (`FizzBuzz` does not increment `Fizz` or `Buzz`).

## Approach

- **Validation separated from logic**: `FizzBuzzInputValidator` checks for `null` and length bounds (`7..100`) before `FizzBuzzDetector` runs.
- **Single-pass character scan**: `FizzBuzzDetector` iterates through the input once with `foreach` and builds the output using `StringBuilder` ($O(n)$ time, $O(n)$ space).
- **Word detection**: Letters and digits form words; apostrophes are kept inside a word only when followed by another letter or digit.

## Project Structure

```text
.
├── FizzBuzz/
│   ├── FizzBuzz.csproj
│   ├── Program.cs
│   ├── FizzBuzzInputValidator.cs
│   ├── FizzBuzzDetector.cs
│   └── FizzBuzzResult.cs
├── FizzBuzz.Tests/
│   ├── FizzBuzz.Tests.csproj
│   ├── FizzBuzzDetectorTests.cs
│   └── FizzBuzzInputValidatorTests.cs
├── FizzBuzzSolution.sln
└── README.md
```

## Run & Test

```bash
dotnet run --project FizzBuzz
dotnet test FizzBuzzSolution.sln
```
