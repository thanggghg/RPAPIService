using System.Runtime.Serialization;
using MediatR;
using RP.Affiliate.Tracking.Models.Requests;
using RP.Library.Helpers;

namespace RP.Affiliate.Tracking.Commands.AffiliateProduct
{
    [DataContract]
    public class CreateAffiliateProductCommand : AffiliateProductRequest, IRequest<BaseResponse>
    {
        public CreateAffiliateProductCommand() { }

    }
}
