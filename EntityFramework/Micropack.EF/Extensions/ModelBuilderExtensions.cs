using System;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using Micropack.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Micropack.EF
{
    public static class ModelBuilderExtensions
    {
        private static void ApplyDbSets(ModelBuilder modelBuilder, Assembly assembly)
        {
            var entityTypes = new Type[] { typeof(IEntity), typeof(IEntityNumeric) };

            assembly.GetTypes()
               .Where(type => entityTypes.Any(entityType => type.IsAssignableFrom(entityType)))
               .ToList()
               .ForEach(type => modelBuilder.Entity(type));
        }

        public static void ApplyDbSetsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            ApplyDbSets(modelBuilder, assembly);
        }

        public static void ApplyDbSetsFromAssemblyContaining<TEntity>(this ModelBuilder modelBuilder) where TEntity : IEntity
        {
            var assembly = typeof(TEntity).Assembly;

            ApplyDbSets(modelBuilder, assembly);
        }

        public static void ApplyConfigurationsFromAssemblyContaining<TEntity, TEntityMap>(this ModelBuilder modelBuilder)
            where TEntity : class, IEntity
            where TEntityMap : class, IEntityTypeConfiguration<TEntity>
        {
            var assembly = typeof(TEntityMap).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        public static void ApplySoftDeleteQueryFilterFromAssemblyContaining<TEntity>(this ModelBuilder modelBuilder) where TEntity : IEntity //ISoftDeletable
        {
            var assembly = typeof(TEntity).Assembly;

            Expression<Func<TEntity, bool>> filter = entity => Microsoft.EntityFrameworkCore.EF.Property<bool>(entity, "IsDeleted") == false;

            assembly.GetTypes()
               .Where(type => type.IsAssignableFrom(typeof(ISoftDeletable)))
               .ToList()
               .ForEach(type => modelBuilder.Entity(type).HasQueryFilter(filter));
        }
    }
}