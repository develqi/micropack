using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Micropack.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Micropack.EF
{
    public static class SoftDeleteExtensions
    {
        public static async Task SoftDelete<TEntity>(this DbSet<TEntity> dbSet, Guid id, CancellationToken cancellationToken = default) 
            where TEntity : class, IEntity, ISoftDeletable
        {
            var entity = await dbSet.FindAsync(id, cancellationToken);

            UpdateEntity(entity, dbSet);
        }

        private static void UpdateEntity<TEntity>(TEntity entity, DbSet<TEntity> dbSet) where TEntity : class, IEntity, ISoftDeletable
        {
            if (entity != null)
            {
                entity.IsDeleted = true;

                dbSet.Update(entity);
            }
        }

        public static void SoftDelete<TEntity>(this DbSet<TEntity> dbSet, TEntity entity) where TEntity : class,  IEntity, ISoftDeletable
        {
            UpdateEntity(entity, dbSet);
        }

        public static IQueryable<TEntity> WhereNotDeleted<TEntity>(this IQueryable<TEntity> query) 
            where TEntity : ISoftDeletable => query.Where(entity => !entity.IsDeleted);

        public static IndexBuilder HasSoftDeleteIndexFilter<TEntity>(this IndexBuilder<TEntity> builder)
           where TEntity : class, IEntity, ISoftDeletable => builder.HasFilter(" IsDeleted = 0");

        public static void HasSoftDeleteQueryFilter<TEntity>(this EntityTypeBuilder<TEntity> builder)
           where TEntity : class, IEntity, ISoftDeletable => builder.HasQueryFilter(x => !x.IsDeleted);
    }
}