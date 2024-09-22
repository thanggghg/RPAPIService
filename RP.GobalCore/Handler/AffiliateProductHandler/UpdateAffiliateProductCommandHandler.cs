using RP.Affiliate.Tracking.Commands.AffiliateProduct;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class UpdateAffiliateProductCommandHandler : IRequestHandler<UpdateAffiliateProductCommand, BaseResponse>
    {
        private readonly IAffiliateProductFunctions _affiliateProductFunctions;

        public UpdateAffiliateProductCommandHandler(IAffiliateProductFunctions affiliateProductFunctions)
        {
            _affiliateProductFunctions = affiliateProductFunctions;
        }

        public async Task<BaseResponse> Handle(UpdateAffiliateProductCommand request, CancellationToken cancellationToken)
        {
            return await _affiliateProductFunctions.UpdateAffiliateProduct(request);

        }
    }
}
