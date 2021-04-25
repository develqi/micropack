using System.Text.RegularExpressions;

namespace Micropack.RegularExpression
{
    public static class StringRegexExtensions
    {
        private static bool IsMatch(string pattern, string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            return new Regex(pattern).IsMatch(input);
        }

        public static bool IsNumeric(this string input) => IsMatch(NumericPatterns.NumericPattern, input);
        
        public static bool IsTenDigitNumericPattern(this string input) => IsMatch(NumericPatterns.TenDigitNumericPattern, input);
        
        public static bool IsElevenDigitNumericPattern(this string input) => IsMatch(NumericPatterns.ElevenDigitNumericPattern, input);
        
        public static bool IsThirteenDigitNumericPattern(this string input) => IsMatch(NumericPatterns.ThirteenDigitNumericPattern, input);
        
        public static bool IsOneToTenDigitsNumericPattern(this string input) => IsMatch(NumericPatterns.OneToTenDigitsNumericPattern, input);
        
        public static bool IsZeroToTwentyDigitsNumericPattern(this string input) => IsMatch(NumericPatterns.ZeroToTwentyDigitsNumericPattern, input);
        
        public static bool IsOnlyPersianLettersAcceptNumericPattern(this string input) => IsMatch(NumericPatterns.OnlyPersianLettersAcceptNumericPattern, input);
    }
}
