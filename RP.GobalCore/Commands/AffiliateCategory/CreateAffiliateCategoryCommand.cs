using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateCategory
{
    public class CreateAffiliateCategoryCommand : IRequest<BaseResponse>
    {
        public long AffiliateStoreId { get; set; }
        public string Name { get; set; }
        public string RefCategoryId { get; set; }
        public CreateAffiliateCategoryCommand() { }

    }
}
