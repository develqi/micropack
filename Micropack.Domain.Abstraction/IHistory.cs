namespace Micropack.Abstraction;

public interface IHistory
{
    DateTimeOffset CreatedOn { get; set; }

    DateTimeOffset? LastModifiedOn { get; set; }
}