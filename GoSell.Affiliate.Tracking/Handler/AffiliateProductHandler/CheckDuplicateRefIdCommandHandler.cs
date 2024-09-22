using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class CheckDuplicateRefIdCommandHandler : IRequestHandler<CheckDuplicateRefIdCommand, BaseResponse>
    {
        private readonly IAffiliateProductFunctions _affiliateProductFunctions;

        public CheckDuplicateRefIdCommandHandler(IAffiliateProductFunctions affiliateProductFunctions)
        {
            _affiliateProductFunctions = affiliateProductFunctions;
        }

        public async Task<BaseResponse> Handle(CheckDuplicateRefIdCommand request, CancellationToken cancellationToken)
        {
            return await _affiliateProductFunctions.CheckDuplicateRefIdAsync(request);
        }
    }
}
