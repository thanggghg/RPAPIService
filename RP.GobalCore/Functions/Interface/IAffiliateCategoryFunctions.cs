using RP.Affiliate.Tracking.Commands;
using RP.Affiliate.Tracking.Commands.AffiliateCategory;
using RP.Affiliate.Tracking.ViewModels;
using RP.Affiliate.Tracking.Queries.AffiliateCategory;
using RP.Library.Helpers;

namespace RP.Affiliate.Tracking.Functions.Interface
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
