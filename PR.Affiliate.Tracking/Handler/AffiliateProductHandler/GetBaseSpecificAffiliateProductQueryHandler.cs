using AutoMapper;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Queries.AffiliateProduct;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetBaseSpecificAffiliateProductQueryHandler : IRequestHandler<GetBaseSpecificAffiliateProductQuery, AffiliateProductViewModel>
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBaseService _baseService;
        private readonly IBaseApi _baseApi;
        public GetBaseSpecificAffiliateProductQueryHandler(IAffiliateProductRepository affiliateProductRepository,
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
        public async Task<AffiliateProductViewModel> Handle(GetBaseSpecificAffiliateProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateProduct = await _affiliateProductRepository.GetByIdAsync(request.Id);
                if(affiliateProduct == null)
                {
                    return null;
                }
                Log.Logger.Information($"DONE {nameof(GetBaseSpecificAffiliateProductQueryHandler)}");
                return _mapper.Map<AffiliateProductViewModel>(affiliateProduct);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetBaseSpecificAffiliateProductQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
