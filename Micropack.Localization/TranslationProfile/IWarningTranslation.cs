namespace Micropack.Localization
{
    public interface IWarningTranslation
    {
        DictionaryJson[] Warnings { get; }

        IWarningTranslation WarningFor(string key);

        IWarningTranslation FaWarning(string fa);

        IWarningTranslation EnWarning(string en);
    }
}
