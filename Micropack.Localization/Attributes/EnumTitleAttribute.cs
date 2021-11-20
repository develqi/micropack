using System;

namespace Micropack.Localization
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class EnumTitleAttribute : Attribute
    {
        private readonly string _fa;
        private readonly string _en;
        private readonly string _key;

        public EnumTitleAttribute(string key, string fa, string en = null)
        {
            _fa = fa;
            _en = en;
            _key = key;
        }
    }
}
