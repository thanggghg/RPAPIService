using Nest;
namespace RP.API.Domains.Elastics
{
    public class GosellOrderModel
    {
        public int? StoreId { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public string Currency { get; set; }
        public long? BranchId { get; set; }
        public string BranchName { get; set; }
        public string ReturnStatus { get; set; }
        public int? ItemsCount { get; set; }
        public string Channel { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<GosellItemOrderModel> Items { get; set; } = new List<GosellItemOrderModel>();
    }
    public class GosellItemOrderModel
    {
        public long? ItemId { get; set; }
        public string Name { get; set; }
        [Ignore]
        public string ItemModelId { get; set; }
        public int? Quantity { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalDiscount { get; set; }
    }
}
