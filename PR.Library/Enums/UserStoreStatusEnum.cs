using System.ComponentModel;

namespace GoSell.Library.Enums
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
