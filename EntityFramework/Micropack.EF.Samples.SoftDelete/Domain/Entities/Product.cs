using System;
using Micropack.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Micropack.EF.Samples.SoftDelete
{
    public class Product : IEntityGuid, ISoftDeletable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedOn { get; set; }
    }

    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(c => c.Name).HasMaxLength(100);

            builder.HasSoftDeleteQueryFilter();

            builder.HasIndex(x => x.Name).HasSoftDeleteIndexFilter().HasName("IX_Name");       
        }
    }
}
