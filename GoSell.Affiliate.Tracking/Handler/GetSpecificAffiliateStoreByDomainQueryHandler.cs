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
    public class GetSpecificAffiliateStoreByDomainQueryHandler : IRequestHandler<GetSpecificAffiliateStoreByDomainQuery, AffiliateStoreByDomainViewModel>
    {
        private readonly ILogger<GetSpecificAffiliateStoreByDomainQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public GetSpecificAffiliateStoreByDomainQueryHandler(ILogger<GetSpecificAffiliateStoreByDomainQueryHandler> logger,
                                                     IMapper mapper,
                                                     IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<AffiliateStoreByDomainViewModel> Handle(GetSpecificAffiliateStoreByDomainQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStore = await _affiliateStoreServices.GetSpecificAffiliateStoreByDomain(request.Domain, cancellationToken);
                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateStoreByDomainQueryHandler)}");
                return affiliateStore != null ? _mapper.Map<AffiliateStoreByDomainViewModel>(affiliateStore) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateStoreByDomainQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
