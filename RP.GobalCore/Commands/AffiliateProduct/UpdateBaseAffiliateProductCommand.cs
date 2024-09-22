using System.Runtime.Serialization;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateProduct
{
    [DataContract]
    public class UpdateBaseAffiliateProductCommand : AffiliateProductRequest, IRequest<BaseResponse>
    {
        public UpdateBaseAffiliateProductCommand() { }
    }
}
