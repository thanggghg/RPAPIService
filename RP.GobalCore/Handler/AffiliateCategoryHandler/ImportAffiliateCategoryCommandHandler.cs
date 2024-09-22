using System.Net;
using RP.Affiliate.Tracking.Commands.AffiliateCategory;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.ViewModels;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateCategoryHandler
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
