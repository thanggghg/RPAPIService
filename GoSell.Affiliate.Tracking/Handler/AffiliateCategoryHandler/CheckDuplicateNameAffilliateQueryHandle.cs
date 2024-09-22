using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class CheckDuplicateNameAffilliateQueryHandle : IRequestHandler<CheckDuplicateNameAffilliateQuery, BaseResponse>
    {       
        private readonly IAffiliateCategoryFunctions _AffiliateCategoryFunctions;

        public CheckDuplicateNameAffilliateQueryHandle(IAffiliateCategoryFunctions AffiliateCategoryFunctions)
        {
            _AffiliateCategoryFunctions = AffiliateCategoryFunctions;
        }

        public async Task<BaseResponse> Handle(CheckDuplicateNameAffilliateQuery request, CancellationToken cancellationToken)
        {
            return await _AffiliateCategoryFunctions.CheckDuplicateNameAffilliate(request);            
        }
    }
}
