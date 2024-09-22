using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class CreateApiKeyCommandHandler : IRequestHandler<CreateApiKeyCommand, string>
    {
        private readonly ILogger<CreateApiKeyCommandHandler> _logger;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public CreateApiKeyCommandHandler(ILogger<CreateApiKeyCommandHandler> logger,
                                         IBaseApi baseApi,
                                         IAffiliateStoreServices affiliateStoreServices
                                        )
        {
            _logger = logger;
            _affiliateStoreServices = affiliateStoreServices;
        }
        public async Task<string> Handle(CreateApiKeyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apiKey = await _affiliateStoreServices.CreateApiKey(request.StoreId, cancellationToken);
                Log.Logger.Information($"DONE {nameof(CreateApiKeyCommandHandler)}");
                return apiKey;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateApiKeyCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
