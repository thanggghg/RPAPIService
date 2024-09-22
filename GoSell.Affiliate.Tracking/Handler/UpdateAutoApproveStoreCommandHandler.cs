using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class UpdateAutoApproveStoreCommandHandler : IRequestHandler<UpdateAutoApproveStoreCommand, bool>
    {
        private readonly ILogger<UpdateAffiliateStoreCommandHandler> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public UpdateAutoApproveStoreCommandHandler(ILogger<UpdateAffiliateStoreCommandHandler> logger,
                                                  IBaseApi baseApi,
                                                  IMapper mapper,
                                                  IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<bool> Handle(UpdateAutoApproveStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStores = await _affiliateStoreServices.GetAllAffiliateStoreByGsId(request.GosellStoreId);
                if (!affiliateStores.Any())
                {
                    throw new Exception("Gosell store not exist");
                }

                if (request.AffilateStoreId != null)
                {
                    affiliateStores = affiliateStores.Where(x => x.Id == request.AffilateStoreId).ToList();
                }

                foreach (var affiliateStore in affiliateStores)
                {
                    affiliateStore.AutoApproved = false;
                    affiliateStore.AutoApprovedDate = DateTime.UtcNow;
                    affiliateStore.UpdateLastModified(_baseApi.User.Sub);
                }

                var result = await _affiliateStoreServices.UpdateRangeAffiliateStoreAsync(affiliateStores, cancellationToken);
                Log.Logger.Information($"DONE {nameof(UpdateAffiliateStoreCommandHandler)}");
                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateAffiliateStoreCommandHandler)} : {ex.Message}");
                throw;
            }
        }
    }
}
