using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Common.Models;
using OfficeOpenXml;

namespace GoSell.Affiliate.Tracking.Services.Interfaces
{
    public interface IAffiliateSubmissionServices
    {
        Task<string> CreateAffiliateSubmission(AffiliateSubmission request, List<AffiliateOrderDetail> affiliateOrderDetails, CancellationToken cancellationToken);
        Task<PaginatedList<AffiliateSubmissionViewModel>> GetAffiliateSubmissionGsByStoreId(GetAllAffiliateSubmissionByGsStoreIdQuery request);
        Task<List<ExportOrderSubmissionViewModel>> GetDataExportOrderByStoreId(FilterDataExportOrderByStoreId filterDataExportOrderByStoreId, CancellationToken cancellationToken);
        Task<AffiliateSubmission> GetAffiliateSubmissionBySubmissionId(long submissionId);
        Task<List<AffiliateSubmission>> GetAffiliateSubmissionBySubmissionIds(List<long> submissionIds, int typeId, List<long> externalStoreIds);
        Task<AffiliateSubmission> GetAffiliateSubmissionBySubmissionId(long submissionId, long externalStoreId);
        Task<long> UpdateListSubmissionAsync(List<AffiliateSubmission> submissions, CancellationToken cancellationToken);
        Task<Tuple<bool, string>> UpdateSubmissionAsync(AffiliateSubmission submissions, CancellationToken cancellationToken);
        Task<ResultImportDataViewModel> ImportSubmissionAndOrderIdFromExcel(ExcelPackage excelPackage, long externalStoreId, CancellationToken cancellationToken, TimeZoneInfo clientTimeZone, bool isFileTemplate = false);
        Task<List<TrackingOrderOfPublishersViewModel>> GetPublishersByAffStoreIdAsync(GetPublishersByAffStoreIdQuery request, CancellationToken cancellationToken);
        Task CreateAffiliateSubmissionHistory(long submissionId, HistoryMessageTemplate jsonActionHistory, string description);
        Tuple<bool, string> GetCommissionApplyStatus(AffiliateSubmission submission);
    }
}
