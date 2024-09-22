using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class CreateAffiliateProductCommandHandler : IRequestHandler<CreateAffiliateProductCommand, BaseResponse>
    {
        private readonly IAffiliateProductFunctions _affiliateProductFunctions;

        public CreateAffiliateProductCommandHandler(IAffiliateProductFunctions affiliateProductFunctions)
        {
            _affiliateProductFunctions = affiliateProductFunctions;
        }

        public async Task<BaseResponse> Handle(CreateAffiliateProductCommand request, CancellationToken cancellationToken)
        {
            return await _affiliateProductFunctions.CreateAffiliateProduct(request);

        }
    }
}
