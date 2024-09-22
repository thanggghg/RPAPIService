using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Pagination;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class GetProductsAddCampaignQuery : GetProductsAddCampaignRequest
    {
        public long StoreId { get; set; }
        public GetProductsAddCampaignQuery()
        {
        }
    }

    public class GetProductsAddCampaignRequest : SearchAndPagingRequest, IRequest<GenericResponse<PagingItems<AffiliateProductAddCampaignViewModel>>>
    {
        public long AffiliateStoreId { get; set; }
        public GetProductsAddCampaignRequest()
        {
        }
    }
}
