namespace Micropack.Multilingual;

public interface IHistoryItem
{
    string CreatorName { get; }

    string LastModifierName { get; }

    DateTimeOffset CreatedOn { get; init; }

    DateTimeOffset? LastModifiedOn { get; init; }
}
