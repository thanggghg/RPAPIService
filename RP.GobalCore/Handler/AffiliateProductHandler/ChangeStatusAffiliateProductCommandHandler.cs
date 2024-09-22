using RP.Affiliate.Tracking.Commands.AffiliateProduct;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class ChangeStatusAffiliateProductCommandHandler : IRequestHandler<ChangeStatusAffiliateProductCommand, BaseResponse>
    {
        private readonly IAffiliateProductFunctions _affiliateProductFunctions;

        public ChangeStatusAffiliateProductCommandHandler(IAffiliateProductFunctions affiliateProductFunctions)
        {
            _affiliateProductFunctions = affiliateProductFunctions;
        }

        public async Task<BaseResponse> Handle(ChangeStatusAffiliateProductCommand request, CancellationToken cancellationToken)
        {
            return await _affiliateProductFunctions.ChangeStatusAffiliateProduct(request);

        }
    }
}
