using RP.Affiliate.Tracking.Commands.AffiliateProduct;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.ViewModels;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class ImportAffiliateProductCommandHandler(IImportAffiliateProductFunctions affiliateImportProductFunctions) : IRequestHandler<ImportAffiliateProductCommand, ImportAffiliateProductResult>
    {
        private readonly IImportAffiliateProductFunctions _affiliateImportProductFunctions = affiliateImportProductFunctions;

        public async Task<ImportAffiliateProductResult> Handle(ImportAffiliateProductCommand request, CancellationToken cancellationToken)
        {
            return await _affiliateImportProductFunctions.ImportAffiliateProduct(request);
        }
    }
}
