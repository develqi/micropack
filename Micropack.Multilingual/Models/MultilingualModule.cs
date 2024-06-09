namespace Micropack.Multilingual;

public class MultilingualModule : Multilingual
{
    public int Id { get; set; }

    public byte Order { get; set; }
        
    public bool IsAccessible { get; set; } = true;

    public List<MultilingualMenu> Menus { get; set; } = [];
}
