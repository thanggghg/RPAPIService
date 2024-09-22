using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Seedwork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class CreateClickTrackingCommandHandler : IRequestHandler<CreateClickTrackingCommand, bool>
    {
        private readonly ILogger<CreateClickTrackingCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateTrackingServices _affiliateTrackingServices;

        public CreateClickTrackingCommandHandler(ILogger<CreateClickTrackingCommandHandler> logger,
                                               IBaseApi baseApi,
                                               IMapper mapper,
                                               IAffiliateTrackingServices affiliateTrackingServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateTrackingServices = affiliateTrackingServices;
        }
        public async Task<bool> Handle(CreateClickTrackingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AffiliateClickTracking affiliateClickTracking = _mapper.Map<AffiliateClickTracking>(request);
                affiliateClickTracking.UpdateCreatedBy("Client");
                affiliateClickTracking.LastModifiedBy = affiliateClickTracking.CreatedBy;
                affiliateClickTracking.LastModifiedDate = affiliateClickTracking.CreatedDate;
                Log.Logger.Information($"DONE {nameof(CreateClickTrackingCommandHandler)}");
                return await _affiliateTrackingServices.CreateAffiliateClickTracking(affiliateClickTracking, cancellationToken);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateClickTrackingCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

    }
}
