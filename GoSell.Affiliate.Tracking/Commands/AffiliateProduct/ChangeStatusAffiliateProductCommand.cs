using System.Runtime.Serialization;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateProduct
{

    public class ChangeStatusAffiliateProductCommand : IRequest<BaseResponse>
    {
        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public long AffiliateStoreId { get; private set; }

        [DataMember]
        public bool? IsActive { get; private set; }

        [DataMember]
        public string UserLogin { get; private set; }

        public ChangeStatusAffiliateProductCommand()
        {
        }

        public ChangeStatusAffiliateProductCommand(long id, long affiliateStoreId, bool? isActive, string userLogin) : this()
        {
            Id = id;
            AffiliateStoreId = affiliateStoreId;
            IsActive = isActive;
            UserLogin = userLogin;
        }

    }
}
