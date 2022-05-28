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

        public static byte Id(this Enum item)
        {
            try
            {
                return (byte)Enum.Parse(item.GetType(), item.ToString());
            }
            catch
            {
                var id = (int)Enum.Parse(item.GetType(), item.ToString());
                return byte.Parse(id.ToString());
            }
        }

        public static List<EnumDictionaryJson> GetDictionaryItems<TEnum>() where TEnum : Enum
        {
            var items = typeof(TEnum).GetMembers()
                .Select(item => new { item.Name, Attribute = item.GetCustomAttribute<EnumTitleAttribute>() })
                .Where(item => item.Attribute is not null)
                .Select(item => item.Name.ToEnum<TEnum>())
                .Select(item => new EnumDictionaryJson
                {
                    Id = item.Id(),
                    Key = item.ToString(),
                    Items = new List<DictionaryItem>
                    {
                        new DictionaryItem{ Code = "Fa", Caption = item.TitleFa() },
                        new DictionaryItem{ Code = "En", Caption = item.TitleEn() }
                    }.Cast<DictionaryItem>().ToList()
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
