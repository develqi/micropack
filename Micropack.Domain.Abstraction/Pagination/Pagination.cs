namespace Micropack.Domain.Abstraction
{
    public record Pagination<TResponse> where TResponse : class
    {
        public int Page { get; init; }

        public int TotalRecords { get; init; }

        public TResponse[] Records { get; init; }
    }
}