namespace RP.Library.Helpers.Pagination
{
    public class SearchPagingAndSortingRequest : PagingAndSortingRequest
    {
        public string Keyword { get; set; }
        public string SearchType { get; set; }
    }
}
