namespace Micropack.Multilingual;

public class MenuMultilingualBuilder : MultilingualBuilder<MultilingualMenu>
{
    public MenuMultilingualBuilder? AddMenu(string key) => AddItem(key) as MenuMultilingualBuilder;

    public override MenuMultilingualBuilder? Fa(string fa) => base.Fa(fa) as MenuMultilingualBuilder;

    public override MenuMultilingualBuilder? En(string en) => base.En(en) as MenuMultilingualBuilder;

    public MenuMultilingualBuilder? Order(byte order)
    {
        _item.Order = order;
        return this;
    }

    public void AddForms(Action<FormMultilingualBuilder> action)
    {
        var formLocalizationFactory = new FormMultilingualBuilder();

        action?.Invoke(formLocalizationFactory);
        _item.Forms = formLocalizationFactory.Items.Cast<MultilingualForm>().ToList();
    }

    public void AddSubMenus(Action<SubmenuMultilingualBuilder> action)
    {
        var subMenuLocalizationFactory = new SubmenuMultilingualBuilder();

        action?.Invoke(subMenuLocalizationFactory);
        _item.SubMenus = subMenuLocalizationFactory.Items.Cast<MultilingualSubmenu>().ToList();
    }
}