namespace Micropack.Multilingual;

public class ColumnItem
{
    public required Caption Caption { get; set; }

    public required string Name { get; set; }

    public ColumnVisibilities Visible { get; set; }

    public bool Sortable { get; set; } = true;

    public ColumnTypes Type { get; set; }

    public string ClassName { get; set; }
}