using System.Runtime.Serialization;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAffiliateMappingByIdQuery : IRequest<List<AffiliateMappingViewModel>>
    {
        [DataMember]
        public virtual long AffiliateStoreId { get; set; }

        public GetAffiliateMappingByIdQuery(long affiliateStoreId)
        {
            AffiliateStoreId = affiliateStoreId;
        }
    }
}
