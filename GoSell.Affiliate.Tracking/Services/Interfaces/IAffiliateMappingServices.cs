using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Models.Mapping;
using OfficeOpenXml;

namespace GoSell.Affiliate.Tracking.Services.Interfaces
{
    public interface IAffiliateMappingServices
    {
        Task<bool> CreateListMapping(List<AffiliateMapping> affiliateStore, CancellationToken cancellationToken);
        Task<List<AffiliateMapping>> GetListAffiliateMappingByAffiliateStoreId(long affiliateStoreId);
        Task<bool> RemoveAllMapingByAffiliateStoreId(long affiliateStoreId, CancellationToken cancellationToken);
        bool IsRowValidateEmpty(ExcelWorksheet worksheet, AffiliateOrderExcelMapping affiliateOrderExcelMapping, int row);
        List<string> RowValidateSubmisison(ExcelWorksheet worksheet, List<AffiliateProduct> affiliateProducts, long externalStoreId, AffiliateOrderExcelMapping affiliateOrderExcelMapping, int row);
        AffiliateSubmission BuildSubmission(ExcelWorksheet worksheet, long externalStoreId, AffiliateOrderExcelMapping affiliateOrderExcelMapping, int row, TimeZoneInfo clientTimeZone, AffiliateSubmission affiliateSubmisson = null);
    }
}
