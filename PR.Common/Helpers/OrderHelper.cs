using System.Reflection;
using GoSell.Common.Enums;

namespace GoSell.Common.Helpers
{
    public static class OrderHelper
    {
        public static IEnumerable<T> CustomEnumerableOrderBy<T>(this IEnumerable<T> data, string orderBy, string thenBy, SortDirection sortType)
        {
            if (string.IsNullOrWhiteSpace(orderBy) || data == null)
                return data;

            IOrderedEnumerable<T> orderedData;

            var property = typeof(T).GetProperty(orderBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
                throw new ArgumentException($"Property '{orderBy}' not found in type '{typeof(T).Name}'.");

            if (sortType == SortDirection.ASC)
            {
                orderedData = data.OrderBy(item => property.GetValue(item, null));
            }
            else
            {
                orderedData = data.OrderByDescending(item => property.GetValue(item, null));
            }

            if (!string.IsNullOrWhiteSpace(thenBy))
            {
                var thenByProperty = typeof(T).GetProperty(thenBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (thenByProperty == null)
                    throw new ArgumentException($"Property '{thenBy}' not found in type '{typeof(T).Name}'.");

                if (sortType == SortDirection.ASC)
                {
                    orderedData = orderedData.ThenBy(item => thenByProperty.GetValue(item, null));
                }
                else
                {
                    orderedData = orderedData.ThenByDescending(item => thenByProperty.GetValue(item, null));
                }
            }

            return orderedData;
        }
    }
}
