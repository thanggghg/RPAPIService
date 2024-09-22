namespace RP.Library.Helpers.Service.Model
{
    public class AffililateStoreReponse
    {
        public long Id { get; set; }

        public long GoSellStoreId { get; set; }
    }

    public class PublisherBaseResponse
    {
        public long Id { get; set; }    // is PublisherId

        public long StoreId { get; set; }

        public long UserId { get; set; }

        public string UserCode { get; set; }

        public string FullName { get; set; }
    }

    public class GetPublisherFilterRequest
    {
        public long AffiliateStoreId { get; set; }

        public List<long> PublisherIds { get; set; }

        public List<string> PublisherCodes { get; set; }

        public string PublisherName { get; set; }
        public string PublisherCode { get; set; }
    }

    public class GetAllAffiliateStoreByGoSellIdRequest
    {
        public bool? isDeleted { get; set; }
        public long GoSellStoreId { get; set; }
    }
}
