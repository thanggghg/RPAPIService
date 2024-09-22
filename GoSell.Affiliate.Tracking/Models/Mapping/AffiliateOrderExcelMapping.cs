using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Database.Entities;

namespace GoSell.Affiliate.Tracking.Models.Mapping
{
    public class AffiliateOrderExcelMapping
    {
        //Submission
        public int? ColMappingOrderId { get; set; }
        public int? ColMappingTaxAmount { get; set; }
        public int? ColMappingShippingFee { get; set; }
        public int? ColMappingDiscountAmount { get; set; }
        public int? ColMappingSubTotalAmount { get; set; }
        public int? ColMappingTotalAmount { get; set; }
        public int? ColMappingPaymentMethod { get; set; }
        public int? ColMappingOrderCreatedDate { get; set; }
        public int? ColMappingStatus { get; set; }

        //OrderDetail
        public int? ColMappingProductName { get; set; }
        public int? ColMappingProductId { get; set; }
        public int? ColMappingSellingPrice { get; set; }
        public int? ColMappingQuantity { get; set; }
        public int? ColMappingUnitPrice { get; set; }
        public int? ColMappingTotalPrice { get; set; }
        public int? ColMappingPublisher { get; set; }
        public int? ColMappingCustomerName { get; set; }
        public int? ColMappingCustomerPhone { get; set; }
        public int? ColMappingCustomerAddress { get; set; }

        //Common
        public int RowStart { get; set; }

        public AffiliateOrderExcelMapping()
        {
            ColMappingOrderId = (int)MappingKeyEnum.ORDER_ID;
            ColMappingTaxAmount = (int)MappingKeyEnum.TAX_AMOUNT;
            ColMappingShippingFee = (int)MappingKeyEnum.SHIPPING_FEE;
            ColMappingDiscountAmount = (int)MappingKeyEnum.DISCOUNT_AMOUNT;
            ColMappingSubTotalAmount = (int)MappingKeyEnum.SUB_TOTAL_AMOUNT;
            ColMappingTotalAmount = (int)MappingKeyEnum.TOTAL_AMOUNT;
            ColMappingPaymentMethod = (int)MappingKeyEnum.PAYMENT_METHOD;
            ColMappingOrderCreatedDate = (int)MappingKeyEnum.ORDER_CREATE_DATE;
            ColMappingStatus = (int)MappingKeyEnum.STATUS;
            ColMappingProductName = (int)MappingKeyEnum.PRODUCT_NAME;
            ColMappingProductId = (int)MappingKeyEnum.PRODUCT_ID;
            ColMappingSellingPrice = (int)MappingKeyEnum.SALE_PRICE;
            ColMappingQuantity = (int)MappingKeyEnum.QUANTITY;
            ColMappingUnitPrice = (int)MappingKeyEnum.UNIT_PRICE;
            ColMappingTotalPrice = (int)MappingKeyEnum.TOTAL_PRICE;
            ColMappingPublisher = (int)MappingKeyEnum.PARTNER_PHONE;
            ColMappingCustomerName = (int)MappingKeyEnum.CUSTOMER_NAME;
            ColMappingCustomerPhone = (int)MappingKeyEnum.CUSTOMER_PHONE;
            ColMappingCustomerAddress = (int)MappingKeyEnum.CUSTOMER_ADDRESS;
            RowStart = 3;//Default follow file template

        }

        public AffiliateOrderExcelMapping(List<AffiliateMapping> lstMapping)
        {
            ColMappingOrderId = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.ORDER_ID)).FirstOrDefault()?.ColumnIndex;
            ColMappingTaxAmount = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.TAX_AMOUNT)).FirstOrDefault()?.ColumnIndex;
            ColMappingShippingFee = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.SHIPPING_FEE)).FirstOrDefault()?.ColumnIndex;
            ColMappingDiscountAmount = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.DISCOUNT_AMOUNT)).FirstOrDefault()?.ColumnIndex;
            ColMappingSubTotalAmount = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.SUB_TOTAL_AMOUNT)).FirstOrDefault()?.ColumnIndex;
            ColMappingTotalAmount = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.TOTAL_AMOUNT)).FirstOrDefault()?.ColumnIndex;
            ColMappingPaymentMethod = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.PAYMENT_METHOD)).FirstOrDefault()?.ColumnIndex;
            ColMappingOrderCreatedDate = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.ORDER_CREATE_DATE)).FirstOrDefault()?.ColumnIndex;
            ColMappingStatus = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.STATUS)).FirstOrDefault()?.ColumnIndex;
            ColMappingProductName = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.PRODUCT_NAME)).FirstOrDefault()?.ColumnIndex;
            ColMappingProductId = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.PRODUCT_ID)).FirstOrDefault()?.ColumnIndex;
            ColMappingSellingPrice = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.SALE_PRICE)).FirstOrDefault()?.ColumnIndex;
            ColMappingQuantity = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.QUANTITY)).FirstOrDefault()?.ColumnIndex;
            ColMappingUnitPrice = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.UNIT_PRICE)).FirstOrDefault()?.ColumnIndex;
            ColMappingTotalPrice = lstMapping.Where(x => x.MappingKey == nameof(MappingKeyEnum.TOTAL_PRICE)).FirstOrDefault()?.ColumnIndex;
            RowStart = (int)lstMapping.FirstOrDefault()?.RowIndex;
        }
    }
}
