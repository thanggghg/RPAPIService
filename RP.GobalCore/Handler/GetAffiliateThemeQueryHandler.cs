using System.Web;
using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using static StackExchange.Redis.Role;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAllAffiliateThemeByStoreIdQueryHandler : IRequestHandler<GetAllAffiliateThemeByStoreIdQuery, List<AffiliateThemeViewModel>>
    {
        private readonly ILogger<GetAllAffiliateThemeByStoreIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public GetAllAffiliateThemeByStoreIdQueryHandler(ILogger<GetAllAffiliateThemeByStoreIdQueryHandler> logger,
                                            IMapper mapper,
                                            IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }
        public async Task<List<AffiliateThemeViewModel>> Handle(GetAllAffiliateThemeByStoreIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateThemes = await _affiliateStoreServices.GetAllAffiliateThemeByStoreId(request.StoreId, cancellationToken);
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateThemeByStoreIdQueryHandler)}");
                var result = affiliateThemes != null ? _mapper.Map<List<AffiliateTheme>, List<AffiliateThemeViewModel>>(affiliateThemes) : null;
                return affiliateThemes != null ? _mapper.Map<List<AffiliateTheme>, List<AffiliateThemeViewModel>>(affiliateThemes) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateThemeByStoreIdQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
