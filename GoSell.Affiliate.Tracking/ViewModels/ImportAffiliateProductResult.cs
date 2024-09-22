namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class ImportAffiliateProductResult
    {
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }        
        public bool HasError { get; set; }
        public int ErrorCount { get; set; }
        public byte[] ErrorData { get; set; }   
    }
}
