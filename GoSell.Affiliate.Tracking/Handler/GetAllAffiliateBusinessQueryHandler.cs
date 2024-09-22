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
    public class GetAllAffiliateBusinessQueryHandler : IRequestHandler<GetAllAffiliateBusinessQuery, List<AffiliateKeyValueViewModel>>
    {
        private readonly ILogger<GetAllAffiliateBusinessQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;

        public GetAllAffiliateBusinessQueryHandler(ILogger<GetAllAffiliateBusinessQueryHandler> logger,
                                           IMapper mapper,
                                           IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<List<AffiliateKeyValueViewModel>> Handle(GetAllAffiliateBusinessQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listBusiness = await _affiliateStoreServices.GetAllAffiliateBusinessAsync();
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateBusinessQueryHandler)}");
                return listBusiness != null ? _mapper.Map<List<AffiliateBusiness>, List<AffiliateKeyValueViewModel>>(listBusiness) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateBusinessQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
