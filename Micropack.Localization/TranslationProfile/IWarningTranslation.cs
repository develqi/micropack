namespace Micropack.Localization
{
    public interface IWarningTranslation
    {
        Dictionary[] Warnings { get; }

        IWarningTranslation WarningFor(string key);

        IWarningTranslation FaWarning(string fa);

        IWarningTranslation EnWarning(string en);
    }
}
