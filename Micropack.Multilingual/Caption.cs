namespace Micropack.Multilingual;

public class Caption
{
    public Caption()
    {
        
    }
    public Caption(string fa)
    {
        Language = "Fa";
        Label = fa;
    }

    public string? Alias { get; set; }

    public string Title => Alias ?? Label;

    public string Label { get; set; }

    public string Language { get; set; }

    public bool ShouldSerializeAlias()
    {
        return !string.IsNullOrWhiteSpace(Alias);
    }
}
