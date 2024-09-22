using AutoMapper;
using GoSell.Affiliate.Tracking.Queries.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCampaignHandler
{
    public class GetAllAffiliateCampaignByStoreIdQueryHandler : IRequestHandler<GetAllAffiliateCampaignByStoreIdQuery, PagingItems<AffiliateCampaignViewModel>>
    {
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GetAllAffiliateCampaignByStoreIdQueryHandler(IAffiliateCampaignRepository affiliateCampaignRepository,
                                            IMediator mediator,
                                            IMapper mapper)
        {
            _affiliateCampaignRepository = affiliateCampaignRepository;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<PagingItems<AffiliateCampaignViewModel>> Handle(GetAllAffiliateCampaignByStoreIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _affiliateCampaignRepository.GetByStoreIdAsync(x => x.AffiliateStoreId == request.AffiliateStoreId);
                var affiliateCampaigns = await query.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateCampaignByStoreIdQueryHandler)}");
                return affiliateCampaigns != null ? _mapper.Map<PagingItems<AffiliateCampaignViewModel>>(affiliateCampaigns) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateCampaignByStoreIdQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
