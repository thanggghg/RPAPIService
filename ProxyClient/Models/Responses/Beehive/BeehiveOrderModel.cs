using Org.BouncyCastle.Asn1.X9;

namespace ProxyClient.Models.Beehive
{
    public class ReturnOrderResponse
    {
        public string Status { get; set; }
        public List<ReturnOrderItem> ReturnOrderItemList { get; set; }
    };
    public class ReturnOrderItem { public int Quantity { get; set; } };

    public class BeeHiveOrderResponse
    {
        public OrderInfo OrderInfo { get; set; }
        public List<BeeHiveOrderItem> Items { get; set; }
        public BeeHiveShippingInfor ShippingInfo { get; set; }
        public BeeHiveCustomerInfor CustomerInfo { get; set; }
    };

    public class BeeHiveCustomerInfor
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        public bool Guest { get; set; }
        public string Email { get; set; }
    }
    public class BeeHiveShippingInfor
    {
        public string InsideCityCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address => Address1;
        public string Address1 { get; set; }
        public string FullAddress { get; set; }
        public string Phone { get; set; }
        public string PhoneCode { get; set; }
        public string ContactName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Email { get; set; }
        public bool Valid => !string.IsNullOrEmpty(FullAddress);
        public string ZipCode { get; set; }
    }

    public class OrderInfo
    {
        public long OrderId { get; set; }
        public string Status { get; set; }
    };

    public class BeeHiveOrderItem
    {
        public long Id { get; set; } // OrderDetailId
        public long ItemId { get; set; } // ProductId
        public string Name { get; set; }
        public string VariationName { get; set; }
        public string ImageUrl { get; set; }
        public long VariationId { get; set; }
        public int Quantity { get; set; }
        public int TotalQuantity { get; set; }
    };

    public class BeeHiveUserOrderResponse
    {
        public string Id { get; set; } //OrderId
    }

    public class BeeHiveUserOrderRequest
    {
        public long StoreId { get; set; }
        public long CustomerId { get; set; }
        public long UserId { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 50; //Default setting
    }

}
