namespace Micropack.Localization
{
    public interface IInformationTranslation
    {
        IInformationTranslation InformationFor(string key);

        IInformationTranslation FaInfo(string fa);

        IInformationTranslation EnInfo(string en);
    }
}
