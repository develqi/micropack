namespace Micropack.Localization
{
    public interface IValidationTranslation
    {
        IValidationTranslation ValidationForKey(string key);

        IValidationTranslation FaMessage(string valueFa);

        IValidationTranslation EnMessage(string valueEn);
    }
}
