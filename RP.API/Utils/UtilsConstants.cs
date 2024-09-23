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
      
        public enum TypeTakeTopAnalytics
        {
            [Description("TopVolume")]
            TopVolume = 1,
            [Description("TopValue")]
            TopValue = 2,
        }

      
    }
}
