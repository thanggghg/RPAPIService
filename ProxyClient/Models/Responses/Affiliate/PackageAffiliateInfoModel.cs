using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyClient.Models.Responses.Affiliate
{
    public class PackageAffiliateInfoModel
    {
        public long Id { get; set; }
        public long ServicePriceId { get; set; }
        public long StoreId { get; set; }
        public long UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public int NumberOfService { get; set; }
        public int NumberOfMonth { get; set; }
        public string Type { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public bool Paid { get; set; }
        public string Note { get; set; }
        public string ActivedAt { get; set; }
        public string ContractId { get; set; }
        public bool QcMark { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedDate { get; set; }
    }
}
