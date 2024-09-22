using System.Web;
using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using static StackExchange.Redis.Role;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAffiliateMappingQueryHandler : IRequestHandler<GetAffiliateMappingByIdQuery, List<AffiliateMappingViewModel>>
    {
        private readonly ILogger<GetAllAffiliateThemeByStoreIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly IAffiliateMappingServices _affiliateMappingServices;
        private readonly IBaseApi _baseApi;
        public GetAffiliateMappingQueryHandler(ILogger<GetAllAffiliateThemeByStoreIdQueryHandler> logger,
                                            IMapper mapper,
                                            IAffiliateStoreServices affiliateStoreServices,
                                            IAffiliateMappingServices affiliateMappingServices,
                                            IBaseApi baseApi)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
            _affiliateMappingServices = affiliateMappingServices;
            _baseApi = baseApi;
        }
        public async Task<List<AffiliateMappingViewModel>> Handle(GetAffiliateMappingByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var externalStoreIds = _affiliateStoreServices.GetAllAffiliateStoreByGsId(_baseApi.User.StoreId).Result.Where(x => !x.IsDeleted).ToList();
                if (externalStoreIds.FindIndex(x => x.Id == request.AffiliateStoreId) < 0)
                {
                    throw new Exception("Store is not exist");
                }
                var result = await _affiliateMappingServices.GetListAffiliateMappingByAffiliateStoreId(request.AffiliateStoreId);
                Log.Logger.Information($"DONE {nameof(GetAffiliateMappingQueryHandler)}");

                return result != null ? _mapper.Map<List<AffiliateMapping>, List<AffiliateMappingViewModel>>(result) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateMappingQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
