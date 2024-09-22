namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class ImportAffiliateCategoryResponse
    {
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }        
        public bool HasError { get; set; }
        public int ErrorCount { get; set; }
        public byte[] ErrorData { get; set; }   
    }
}
