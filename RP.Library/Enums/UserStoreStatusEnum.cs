using System.ComponentModel;

namespace RP.Library.Enums
{
    public enum UserStoreStatusEnum
    {
        [Description("Pending")]
        PENDING,
        [Description("Activated")]
        ACTIVATED,
        [Description("InActived")]
        INACTIVED,
        [Description("Locked")]
        LOCKED,
        [Description("Rejected")]
        REJECTED,
    }
}
