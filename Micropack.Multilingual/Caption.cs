namespace Micropack.Multilingual;

public class Caption
{
    public string? Alias { get; set; }

    public string Title => Alias ?? Label;

    public required string Label { get; set; }

    public required string Language { get; set; }

    public bool ShouldSerializeTitle() => false;

    public bool ShouldSerializeLabel() => !string.IsNullOrWhiteSpace(Label); // If En label is not empty

    public bool ShouldSerializeAlias() => !string.IsNullOrWhiteSpace(Alias);
}
