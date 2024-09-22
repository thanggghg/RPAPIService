using System.ComponentModel;
namespace RP.API.Utils
{
    public static class UtilsConstants
    {
        public static int DefaultPageNumber = 1;
        public static int DefaultPageSize = 20;
        public static int DefaultESRespone = 10000;
        public static int DefaultTopResponse = 5;
        public static string DefaultLang = "vi";
        public static string DefaultOderField = "Volumes";
        public static string StoreBranchIndex = "storebranch";
        public static string GosellOrderIndex = "gosell_order";
        public static string SegmentIndex = "segment";
        public static string CustomerProfileIndex = "customerprofile";
        public static string DefaultSort = "asc";
        public static string GroupByKey = "groupByKey";
        public static string SumValues = "sum_values";
        public static string SumVolumes = "sum_volumes";
        public static string ItemsCount = "itemsCount";
        public static string ItemsPrice = "items.price";
        public static string BranchName = "branch_name";
        public static string BranchNameKeyword = "branchName.keyword";
        public static string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        public static int ProductIdLimit = 1000;
        public enum WidgetTypes
        {
            [Description("SALE_PERFORMANCE")]
            SalePerformance = 1,
            [Description("UNIT_RETURN")]
            UnitReturn = 2,
            [Description("PRODUCTS")]
            Products = 3,
            [Description("REMAINING_STOCK")]
            RemainingStock = 4,
            [Description("FREQUENCY_INVENTORY")]
            FrequencyInventory = 5,
            [Description("SALE_PERFORMANCE_BY_PRODUCT")]
            SalePerformanceByProduct = 6,
            [Description("OTHER")]
            Other = 99
        }
        public enum FilterAnalyticTypes
        {
            [Description("ProductName")]
            ProductName = 1,
            [Description("Channel")]
            Channel = 2,
            [Description("CustomerSegment")]
            CustomerSegment = 3,
            [Description("Geographical")]
            Geographical = 4,
            [Description("Branch")]
            Branch = 5
        }
        public enum TypeTakeTopAnalytics
        {
            [Description("TopVolume")]
            TopVolume = 1,
            [Description("TopValue")]
            TopValue = 2,
        }

        public enum SortByField
        {
            [Description("Volumes")]
            Volumes = 1,
            [Description("Values")]
            Values = 2,
        }

        public enum AggregationsType
        {
            [Description("Sum")]
            Sum = 1,
            [Description("Term")]
            Term = 2,
        }

        public enum OrderStatus
        {
            [Description("DELIVERED")]
            DELIVERED = 1,
            [Description("RETURNED")]
            RETURNED = 2,
            [Description("COMPLETED")]
            COMPLETED = 3,
            [Description("CANCELLED")]
            CANCELLED = 6,
        }

        public enum PurchaseOrderStatus
        {
            [Description("ORDER")]
            ORDER = 1,
            [Description("IN_PROGRESS")]
            IN_PROGRESS = 2,
            [Description("COMPLETED")]
            COMPLETED = 3,
            [Description("CANCELED")]
            CANCELED = 4,
        }

        public enum ItemStatus
        {
            [Description("ACTIVE")]
            ACTIVE = 1,
            [Description("ERROR")]
            ERROR = 2,
        }

        public enum BranchStatus
        {
            [Description("ACTIVE")]
            ACTIVE = 1,
            [Description("INACTIVE")]
            INACTIVE = 2,
        }

        public enum SortType
        {
            [Description("ASC")]
            ASC = 1,
            [Description("DESC")]
            DESC = 2,
        }

        public enum GroupByDate
        {
            WEEK,
            MONTH
        }

        public enum ActionRequest
        {
            [Description("Create")]
            Create = 1,
            [Description("Edit")]
            Edit = 2,
            [Description("Delete")]
            Delete = 3,
        }

        public enum CommissionSettingType
        {
            [Description("DefaultForAll")]
            DefaultForAll = 0,
            [Description("AllProduct")]
            AllProduct = 1,
            [Description("AllAffiliate")]
            AllAffiliate = 2,
            [Description("AllCollection")]
            AllCollection = 3,
            [Description("AllCategory")]
            AllCategory = 4,
            [Description("AllCampaign")]
            AllCampaign = 5,
        }
    }
}
