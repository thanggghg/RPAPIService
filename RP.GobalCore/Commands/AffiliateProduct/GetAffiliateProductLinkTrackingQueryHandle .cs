
using System.Net;
using RP.Affiliate.Authentication.Domain.Entities.Affiliate;
using RP.Affiliate.Authentication.Domain.Repositories;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using RP.Affiliate.Tracking.Repositories;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.Services.Interfaces;
using RP.Common.Enums;
using RP.Library.Helpers;
using RP.Library.Helpers.Api;
using RP.Library.Helpers.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetAffiliateProductLinkTrackingQueryHandle : IRequestHandler<GetAffiliateProductLinkTrackingQuery, GenericResponse<string>>
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IAffiliateTrackingServices _affiliateTrackingServices;
        private readonly IAffiliateAuthRepository<AffiliateUserStore> _affiliateUserStoreRepository;
        private readonly IAffiliateRepository<AffiliateCampaign> _affiliateCampaignRepository;
        private readonly IAffiliateRepository<AffiliateCampaignProduct> _affiliateCampaignProductRepository;
        private readonly IBaseApi _baseApi;
        private readonly IBaseService _baseService;
        public GetAffiliateProductLinkTrackingQueryHandle(IAffiliateProductRepository affiliateProductRepository,
                                             IAffiliateTrackingServices affiliateTrackingServices,
                                             IAffiliateAuthRepository<AffiliateUserStore> affiliateUserStoreRepository,
                                             IAffiliateRepository<AffiliateCampaign> affiliateCampaignRepository,
                                             IAffiliateRepository<AffiliateCampaignProduct> affiliateCampaignProductRepository,
                                             IBaseApi baseApi,
                                             IBaseService baseService)
        {
            _affiliateProductRepository = affiliateProductRepository;
            _affiliateTrackingServices = affiliateTrackingServices;
            _affiliateUserStoreRepository = affiliateUserStoreRepository;
            _affiliateCampaignRepository = affiliateCampaignRepository;
            _affiliateCampaignProductRepository = affiliateCampaignProductRepository;
            _baseApi = baseApi;
            _baseService = baseService;
        }

        public async Task<GenericResponse<string>> Handle(GetAffiliateProductLinkTrackingQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _affiliateUserStoreRepository.Filter(x => x.Id == query.UserId && x.IsDeleted != true).FirstOrDefaultAsync();
                var userAllowStatusList = new List<UserStoreStatusEnum> { UserStoreStatusEnum.ACTIVATED, UserStoreStatusEnum.PENDING };
                if (user == null || !userAllowStatusList.Contains(user.Status))
                {
                    return new GenericResponse<string>(HttpStatusCode.Unauthorized, "User not ACTIVATED", null);
                }
                AffiliateProduct product;

                if (query.IsPublisher)
                {
                    product = await _affiliateProductRepository.GetByRefIdWithAffiliateStoreIdAsync(query.RefProductId, _baseApi.User.AffiliateStoreId);
                }
                else
                {
                    product = await _affiliateProductRepository.GetByRefIdAsync(query.RefProductId);
                    if (product != null && _baseService.isInvalidAffiliateStore(product.AffiliateStoreId, _baseApi.User.StoreId))
                    {
                        return new GenericResponse<string>(HttpStatusCode.NotFound, "Product not exist", null);
                    }
                }

                if (product == null)
                {
                    return new GenericResponse<string>(HttpStatusCode.NotFound, "Product not exist", null);
                }
                else
                {
                    var now = DateTime.UtcNow;
                    var affiliateLink = new AffiliateLink();
                    var affiliateCampaign = (from ac in _affiliateCampaignRepository.Filter(x => x.AffiliateStoreId == product.AffiliateStoreId && x.StartDate <= now && now <= x.EndDate)
                                             join acp in _affiliateCampaignProductRepository.Filter(x => x.AffiliateProductId == product.Id) on ac.Id equals acp.AffiliateCampaignId
                                             select ac).ToList().FirstOrDefault();
                    affiliateLink.UpdateCreatedBy(query.UserLogin);
                    affiliateLink.PartnerId = query.UserId;
                    affiliateLink.OriginLink = product.ProductUrl;
                    affiliateLink.ProductId = product.Id;
                    affiliateLink.CampaignId = affiliateCampaign != null ? affiliateCampaign.Id : null;
                    var link = await _affiliateTrackingServices.CreateAffiliateProductLinkTracking(affiliateLink, cancellationToken);
                    Log.Logger.Information($"DONE {nameof(GetAffiliateProductLinkTrackingQuery)}");

                    return await Task.FromResult(new GenericResponse<string>(HttpStatusCode.OK, "Get Link Successfull", link));
                }

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateProductLinkTrackingQuery)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}

