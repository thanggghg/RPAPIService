using AutoMapper;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using RP.Affiliate.Tracking.Repositories;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers.Api;
using RP.Library.Helpers.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetSpecificAffiliateProductQueryHandler : IRequestHandler<GetSpecificAffiliateProductQuery, AffiliateProductViewModel>
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBaseService _baseService;
        private readonly IBaseApi _baseApi;
        public GetSpecificAffiliateProductQueryHandler(IAffiliateProductRepository affiliateProductRepository,
                                            IMediator mediator,
                                            IMapper mapper,
                                            IBaseService baseService,
                                            IBaseApi baseApi)
        {
            _affiliateProductRepository = affiliateProductRepository;
            _mediator = mediator;
            _mapper = mapper;
            _baseService = baseService;
            _baseApi = baseApi;
        }
        public async Task<AffiliateProductViewModel> Handle(GetSpecificAffiliateProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateProduct = await _affiliateProductRepository.GetByIdAsync(request.Id);
                if(affiliateProduct == null || _baseService.isInvalidAffiliateStore(affiliateProduct.AffiliateStoreId, _baseApi.User.StoreId))
                {
                    return null;
                }
                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateProductQueryHandler)}");
                return _mapper.Map<AffiliateProductViewModel>(affiliateProduct);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateProductQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
