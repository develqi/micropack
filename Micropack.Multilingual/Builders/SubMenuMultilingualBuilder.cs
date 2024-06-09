namespace Micropack.Multilingual;

public class SubMenuMultilingualBuilder : MultilingualBuilder<SubMenuItem>
{
    public SubMenuMultilingualBuilder AddSubMenu(string key) => AddItem(key) as SubMenuMultilingualBuilder;

    public void LocalizeForms(Action<FormMultilingualBuilder> action)
    {
        var formLocalizationFactory = new FormMultilingualBuilder();

        action?.Invoke(formLocalizationFactory);
        _item.Forms = formLocalizationFactory.Items.Cast<FormItem>().ToList();
    }

    public override SubMenuMultilingualBuilder Fa(string fa) => base.Fa(fa) as SubMenuMultilingualBuilder;

    public override SubMenuMultilingualBuilder En(string en) => base.En(en) as SubMenuMultilingualBuilder;
}