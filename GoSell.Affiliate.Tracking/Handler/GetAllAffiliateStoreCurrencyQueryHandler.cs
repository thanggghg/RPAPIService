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
    public class GetAllAffiliateStoreCurrencyQueryHandler : IRequestHandler<GetAllAffiliateStoreCurrencyQuery, List<AffiliateStoreCurrencyViewModel>>
    {
        private readonly ILogger<GetAllAffiliateStoreCurrencyQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;

        public GetAllAffiliateStoreCurrencyQueryHandler(ILogger<GetAllAffiliateStoreCurrencyQueryHandler> logger,
                                           IMapper mapper,
                                           IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<List<AffiliateStoreCurrencyViewModel>> Handle(GetAllAffiliateStoreCurrencyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStoreCurrencies = await _affiliateStoreServices.GetAllAffiliateStoreCurrencyAsync();
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateStoreQueryHandler)}");
                return affiliateStoreCurrencies != null ? _mapper.Map<List<AffiliateStoreCurrency>, List<AffiliateStoreCurrencyViewModel>>(affiliateStoreCurrencies) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
