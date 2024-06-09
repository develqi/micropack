namespace Micropack.Multilingual;

public class FormActionMultilingualBuilder : MultilingualBuilder<FormItem>
{
    //public TabFormMultilingualBuilder AddField<TController>() where TController : ControllerBase => AddItem(typeof(TController).Name.Replace("Controller", "")) as TabFormMultilingualBuilder;

    public FormActionMultilingualBuilder AddAction(string name, string resource)
    {
        var formLocalizationFactory = new FormActionMultilingualBuilder();

        //action?.Invoke(formLocalizationFactory);
        //_item.Forms = formLocalizationFactory.Items.Cast<FormItem>().ToList();

        return this;
    }

    public void AddCRUDActions()
    {
        AddCreateAction();
        AddUpdateAction();
        AddReadAction();
        AddDeleteAction();
    }

    public FormActionMultilingualBuilder AddCreateAction()
    {
        //  form.AddAction("Create", "copmanies").Fa("افزودن").En("Add");
        return this;
    }

    public FormActionMultilingualBuilder AddUpdateAction()
    {
        //form.AddAction("Update", "copmanies").Fa("ویرایش").En("Edit");
        return this;
    }
    public FormActionMultilingualBuilder AddReadAction()
    {
        return this;
    }

    public FormActionMultilingualBuilder AddDeleteAction()
    {
        return this;
    }
    public override FormActionMultilingualBuilder Fa(string fa) => base.Fa(fa) as FormActionMultilingualBuilder;

    public override FormActionMultilingualBuilder En(string en) => base.En(en) as FormActionMultilingualBuilder;
}