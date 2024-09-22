using MediatR;
using Microsoft.AspNetCore.Http;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class CreateTokenAPICommand : IRequest<string>
    {
        public long AffiliateStoreId { get; set; }
        public string APIKey { get; set; }
        public CreateTokenAPICommand() { }
    }
}
