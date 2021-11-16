namespace Micropack.Localization
{
    public interface IValidationTranslation
    {
        Dictionary[] Validations { get; }

        IValidationTranslation ValidationFor(string key);

        IValidationTranslation FaMessage(string fa);

        IValidationTranslation EnMessage(string en);
    }
}
