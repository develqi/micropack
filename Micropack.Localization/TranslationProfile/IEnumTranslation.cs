using System;

namespace Micropack.Localization
{
    public record EnumItem(string EnumName, DictionaryJson[] EnumItems);

    public interface IEnumTranslation
    {
        EnumItem [] Enums { get; }

        void EnumFor<TEnum>() where TEnum : Enum;
    }
}
