using AutoMapper;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers.Api;
using RP.Library.Helpers.Pagination;
using MediatR;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetAffiliateProductViewPublisherQueryHandler : IRequestHandler<GetAffiliateProductViewPublisherQuery, PagingItems<AffiliateProductViewModel>>
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;

        public GetAffiliateProductViewPublisherQueryHandler(IAffiliateProductRepository affiliateProductRepository,
                                           IAffiliateCampaignRepository affiliateCampaignRepository,
                                           IMapper mapper,
                                           IBaseApi baseApi)
        {
            _affiliateProductRepository = affiliateProductRepository;
            _affiliateCampaignRepository = affiliateCampaignRepository;
            _mapper = mapper;
            _baseApi = baseApi;
        }

        public async Task<PagingItems<AffiliateProductViewModel>> Handle(GetAffiliateProductViewPublisherQuery request, CancellationToken cancellationToken)
        {
            try
            {
                request.AffiliateStoreId = _baseApi.User.AffiliateStoreId;
                if (request.CampaignId != null && request.CampaignId > 0)
                {
                    return await _affiliateProductRepository.GetProductWithCampaignQuery(request);
                }
                else
                {
                    var affiliateProducts = await _affiliateProductRepository.GetProducNotCampaignQuery(request);

                    return affiliateProducts != null ? _mapper.Map<PagingItems<AffiliateProductViewModel>>(affiliateProducts) : null;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateProductViewPublisherQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
