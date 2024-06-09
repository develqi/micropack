namespace Micropack.Multilingual;

public class Caption
{
    public string? Alias { get; set; }

    public string Title => Alias ?? Label;

    public required string Label { get; set; }

    public required string Language { get; set; }

    public bool ShouldSerializeAlias()
    {
        return !string.IsNullOrWhiteSpace(Alias);
    }
}
