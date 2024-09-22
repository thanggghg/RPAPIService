using AutoMapper;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetBaseSpecificAffiliateStoreByIdQueryHandler : IRequestHandler<GetBaseSpecificAffiliateStoreByIdQuery, AffiliateStoreViewModel>
    {
        private readonly ILogger<GetSpecificAffiliateStoreByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public GetBaseSpecificAffiliateStoreByIdQueryHandler(ILogger<GetSpecificAffiliateStoreByIdQueryHandler> logger,
                                                     IMapper mapper,
                                                     IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<AffiliateStoreViewModel> Handle(GetBaseSpecificAffiliateStoreByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStore = await _affiliateStoreServices.GetBaseSpecificAffiliateByStoreId(request.Id, cancellationToken);
                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateStoreByIdQueryHandler)}");
                return affiliateStore != null ? _mapper.Map<AffiliateStoreViewModel>(affiliateStore) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateStoreByIdQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
