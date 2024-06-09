namespace Micropack.Abstraction;

public record Pagination<TResponse>(int Page, int TotalRecords, IEnumerable<TResponse> Records) where TResponse : class, new();
