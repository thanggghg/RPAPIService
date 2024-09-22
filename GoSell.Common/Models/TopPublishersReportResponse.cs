namespace GoSell.Common.Models
{
    public class TopPublishersReportResponse
    {
        public long PublisherId { get; set; }
        public string PublisherCode { get; set; }
        public string PublisherName { get; set; }
        public decimal Revenue { get; set; }
        public decimal Commission { get; set; }
    }
}
