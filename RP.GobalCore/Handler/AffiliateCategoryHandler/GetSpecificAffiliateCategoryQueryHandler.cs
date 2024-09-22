using AutoMapper;
using RP.Affiliate.Tracking.Database.Entities;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Queries;
using RP.Affiliate.Tracking.Repositories;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateCategoryHandler
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
