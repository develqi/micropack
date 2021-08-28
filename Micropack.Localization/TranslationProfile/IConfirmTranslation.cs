namespace Micropack.Localization
{
    public interface IConfirmTranslation
    {
        IConfirmTranslation ConfirmFor(string key);

        IConfirmTranslation FaConfirm(string fa);

        IConfirmTranslation EnConfirm(string en);
    }
}
