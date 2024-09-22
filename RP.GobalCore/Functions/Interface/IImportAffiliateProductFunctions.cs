using RP.Affiliate.Tracking.Commands.AffiliateProduct;
using RP.Affiliate.Tracking.ViewModels;

namespace RP.Affiliate.Tracking.Functions.Interface
{
    public interface IImportAffiliateProductFunctions
    {
        Task<ImportAffiliateProductResult> ImportAffiliateProduct(ImportAffiliateProductCommand request);
    }
}
