using GoSell.Library.Enums;

namespace GoSell.Library.Constants
{
    public class StaffPermission
    {
        public StaffPermissionEnum ThirdLevel { get; set; }
        public string SecondLevel { get; set; }
        public string FirstLevel { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int BitIndex { get; set; }
        public string CombinedKey => $"{FirstLevel}-{SecondLevel}";
    }
    public static class StaffPermissionConstanst
    {
        public static List<StaffPermission> StaffPermissionList { get; set; }

        static StaffPermissionConstanst()
        {
            StaffPermissionList = new List<StaffPermission>
            {
                new() { FirstLevel = "affiliateExternalStore", SecondLevel = "affiliatePublishers", ThirdLevel = StaffPermissionEnum.ViewPublisherList, Name = "View Publisher List", Code = 1, BitIndex = 0 },
                new() { FirstLevel = "affiliateExternalStore", SecondLevel = "affiliatePublishers", ThirdLevel = StaffPermissionEnum.ViewPublisherDetail, Name = "View Publisher Detail", Code = 2, BitIndex = 1 },
                new() { FirstLevel = "affiliateExternalStore", SecondLevel = "affiliatePublishers", ThirdLevel = StaffPermissionEnum.ApproveRejectPublisher, Name = "Approve/Reject Publisher", Code = 4, BitIndex = 2 },
                new() { FirstLevel = "affiliateExternalStore", SecondLevel = "affiliatePublishers", ThirdLevel = StaffPermissionEnum.EditPublisher, Name = "Edit Publisher", Code = 8, BitIndex = 3 },
                new() { FirstLevel = "affiliateExternalStore", SecondLevel = "affiliatePublishers", ThirdLevel = StaffPermissionEnum.ActiveDeactivePublisher, Name = "Activate/Deactivate Publisher", Code = 16, BitIndex = 4 },
                new() { FirstLevel = "affiliateExternalStore", SecondLevel = "affiliatePublishers", ThirdLevel = StaffPermissionEnum.BlockUnblockPublisher, Name = "Block/Unblock Publisher", Code = 32, BitIndex = 5 },

                new() { FirstLevel = "affiliateExternalStore", SecondLevel = "externalStoreSetting", ThirdLevel = StaffPermissionEnum.AutoApprovePublisher, Name = "Auto-Approve Publisher", Code = 1024, BitIndex = 10 },
                new() { FirstLevel = "affiliateExternalStore", SecondLevel = "externalStoreSetting", ThirdLevel = StaffPermissionEnum.AllowPublisherRegister, Name = "Allow Publisher Register", Code = 2048, BitIndex = 11 },
            };
        }
    }

}
