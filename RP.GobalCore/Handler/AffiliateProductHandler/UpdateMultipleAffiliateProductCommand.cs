using RP.Affiliate.Tracking.Commands;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler
{
    public class UpdateMultipleAffiliateProductHandler : IRequestHandler<UpdateMultipleAffiliateProductCommand, BaseResponse>
    {
        private readonly IAffiliateProductFunctions _affiliateProductFunctions;

        public UpdateMultipleAffiliateProductHandler(IAffiliateProductFunctions affiliateProductFunctions)
        {
            _affiliateProductFunctions = affiliateProductFunctions;
        }

        public async Task<BaseResponse> Handle(UpdateMultipleAffiliateProductCommand request, CancellationToken cancellationToken)
        {
            return await _affiliateProductFunctions.UpdateMultipleAffiliateProduct(request);
        }
    }
}
