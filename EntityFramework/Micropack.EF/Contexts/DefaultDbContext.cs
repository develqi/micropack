using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Micropack.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Micropack.EF
{
    public class DefaultDbContext<TEntity, TEntityMap> : DbContext, IDbContext
        where TEntity : class, IEntity
        where TEntityMap : class, IEntityTypeConfiguration<TEntity>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyDbSetsFromAssemblyContaining<TEntity>();
            modelBuilder.ApplyConfigurationsFromAssemblyContaining<TEntity, TEntityMap>();
            modelBuilder.ApplySoftDeleteQueryFilterFromAssemblyContaining<TEntity>();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            DetectChangesBeforSaveChanges();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            DetectChangesBeforSaveChanges();

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public void TryUpdateManyToMany<TEntity, TKey>(IEnumerable<TEntity> currentItems, IEnumerable<TEntity> newItems, Func<TEntity, TKey> getKey) where TEntity : class, IEntity
        {
            var toRemoveData = currentItems.Except(newItems, getKey);
            var toAddData = newItems.Except(currentItems, getKey);
            var toUpdateData = currentItems.Intersect(newItems);

            Set<TEntity>().RemoveRange(toRemoveData);
            Set<TEntity>().AddRange(toAddData);
            Set<TEntity>().UpdateRange(toUpdateData);
        }

        // -------------------- Private -------------------- //

        private void DetectChangesBeforSaveChanges()
        {
            base.ChangeTracker.DetectChanges();

            var entries = base.ChangeTracker.Entries();

            if(entries.Any())
            {
                ApplyHistories(entries);

                //var httpContextAccessor = ServiceLocator.Current.GetInstance<IHttpContextAccessor>();
                //if (httpContextAccessor == null)
                //    throw new Exception("The IHttpContextAccessor service is not registered by default");

                //var userId = httpContextAccessor.HttpContext.User.Identity.GetUserId();
                //ApplyOwnerId(entries, userId);
                
                //var tenantId = httpContextAccessor.HttpContext.User.Identity.GetTenantId();
                //ApplyTenantId(entries, tenantId);
            }
        }

        private void ApplyHistories(IEnumerable<EntityEntry> entries)
        {
            var now = DateTime.UtcNow;

            var historyEntries = entries.Where(entry => typeof(IHistory).IsAssignableFrom(entry.Entity.GetType()));

            historyEntries.Where(entry => entry.State == EntityState.Added).ToList().ForEach(entry => (entry.Entity as IHistory).CreatedOn = now);
            historyEntries.Where(entry => entry.State == EntityState.Modified).ToList().ForEach(entry => (entry.Entity as IHistory).LastModifiedOn = now);
        }

        private void ApplyOwnerId(IEnumerable<EntityEntry> entries, Guid userId)
        {
            var ownerEntries = entries.Where(entry => entry.State == EntityState.Added)
                                      .Where(entry => typeof(IOwner).IsAssignableFrom(entry.Entity.GetType()))
                                      .ToList();

            ownerEntries.ForEach(entry => (entry.Entity as IOwner).OwnerId = userId);
        }

        private void ApplyTenantId(IEnumerable<EntityEntry> entries, int tenantId)
        {
            var tenantableEntries = entries.Where(entry => entry.State == EntityState.Added)
                                           .Where(entry => typeof(ITenantable).IsAssignableFrom(entry.Entity.GetType()))
                                           .ToList();

            tenantableEntries.ForEach(entry => (entry.Entity as ITenantable).TenantId = tenantId);
        }
    }
}
