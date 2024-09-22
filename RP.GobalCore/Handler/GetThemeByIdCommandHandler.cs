using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetThemeByIdCommandHandler : IRequestHandler<GetThemeByIdCommand, AffiliateThemeViewModel>
    {
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public GetThemeByIdCommandHandler(IBaseApi baseApi,
                                                 IMapper mapper,
                                                 IAffiliateStoreServices affiliateStoreServices)
        {
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }
        public async Task<AffiliateThemeViewModel> Handle(GetThemeByIdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _affiliateStoreServices.GetAffiliateThemeById(command.Id, cancellationToken);

                Log.Logger.Information($"DONE {nameof(CreateAffiliateLinkCommandHandler)}");
                return _mapper.Map<AffiliateThemeViewModel>(response);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateLinkCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
