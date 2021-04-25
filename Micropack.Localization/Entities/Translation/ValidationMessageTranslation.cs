using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Micropack.Localization
{    
    // ToDo: ErrorMessageTranslation 
    // ToDo: BusinessRuleMessageTranslation 
    public class ValidationMessageTranslation : Translation
    {

    }

    public class ValidationTranslationMap : IEntityTypeConfiguration<ValidationMessageTranslation>
    {
        public void Configure(EntityTypeBuilder<ValidationMessageTranslation> builder)
        {
            builder.Property(p => p.Key).HasMaxLength(150);
            builder.Property(p => p.Value).HasMaxLength(500);
            builder.Property(p => p.CustomValue).HasMaxLength(500);

            //builder.HasIndex(x => new { x.Key, x.LanguageId }).IsUnique().HasDatabaseName("IX_Key_LanguageId");

            builder.HasOne(x => x.Language).WithMany(x => x.ValidationMessageTranslations).HasForeignKey(x => x.LanguageId);
        }
    }
}
