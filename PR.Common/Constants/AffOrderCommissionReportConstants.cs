using System.Drawing;

namespace GoSell.Common.Constants
{
    public class AffOrderCommissionReportConstants
    {
        public const string SYSTEM = "system";

        public static readonly Color HEADER_FONT_COLOR = Color.FromArgb(255, 255, 255);
        public static readonly Color HEADER_BACKGROUND_COLOR = Color.FromArgb(48, 84, 150);
    }

    public class AffOrderCommissionReportColumnConstants
    {
        public const string PUBLISHER_CODE = "publisherCode";
        public const string PUBLISHER_NAME = "publisherName";
        public const string PERIOD = "period";
        public const string FROM = "from";
        public const string TO = "to";
        public const string COMMISSION_TYPE = "commissionType";
        public const string STATUS = "status";
        public const string TOTAL_COMMISSION = "totalCommission";
        public const string TOTAL_REVENUE = "totalRevenue";
        public const string TAX_DEDUCTION = "taxDeduction";
        public const string SHIPPING_DEDUCTION = "shippingDeduction";
        public const string DISCOUNT_DEDUCTION = "discountDeduction";
        public const string COMMISSION_SUBTOTAL = "commissionSubTotal";
        public const string COMMISSION_BONUS = "commissionBonus";
        public const string COMMISSION_MULTITIER = "commissionMultiter";
        public const string COMMISSION_TAX = "commissionTax";
        public const string COMMISSION_FINAL = "commissionFinal";
        public const string LAST_UPDATE = "lastUpdate";
        public const string NOTE = "note";
    }
}
