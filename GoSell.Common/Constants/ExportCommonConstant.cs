namespace GoSell.Common.Constants
{
    public class ExportCommonConstant
    {
        public const int DEFAULT_PAGE_INDEX = 0;
        public const int PAGE_SIZE = 20;
        public const string TEXT = "text";
        public const string NUMBER = "number";
        public const string DATE = "date";
        public const string EN = "en";
        public const string VI = "vi";
        public const int SIZE_LIMIT = 5000;
    }

    public class LocalizationExportCommonConstants
    {
        public const string ORDER_COMMISSION_REPORT_CAPTION = "export.affOrderCommissionReport.caption.";
        public const string ORDER_COMMISSION_REPORT_CELL = "export.affOrderCommissionReport.cellValue.";
        public const string ORDER_COMMISSION_REPORT_TEMPLATE_FILENAME = "export.affOrderCommissionReport.template.fileName";
        public const string ORDER_COMMISSION_REPORT_TEMPLATE_SHEETNAME = "export.affOrderCommissionReport.template.sheetName";
        public const string PRODUCT_COMMISSION_REPORT_TEMPLATE_FILENAME = "export.affProductCommissionReport.template.fileName";
        public const string CAMPAIGN_COMMISSION_REPORT_TEMPLATE_FILENAME = "export.affCampaignCommissionReport.template.fileName";

        public const string URL_REPORT_CAPTION = "export.orderExternalStore.exportSubmission.affUrlReport.caption.";
        public const string URL_REPORT_TEMPLATE_FILENAME = "export.orderExternalStore.exportSubmission.affUrlReport.template.fileName";
        public const string URL_REPORT_TEMPLATE_SHEETNAME = "export.orderExternalStore.exportSubmission.affUrlReport.template.sheetName";
    }

    public static class CurrencyConstants
    {
        public const string VND = "VND";
        public const string USD = "USD";
        public const string OTHER = "OTHER";
    }

    public static class CurrencyFormats
    {
        public const string VND = "{0:#,##0}";
        public const string OTHER = "{0:#,##0.##}";
    }
}
