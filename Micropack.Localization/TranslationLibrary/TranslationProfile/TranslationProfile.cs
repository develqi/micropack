using System;
using System.Linq;
using System.Collections.Generic;

namespace Micropack.Localization
{
    public class TranslationProfile : ILableTranslation, IValidationTranslation
    {
        private readonly List<LabelTranslation> _labelsTranslation;
        private readonly List<ValidationMessageTranslation> _validationsTranslation;

        private string _keyLabel;
        private string _keyValidation;

        public TranslationProfile()
        {
            _labelsTranslation = new List<LabelTranslation>();
            _validationsTranslation = new List<ValidationMessageTranslation>();
        }

        public ILableTranslation LabelFor(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("LabelKey", "TranslationProfile.cs error=> Label key is null or empty");

            _keyLabel = key;

            if (!_labelsTranslation.Any(x => x.Key == key))
                _labelsTranslation.Add(new LabelTranslation { Key = key });

            return this;
        }

        public ILableTranslation Fa(string valueFa)
        {
            var lable = _labelsTranslation.FirstOrDefault(x => x.Key == _keyLabel);

            if (lable != null)
            {
                lable.Value = valueFa;
                lable.LanguageId = 1;
            }

            return this;
        }

        public ILableTranslation En(string valueEn)
        {
            var lable = _labelsTranslation.FirstOrDefault(x => x.Key == _keyLabel);

            if (lable != null)
            {
                lable.Value = valueEn;
                lable.LanguageId = 2;
            }

            return this;
        }

        public IValidationTranslation ValidationFor(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("ValidationKey", "TranslationProfile.cs error=> Validation key is null or empty");

            _keyValidation = key;

            if (!_validationsTranslation.Any(x => x.Key == key))
                _validationsTranslation.Add(new ValidationMessageTranslation { Key = key });

            return this;
        }

        public IValidationTranslation FaMessage(string valueFa)
        {
            var validation = _validationsTranslation.FirstOrDefault(x => x.Key == _keyValidation);

            if (validation != null)
            {
                validation.Value = valueFa;
                validation.LanguageId = 1;
            }

            return this;
        }

        public IValidationTranslation EnMessage(string valueEn)
        {
            var validation = _validationsTranslation.FirstOrDefault(x => x.Key == _keyValidation);

            if (validation != null)
            {
                validation.Value = valueEn;
                validation.LanguageId = 2;
            }

            return this;
        }

        public List<LabelTranslation> Labels => _labelsTranslation;
    }
}
