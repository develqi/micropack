using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Micropack.EF
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder HasJsonConversion<JObject>(this PropertyBuilder propertyBuilder) where JObject : class
        {
            var converter = new ValueConverter<JObject, string>(
                                                                value => JsonConvert.SerializeObject(value),
                                                                dbValue => JsonConvert.DeserializeObject<JObject>(dbValue));

            var comparer = new ValueComparer<JObject>(
                                                      (l, r) => JsonConvert.SerializeObject(l) == JsonConvert.SerializeObject(r),
                                                      value => value == null ? 0 : JsonConvert.SerializeObject(value).GetHashCode(),
                                                      dbValue => JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(dbValue)));

            propertyBuilder.HasConversion(converter);
            propertyBuilder.Metadata.SetValueConverter(converter);
            propertyBuilder.Metadata.SetValueComparer(comparer);

            return propertyBuilder;
        }
    }
}