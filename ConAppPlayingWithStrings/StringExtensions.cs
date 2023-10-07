using System;

namespace ConAppPlayingWithStrings;

public static class StringExtensions
{
    public static string toMask(this string input, int showNumChars, char maskChar = '*') =>
        input[^Math.Min(input.Length, showNumChars)..]
        .PadLeft(input.Length, maskChar);
}
