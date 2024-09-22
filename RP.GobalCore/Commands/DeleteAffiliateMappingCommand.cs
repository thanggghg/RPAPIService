using System.Runtime.Serialization;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class DeleteAffiliateMappingCommand : IRequest<bool>
    {
        [DataMember]
        public virtual long AffiliateStoreId { get; set; }

        public DeleteAffiliateMappingCommand(long affiliateStoreId)
        {
            AffiliateStoreId = affiliateStoreId;
        }
    }
}
