using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class CreateOrderTrackingCommandHandler : IRequestHandler<CreateOrderTrackingCommand, bool>
    {
        private readonly ILogger<CreateOrderTrackingCommand> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateTrackingServices _affiliateTrackingServices;

        public CreateOrderTrackingCommandHandler(ILogger<CreateOrderTrackingCommand> logger,
                                               IBaseApi baseApi,
                                               IMapper mapper,
                                               IAffiliateTrackingServices affiliateTrackingServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateTrackingServices = affiliateTrackingServices;
        }
        public async Task<bool> Handle(CreateOrderTrackingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AffiliateOrderTracking affiliateOrderTracking = new AffiliateOrderTracking();
                affiliateOrderTracking.OrderId = request.OrderId;
                affiliateOrderTracking.TrackingIds = request.TrackingIds;
                affiliateOrderTracking.Website = request.Website;
                affiliateOrderTracking.UpdateCreatedBy("Client");
                affiliateOrderTracking.OrderCreateTime = DateTime.Now;
                affiliateOrderTracking.LastModifiedBy = affiliateOrderTracking.CreatedBy;
                Log.Logger.Information($"DONE {nameof(CreateOrderTrackingCommand)}");
                return await _affiliateTrackingServices.CreateAffiliateOrderTracking(affiliateOrderTracking, cancellationToken);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateOrderTrackingCommand)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

    }
}
