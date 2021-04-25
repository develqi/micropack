using System;
using Micropack.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Micropack.EF
{
    public static class TenantableExtensions
    {
        public static IndexBuilder HasTenantableIndexFilter<TEntity>(this IndexBuilder<TEntity> builder)
             where TEntity : class, IEntity, ITenantable
        {
            var tenantId = Guid.Empty; // ToDo: get TenantId from HttpContext
            return builder.HasFilter($" TenantId <> {tenantId}");
        }

        public static void HasTenantableQueryFilter<TEntity>(this EntityTypeBuilder<TEntity> builder)
           where TEntity : class, IEntity, ITenantable
        {
            var tenantId = 0; // ToDo: get TenantId from HttpContext

            builder.HasQueryFilter(x => x.TenantId == tenantId);
        }
    }
}