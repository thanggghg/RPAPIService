using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCampaign
{
    public class GetSpecificAffiliateCampaignQuery(long storeId, long id) : IRequest<GenericResponse<AffiliateCampaignDetailViewModel>>
    {
        public long Id { get; } = id;
        public long StoreId { get; } = storeId;
    }
}
