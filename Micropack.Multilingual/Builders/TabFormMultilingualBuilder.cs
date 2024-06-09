namespace Micropack.Multilingual;

public class TabFormMultilingualBuilder : MultilingualBuilder<MultilingualForm>
{
    public TabFormMultilingualBuilder AddTabForm(string name) => AddItem(name) as TabFormMultilingualBuilder;

    public TabFormMultilingualBuilder UseTranslation<TTranslationProfile>() //where TTranslationProfile : TranslationProfile
    {
        var translationProfile = Activator.CreateInstance<TTranslationProfile>();

        //_item.Localizations.Labels = translationProfile.Labels;
        //_item.Localizations.Errors = translationProfile.Errors;
        //_item.Localizations.Warnings = translationProfile.Warnings;
        //_item.Localizations.Confirms = translationProfile.Confirms;
        //_item.Localizations.Validations = translationProfile.Validations;
        //_item.Localizations.Informations = translationProfile.Informations;

        return this;
    }

    public TabFormMultilingualBuilder AddFields(Action<FormFieldMultilingualBuilder> action)
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


    public TabFormMultilingualBuilder UseTabDataGrid<TDataGrid>() where TDataGrid : DatagridBuilder
    {
        var datagrid = Activator.CreateInstance<TDataGrid>();

        _item.Localizations.Datagrid = datagrid;

        return this;
    }

    //public TabFormMultilingualBuilder UseEnums<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Enums = translationProfile.Enums;

    //    return this;
    //}

    //public TabFormMultilingualBuilder UseLabels<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Labels = translationProfile.Labels;

    //    return this;
    //}

    //public TabFormMultilingualBuilder UseErrors<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Errors = translationProfile.Errors;

    //    return this;
    //}

    //public TabFormMultilingualBuilder UseWarnings<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Warnings = translationProfile.Warnings;

    //    return this;
    //}

    //public TabFormMultilingualBuilder UseConfirms<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Confirms = translationProfile.Confirms;

    //    return this;
    //}

    //public TabFormMultilingualBuilder UseValidations<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Validations = translationProfile.Validations;

    //    return this;
    //}

    //public TabFormMultilingualBuilder UseInformations<TTranslationProfile>() where TTranslationProfile : TranslationProfile
    //{
    //    var translationProfile = Activator.CreateInstance<TTranslationProfile>();

    //    _item.Localizations.Informations = translationProfile.Informations;

    //    return this;
    //}

    public override TabFormMultilingualBuilder Fa(string fa) => base.Fa(fa) as TabFormMultilingualBuilder;

    public override TabFormMultilingualBuilder En(string en) => base.En(en) as TabFormMultilingualBuilder;
}