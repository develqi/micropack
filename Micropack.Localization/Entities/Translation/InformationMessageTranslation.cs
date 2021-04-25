using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Micropack.Localization
{
    public class InformationMessageTranslation : Translation
    {
        
    }

    public class InformationTranslationMap : IEntityTypeConfiguration<InformationMessageTranslation>
    {
        public void Configure(EntityTypeBuilder<InformationMessageTranslation> builder)
        {
            builder.Property(x => x.Key).HasMaxLength(150);
            builder.Property(x => x.Value).HasMaxLength(500);
            builder.Property(x => x.CustomValue).HasMaxLength(500);

            //builder.HasIndex(x => new { x.Key, x.LanguageId }).IsUnique().HasDatabaseName("IX_Key_LanguageId");

            builder.HasOne(x => x.Language).WithMany(x => x.InformationMessageTranslations).HasForeignKey(x => x.LanguageId);
        }
    }
}
