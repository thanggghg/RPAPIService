using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCategory
{
    public class CreateAffiliateCategoryCommand : IRequest<BaseResponse>
    {
        public long AffiliateStoreId { get; set; }
        public string Name { get; set; }
        public string RefCategoryId { get; set; }
        public CreateAffiliateCategoryCommand() { }

    }
}
