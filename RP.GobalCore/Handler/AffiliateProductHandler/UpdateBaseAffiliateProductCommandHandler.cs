using RP.Affiliate.Tracking.Commands.AffiliateProduct;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class UpdateBaseAffiliateProductCommandHandler : IRequestHandler<UpdateBaseAffiliateProductCommand, BaseResponse>
    {
        private readonly IAffiliateProductFunctions _affiliateProductFunctions;

        public UpdateBaseAffiliateProductCommandHandler(IAffiliateProductFunctions affiliateProductFunctions)
        {
            _affiliateProductFunctions = affiliateProductFunctions;
        }

        public async Task<BaseResponse> Handle(UpdateBaseAffiliateProductCommand request, CancellationToken cancellationToken)
        {
            return await _affiliateProductFunctions.UpdateBaseAffiliateProduct(request);

        }
    }
}
