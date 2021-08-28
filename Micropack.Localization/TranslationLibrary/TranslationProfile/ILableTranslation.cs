namespace Micropack.Localization
{
    public interface ILableTranslation
    {
        ILableTranslation LabelFor(string key);

        ILableTranslation Fa(string valueFa);

        ILableTranslation En(string valueEn);
    }
}
