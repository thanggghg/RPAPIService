using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCategory
{
    public class GetAffiliateCategorySelectListQuery : SearchAndPagingRequest, IRequest<PagingItems<AffiliateCategoryViewModel>>
    {
        public long AffiliateStoreId { get; set; }
        public string Status { get; set; }

        public long? AffiliateProductId { get; set; }

        public GetAffiliateCategorySelectListQuery() { }
    }

}
