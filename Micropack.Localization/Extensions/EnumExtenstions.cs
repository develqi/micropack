using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Micropack.Localization
{
    public static class EnumExtenstions
    {
        private static CustomAttributeData GetEnumTitleAttribute(this Enum item)
        {
            return item.GetType().GetField(item.ToString()).CustomAttributes.FirstOrDefault(attr => attr.AttributeType == typeof(EnumTitleAttribute));
        }

        public static string TitleFa(this Enum item)
        {
            return item.GetEnumTitleAttribute().ConstructorArguments[1].Value?.ToString();
        }

        public static string TitleEn(this Enum item)
        {
            return item.GetEnumTitleAttribute().ConstructorArguments[2].Value?.ToString();
        }

        public static List<Dictionary> GetDictionaryItems<TEnum>() where TEnum : Enum
        {
            var items = typeof(TEnum).GetMembers()
                .Select(item => new { item.Name, Attribute = item.GetCustomAttribute<EnumTitleAttribute>() })
                .Where(item => item.Attribute is not null)
                .Select(item => item.Name.ToEnum<TEnum>())
                .Select(item => new Dictionary 
                {
                    Key = item.ToString(), Fa = item.TitleFa(), En = item.TitleEn()
                })
                .ToList();

            return items;
        }

        private static TEnum ToEnum<TEnum>(this string value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value, true);
        }

        public static TEnum GetFilteredEnum<TEnum>(this string filter) where TEnum : Enum
        {
            if (string.IsNullOrWhiteSpace(filter))
                return default;

            var items = typeof(TEnum).GetMembers()
                .Select(item => new { Name = item.Name, Attribute = item.GetCustomAttribute<EnumTitleAttribute>() })
                .Where(item => item.Attribute is not null)
                .Select(item => item.Name.ToEnum<TEnum>())                
                .Select(item => new {Item = item, TitleFa = item.TitleFa(), TitleEn = item.TitleEn() })
                .ToList();

            return items.Where(item => item.TitleFa.Contains(filter)).Select(item => item.Item).FirstOrDefault();
        }
    }
}
