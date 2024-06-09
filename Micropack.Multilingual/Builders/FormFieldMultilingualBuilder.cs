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

    public override FormFieldMultilingualBuilder Fa(string fa) => base.Fa(fa) as FormFieldMultilingualBuilder;

    public override FormFieldMultilingualBuilder En(string en) => base.En(en) as FormFieldMultilingualBuilder;
}
