using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class UpdateAffiliateStoreCommandHandler : IRequestHandler<UpdateAffiliateStoreCommand, bool>
    {
        private readonly ILogger<UpdateAffiliateStoreCommandHandler> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public UpdateAffiliateStoreCommandHandler(ILogger<UpdateAffiliateStoreCommandHandler> logger,
                                                  IBaseApi baseApi,
                                                  IMapper mapper,
                                                  IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<bool> Handle(UpdateAffiliateStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStore = await _affiliateStoreServices.GetSpecificAffiliateByStoreId(request.Id, cancellationToken);
                if (affiliateStore == null)
                {
                    throw new Exception("Store not exist");
                }

                affiliateStore.Logo = request.Logo;
                affiliateStore.AllowPublisherRegister = request.AllowPublisherRegister;
                affiliateStore.AutoApproved = request.AutoApproved;
                affiliateStore.CookieDurationDay = request.CookieDurationDay;
                affiliateStore.ApiKey = request.ApiKey;
                affiliateStore.Name = request.Name;
                affiliateStore.Website = request.Website;
                affiliateStore.AllowGetOrderTrackingCode = request.AllowGetOrderTrackingCode;
                affiliateStore.AllowGetOrderTrackingUrl = request.AllowGetOrderTrackingUrl;
                affiliateStore.KeyWordByUrl = request.KeyWordByUrl;
                affiliateStore.KeyWordByCode = request.KeyWordByCode;
                affiliateStore.UpdateLastModified(_baseApi.User.Sub);
                affiliateStore.AffiliateStoreCurrencyId = request.CurrencyId;

                var result = await _affiliateStoreServices.UpdateAffiliateStore(affiliateStore, cancellationToken);
                Log.Logger.Information($"DONE {nameof(UpdateAffiliateStoreCommandHandler)}");
                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateAffiliateStoreCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
