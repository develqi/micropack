namespace Micropack.Multilingual;

public class MultilingualFactory
{
    private readonly Multilingual _multilingual;

    public MultilingualFactory(string Key, string Fa, string En = "")
    {
        _multilingual = new Multilingual
                        {
                            Key = Key,
                            Captions =
                            [
                                new Caption { Language = "Fa", Label = Fa },
                                new Caption { Language = "En", Label = En }
                            ]
                        };
    }

    public MultilingualFactory(string Key, List<Caption> captions)
    {
        _multilingual = new Multilingual
        {
            Key = Key,
            Captions = captions
        };
    }

    public Multilingual Create() => _multilingual;
}
