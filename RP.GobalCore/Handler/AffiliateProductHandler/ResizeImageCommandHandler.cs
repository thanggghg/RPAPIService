using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class ResizeImageCommandHandler : IRequestHandler<ResizeImageCommand, byte[]>
    {
        private readonly IAffiliateProductFunctions _affiliateProductFunctions;

        public ResizeImageCommandHandler(IAffiliateProductFunctions affiliateProductFunctions)
        {
            _affiliateProductFunctions = affiliateProductFunctions;
        }

        public async Task<byte[]> Handle(ResizeImageCommand request, CancellationToken cancellationToken)
        {
            return await _affiliateProductFunctions.ResizeImage(request);
        }
    }
}
