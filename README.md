# FizzBuzz Detector

A C# / .NET 8 solution implementing the Akvelon **FizzBuzz Detector** coding challenge.

## Overview

`FizzBuzzDetector.GetOverlappings(string input)` scans an input string (7 to 100 characters), identifies 1-indexed alphanumeric words while preserving all original punctuation and whitespace, and replaces:

- Every **3rd** word with `Fizz`
- Every **5th** word with `Buzz`
- Every **15th** word (divisible by both 3 and 5) with `FizzBuzz`

Each replacement increments only its own counter (`FizzCount`, `BuzzCount`, or `FizzBuzzCount`), so a `FizzBuzz` replacement does **not** increment `FizzCount` or `BuzzCount`.

## Word Boundary & Validation Rules

- **Alphanumeric words**: A word is a maximal contiguous sequence of letters and digits (`char.IsLetterOrDigit`), optionally containing internal apostrophes (`'` or `’`) that are immediately flanked by alphanumeric characters (e.g., `It's`, `don't`).
- **Outer quotes & trailing apostrophes**: Leading or trailing apostrophes (e.g., `'don't'` or `dogs'`) are treated as punctuation and preserved in place.
- **Punctuation & whitespace**: All non-word characters (spaces, tabs, newlines, commas, periods, hyphens, consecutive symbols, etc.) are copied directly to the output without advancing the word counter.
- **Input validation**:
  - `null` input throws `ArgumentNullException`.
  - Input with length `< 7` or `> 100` throws `ArgumentOutOfRangeException` (including empty string `""`).
  - Whitespace-only or punctuation-only strings within `[7, 100]` characters are valid and return unchanged with zero counts.

## Algorithm & Complexity

The algorithm uses a single-pass character-by-character scan with a pre-sized `StringBuilder`:

1. Validate `input` for non-null and length bounds (`7 <= |s| <= 100`).
2. Iterate `index` from `0` to `input.Length - 1`:
   - If `input[index]` starts a word (`char.IsLetterOrDigit`), advance `index` across all characters belonging to the word, increment `wordPosition`, and append `FizzBuzz`, `Fizz`, `Buzz`, or the original slice (`StringBuilder.Append(input, start, length)` without allocating substrings).
   - Otherwise, append `input[index]` directly and increment `index`.
3. Return `FizzBuzzResult` with the built string and the three independent counters.

- **Time Complexity**: $O(n)$, where $n$ is `input.Length`. Each character is visited a constant number of times, and appending uses direct buffer copies without intermediate string allocations.
- **Space Complexity**: $O(n)$ for the output `StringBuilder` and resulting string, with $O(1)$ auxiliary working memory.

## Project Structure

```text
.
├── FizzBuzz/
│   ├── FizzBuzz.csproj
│   ├── FizzBuzzDetector.cs
│   └── FizzBuzzResult.cs
├── FizzBuzz.Tests/
│   ├── FizzBuzz.Tests.csproj
│   └── FizzBuzzDetectorTests.cs
├── FizzBuzzSolution.sln
└── README.md
```

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

## Build & Run Tests

From the solution root directory:

```bash
dotnet restore
dotnet build --no-restore
dotnet test --no-build --verbosity normal
```
