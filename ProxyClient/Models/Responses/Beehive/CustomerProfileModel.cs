namespace ProxyClient.Models.Responses.Beehive
{
    public class CustomerProfileResult
    {
        public int Total { get; set; }

        public List<CustomerProfileModel> CustomerProfiles { get; set; }
    }

    public class CustomerProfileDetailResult
    {
        public int Total { get; set; }
        public CustomerProfileDetailModel CustomerProfileDetail { get; set; }
    }

    public class CustomerProfileDetailModel
    {
        public int Id { get; set; }
        public long? UserId { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public int StoreId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneNumberWithoutZero { get; set; }
        public string PhoneNumberWithZero { get; set; }
        public string PhoneNumberWithPhoneCode { get; set; }
        public CustomerAddressDetailModel CustomerAddress { get; set; }
        public CustomerAddressDetailFullModel CustomerAddressFull { get; set; }
    }

    public class CustomerProfileModel
    {
        public int Id { get; set; }
        public long? UserId {  get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public int StoreId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public string SaleChannel { get; set; }
        public int TotalOrder { get; set; }
        public double TotalPurchase { get; set; }
        public double TotalPurchase3Months { get; set; }
        public double TotalRefund { get; set; }
        public double OrderDebtSummary { get; set; }
        public bool Guest { get; set; }
        public string CustomerAddress { get; set; }
        public CustomerAddressDetailModel CustomerAddressDetail { get; set; }
        public CustomerAddressDetailFullModel CustomerAddressDetailFull { get; set; }
        public int ResponsibleStaffUserId { get; set; }
        public string Segment { get; set; }
        public int MemberPoint { get; set; }
        public string PartnerType { get; set; }
        public string CreatedByUser { get; set; }
        public double DebtLimitAmount { get; set; }
        public int DebtDuration { get; set; }
    }

    public class CustomerAddressDetailModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string CountryCode { get; set; }
        public string LocationCode { get; set; }
        public string DistrictCode { get; set; }
        public string WardCode { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
    
    public class CustomerAddressDetailFullModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
    }
}
