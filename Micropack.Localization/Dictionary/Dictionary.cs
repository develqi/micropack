﻿using System.Collections.Generic;

namespace Micropack.Localization
{
    public class Dictionary
    {
        public byte Order { get; set; }

        public string Key { get; set; }

        public string Fa { get; set; }

        public string En { get; set; }

        /// <summary>
        /// متن اختصاصی که کاربر جایگزین میکند
        /// </summary>
        public string Alias { get; set; }

        public bool ShouldSerializeFa() => !(string.IsNullOrWhiteSpace(Fa));

        public bool ShouldSerializeEn() => !(string.IsNullOrWhiteSpace(En));

        public bool ShouldSerializeAlias() => !(string.IsNullOrWhiteSpace(Alias));

        public List<DictionaryItem> Items { get; set; }
    }
}
