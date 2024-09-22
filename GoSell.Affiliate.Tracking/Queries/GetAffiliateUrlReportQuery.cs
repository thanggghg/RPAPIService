using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAffiliateUrlReportQuery : IRequest<AffiliateUrlReportViewModel>
    {
        public GetAffiliateUrlReportQuery(long affiliateStoreId, AffiliateUrlReportRequest request)
        {
            AffiliateStoreId = affiliateStoreId;
            Request = request;
        }
        public long AffiliateStoreId { get; set; }
        public AffiliateUrlReportRequest Request { get; set; }
    }
}
