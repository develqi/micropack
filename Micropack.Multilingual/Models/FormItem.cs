namespace Micropack.Multilingual;

public class FormItem : Multilingual
{
    public FormLocalization Localizations { get; set; } = new();

    public List<Multilingual> Permissions { get; set; } = [];

    public List<FormItem> TabForms { get; set; } = [];
}
