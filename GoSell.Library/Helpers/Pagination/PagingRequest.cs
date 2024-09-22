namespace GoSell.Library.Helpers.Pagination
{
    public class PagingRequest
    {
        private const int DefaultPageSize = 20;
        private const int DefaultPageNumber = 0;
        private const bool DefaultPaging = false;

        private int? _pageSize;
        private int? _pageNumber;
        private bool? _isPaging;

        public int? PageSize
        {
            get
            {
                if (_pageSize == null || _pageSize <= 0) _pageSize = DefaultPageSize;

                return _pageSize.Value;
            }
            set
            {
                _pageSize = value;
            }
        }

        public int? PageNumber
        {
            get
            {
                if (_pageNumber == null || _pageNumber < 0) _pageNumber = DefaultPageNumber;

                return _pageNumber.Value;
            }
            set
            {
                _pageNumber = value is null || value < 0 ? DefaultPageNumber : value;
            }
        }

        public bool? IsPaging
        {
            get
            {
                if (_isPaging == null) _isPaging = DefaultPaging;

                return _isPaging.Value;
            }
            set
            {
                _isPaging = value is null ? DefaultPaging : value;
            }
        }

        public int GetSkipItems()
        {
            return PageNumber.Value * PageSize.Value;
        }
    }
}
