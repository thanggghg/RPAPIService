using AutoMapper;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetThemesOfBusinessQueryHandler : IRequestHandler<GetThemesOfBusinessQuery, List<DefaultThemeViewModel>>
    {
        private readonly ILogger<GetThemesOfBusinessQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public GetThemesOfBusinessQueryHandler(ILogger<GetThemesOfBusinessQueryHandler> logger,
                                            IMapper mapper,
                                            IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }
        public async Task<List<DefaultThemeViewModel>> Handle(GetThemesOfBusinessQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateThemes = await _affiliateStoreServices.GetThemesOfBusinessQueryAsync(request.ExternalStoreId);
                Log.Logger.Information($"DONE {nameof(GetThemesOfBusinessQueryHandler)}");

                return affiliateThemes;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetThemesOfBusinessQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
