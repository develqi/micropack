namespace Micropack.Localization
{
    public class ValidationTranslation : TranslationProfile
    {
        public ValidationTranslation()
        {
            ValidationForKey("RequiredValidationMessage").FaMessage("وارد کردن این فیلد اجباری است").EnMessage("This filed is required.");

            ValidationForKey("MaxLengthValidationMessage")
                .FaMessage("حداکثر تعداد کاراکتر مجاز برای فیلد '{0}' {1} میباشد")
                .EnMessage("Maximum lentgh for field '{0}' is {1}");
        }

        //ToDo: initial translation cash and read from cash ro database
        public string RequiredValidationMessage => "";
    }
}
