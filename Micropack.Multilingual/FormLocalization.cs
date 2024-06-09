namespace Micropack.Multilingual;

public record FormLocalization
{
    public EnumJson[] Enums { get; set; }

    public Multilingual[] Labels { get; set; }

    public Multilingual[] Errors { get; set; }

    public Multilingual[] Confirms { get; set; }

    public Multilingual[] Warnings { get; set; }

    public Multilingual[] Validations { get; set; }

    public Multilingual[] Informations { get; set; }

    public DatagridBuilder Datagrid { get; set; }

    public bool ShouldSerializeDatagrid() => Datagrid is not null;

    public bool ShouldSerializeLabels() => Labels is not null && Labels.Any();

    public bool ShouldSerializeErrors() => Errors is not null && Errors.Any();

    public bool ShouldSerializeConfirms() => Confirms is not null && Confirms.Any();

    public bool ShouldSerializeWarnings() => Warnings is not null && Warnings.Any();

    public bool ShouldSerializeValidations() => Validations is not null && Validations.Any();

    public bool ShouldSerializeInformations() => Informations is not null && Informations.Any();
}
