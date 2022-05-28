using System;

namespace Micropack.Localization
{
    public record EnumJson(string EnumName, EnumDictionaryJson[] EnumItems);

    public interface IEnumTranslation
    {
        EnumJson[] Enums { get; }

        void EnumFor<TEnum>() where TEnum : Enum;
    }
}
