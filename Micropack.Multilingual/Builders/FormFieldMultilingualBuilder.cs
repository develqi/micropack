namespace Micropack.Multilingual;

public class FormFieldMultilingualBuilder : MultilingualBuilder<MultilingualFormField>
{
    //public TabFormMultilingualBuilder AddField<TController>() where TController : ControllerBase => AddItem(typeof(TController).Name.Replace("Controller", "")) as TabFormMultilingualBuilder;

    public FormFieldMultilingualBuilder AddField(string name)
    {
        var formLocalizationFactory = new FormMultilingualBuilder();

        //action?.Invoke(formLocalizationFactory);
        //_item.Forms = formLocalizationFactory.Items.Cast<FormFieldItem>().ToList();

        return this;
    }

    public FormFieldMultilingualBuilder? Order(byte order)
    {
        _item.Order = order;
        return this;
    }

    public FormFieldMultilingualBuilder? Type(byte type)
    {
        _item.Type = type;
        return this;
    }

    public FormFieldMultilingualBuilder? Size(byte size)
    {
        _item.Size = size;
        return this;
    }

    public FormFieldMultilingualBuilder? Resource(string resource)
    {
        _item.Resource = resource;
        return this;
    }

    public override FormFieldMultilingualBuilder Fa(string fa) => base.Fa(fa) as FormFieldMultilingualBuilder;

    public override FormFieldMultilingualBuilder En(string en) => base.En(en) as FormFieldMultilingualBuilder;
}
