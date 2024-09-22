namespace GoSell.Common.Models
{
    public class PublisherUserBankInfoResponse
    {
        public long Id { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
