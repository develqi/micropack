using System.Linq;
using System.Collections.Generic;

namespace Micropack.Localization
{
    public class DictionaryJson
    {
        public byte Order { get; set; }

        public string Key { get; set; }

        public string Caption(string code = null)
        {
            if (code is null)
            {
                var firstItem = Items.FirstOrDefault();
                return firstItem.Alias ?? firstItem.Caption;
            }

            var dictionaryItem = Items.FirstOrDefault(item => item.Code == code);
            if(dictionaryItem == null)
                return null;

           return dictionaryItem.Alias ?? dictionaryItem.Caption;
        }

        public DictionaryItem Item(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Items.FirstOrDefault();

            return Items.FirstOrDefault(item => item.Code.ToLower() == code.ToLower());
        }

        public List<DictionaryItem> Items { get; set; } = new();

        public bool ShouldSerializeOrder() => Order > 0;

        public bool ShouldSerializeItems() => Items is not null;

        public bool ShouldSerializeKey() => !(string.IsNullOrWhiteSpace(Key));
    }
}
