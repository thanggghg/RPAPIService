using System.Linq.Expressions;
using System.Reflection;

namespace GoSell.Common.Helpers
{
    public static class SearchHelper<T>
    {
        public static Expression<Func<T, bool>> GetQueryConditionsFromSearchKeyword(string searchType, string searchKeyword)
        {
            if (!string.IsNullOrEmpty(searchType) && !string.IsNullOrEmpty(searchKeyword))
            {
                PropertyInfo property = typeof(T).GetProperties().FirstOrDefault(p => string.Equals(p.Name, searchType, StringComparison.OrdinalIgnoreCase));

                if (property != null)
                {
                    string normalizedSearchKeyword = searchKeyword.ToLower();

                    ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
                    MemberExpression propertyAccess = Expression.Property(parameter, property);

                    ConstantExpression searchValue = Expression.Constant(normalizedSearchKeyword, typeof(string));
                    MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                    if (property.PropertyType != typeof(string))
                    {
                        // Convert non-string properties to string and then perform Contains
                        MethodInfo toStringMethod = property.PropertyType.GetMethod("ToString", Type.EmptyTypes);
                        MethodCallExpression toStringExp = Expression.Call(propertyAccess, toStringMethod);
                        MethodCallExpression containsMethodExp = Expression.Call(toStringExp, containsMethod, searchValue);
                        return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameter);
                    }
                    else
                    {
                        MethodInfo toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                        MethodCallExpression toLowerExp = Expression.Call(propertyAccess, toLowerMethod);
                        MethodCallExpression containsMethodExp = Expression.Call(toLowerExp, containsMethod, searchValue);
                        return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameter);
                    }
                }
            }
            return Expression.Lambda<Func<T, bool>>(Expression.Constant(true), Expression.Parameter(typeof(T), "x"));
        }

    }
}
