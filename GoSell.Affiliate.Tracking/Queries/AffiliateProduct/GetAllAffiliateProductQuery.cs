using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class GetAllAffiliateProductQuery : SearchAndPagingRequest, IRequest<PagingItems<AffiliateProductViewModel>>
    {
        public long AffiliateStoreId { get; set; }
        public bool? IsStopSelling { get; set; }
        public string Status { get; set; }
        public string AffiliateStoreFilterStatus { get; set; }
        public long? CategoryId {  get; set; }
        public GetAllAffiliateProductQuery() { }
    }
}
