namespace Micropack.Localization
{
    public interface IErrorTranslation
    {
        IErrorTranslation ErrorFor(string key);

        IErrorTranslation FaError(string fa);

        IErrorTranslation EnError(string en);
    }
}
