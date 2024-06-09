namespace Micropack.EF;

public interface IQueryDB
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
}