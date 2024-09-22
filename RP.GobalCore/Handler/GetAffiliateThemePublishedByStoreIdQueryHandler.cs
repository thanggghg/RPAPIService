using AutoMapper;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAffiliateThemePublishedByStoreIdQueryHandler : IRequestHandler<GetAffiliateThemePublishedByStoreIdQuery, AffiliateThemeViewModel>
    {
        private readonly ILogger<GetAffiliateThemePublishedByStoreIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public GetAffiliateThemePublishedByStoreIdQueryHandler(ILogger<GetAffiliateThemePublishedByStoreIdQueryHandler> logger,
                                            IMapper mapper,
                                            IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }
        public async Task<AffiliateThemeViewModel> Handle(GetAffiliateThemePublishedByStoreIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateTheme = await _affiliateStoreServices.GetAffiliateThemePublishedByStoreId(request.StoreId, cancellationToken);
                Log.Logger.Information($"DONE {nameof(GetAffiliateThemePublishedByStoreIdQueryHandler)}");
                return affiliateTheme != null ? _mapper.Map<AffiliateThemeViewModel>(affiliateTheme) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateThemePublishedByStoreIdQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
