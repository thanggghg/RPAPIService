using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace RP.Library.Helpers.Pagination
{
    public static class QueryableExtensions
    {
        public static Task<PagingItems<T>> PaginatedListAsync<T>(this IQueryable<T> queryable, int pageSize, int pageNumber, bool? isPaging = true) where T : class
        {
            return PagingItems<T>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize, isPaging);
        }

        public static IQueryable<T> DynamicContainsQuery<T>(this IQueryable<T> queryable, string columnName, string keyword)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, columnName);
                var propertyType = typeof(T).GetProperty(columnName)?.PropertyType;
                var containsMethod = propertyType?.GetMethod("Contains", new[] { typeof(string) });

                if (containsMethod == null)
                {
                    throw new ArgumentException($"Type {propertyType} does not have a Contains method with columnName {columnName}");
                }

                var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                var toLowerCall = Expression.Call(property, toLowerMethod);

                var containsCall = Expression.Call(toLowerCall, containsMethod, Expression.Constant(keyword.ToLower()));

                var lambda = Expression.Lambda<Func<T, bool>>(containsCall, parameter);

                return queryable.Where(lambda);
            }
            catch
            {
                throw new ArgumentException("Error DynamicContainsQuery", columnName);
            }
        }

        public static IQueryable<T> OrderByName<T>(this IQueryable<T> source, string propertyName, bool sortASC)
        {
            try
            {
                if (source == null)
                {
                    throw new ArgumentNullException(nameof(source));
                }

                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    throw new ArgumentException("Order by property should not empty", nameof(propertyName));
                }

                Type type = typeof(T);
                ParameterExpression arg = Expression.Parameter(type, "x");
                PropertyInfo propertyInfo = type.GetProperty(propertyName);
                Expression expression = Expression.Property(arg, propertyInfo);
                type = propertyInfo.PropertyType;

                Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
                LambdaExpression lambda = Expression.Lambda(delegateType, expression, arg);

                var methodName = sortASC ? "OrderBy" : "OrderByDescending";
                object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
                return (IQueryable<T>)result;
            }
            catch
            {
                throw new ArgumentException("Error OrderByName", propertyName);
            }
        }
    }
}
