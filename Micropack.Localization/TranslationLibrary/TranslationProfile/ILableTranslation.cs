namespace Micropack.Localization
{
    public interface ILableTranslation
    {
        ILableTranslation LabelForKey(string key);

        ILableTranslation Fa(string valueFa);

        ILableTranslation En(string valueEn);
    }
}
