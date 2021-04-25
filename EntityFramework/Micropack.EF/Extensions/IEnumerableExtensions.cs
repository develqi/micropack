using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;

namespace Micropack.EF
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Except<T, TKey>(this IEnumerable<T> items, IEnumerable<T> other, Func<T, TKey> getKeyFunc)
        {
            return items.GroupJoin(other, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems })
                        .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                        .Where(t => t.temp is null || t.temp.Equals(default(T)))
                        .Select(t => t.t.item);
        }
    }
}
