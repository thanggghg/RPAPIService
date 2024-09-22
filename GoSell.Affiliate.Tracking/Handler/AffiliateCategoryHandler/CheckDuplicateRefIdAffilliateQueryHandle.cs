using GoSell.Affiliate.Tracking.Commands.AffiliateCategory;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCategoryHandler
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
