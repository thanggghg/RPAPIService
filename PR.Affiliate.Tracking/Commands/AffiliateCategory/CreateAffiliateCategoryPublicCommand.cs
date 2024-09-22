using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCategory
{
    public class CreateAffiliateCategoryPublicCommand : IRequest<BaseResponse>
    {
        public long AffiliateStoreId { get; set; }
        public string Name { get; set; }
        public string RefCategoryId { get; set; }
        public bool? Status { get; set; }
        public bool? IsDeleted { get; set; }
        public string TokenAPI { get; set; }
    }
}
