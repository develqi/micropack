namespace Micropack.Localization
{
    public interface IConfirmTranslation
    {
        DictionaryJson[] Confirms { get; }

        IConfirmTranslation ConfirmFor(string key);

        IConfirmTranslation FaConfirm(string fa);

        IConfirmTranslation EnConfirm(string en);
    }
}
