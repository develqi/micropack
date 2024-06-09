namespace Micropack.Multilingual;

public class MultilingualMenu : Multilingual
{
    public int Id { get; set; }

    public byte Order { get; set; }

    public bool IsAccessible { get; set; } = true;

    public List<MultilingualForm> Forms { get; set; } = [];

    public List<MultilingualSubMenu> SubMenus { get; set; } = [];
}
