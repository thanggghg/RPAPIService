using Microsoft.EntityFrameworkCore;

namespace RP.Library.Helpers.Pagination
{
    public class PagingItems<T> where T : class
    {
        public PagingItems()
        {
        }

        public PagingItems(IEnumerable<T> items, int pageSize, int pageNumber, int totalItems)
        {
            Items = items;
            PagingInfo = new PagingInfo
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                TotalItems = totalItems
            };
        }

        public PagingItems(IEnumerable<T> items, PagingInfo pagingInfo)
        {
            Items = items;
            PagingInfo = pagingInfo;
        }

        public IEnumerable<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public static async Task<PagingItems<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, bool? isPaging = true)
        {
            var totalItems = await source.CountAsync();
            if (isPaging == true)
            {
                var items = await source.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
                return new PagingItems<T>(items, pageSize, pageNumber, totalItems);
            }
            else
            {
                var items = await source.ToListAsync();
                return new PagingItems<T>(items, totalItems, 0, totalItems);
            }          
        }
    }
}
