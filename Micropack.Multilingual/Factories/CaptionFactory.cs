namespace Micropack.Multilingual;

public record class CaptionFactory(string Fa, string En = "")
{
    public Caption Create()
    {
        return new Caption
        {
            Language = "Fa",
            Label = Fa
        };
    }
}
