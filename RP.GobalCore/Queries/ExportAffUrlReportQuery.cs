using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoSell.Affiliate.Tracking.ViewModels;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class ExportAffUrlReportQuery
    {
        public ExportAffUrlReportQuery(List<AffiliateUrlModel> exportData, string currencyCode)
        {
            ExportData = exportData;
            CurrencyCode = currencyCode;
        }

        public List<AffiliateUrlModel> ExportData { get; set; }
        public string CurrencyCode { get; set; }
    }
}
