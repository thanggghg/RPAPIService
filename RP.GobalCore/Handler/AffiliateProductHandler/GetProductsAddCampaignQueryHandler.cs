using System.Net;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers;
using RP.Library.Helpers.Pagination;
using RP.Library.Helpers.Service;
using MediatR;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetProductsAddCampaignQueryHandler(IAffiliateProductRepository affiliateProductRepository,
                                                    IBaseService baseService) 
                                                    : IRequestHandler<GetProductsAddCampaignQuery, GenericResponse<PagingItems<AffiliateProductAddCampaignViewModel>>>
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository = affiliateProductRepository;
        private readonly IBaseService _baseService = baseService;

        public async Task<GenericResponse<PagingItems<AffiliateProductAddCampaignViewModel>>> Handle(GetProductsAddCampaignQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // check affiliate store
                if (_baseService.isInvalidAffiliateStore(request.AffiliateStoreId, request.StoreId))
                    return new GenericResponse<PagingItems<AffiliateProductAddCampaignViewModel>>(HttpStatusCode.NotFound, "Not found affiliate store", 
                        new PagingItems<AffiliateProductAddCampaignViewModel>
                        {
                            Items = [],
                            PagingInfo = new PagingInfo
                            {
                                PageNumber = 0,
                                PageSize = request.PageSize ?? 20,
                                TotalItems = 0
                            }
                        });

                var data = await _affiliateProductRepository.GetProductsAddCampaignAsync(request);
                return new GenericResponse<PagingItems<AffiliateProductAddCampaignViewModel>>(HttpStatusCode.OK, "List Product", data);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetProductsAddCampaignQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
