namespace Micropack.Multilingual;

public class ModuleItem : Multilingual
{
    public int Id { get; set; }

    public short Order { get; set; }
        
    public bool IsAccessible { get; set; } = true;

    public List<MenuItem> Menus { get; set; } = [];
}
