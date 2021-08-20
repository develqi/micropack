using System;
using System.Linq;
using System.Collections.Generic;

namespace Micropack.Localization
{
    public class TranslationProfile : ILableTranslation, IValidationTranslation, IInformationTranslation, IWarningTranslation, IConfirmTranslation, IErrorTranslation
    {
        private readonly List<Transtation> _labels;
        private readonly List<Transtation> _errors;
        private readonly List<Transtation> _confirms;
        private readonly List<Transtation> _warnings;
        private readonly List<Transtation> _validations;
        private readonly List<Transtation> _informations;

        private string _labelKey;
        private string _errorKey;
        private string _warningKey;
        private string _confirmKey;
        private string _validationKey;
        private string _informationKey;

        public TranslationProfile()
        {
            _labels = new List<Transtation>();
            _errors = new List<Transtation>();
            _confirms = new List<Transtation>();
            _warnings = new List<Transtation>();
            _validations = new List<Transtation>();
            _informations = new List<Transtation>();
        }

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
    }
}
