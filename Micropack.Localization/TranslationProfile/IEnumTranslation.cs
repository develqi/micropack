using System;

namespace Micropack.Localization
{
    public record EnumItem(string EnumName, Dictionary[] EnumItems);

    public interface IEnumTranslation
    {
        EnumItem [] Enums { get; }

        void EnumFor<TEnum>() where TEnum : Enum;
    }
}
