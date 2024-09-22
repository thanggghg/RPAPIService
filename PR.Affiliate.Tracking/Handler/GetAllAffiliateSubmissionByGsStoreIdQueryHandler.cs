using AutoMapper;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAllAffiliateSubmissionByGsStoreIdQueryHandler : IRequestHandler<GetAllAffiliateSubmissionByGsStoreIdQuery, PaginatedList<AffiliateSubmissionViewModel>>
    {
        private readonly ILogger<GetAllAffiliateBusinessQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;

        public GetAllAffiliateSubmissionByGsStoreIdQueryHandler(ILogger<GetAllAffiliateBusinessQueryHandler> logger,
                                           IMapper mapper,
                                           IAffiliateSubmissionServices affiliateSubmissionServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateSubmissionServices = affiliateSubmissionServices;
        }

        public async Task<PaginatedList<AffiliateSubmissionViewModel>> Handle(GetAllAffiliateSubmissionByGsStoreIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _affiliateSubmissionServices.GetAffiliateSubmissionGsByStoreId(request);
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateBusinessQueryHandler)}");
                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateBusinessQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
