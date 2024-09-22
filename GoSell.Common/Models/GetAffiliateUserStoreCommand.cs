using MediatR;

namespace GoSell.Common.Models
{
    public class GetAffiliateUserStoreCommand : IRequest<AffiliateUserStoreModelRespone>
    {
        public GetAffiliateUserStoreCommand(long storeId, string searchType, string searchKeyword)
        {
            StoreId = storeId;
            SearchType = searchType;
            SearchKeyword = searchKeyword;
        }

        public long StoreId { get; set; }
        public string SearchType { get; set; }
        public string SearchKeyword { get; set; }
    }
}
