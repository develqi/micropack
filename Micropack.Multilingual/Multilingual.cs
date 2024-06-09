namespace Micropack.Multilingual;

public class Multilingual
{
    public required string Key { get; set; }

    public List<Caption> Captions { get; set; } = [];

    public Caption? GetCaption(string language = "Fa")
    {
        return Captions
            .Where(caption => caption.Language == language)
            .FirstOrDefault();
    }

    public void AddCaption(string label, string language = "Fa")
    {
        var caption = Captions
            .Where(caption => caption.Language == language)
            .FirstOrDefault() ?? new Caption { Language = language, Label = label };

        Captions.Add(caption);
    }

    public bool ShouldSerializeItems()
    {
        return Captions != null;
    }
}
