namespace Micropack.Abstraction;

public static class IPaginationExtensions
{
    public static IQueryable<TEntity> Pagination<TEntity>(this IQueryable<TEntity> query, int page, int size) where TEntity : class
    {
        return (page == 1) ? query.Take(size) : query.Skip((page - 1) * size).Take(size);
    }
}