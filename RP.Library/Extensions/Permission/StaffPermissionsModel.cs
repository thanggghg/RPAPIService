using Newtonsoft.Json;

namespace RP.Library.Extensions.Permission
{
    public class StaffPermissionsModel
    {
        public long UserId { get; set; }
        public long StoreId { get; set; }
        public long StaffId { get; set; }
        public string StaffName { get; set; }
        [JsonProperty("staffPermissions")]
        public Dictionary<string, int> StaffPermissions { get; set; }
    }
}
