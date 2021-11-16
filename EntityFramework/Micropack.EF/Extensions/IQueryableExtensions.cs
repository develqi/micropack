using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Micropack.Domain.Abstraction;

namespace Micropack.EF
{
    public static class IQueryableExtensions
    {
        //public static IQueryable<dynamic> PaginationToQuery<TEntity>(this IQueryable<TEntity> query, PaginationRequest pagination) where TEntity : class
        //{
        //    return query.Sort(pagination.Sort)
        //                .Pagination(pagination.Page, pagination.Size)
        //                .DynamicSelect(pagination.Select);
        //}

        public static IQueryable<TEntity> UnionSpecialId<TEntity>(this IQueryable<TEntity> query, int recordId) where TEntity : class, IEntityNumeric
        {
            return query.Union(query.Where(x => recordId == 0 || x.Id == recordId));
        }

        public static IQueryable<TEntity> Pagination<TEntity>(this IQueryable<TEntity> query, int page, int count) where TEntity : class
        {
            return page == 1 ? query.Take(count) : query.Skip((page - 1) * count).Take(count);
        }

        public static IQueryable<dynamic> DynamicSelect<TEntity>(this IQueryable<TEntity> query, string select) 
            where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(select))
                return query;

            try
            {
                var dynamicProperties = select.Replace(" ", "").Split(',').Select(x => $"{char.ToUpperInvariant(x[0])}{x.Substring(1)}");

                var properties = dynamicProperties
                    .Select(f => typeof(TEntity).GetProperty(f))
                    .Select(p => new DynamicProperty(p.Name, p.PropertyType))
                    .ToList();

                var resultType = DynamicClassFactory.CreateType(properties, false);

                var source = Expression.Parameter(typeof(TEntity), "o");

                var bindings = properties.Select(p => Expression.Bind(resultType.GetProperty(p.Name), Expression.Property(source, p.Name)));

                var result = Expression.MemberInit(Expression.New(resultType), bindings);

                var dynamicExpression = Expression.Lambda<Func<TEntity, dynamic>>(result, source);

                return query.Select(dynamicExpression);
            }
            catch
            {
                return query;
            }
        }

        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, string orderby) where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(orderby))
                return query;

            var orderParams = orderby.Trim().Split(',');
            var propertyInfos = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
                return query;

            return query.OrderBy(orderQuery);
        } 

        public static IQueryable<TEntity> WhereIdEqual<TEntity>(this IQueryable<TEntity> query, Guid id) 
            where TEntity : class, IEntityGuid => query.Where(x => x.Id == id);

        public static IQueryable<TEntity> WhereIdEqual<TEntity>(this IQueryable<TEntity> query, int id)
            where TEntity : class, IEntityNumeric => query.Where(x => x.Id == id);
    }
}
