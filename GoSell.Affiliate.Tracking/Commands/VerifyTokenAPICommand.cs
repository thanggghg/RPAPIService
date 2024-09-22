using GoSell.Library.Extensions.JWT;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class VerifyTokenAPICommand : IRequest<PayloadJWT>
    {
        public string token { get; set; }
        public VerifyTokenAPICommand() { }
    }
}
