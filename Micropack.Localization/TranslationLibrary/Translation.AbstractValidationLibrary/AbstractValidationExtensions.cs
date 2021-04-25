using FluentValidation;

namespace Micropack.Localization
{
    public static class AbstractValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> IsRequiredhWithTranslateMessage<T>(this IRuleBuilder<T, string> ruleBuilder, string key = "RequiredValidationMessage")
        {
            if (key is null)
                throw new System.ArgumentNullException(nameof(key));

            //ToDo: read Required key from cash
            var message = "";

            return ruleBuilder.NotNull().WithMessage(message);
        }

        public static IRuleBuilderOptions<T, string> MaximumLengthWithTranslateMessage<T>(this IRuleBuilder<T, string> ruleBuilder, int maximumLength, string key = "MaxLengthValidationMessage")
        {
            if (key is null)
                throw new System.ArgumentNullException(nameof(key));
            
            //ToDo: read MaxLength key from cash
            var message = "";

            return ruleBuilder.MaximumLength(maximumLength).WithMessage(message);
        }
    }
}
