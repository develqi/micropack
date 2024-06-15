namespace Micropack.Multilingual;

public class MultilingualFormField : Multilingual
{
    public int Id { get; set; }

    public byte Order { get; set; }

    public byte Type { get; set; }

    public byte Size { get; set; }    

    public string? Resource { get; set; }
}
