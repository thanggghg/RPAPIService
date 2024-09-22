using RP.Affiliate.Tracking.Commands;
using RP.Affiliate.Tracking.Commands.AffiliateProduct;
using RP.Affiliate.Tracking.Models.Requests;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers;
using RP.Library.Helpers.Pagination;
using Microsoft.AspNetCore.Http;

namespace RP.Affiliate.Tracking.Functions.Interface
{
    public interface IAffiliateProductFunctions
    {
        Task<BaseResponse> CreateAffiliateProduct(CreateAffiliateProductCommand request);
        Task<BaseResponse> UpdateAffiliateProduct(UpdateAffiliateProductCommand request);
        Task<BaseResponse> UpdateBaseAffiliateProduct(UpdateBaseAffiliateProductCommand request);
        Task<BaseResponse> DeleteAffiliateProduct(DeleteAffiliateProductCommand request);
        Task<BaseResponse> ChangeStatusAffiliateProduct(ChangeStatusAffiliateProductCommand request);
        Task<BaseResponse> UpdateMultipleAffiliateProduct(UpdateMultipleAffiliateProductCommand request);
        Task<GenericResponse<bool>> CheckDuplicateRefIdAsync(CheckDuplicateRefIdCommand request);
        Task<GenericResponse<string>> GetProductLinkToPublisherPage(GetProductLinkQuery request);
        Task<byte[]> ExportProductImportTemplate(ExportProductImportTemplateQuery request);
        Task<PagingItems<AffiliateProductViewModel>> GoToPublisherPage(long id);
        List<ProductCateInfoVM> GetProductAndCategoryInfoByProductIds(ProductCateInfoRequest productInfo);
        List<ProductCateInfoVM> GetProductCategoryMappings(ProductCateInfoRequest productInfo);
        Task<byte[]> ResizeImage(ResizeImageCommand request);
    }
}
