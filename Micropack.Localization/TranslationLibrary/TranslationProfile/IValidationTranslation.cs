namespace Micropack.Localization
{
    public interface IValidationTranslation
    {
        IValidationTranslation ValidationFor(string key);

        IValidationTranslation FaMessage(string valueFa);

        IValidationTranslation EnMessage(string valueEn);
    }
}
