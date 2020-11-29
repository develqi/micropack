using MediatR;

namespace Micropack.ESCQRS
{
    public record PaginationQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {
        public int Page { get; init; } = 1;

        public int Size { get; init; } = 20;

        public string OrderBy { get; init; }

        public string Select { get; init; }

        public string Filter { get; init; }

        public bool NoFilter => string.IsNullOrWhiteSpace(Filter);
    }

}
