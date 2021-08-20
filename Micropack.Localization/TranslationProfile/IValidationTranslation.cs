namespace Micropack.Localization
{
    public interface IValidationTranslation
    {
        IValidationTranslation ValidationFor(string key);

        IValidationTranslation FaMessage(string fa);

        IValidationTranslation EnMessage(string en);
    }
}
