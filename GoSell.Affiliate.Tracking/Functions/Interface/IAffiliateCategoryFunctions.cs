using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commands.AffiliateCategory;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Affiliate.Tracking.Queries.AffiliateCategory;
using GoSell.Library.Helpers;

namespace GoSell.Affiliate.Tracking.Functions.Interface
{
    public interface  IAffiliateCategoryFunctions
    {
        Task<BaseResponse> CheckDuplicateRefIdAffilliate(CheckDuplicateRefIdAffilliateQuery request);
        Task<BaseResponse> CheckDuplicateNameAffilliate(CheckDuplicateNameAffilliateQuery request);
        Task<BaseResponse> ChangeStatusAffiliateCategory(ChangeStatusAffiliateCategoryCommand request);
        Task<ImportAffiliateCategoryResponse> ImportAffiliateCategory(ImportAffiliateCategoryCommand request);
        Task<byte[]> ExportCategoryImportTemplate(ExportCategoryImportTemplateQuery request);
    }
}
