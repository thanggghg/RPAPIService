namespace RP.Library.Helpers.Pagination
{
    public class PagingAndSortingRequest : PagingRequest
    {
        public string SortName { get; set; }
        public bool SortASC { get; set; }
    }
}
