using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.ViewModels;

namespace GoSell.Affiliate.Tracking.Functions.Interface
{
    public interface IImportAffiliateProductFunctions
    {
        Task<ImportAffiliateProductResult> ImportAffiliateProduct(ImportAffiliateProductCommand request);
    }
}
