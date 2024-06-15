namespace Micropack.Multilingual;

public class SubmenuMultilingualBuilder : MultilingualBuilder<MultilingualSubmenu>
{
    public SubmenuMultilingualBuilder AddSubMenu(string key) => AddItem(key) as SubmenuMultilingualBuilder;

    public void LocalizeForms(Action<FormMultilingualBuilder> action)
    {
        var formLocalizationFactory = new FormMultilingualBuilder();

        action?.Invoke(formLocalizationFactory);
        _item.Forms = formLocalizationFactory.Items.Cast<MultilingualForm>().ToList();
    }

    public override SubmenuMultilingualBuilder Fa(string fa) => base.Fa(fa) as SubmenuMultilingualBuilder;

    public override SubmenuMultilingualBuilder En(string en) => base.En(en) as SubmenuMultilingualBuilder;
}