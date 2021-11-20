using System;
using System.Linq;
using System.Collections.Generic;

namespace Micropack.Localization
{
    public class TranslationProfile :
        IEnumTranslation,
        ILableTranslation, 
        IErrorTranslation,
        IWarningTranslation, 
        IConfirmTranslation, 
        IValidationTranslation, 
        IInformationTranslation
    {
        private readonly List<EnumItem> _enums = new();
        private readonly List<Transtation> _labels = new();
        private readonly List<Transtation> _errors = new();
        private readonly List<Transtation> _confirms = new();
        private readonly List<Transtation> _warnings = new();
        private readonly List<Transtation> _validations = new();
        private readonly List<Transtation> _informations = new();

        private string _labelKey;
        private string _errorKey;
        private string _warningKey;
        private string _confirmKey;
        private string _validationKey;
        private string _informationKey;

        public EnumItem[] Enums => _enums.ToArray();

        public Dictionary[] Errors => _errors.Select(error => error.Dictionary).ToArray();

        public Dictionary[] Labels => _labels.Select(label => label.Dictionary).ToArray();

        public Dictionary[] Confirms => _confirms.Select(confirm => confirm.Dictionary).ToArray();

        public Dictionary[] Warnings => _warnings.Select(warning => warning.Dictionary).ToArray();

        public Dictionary[] Validations => _validations.Select(validation => validation.Dictionary).ToArray();

        public Dictionary[] Informations => _informations.Select(information => information.Dictionary).ToArray();

        public ILableTranslation LabelFor(string key)
        {
            _labels.AddKey(key, LocalizationTypes.Label);
            _labelKey = key;

            return this;
        }

        public ILableTranslation Fa(string fa)
        {
            _labels.Find(_labelKey).Fa(fa);

            return this;
        }

        public ILableTranslation En(string en)
        {
            _labels.Find(_labelKey).En(en);

            return this;
        }


        public IValidationTranslation ValidationFor(string key)
        {
            _validations.AddKey(key, LocalizationTypes.Validation);
            _validationKey = key;

            return this;
        }

        public IValidationTranslation FaMessage(string fa)
        {
            _validations.Find(_validationKey).Fa(fa);

            return this;
        }

        public IValidationTranslation EnMessage(string en)
        {
            _validations.Find(_validationKey).En(en);

            return this;
        }


        public IInformationTranslation InformationFor(string key)
        {
            _informations.AddKey(key, LocalizationTypes.Information);
            _informationKey = key;

            return this;
        }

        public IInformationTranslation FaInfo(string fa)
        {
            _informations.Find(_informationKey).Fa(fa);

            return this;
        }

        public IInformationTranslation EnInfo(string en)
        {
            _informations.Find(_informationKey).En(en);

            return this;
        }


        public IConfirmTranslation ConfirmFor(string key)
        {
            _confirms.AddKey(key, LocalizationTypes.Confirm);
            _confirmKey = key;

            return this;
        }

        public IConfirmTranslation FaConfirm(string fa)
        {
            _confirms.Find(_confirmKey).Fa(fa);

            return this;
        }

        public IConfirmTranslation EnConfirm(string en)
        {
            _confirms.Find(_confirmKey).En(en);

            return this;
        }

        
        public IWarningTranslation WarningFor(string key)
        {
            _warnings.AddKey(key, LocalizationTypes.Warning);
            _warningKey = key;

            return this;
        }

        public IWarningTranslation FaWarning(string fa)
        {
            _warnings.Find(_warningKey).Fa(fa);

            return this;
        }

        public IWarningTranslation EnWarning(string en)
        {
            _warnings.Find(_warningKey).En(en);

            return this;
        }


        public IErrorTranslation ErrorFor(string key)
        {
            _errors.AddKey(key, LocalizationTypes.Warning);
            _errorKey = key;

            return this;
        }

        public IErrorTranslation FaError(string fa)
        {
            _errors.Find(_errorKey).Fa(fa);

            return this;
        }

        public IErrorTranslation EnError(string en)
        {
            _errors.Find(_errorKey).En(en);

            return this;
        }

        public void EnumFor<TEnum>() where TEnum : Enum
        {
            var enumName = typeof(TEnum).Name;

            if (!_enums.Any(e => e.EnumName == enumName))
            {
                var enumItems = EnumExtenstions.GetDictionaryItems<TEnum>().Select((item, index) => new Dictionary
                {
                    En = item.En,
                    Fa = item.Fa,
                    Key = item.Key,
                    Alias = item.Alias,
                    Order = (byte)(index + 1)
                }).ToArray();

                var enumItem = new EnumItem(enumName, enumItems);
                _enums.Add(enumItem);
            }
        }        
    }
}
