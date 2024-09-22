using MediatR;

namespace GoSell.Common.Models
{
    public class GetAllAffiliateUserStoreByAffiliateStoreIdsQuery : IRequest<List<long>>
    {
        public List<long> AffiliateStoreIds { get; set; }
    }
}
