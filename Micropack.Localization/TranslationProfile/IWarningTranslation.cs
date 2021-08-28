namespace Micropack.Localization
{
    public interface IWarningTranslation
    {
        IWarningTranslation WarningFor(string key);

        IWarningTranslation FaWarning(string fa);

        IWarningTranslation EnWarning(string en);
    }
}
