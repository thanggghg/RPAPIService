using System.Net;
using GoSell.Affiliate.Tracking.Commands.AffiliateCategory;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class ImportAffiliateCategoryCommandHandler(IAffiliateCategoryFunctions affiliateCategoryFunctions) : IRequestHandler<ImportAffiliateCategoryCommand, ImportAffiliateCategoryResponse>
    {
        private readonly IAffiliateCategoryFunctions _affiliateCategoryFunctions = affiliateCategoryFunctions;

        public async Task<ImportAffiliateCategoryResponse> Handle(ImportAffiliateCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = await _affiliateCategoryFunctions.ImportAffiliateCategory(request);
            return data;
        }
    }
}
