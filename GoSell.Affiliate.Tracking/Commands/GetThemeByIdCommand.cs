using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class GetThemeByIdCommand : IRequest<AffiliateThemeViewModel>
    {
        public long Id { get; set; }
    }
}
