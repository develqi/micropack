namespace Micropack.Localization
{
    public interface IValidationTranslation
    {
        DictionaryJson[] Validations { get; }

        IValidationTranslation ValidationFor(string key);

        IValidationTranslation FaMessage(string fa);

        IValidationTranslation EnMessage(string en);
    }
}
