using MediatR;

namespace GoSell.Common.Models
{
    public class GetAffiliateUserStoreByIdsCommand : IRequest<AffiliateUserStoreModelRespone>
    {
        public List<long> Ids { get; set; }
    }
}
