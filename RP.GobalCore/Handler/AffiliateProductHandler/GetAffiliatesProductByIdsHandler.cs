using AutoMapper;
using RP.Affiliate.Tracking.Commands.AffiliateProduct;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Library.Helpers.Api;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetAffiliatesProductByIdsHandler : IRequestHandler<GetAffiliateProductsByIdsCommand, List<AffiliateProduct>>
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;

        public GetAffiliatesProductByIdsHandler(IAffiliateProductRepository affiliateProductRepository,
                                           IMediator mediator,
                                           IMapper mapper,
                                           IBaseApi baseApi)
        {
            _affiliateProductRepository = affiliateProductRepository;
            _mediator = mediator;
            _mapper = mapper;
            _baseApi = baseApi;
        }

        public async Task<List<AffiliateProduct>> Handle(GetAffiliateProductsByIdsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _affiliateProductRepository.GetAsync(s => s.AffiliateStoreId == request.AffiliateStoreId && request.ProductIds.Contains(s.RefProductId)).ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliatesProductByIdsHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
