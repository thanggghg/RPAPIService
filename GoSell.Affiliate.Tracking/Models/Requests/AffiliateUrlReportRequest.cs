using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoSell.Common.Enums;

namespace GoSell.Affiliate.Tracking.Models.Requests
{
    public class AffiliateUrlReportRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string SearchType { get; set; }
        public string SearchKeyword { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool isExport { get; set; } = false;
        public long PublisherId { get; set; }
        public string currencyCode { get; set; }

    }
}
