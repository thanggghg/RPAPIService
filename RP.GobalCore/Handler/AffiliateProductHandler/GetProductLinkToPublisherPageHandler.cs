using RP.Affiliate.Tracking.Commands;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
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
