using System.Runtime.Serialization;
using MediatR;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Library.Helpers;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateProduct
{
    [DataContract]
    public class CreateAffiliateProductCommand : AffiliateProductRequest, IRequest<BaseResponse>
    {
        public CreateAffiliateProductCommand() { }

    }
}
