using AutoMapper;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetPublishersByAffStoreIdQueryHandler : IRequestHandler<GetPublishersByAffStoreIdQuery, List<TrackingOrderOfPublishersViewModel>>
    {
        private readonly ILogger<GetPublishersByAffStoreIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;
        private readonly IAffiliatePartnerServices _affiliatePartnerSerivces;

        public GetPublishersByAffStoreIdQueryHandler(ILogger<GetPublishersByAffStoreIdQueryHandler> logger,
                                           IMapper mapper,
                                           IAffiliatePartnerServices affiliatePartnerSerivces,
                                           IAffiliateSubmissionServices affiliateSubmissionServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliatePartnerSerivces = affiliatePartnerSerivces;
            _affiliateSubmissionServices = affiliateSubmissionServices;
        }

        public async Task<List<TrackingOrderOfPublishersViewModel>> Handle(GetPublishersByAffStoreIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _affiliateSubmissionServices.GetPublishersByAffStoreIdAsync(request, cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
