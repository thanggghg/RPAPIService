using GoSell.Common.Enums;

namespace GoSell.Common.Models
{
    public class AffiliateUserStoreModelRespone
    {
        public List<AffiliateUserStoreModel> AffiliateUserStoreModels { get; set; }
    }
    public class AffiliateUserStoreModel
    {
        public long Id { get; set; }
        public string PublisherCode { get; set; }
        public string PublisherName { get; set; }
        public UserStoreStatusEnum Status { get; set; }
    }
}
