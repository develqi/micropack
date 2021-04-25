
namespace Micropack.RegularExpression
{
    public class NumericPatterns
    {
        public static string NumericPattern => @"^\d+$";

        public static string TenDigitNumericPattern => @"^\d{10}$";

        public static string ElevenDigitNumericPattern => @"^\d{11}$";

        public static string ThirteenDigitNumericPattern => @"^\d{12}$";

        public static string OneToTenDigitsNumericPattern => @"^\d{1,10}$";

        public static string ZeroToTwentyDigitsNumericPattern => @"^\d{0,20}$";

        public static string OnlyPersianLettersAcceptNumericPattern => @"^[ 0123456789۱۲۳۴۵۶۷۸۹آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی]+$";
    }
}
