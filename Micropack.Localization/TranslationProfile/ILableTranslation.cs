namespace Micropack.Localization
{
    public interface ILableTranslation
    {
        DictionaryJson[] Labels { get; }

        ILableTranslation LabelFor(string key);

        ILableTranslation Fa(string fa);

        ILableTranslation En(string en);
    }
}
