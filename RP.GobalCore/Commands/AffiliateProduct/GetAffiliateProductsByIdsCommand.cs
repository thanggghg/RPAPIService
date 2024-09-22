using RP.Affiliate.Tracking.Models.Requests;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateProduct
{
    public class GetAffiliateProductsByIdsCommand : AffiliateProductsRequest, IRequest<List<RP.Affiliate.Tracking.Entities.AffiliateProduct>>
    {
    }
}
