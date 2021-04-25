using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Micropack.Localization
{  
    public class LabelTranslation : Translation
    {
       
    }

    public class LabelTranslationMap : IEntityTypeConfiguration<LabelTranslation>
    {
        public void Configure(EntityTypeBuilder<LabelTranslation> builder)
        {
            builder.Property(p => p.Key).HasMaxLength(150);
            builder.Property(p => p.Value).HasMaxLength(150);
            builder.Property(p => p.CustomValue).HasMaxLength(150);

            //builder.HasIndex(p => p.Key).IsUnique().HasDatabaseName("IX_Key");

            //builder.HasIndex(x => new { x.Key, x.LanguageId }).IsUnique().HasDatabaseName("IX_Key_LanguageId");

            //ToDo: بررسی راهکاری برای تعریف داده های ترجمه
            // مثلا چیزی شبیه کلاس های پروفایل در اتو مپر
            // استفاده از نام اختصاری زبان به جای شناسه عددی زبان جهت ساده تر شدن تعریف اطلاعات
            // در زبان های مختلف
            builder.HasData(
                new LabelTranslation { Id = 1, Key = "Module", Value = "ماژول", CustomValue = "", LanguageId = 1 },
                     new LabelTranslation { Id = 1, Key = "Module", Value = "Module", CustomValue = "", LanguageId = 2 }
                );
        }
    }
}
