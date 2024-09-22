using System.Runtime.Serialization;
using RP.Affiliate.Tracking.Models.Requests;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateProduct
{
    [DataContract]
    public class UpdateBaseAffiliateProductCommand : AffiliateProductRequest, IRequest<BaseResponse>
    {
        public UpdateBaseAffiliateProductCommand() { }
    }
}
