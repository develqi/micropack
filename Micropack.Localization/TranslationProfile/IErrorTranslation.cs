namespace Micropack.Localization
{
    public interface IErrorTranslation
    {
        Dictionary[] Errors { get; }

        IErrorTranslation ErrorFor(string key);

        IErrorTranslation FaError(string fa);

        IErrorTranslation EnError(string en);
    }
}
