using System;

namespace Micropack.Localization
{
    public record EnumJson(string EnumName, DictionaryJson[] EnumItems);

    public interface IEnumTranslation
    {
        EnumJson[] Enums { get; }

        void EnumFor<TEnum>() where TEnum : Enum;
    }
}
