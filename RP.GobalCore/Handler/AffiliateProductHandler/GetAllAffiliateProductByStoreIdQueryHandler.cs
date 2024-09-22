using AutoMapper;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers.Pagination;
using MediatR;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetAllAffiliateProductByStoreIdQueryHandler : IRequestHandler<GetAllAffiliateProductByStoreIdQuery, PagingItems<AffiliateProductViewModel>>
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GetAllAffiliateProductByStoreIdQueryHandler(IAffiliateProductRepository affiliateProductRepository,
                                            IMediator mediator,
                                            IMapper mapper)
        {
            _affiliateProductRepository = affiliateProductRepository;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<PagingItems<AffiliateProductViewModel>> Handle(GetAllAffiliateProductByStoreIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _affiliateProductRepository.GetByStoreIdAsync(x => x.AffiliateStoreId == request.AffiliateStoreId);
                var affiliateProducts = await query.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateProductByStoreIdQueryHandler)}");
                return affiliateProducts != null ? _mapper.Map<PagingItems<AffiliateProductViewModel>>(affiliateProducts) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateProductByStoreIdQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
