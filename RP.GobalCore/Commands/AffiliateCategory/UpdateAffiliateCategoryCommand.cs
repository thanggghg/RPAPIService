using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateCategory
{
    public class UpdateAffiliateCategoryCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RefCategoryId { get; set; }
        public long AffiliateStoreId { get; set; }
        public UpdateAffiliateCategoryCommand() { }
    }
}
