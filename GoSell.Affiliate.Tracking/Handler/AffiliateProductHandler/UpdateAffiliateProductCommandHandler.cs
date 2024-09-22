using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
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
