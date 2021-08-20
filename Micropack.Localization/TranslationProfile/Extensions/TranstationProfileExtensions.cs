using System;
using System.Linq;
using System.Collections.Generic;

namespace Micropack.Localization
{
    internal static class TranstationProfileExtensions
    {
        internal static Transtation Find(this IEnumerable<Transtation> transtations, string key)
        {
            var translation = transtations.FirstOrDefault(error => error.Dictionary.Key == key);

            if (translation is null)
                throw new ArgumentNullException("ErrorKey", "TranslationProfile.cs error=> Error key is null or empty");

            return translation;
        }

        internal static bool HasKey(this IEnumerable<Transtation> transtations, string key)
        {
            return transtations.Any(information => information.Dictionary.Key == key);
        }

        internal static void AddKey(this IList<Transtation> transtations, string key, LocalizationTypes type)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("Key", "TranslationProfile.cs error=> key is null or empty");

            if (!transtations.HasKey(key))
                transtations.Add(new Transtation(key, type));
        }
    }
}
