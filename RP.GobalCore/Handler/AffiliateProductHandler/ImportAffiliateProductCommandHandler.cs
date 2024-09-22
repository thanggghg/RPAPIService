using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
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
