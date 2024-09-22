using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.Queries.AffiliateProduct;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetProductLinkToPublisherPageHandler : IRequestHandler<GetProductLinkQuery, GenericResponse<string>>
    {
        private readonly IAffiliateProductFunctions _affiliateProductFunctions;

        public GetProductLinkToPublisherPageHandler(IAffiliateProductFunctions affiliateProductFunctions)
        {
            _affiliateProductFunctions = affiliateProductFunctions;
        }

        public async Task<GenericResponse<string>> Handle(GetProductLinkQuery request,CancellationToken cancellationToken)
        {
            return await _affiliateProductFunctions.GetProductLinkToPublisherPage(request);

        }
    }
}
