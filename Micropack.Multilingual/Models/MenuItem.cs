namespace Micropack.Multilingual;

public class MenuItem : Multilingual
{
    public List<FormItem> Forms { get; set; } = [];

    public List<SubMenuItem> SubMenus { get; set; } = [];
}
