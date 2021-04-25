using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Micropack.Localization
{
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public ICollection<LabelTranslation> LabelTranslations { get; set; }

        public ICollection<ValidationMessageTranslation> ValidationMessageTranslations { get; set; }
        
        public ICollection<InformationMessageTranslation> InformationMessageTranslations { get; set; }
    }

    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Abbreviation).HasMaxLength(3);

            //builder.HasIndex(p => p.Name).IsUnique().HasDatabaseName("IX_Name");
            //builder.HasIndex(p => p.Abbreviation).IsUnique().HasDatabaseName("IX_Abbreviation");

            //seed data
            builder.HasData(
                            new Language { Id = 1, Name = "Persian", Abbreviation = "Fa" },
                            new Language { Id = 2, Name = "English", Abbreviation = "En" }
                           );
        }
    }
}
