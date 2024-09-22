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
    public class GetAllAffiliateStoreQueryHandler : IRequestHandler<GetAllAffiliateStoreQuery, List<AffiliateStoreViewModel>>
    {
        private readonly ILogger<GetAllAffiliateStoreQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;

        public GetAllAffiliateStoreQueryHandler(ILogger<GetAllAffiliateStoreQueryHandler> logger,
                                           IMapper mapper,
                                           IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<List<AffiliateStoreViewModel>> Handle(GetAllAffiliateStoreQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStores = await _affiliateStoreServices.GetAllAffiliateStore(cancellationToken);
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateStoreQueryHandler)}");
                return affiliateStores != null ? _mapper.Map<List<AffiliateStore>, List<AffiliateStoreViewModel>>(affiliateStores) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
