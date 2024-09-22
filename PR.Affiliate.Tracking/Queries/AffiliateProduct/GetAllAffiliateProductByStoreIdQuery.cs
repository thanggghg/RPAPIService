using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class GetAllAffiliateProductByStoreIdQuery : SearchAndPagingRequest, IRequest<PagingItems<AffiliateProductViewModel>>
    {
        public long? AffiliateStoreId { get; set; }
        public GetAllAffiliateProductByStoreIdQuery()
        {

        }
    }
}
