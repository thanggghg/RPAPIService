using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
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
