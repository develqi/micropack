namespace Micropack.Multilingual;

public class ModuleMultilingualBuilder : MultilingualBuilder<MultilingualModule>
{
    public ModuleMultilingualBuilder? AddModule(string key) => AddItem(key) as ModuleMultilingualBuilder;

    public override ModuleMultilingualBuilder? Fa(string fa) => base.Fa(fa) as ModuleMultilingualBuilder;

    public override ModuleMultilingualBuilder? En(string en) => base.En(en) as ModuleMultilingualBuilder;

    public override ModuleMultilingualBuilder? Order(byte order) => base.Order(order) as ModuleMultilingualBuilder;

    public void AddMenus(Action<MenuMultilingualBuilder> action)
    {
        var menuLocalizationFactory = new MenuMultilingualBuilder();

        action?.Invoke(menuLocalizationFactory);
        _item.Menus = menuLocalizationFactory.Items.Cast<MultilingualMenu>().ToList();
    }
}
