namespace Micropack.Multilingual;

public record class MultilingualFactory(string Key, string Fa, string En = "")
{
    public Multilingual Create()
    {
        return new Multilingual
        {
            Key = Key,
            Captions =
            [
                new Caption { Language = "Fa", Label = Fa },
                new Caption { Language = "En", Label = En }
            ]
        };
    }
}