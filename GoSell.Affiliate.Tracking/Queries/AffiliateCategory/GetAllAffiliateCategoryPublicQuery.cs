using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCategory
{
    public class GetAllAffiliateCategoryPublicQuery : SearchAndPagingRequest, IRequest<PagingItems<AffiliateCategoryPublicViewModel>>
    {
        public long AffiliateStoreId { get; set; }
        public string Status { get; set; }
        public string StoreStatus { get; set; }
        public GetAllAffiliateCategoryPublicQuery() { }

    }
}
