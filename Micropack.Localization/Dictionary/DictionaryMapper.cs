namespace Micropack.Localization
{
    public class DictionaryMapper
    {
        public static string MapTitle(Dictionary dictionary) => LocalizationInfo.CurrentLanguage == "Fa" ? dictionary.Fa : dictionary.En ?? dictionary.Key;
    }
}