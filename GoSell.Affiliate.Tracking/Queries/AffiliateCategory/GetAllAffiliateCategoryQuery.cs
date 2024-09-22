using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCategory
{
    public class GetAllAffiliateCategoryQuery : SearchAndPagingRequest, IRequest<PagingItems<AffiliateCategoryViewModel>>
    {
        public long AffiliateStoreId { get; set; }
        public string Status { get; set; }
        public string StoreStatus { get; set; }
        public string TokenAPI { get; set; }
    }
}
