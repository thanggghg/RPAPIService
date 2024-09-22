using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class GetAPIAffiliateProductQuery : SearchAndPagingRequest, IRequest<PagingItems<AffiliateProductViewModel>>
    {
        public long? CategoryId { get; set; }
        public long AffiliateStoreId { get; set; }
        public string TokenAPI { get; set; }
        public bool? isOutOfStock { get; set; }
        public bool? IsDeleted { get; set; }
        public GetAPIAffiliateProductQuery() { }
    }
}
