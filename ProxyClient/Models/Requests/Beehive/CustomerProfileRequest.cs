namespace ProxyClient.Models.Requests.Beehive
{
    public class CustomerProfileRequest
    {
        public long StoreId { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; } = int.MaxValue;

        public string Keyword { get; set; }

        public string Sort { get; set; } = "DESC";

        public string BranchIds { get; set; }

        public bool IgnoreBranch { get; set; } = true;

        public string SearchField { get; set; } = "NAME";

        public double? OperationDebtAmount { get; set; }

        public double? DebtAmountValue { get; set; } = 0;

        public bool OnlyContact { get; set; } = false;

        public string CustomerTypes { get; set; } = "CONTACT_CUSTOMER";

        public string SortType { get; set; } = "CREATED_DATE";
    }
}
