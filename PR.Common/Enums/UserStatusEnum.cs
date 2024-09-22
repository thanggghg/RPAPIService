using System.ComponentModel;

namespace GoSell.Common.Enums
{
    public enum UserStatusEnum
    {
        PRE_ACTIVATED,
        REGISTERED,
        ACTIVATED,
        LOCKED
    }

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

    public enum UserStoreTabTypeEnum
    {
        [Description("Publishers")]
        PUBLISHERS,
        [Description("Applications")]
        APPLICATIONS
    }
}
