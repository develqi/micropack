namespace Micropack.Multilingual;

public class MultilingualForm : Multilingual
{
    public int Id { get; set; }

    public byte Order { get; set; }

    public bool IsAccessible { get; set; } = true;

    public FormLocalization Localizations { get; set; } = new();

    public List<Multilingual> Permissions { get; set; } = [];

    public List<MultilingualForm> TabForms { get; set; } = [];
}