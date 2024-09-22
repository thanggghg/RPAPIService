using AutoMapper;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAllAffiliateColorDefaultQueryHandler : IRequestHandler<GetAllAffiliateColorDefaultQuery, List<AffiliateKeyValueViewModel>>
    {
        private readonly ILogger<GetAllAffiliateColorDefaultQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;

        public GetAllAffiliateColorDefaultQueryHandler(ILogger<GetAllAffiliateColorDefaultQueryHandler> logger,
                                           IMapper mapper,
                                           IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<List<AffiliateKeyValueViewModel>> Handle(GetAllAffiliateColorDefaultQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var colors = await _affiliateStoreServices.GetAllAffiliateColorDefaultAsync(request.IsBusinessColor, cancellationToken);
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateColorDefaultQueryHandler)}");
                return colors != null ? _mapper.Map<List<AffiliateColorDefault>, List<AffiliateKeyValueViewModel>>(colors) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateColorDefaultQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
