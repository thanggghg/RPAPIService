using AutoMapper;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetSpecificAffiliateStoreByGoSellStoreIdQueryHandler : IRequestHandler<GetSpecificAffiliateStoreByGoSellStoreIdQuery, AffiliateStoreViewModel>
    {
        private readonly ILogger<GetSpecificAffiliateStoreByGoSellStoreIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public GetSpecificAffiliateStoreByGoSellStoreIdQueryHandler(ILogger<GetSpecificAffiliateStoreByGoSellStoreIdQueryHandler> logger,
                                                     IMapper mapper,
                                                     IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<AffiliateStoreViewModel> Handle(GetSpecificAffiliateStoreByGoSellStoreIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStore = await _affiliateStoreServices.GetSpecificAffiliateByGoSellStoreId(request.GoSellStoreId, cancellationToken);
                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateStoreByGoSellStoreIdQueryHandler)}");
                return affiliateStore != null ? _mapper.Map<AffiliateStoreViewModel>(affiliateStore) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateStoreByGoSellStoreIdQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
