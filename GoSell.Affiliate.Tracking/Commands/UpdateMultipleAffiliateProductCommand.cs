using System.Runtime.Serialization;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{

    public class UpdateMultipleAffiliateProductCommand : IRequest<BaseResponse>
    {
        [DataMember]
        public string ActionType { get; private set; }

        [DataMember]
        public List<long> ProductIds { get; private set; }

        [DataMember]
        public long AffiliateStoreId { get; private set; }

        [DataMember]
        public string UserLogin { get; private set; }

        public UpdateMultipleAffiliateProductCommand()
        {
        }

        public UpdateMultipleAffiliateProductCommand(string actionType, List<long> productIds, long affiliateStoreId, string userLogin) : this()
        {
            ActionType = actionType;
            ProductIds = productIds;
            AffiliateStoreId = affiliateStoreId;
            UserLogin = userLogin;
        }
    }
}
