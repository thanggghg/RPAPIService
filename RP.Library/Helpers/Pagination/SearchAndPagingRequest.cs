namespace GoSell.Library.Helpers.Pagination
{
    public class SearchAndPagingRequest : PagingRequest
    {
        public string Keyword { get; set; }
        public string SearchType { get; set; }
    }
}
