namespace Micropack.ESCQRS;

public class PaginationQuery<TResponse> : IRequest<TResponse> where TResponse : class
{
    public int Page { get; set; } = 1;

    public int Size { get; set; } = 20;

    public string? OrderBy { get; set; }

    public string? Select { get; set; }

    public string? Filter { get; set; }

    public bool NoFilter => string.IsNullOrWhiteSpace(Filter);
}
