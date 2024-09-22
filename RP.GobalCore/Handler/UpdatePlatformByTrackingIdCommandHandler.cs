using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class UpdatePlatformByTrackingIdCommandHandler : IRequestHandler<UpdatePlatformByTrackingIdCommand, bool>
    {
        private readonly ILogger<UpdatePlatformByTrackingIdCommand> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateTrackingServices _affiliateTrackingServices;
        public UpdatePlatformByTrackingIdCommandHandler(ILogger<UpdatePlatformByTrackingIdCommand> logger,
                                                  IBaseApi baseApi,
                                                  IMapper mapper,
                                                  IAffiliateTrackingServices affiliateTrackingServices)
        {
            _logger = logger;
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateTrackingServices = affiliateTrackingServices;
        }

        public async Task<bool> Handle(UpdatePlatformByTrackingIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _affiliateTrackingServices.UpdatePlatformByTrackingId(request, cancellationToken);

                Log.Logger.Information($"DONE {nameof(UpdatePlatformByTrackingIdCommandHandler)}");
                return res;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdatePlatformByTrackingIdCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
