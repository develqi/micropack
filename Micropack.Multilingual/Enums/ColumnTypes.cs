namespace Micropack.Multilingual;

public enum ColumnTypes : byte
{
    Number = 1,
    String = 2,
    DateTime = 3,
    Boolean = 4,
    Enum = 5,
    Icon = 6,
    Avatar = 7,
    Currency = 8,

    // New
    Switch,
    Navigator,
}
