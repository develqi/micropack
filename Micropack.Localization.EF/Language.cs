using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Micropack.Localization.EF
{
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public ICollection<Transtation> Transtations { get; set; }
    }

    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages", "Localization");

            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Abbreviation).HasMaxLength(3);

            builder.HasData(
                            new Language { Id = 1, Name = "Persian", Abbreviation = "Fa" },
                            new Language { Id = 2, Name = "English", Abbreviation = "En" }
                           );
        }
    }
}
