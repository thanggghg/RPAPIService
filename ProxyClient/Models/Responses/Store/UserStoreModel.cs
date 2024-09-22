namespace ProxyClient.Models.Responses.Store
{
    public class UserStoreModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ImageModel StoreImage { get; set; }

        public StoreType StoreType { get; set; }

        public string City { get; set; }

        public string DashboardDomain { get; set; }

        public List<long> CategoryIds { get; set; }
    }

    public enum StoreType
    {
        PRODUCT,
        DEAL,
    }
}
