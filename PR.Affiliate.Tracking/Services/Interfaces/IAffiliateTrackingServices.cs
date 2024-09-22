using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.ViewModels;

namespace GoSell.Affiliate.Tracking.Services.Interfaces
{
    public interface IAffiliateTrackingServices
    {
        Task<bool> CreateAffiliateClickTracking(AffiliateClickTracking clickTracking, CancellationToken cancellationToken);

        Task<List<string>> CreateAffiliateLinkTracking(List<AffiliateLink> affiliateLinks, CancellationToken cancellationToken);

        Task<string> CreateAffiliateProductLinkTracking(AffiliateLink affiliateLink, CancellationToken cancellationToken);

        Task<bool> CreateAffiliateOrderTracking(AffiliateOrderTracking orderTracking, CancellationToken cancellationToken);

        Task<List<AffiliateOrderTracking>> GetAffiliateOrderTracking(long latestId);

        Task<bool> UpdatePlatformByTrackingId(UpdatePlatformByTrackingIdCommand request, CancellationToken cancellationToken);

        Task<AffiliateUrlReportViewModel> GetAffiliateUrlReport(GetAffiliateUrlReportQuery request, CancellationToken cancellationToken);

    }
}
