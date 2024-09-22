using System.Runtime.Serialization;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCategory
{
    [DataContract]
    public class CheckDuplicateRefIdAffilliateQuery : IRequest<BaseResponse>
    {
        public string RefId { get; set; }
        public long AffiliateStoreId { get; set; }
        public CheckDuplicateRefIdAffilliateQuery() { }

    }
}
