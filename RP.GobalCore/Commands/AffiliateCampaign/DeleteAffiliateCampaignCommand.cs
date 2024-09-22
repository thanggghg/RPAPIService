using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCampaign
{
    public class DeleteAffiliateCampaignCommand(long id, long storeId) : IRequest<BaseResponse>
    {
        public long Id { get; private set; } = id;
        public long StoreId { get; set; } = storeId;
    }
}
