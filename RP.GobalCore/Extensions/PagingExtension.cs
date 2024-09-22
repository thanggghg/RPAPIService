using RP.Common.Models;

namespace RP.Affiliate.Tracking.Extensions
{
    public static class PagingExtension<T> where T : class
    {
        public static PaginatedList<T> ConvertPaging(List<T> data, int pageNumber = 1, int pageSize = 5, int count = 0)
        {
            return new PaginatedList<T>(data, count, pageNumber, pageSize);
        }
    }
}
