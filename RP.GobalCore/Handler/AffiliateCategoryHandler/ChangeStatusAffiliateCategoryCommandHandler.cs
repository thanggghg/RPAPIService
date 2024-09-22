using RP.Affiliate.Tracking.Commands.AffiliateCategory;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class ChangeStatusAffiliateCategoryCommandHandler : IRequestHandler<ChangeStatusAffiliateCategoryCommand, BaseResponse>
    {
        private readonly IAffiliateCategoryFunctions _AffiliateCategoryFunctions;

        public ChangeStatusAffiliateCategoryCommandHandler(IAffiliateCategoryFunctions AffiliateCategoryFunctions)
        {
            _AffiliateCategoryFunctions = AffiliateCategoryFunctions;
        }

        public async Task<BaseResponse> Handle(ChangeStatusAffiliateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _AffiliateCategoryFunctions.ChangeStatusAffiliateCategory(request);
        }
    }
}
