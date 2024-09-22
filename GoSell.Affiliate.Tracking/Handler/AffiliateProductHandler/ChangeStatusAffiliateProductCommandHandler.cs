using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
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
