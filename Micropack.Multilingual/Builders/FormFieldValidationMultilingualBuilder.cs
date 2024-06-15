namespace Micropack.Multilingual;

public class FormFieldValidationMultilingualBuilder : MultilingualBuilder<MultilingualFormFieldValidation>
{
    public FormFieldValidationMultilingualBuilder AddValidationField(string name)
    {
        return this;
    }
}
