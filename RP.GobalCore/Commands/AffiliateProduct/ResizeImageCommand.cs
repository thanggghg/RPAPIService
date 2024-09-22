using MediatR;
using Microsoft.AspNetCore.Http;

namespace RP.Affiliate.Tracking.Commands.AffiliateProduct
{
    public class ResizeImageCommand : IRequest<byte[]>
    {
        public IFormFile Image { get; set; }
        public ResizeImageCommand() { }   
    }
}
