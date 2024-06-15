namespace Micropack.Multilingual;

public class FormMultilingualBuilder : MultilingualBuilder<MultilingualForm>
{
    public void AddTabForms(Action<TabFormMultilingualBuilder> action)
    {
        var tabFormLocalizationFactory = new TabFormMultilingualBuilder();

        action?.Invoke(tabFormLocalizationFactory);

        _item.TabForms = tabFormLocalizationFactory.Items.Cast<MultilingualForm>().ToList();
    }

    public FormMultilingualBuilder? Order(byte order)
    {
        _item.Order = order;
        return this;
    }

    public FormMultilingualBuilder AddFields(Action<FormFieldMultilingualBuilder> action)
    {
        var tabFormLocalizationFactory = new FormFieldMultilingualBuilder();

        action?.Invoke(tabFormLocalizationFactory);

        _item.TabForms = tabFormLocalizationFactory.Items.Cast<MultilingualForm>().ToList();

        return this;
    }

    public void AddActions(Action<FormActionMultilingualBuilder> action)
    {
        var tabFormLocalizationFactory = new FormActionMultilingualBuilder();

        action?.Invoke(tabFormLocalizationFactory);

        _item.TabForms = tabFormLocalizationFactory.Items.Cast<MultilingualForm>().ToList();
    }

    public FormMultilingualBuilder AddForm(string name) 
    {
        return AddItem(name) as FormMultilingualBuilder;
    }

    //public FormMultilingualBuilder UseTranslation<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Labels = translationProfile.Labels;
    //    _item.Localizations.Errors = translationProfile.Errors;
    //    _item.Localizations.Warnings = translationProfile.Warnings;
    //    _item.Localizations.Confirms = translationProfile.Confirms;
    //    _item.Localizations.Validations = translationProfile.Validations;
    //    _item.Localizations.Informations = translationProfile.Informations;

    //    return this;
    //}

    public FormMultilingualBuilder UseDataGrid<TDataGrid>() where TDataGrid : DatagridBuilder
    {
        var datagrid = Activator.CreateInstance<TDataGrid>();

        _item.Localizations.Datagrid = datagrid;

        return this;
    }

    public FormMultilingualBuilder AddFields<TTranslationProfile>() //where TTranslationProfile : TranslationProfile
    {
        var translationProfile = Activator.CreateInstance<TTranslationProfile>();

        //_item.Localizations.Labels = translationProfile.Labels;

        return this;
    }

    //public FormMultilingualBuilder UseErrors<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Errors = translationProfile.Errors;

    //    return this;
    //}

    //public FormMultilingualBuilder UseWarnings<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Warnings = translationProfile.Warnings;

    //    return this;
    //}

    //public FormMultilingualBuilder UseConfirms<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Confirms = translationProfile.Confirms;

    //    return this;
    //}

    //public FormMultilingualBuilder UseValidations<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Validations = translationProfile.Validations;

    //    return this;
    //}

    //public FormMultilingualBuilder UseInformations<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Informations = translationProfile.Informations;

    //    return this;
    //}

    //public FormMultilingualBuilder UseEnums<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Enums = translationProfile.Enums;

    //    return this;
    //}

    public override FormMultilingualBuilder Fa(string fa) => base.Fa(fa) as FormMultilingualBuilder;

    public override FormMultilingualBuilder En(string en) => base.En(en) as FormMultilingualBuilder;
}
