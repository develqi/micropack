//using FluentValidation;
//using System;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text.RegularExpressions;

//namespace Micropack.Localization.FluentValidation.Extensions
//{
//    public static class LocalizationExtensions
//    {
//        public static IRuleBuilderOptions<T, string> IsRequiredhWithTranslateMessage<T>(this IRuleBuilder<T, string> ruleBuilder, string key = "RequiredValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder
//                .NotNull().WithMessage(GlobalValidations.RequiredValidationMessage)
//                .NotEmpty().WithMessage(GlobalValidations.RequiredValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, string> MaximumLengthWithTranslateMessage<T>(this IRuleBuilder<T, string> ruleBuilder, int maximumLength, string key = "MaxLengthValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.MaximumLength(maximumLength).WithMessage(string.Format(GlobalValidations.MaximumLengthValidationMessage, maximumLength));
//        }

//        public static IRuleBuilderOptions<T, decimal> MaximumLengthWithTranslateMessage<T>(this IRuleBuilder<T, decimal> ruleBuilder, decimal maxLenght, string key = "MaximumLengthValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.InclusiveBetween(0, maxLenght).WithMessage(GlobalValidations.MaximumLengthValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, int?> MaximumValueWithTranslateMessage<T>(this IRuleBuilder<T, int?> ruleBuilder, int maximum, string key = "MaximumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.LessThanOrEqualTo(maximum).WithMessage(string.Format(GlobalValidations.MaximumValueValidationMessage, maximum));
//        }

//        public static IRuleBuilderOptions<T, int> MaximumValueWithTranslateMessage<T>(this IRuleBuilder<T, int> ruleBuilder, int maximum, string key = "MaximumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.LessThanOrEqualTo(maximum).WithMessage(string.Format(GlobalValidations.MaximumValueValidationMessage, maximum));
//        }

//        public static IRuleBuilderOptions<T, byte?> MaximumValueWithTranslateMessage<T>(this IRuleBuilder<T, byte?> ruleBuilder, int maximum, string key = "MaximumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.Must(p => p < maximum).WithMessage(string.Format(GlobalValidations.MaximumValueValidationMessage, maximum));
//        }

//        public static IRuleBuilderOptions<T, byte> MaximumValueWithTranslateMessage<T>(this IRuleBuilder<T, byte> ruleBuilder, int maximum, string key = "MaximumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.Must(p => p < maximum).WithMessage(string.Format(GlobalValidations.MaximumValueValidationMessage, maximum));
//        }

//        public static IRuleBuilderOptions<T, decimal?> MaximumValueWithTranslateMessage<T>(this IRuleBuilder<T, decimal?> ruleBuilder, int maximumLength, string key = "MaximumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.LessThanOrEqualTo(maximumLength).WithMessage(string.Format(GlobalValidations.MaximumValueValidationMessage, maximumLength));

//        }

//        public static IRuleBuilderOptions<T, decimal> MaximumValueWithTranslateMessage<T>(this IRuleBuilder<T, decimal> ruleBuilder, int maximumLength, string key = "MaximumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.LessThanOrEqualTo(maximumLength).WithMessage(string.Format(GlobalValidations.MaximumValueValidationMessage, maximumLength));
//        }

//        public static IRuleBuilderOptions<T, int?> MinimumValueValidationMessage<T>(this IRuleBuilder<T, int?> ruleBuilder, int minimum, string key = "MinimumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.GreaterThanOrEqualTo(minimum).WithMessage(string.Format(GlobalValidations.MinimumValueValidationMessage, minimum));
//        }

//        public static IRuleBuilderOptions<T, int> MinimumValueValidationMessage<T>(this IRuleBuilder<T, int> ruleBuilder, int minimum, string key = "MinimumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.GreaterThanOrEqualTo(minimum).WithMessage(string.Format(GlobalValidations.MinimumValueValidationMessage, minimum));
//        }

//        public static IRuleBuilderOptions<T, decimal> MinimumValueValidationMessage<T>(this IRuleBuilder<T, decimal> ruleBuilder, int minimum, string key = "MinimumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.GreaterThanOrEqualTo(minimum).WithMessage(string.Format(GlobalValidations.MinimumValueValidationMessage, minimum));
//        }

//        public static IRuleBuilderOptions<T, decimal?> MinimumValueValidationMessage<T>(this IRuleBuilder<T, decimal?> ruleBuilder, int minimum, string key = "MinimumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.GreaterThanOrEqualTo(minimum).WithMessage(string.Format(GlobalValidations.MinimumValueValidationMessage, minimum));
//        }

//        public static IRuleBuilderOptions<T, byte?> MinimumValueWithTranslateMessage<T>(this IRuleBuilder<T, byte?> ruleBuilder, int minimum, string key = "MinimumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.Must(p => p > minimum).WithMessage(string.Format(GlobalValidations.MaximumValueValidationMessage, minimum));
//        }

//        public static IRuleBuilderOptions<T, byte> MinimumValueWithTranslateMessage<T>(this IRuleBuilder<T, byte> ruleBuilder, int minimum, string key = "MinimumValueValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.Must(p => p > minimum).WithMessage(string.Format(GlobalValidations.MinimumValueValidationMessage, minimum));
//        }

//        public static IRuleBuilderOptions<T, int> ExclusiveBetweenWithTranslateMessage<T>(this IRuleBuilder<T, int> ruleBuilder, int from, int to, string key = "ExclusiveBetweenValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.ExclusiveBetween(from, to).WithMessage(string.Format(GlobalValidations.ExclusiveBetweenValidationMessage, from, to));
//        }

//        public static IRuleBuilderOptions<T, string> EmailAddressWithTranslateMessage<T>(this IRuleBuilder<T, string> ruleBuilder, string key = "EmailAddressValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.EmailAddress().WithMessage(GlobalValidations.EmailAddressValidationMessage);
//        }


//        public static IRuleBuilderOptions<T, decimal> ScalePrecisionWithTranslateMessage<T>(this IRuleBuilder<T, decimal> ruleBuilder, int scale, int precision, string key = "ScalePrecisionValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.ScalePrecision(scale, precision).WithMessage(string.Format(GlobalValidations.ScalePrecisionValidationMessage, scale, precision));
//        }

//        public static IRuleBuilderOptions<T, decimal?> ScalePrecisionWithTranslateMessage<T>(this IRuleBuilder<T, decimal?> ruleBuilder, int scale, int precision, string key = "ScalePrecisionValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.ScalePrecision(scale, precision).WithMessage(string.Format(GlobalValidations.ScalePrecisionValidationMessage, scale, precision));
//        }

//        public static IRuleBuilderOptions<T, string> EmptyWithTranslateMessage<T>(this IRuleBuilder<T, string> ruleBuilder, string key = "MustBeEmptyValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.Empty().WithMessage(GlobalValidations.MustBeEmptyValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, int> EmptyWithTranslateMessage<T>(this IRuleBuilder<T, int> ruleBuilder, string key = "MustBeEmptyValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.Empty().WithMessage(GlobalValidations.MustBeEmptyValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, int?> EmptyWithTranslateMessage<T>(this IRuleBuilder<T, int?> ruleBuilder, string key = "MustBeEmptyValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.Empty().WithMessage(GlobalValidations.MustBeEmptyValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, string> NotEmptyWithTranslateMessage<T>(this IRuleBuilder<T, string> ruleBuilder, string key = "MustNotBeEmptyValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.NotEmpty().WithMessage(GlobalValidations.MustNotBeEmptyValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, int?> NotEmptyWithTranslateMessage<T>(this IRuleBuilder<T, int?> ruleBuilder, string key = "MustNotBeEmptyValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.NotEmpty().WithMessage(GlobalValidations.MustNotBeEmptyValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, DateTime> NotEmptyWithTranslateMessage<T>(this IRuleBuilder<T, DateTime> ruleBuilder, string key = "MaxLengthValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.NotEmpty().WithMessage(GlobalValidations.MustNotBeEmptyValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, TEnum> NotEmptyWithTranslateMessage<T, TEnum>(this IRuleBuilder<T, TEnum> ruleBuilder, string key = "MaxLengthValidationMessage")
//            where TEnum : struct
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.NotEmpty().WithMessage(GlobalValidations.MustNotBeEmptyValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, string> RegexMatchWithTranslateMessage<T>(this IRuleBuilder<T, string> ruleBuilder, string regex, string key = "NotValidValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.Matches(regex).WithMessage(GlobalValidations.NotValidValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, string> NationalCodeWithTranslateMessage<T>(this IRuleBuilder<T, string> ruleBuilder, string key = "NotValidValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.Must(input =>
//            {
//                if (input == null)
//                {
//                    return false;
//                }

//                if (Regex.IsMatch(input, @"^\d{10}$") is false)
//                {
//                    return false;
//                }

//                var check = Convert.ToInt32(input.Substring(9, 1));

//                var sum = Enumerable.Range(0, 9)
//                .Select(x => Convert.ToInt32(input.Substring(x, 1)) * (10 - x))
//                .Sum() % 11;

//                return (sum < 2 && check == sum) || (sum >= 2 && check + sum == 11);
//            }).WithMessage(GlobalValidations.NotValidValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, DateTime> EndDateGreaterThanOrEqualToStartDateWithTranslateMessage<T>(this IRuleBuilder<T, DateTime> ruleBuilder, Expression<Func<T, DateTime>> startDate, string key = "EndDateGreaterThanOrEqualToStartDateValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.GreaterThanOrEqualTo(startDate).WithMessage(GlobalValidations.EndDateGreaterThanOrEqualToStartDateValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, DateTime?> EndDateGreaterThanOrEqualToStartDateWithTranslateMessage<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, Expression<Func<T, DateTime>> startDate, string key = "EndDateGreaterThanOrEqualToStartDateValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.GreaterThanOrEqualTo(startDate).WithMessage(GlobalValidations.EndDateGreaterThanOrEqualToStartDateValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, DateTime> IsRequiredhWithTranslateMessage<T>(this IRuleBuilder<T, DateTime> ruleBuilder, string key = "RequiredValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder
//                .NotNull().WithMessage(GlobalValidations.RequiredValidationMessage)
//                .NotEmpty().WithMessage(GlobalValidations.RequiredValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, int> MustBeIntegerIdWithTranslateMessage<T>(this IRuleBuilder<T, int> ruleBuilder, string key = "NotValidIdValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.GreaterThanOrEqualTo(1).WithMessage(GlobalValidations.NotValidIdValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, int?> MustBeIntegerIdWithTranslateMessage<T>(this IRuleBuilder<T, int?> ruleBuilder, string key = "NotValidValidationMessage")
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.GreaterThanOrEqualTo(1).WithMessage(GlobalValidations.NotValidValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, TEnum> IsEnumWithTranslateMessage<T, TEnum>(this IRuleBuilder<T, TEnum> ruleBuilder, string key = "IsEnumValidationMessage")
//            where TEnum : struct
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.IsInEnum().WithMessage(GlobalValidations.IsEnumValidationMessage);
//        }

//        public static IRuleBuilderOptions<T, TEnum?> IsEnumWithTranslateMessage<T, TEnum>(this IRuleBuilder<T, TEnum?> ruleBuilder, string key = "IsEnumValidationMessage")
//            where TEnum : struct
//        {
//            if (key is null)
//            {
//                throw new ArgumentNullException(nameof(key));
//            }

//            return ruleBuilder.IsInEnum().WithMessage(GlobalValidations.IsEnumValidationMessage);
//        }
//    }
//}
