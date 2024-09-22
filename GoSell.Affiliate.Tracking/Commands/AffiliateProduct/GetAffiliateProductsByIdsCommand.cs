using GoSell.Affiliate.Tracking.Models.Requests;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateProduct
{
    public class GetAffiliateProductsByIdsCommand : AffiliateProductsRequest, IRequest<List<GoSell.Affiliate.Tracking.Entities.AffiliateProduct>>
    {
    }
}
