using AutoMapper;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAffiliateThemeByBusinessIdQueryHandler : IRequestHandler<GetAffiliateThemeByBusinessIdQuery, AffiliateThemeViewModel>
    {
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public GetAffiliateThemeByBusinessIdQueryHandler(IBaseApi baseApi,
                                                 IMapper mapper,
                                                 IAffiliateStoreServices affiliateStoreServices)
        {
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }
        public async Task<AffiliateThemeViewModel> Handle(GetAffiliateThemeByBusinessIdQuery command, CancellationToken cancellationToken)
        {
            try
            {
                var (theme, business) = await _affiliateStoreServices.GetAffiliateThemeByBusinessIdAsync(command, cancellationToken);
                var themeView = _mapper.Map<AffiliateThemeViewModel>(theme);
                themeView.ThumbnailImage = business.ThumbnailImagePath;

                Log.Logger.Information($"DONE {nameof(GetAffiliateThemeByBusinessIdQueryHandler)}");
                return themeView;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateThemeByBusinessIdQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
