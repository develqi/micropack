using System.Linq;

namespace Micropack.DesignPattern.Specification
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> WhereRule<T>(this IQueryable<T> query, BusinessRule<T> rule) 
            where T : class 
                           => query.Where(rule.Predictate);
    }
}