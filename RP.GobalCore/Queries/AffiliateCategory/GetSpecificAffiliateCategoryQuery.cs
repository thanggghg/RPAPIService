using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetSpecificAffiliateCategoryQuery : IRequest<AffiliateCategoryViewModel>
    {
        public long Id { get; set; }

        public long AffiliatetStoreId { get; set; }
        
        public GetSpecificAffiliateCategoryQuery(long id)
        {
            Id = id;
        }
    }
}
