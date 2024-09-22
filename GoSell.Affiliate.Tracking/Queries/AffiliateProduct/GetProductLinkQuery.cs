using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class GetProductLinkQuery : IRequest<GenericResponse<string>>
    {
        public long Id { get; }
        public GetProductLinkQuery(long id)
        {
            Id = id;
        }
    }
}
