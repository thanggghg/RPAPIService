using RP.Affiliate.Tracking.Commands.AffiliateCategory;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class CheckDuplicateRefIdAffilliateQueryHandle : IRequestHandler<CheckDuplicateRefIdAffilliateQuery, BaseResponse>
    {
        private readonly IAffiliateCategoryFunctions _AffiliateCategoryFunctions;

        public CheckDuplicateRefIdAffilliateQueryHandle(IAffiliateCategoryFunctions AffiliateCategoryFunctions)
        {
            _AffiliateCategoryFunctions = AffiliateCategoryFunctions;
        }

        public async Task<BaseResponse> Handle(CheckDuplicateRefIdAffilliateQuery request, CancellationToken cancellationToken)
        {
            return await _AffiliateCategoryFunctions.CheckDuplicateRefIdAffilliate(request);
        }
    }
}
