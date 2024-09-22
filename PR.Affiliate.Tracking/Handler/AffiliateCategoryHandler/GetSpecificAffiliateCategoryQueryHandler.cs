using AutoMapper;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class GetSpecificAffiliateCategoryQueryHandler : IRequestHandler<GetSpecificAffiliateCategoryQuery, AffiliateCategoryViewModel>
    {
        private readonly IAffiliateCategoryRepository _AffiliateCategoryRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        public GetSpecificAffiliateCategoryQueryHandler(IAffiliateCategoryRepository AffiliateCategoryRepository,
                                            IMediator mediator,
                                            IMapper mapper,
                                            IBaseApi baseApi)
        {
            _AffiliateCategoryRepository = AffiliateCategoryRepository;
            _mediator = mediator;
            _mapper = mapper;
            _baseApi = baseApi;
        }
        public async Task<AffiliateCategoryViewModel> Handle(GetSpecificAffiliateCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var AffiliateCategory = await _AffiliateCategoryRepository.GetByIdAsync(request.Id, request.AffiliatetStoreId);
                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateCategoryQueryHandler)}");
                return AffiliateCategory != null ? _mapper.Map<AffiliateCategoryViewModel>(AffiliateCategory) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateCategoryQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
