namespace Micropack.Multilingual;

public class MultilingualSubMenu : Multilingual
{
    public int Id { get; set; }

    public byte Order { get; set; }

    public bool IsAccessible { get; set; } = true;

    public List<MultilingualForm> Forms { get; set; } = [];
}
