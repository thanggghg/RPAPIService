using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateCategory
{
    public class DeleteAffiliateCategoryCommand : IRequest<BaseResponse>
    {
        public DeleteAffiliateCategoryCommand() { }
        public long Id { get; private set; }
        
        public DeleteAffiliateCategoryCommand(long id) { 
            Id = id;
        }
    }
}
