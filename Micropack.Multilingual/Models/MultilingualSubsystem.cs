namespace Micropack.Multilingual;

public class MultilingualSubsystem : Multilingual
{
    public int Id { get; set; }

    public byte Order { get; set; }

    public bool IsAccessible { get; set; }

    public required string Title { get; set; }
}
