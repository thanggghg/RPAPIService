using System.Runtime.Serialization;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class CreateAffiliateMappingCommand : IRequest<bool>
    {
        [DataMember]
        public List<CreateAffiliateMappingViewModel> ListAffiliateMapping { get; set; }
        [DataMember]
        public virtual long AffiliateStoreId { get; set; }
    }
}
