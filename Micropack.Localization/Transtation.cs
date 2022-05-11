using System.Linq;

namespace Micropack.Localization
{
    public class Transtation
    {
        internal Transtation(string key, LocalizationTypes type)
        {
            Type = type;
            Dictionary = new DictionaryJson { Key = key };
        }

        public DictionaryJson Dictionary { get; private set; }

        public LocalizationTypes Type { get; private set; }

        internal void Fa(string fa)
        {
            var faDictionaryItem = Dictionary.Items.FirstOrDefault(item => item.Code == "Fa");
            if(faDictionaryItem != null)
                faDictionaryItem.Caption = fa;

            faDictionaryItem = new DictionaryItem { Caption = fa, Code = "Fa" };
            Dictionary.Items.Add(faDictionaryItem);
        }

        internal void En(string en)
        {
            var enDictionaryItem = Dictionary.Items.FirstOrDefault(item => item.Code == "En");
            if (enDictionaryItem != null)
                enDictionaryItem.Caption = en;

            enDictionaryItem = new DictionaryItem { Caption = en, Code = "En" };
            Dictionary.Items.Add(enDictionaryItem);
        }
    }
}
