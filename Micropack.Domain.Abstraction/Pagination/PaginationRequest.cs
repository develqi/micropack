namespace Micropack.Domain.Abstraction
{
    public record PaginationRequest
    {
        public int Page { get; set; } = 1;

        public short Size { get; set; } = 20;

        public string OrderBy { get; set; }

        public string Select { get; set; }

        public string Filter { get; set; }

        public bool NoFilter() => string.IsNullOrWhiteSpace(Filter);

        public bool NoOrderBy() => string.IsNullOrWhiteSpace(OrderBy);

        public bool NoSelect() => string.IsNullOrWhiteSpace(Select);
    }
}