using Micropack.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Micropack.Localization.EF
{
    public class Transtation
    {
        public int Id { get; set; }

        public DictionaryJson Dictionary { get; set; }

        public LocalizationTypes Type { get; set; }
    }

    public class TranstationMap : IEntityTypeConfiguration<Transtation>
    {
        public void Configure(EntityTypeBuilder<Transtation> builder)
        {
            builder.ToTable("Translations", "Localization");

            builder.Property(x => x.Dictionary).IsRequired().HasMaxLength(1000).HasJsonConversion<DictionaryJson>();
        }
    }
}
