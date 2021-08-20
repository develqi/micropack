namespace Micropack.Localization
{
    public class Transtation
    {
        internal Transtation(string key, LocalizationTypes type)
        {
            Type = type;
            Dictionary = new Dictionary { Key = key };
        }

        public Dictionary Dictionary { get; private set; }

        public LocalizationTypes Type { get; private set; }

        internal void Fa(string fa) => Dictionary.Fa = fa;

        internal void En(string en) => Dictionary.En = en;
    }
}
