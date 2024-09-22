namespace ProxyClient.Models.Responses.Store
{
    public class StoreStaffModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public long StoreId { get; set; }
        public bool Enabled { get; set; } = false;
         
    }
}
