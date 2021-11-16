namespace Micropack.Localization
{
    public interface IConfirmTranslation
    {
        Dictionary[] Confirms { get; }

        IConfirmTranslation ConfirmFor(string key);

        IConfirmTranslation FaConfirm(string fa);

        IConfirmTranslation EnConfirm(string en);
    }
}
