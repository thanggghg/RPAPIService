using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class CheckDuplicateNameAffilliateQuery: IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public long AffiliateStoreId { get; set; }

        public CheckDuplicateNameAffilliateQuery() { }

    }
}
