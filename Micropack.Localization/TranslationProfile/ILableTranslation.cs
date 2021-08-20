namespace Micropack.Localization
{
    public interface ILableTranslation
    {
        ILableTranslation LabelFor(string key);

        ILableTranslation Fa(string fa);

        ILableTranslation En(string en);
    }
}
