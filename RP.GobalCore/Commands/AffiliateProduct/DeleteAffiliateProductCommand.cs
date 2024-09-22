using System.Runtime.Serialization;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateProduct
{
    public class DeleteAffiliateProductCommand : IRequest<BaseResponse>
    {
        public DeleteAffiliateProductCommand() { }
        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public string UserLogin { get; private set; }

        public DeleteAffiliateProductCommand(long id, string userLogin) : this()
        {
            Id = id;
            UserLogin = userLogin;
        }
    }
}
