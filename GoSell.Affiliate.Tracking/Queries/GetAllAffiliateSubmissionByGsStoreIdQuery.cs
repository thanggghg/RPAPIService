using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Common.Models;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAllAffiliateSubmissionByGsStoreIdQuery : IRequest<PaginatedList<AffiliateSubmissionViewModel>>
    {
        public long GsStoreId { get; set; }
        public int TypeId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int? SearchType { get; set; }
        public string SearchString { get; set; }
        public int? ApprovalStatus { get; set; }
        public Boolean? AffStoreStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? AffiliateStoreId { get; set; }

        public GetAllAffiliateSubmissionByGsStoreIdQuery(long gsStoreId, int typeId, int pageSize, int pageNumber,
            string searchString, int? searchType, int? approvalStatus, int? affiliateStoreId, DateTime? fromdate, DateTime? toDate, Boolean? affStoreStatus)
        {
            GsStoreId = gsStoreId;
            TypeId = typeId;
            PageSize = pageSize;
            PageNumber = pageNumber;
            SearchString = searchString;
            SearchType = searchType;
            ApprovalStatus = approvalStatus;
            AffiliateStoreId = affiliateStoreId;
            FromDate = fromdate;
            ToDate = toDate;
            AffStoreStatus = affStoreStatus;
        }
    }
}
