
namespace Micropack.Localization
{
    public class DictionaryItem
    {
        public string Caption { get; set; }

        /// <summary>
        /// متن اختصاصی که کاربر جایگزین میکند
        /// </summary>
        public string Alias { get; set; }

        public string? Code { get; set; }

        public bool ShouldSerializeCaption() => !(string.IsNullOrWhiteSpace(Caption));

        public bool ShouldSerializeAlias() => !(string.IsNullOrWhiteSpace(Alias));
    }
}
