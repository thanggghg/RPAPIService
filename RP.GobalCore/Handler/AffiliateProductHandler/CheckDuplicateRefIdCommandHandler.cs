using RP.Affiliate.Tracking.Commands;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
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
