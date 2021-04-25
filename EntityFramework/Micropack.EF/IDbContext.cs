using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Micropack.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Micropack.EF
{
    public interface IDbContext
    {
        ChangeTracker ChangeTracker { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        bool ChangeDetected<TEntity>(TEntity entity) where TEntity : class => Entry(entity).State == EntityState.Modified;

        void TryUpdateManyToMany<TEntity, TKey>(IEnumerable<TEntity> currentItems, IEnumerable<TEntity> newItems, Func<TEntity, TKey> getKey) where TEntity : class, IEntity;
    }
}
