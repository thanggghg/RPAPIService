using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetOrderTrackingQueryHandler : IRequestHandler<GetOrderTrackingCommand, List<AffiliateOrderTrackingViewModel>>
    {
        private readonly ILogger<GetOrderTrackingCommand> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateTrackingServices _affiliateTrackingServices;

        public GetOrderTrackingQueryHandler(ILogger<GetOrderTrackingCommand> logger,
                                               IBaseApi baseApi,
                                               IMapper mapper,
                                               IAffiliateTrackingServices affiliateTrackingServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateTrackingServices = affiliateTrackingServices;
        }
        public async Task<List<AffiliateOrderTrackingViewModel>> Handle(GetOrderTrackingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateOrderTracking = await _affiliateTrackingServices.GetAffiliateOrderTracking(request.LatestId);
                List<AffiliateOrderTrackingViewModel> result = affiliateOrderTracking
                            .Select(x => new AffiliateOrderTrackingViewModel
                            {
                                Id = x.Id,
                                OrderId = x.OrderId,
                                Website = x.Website,
                                OrderCreateTime = x.OrderCreateTime,
                            }).OrderByDescending(x => x.OrderCreateTime).ToList();


                Log.Logger.Information($"DONE {nameof(GetOrderTrackingCommand)}");
                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetOrderTrackingCommand)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

    }
}
