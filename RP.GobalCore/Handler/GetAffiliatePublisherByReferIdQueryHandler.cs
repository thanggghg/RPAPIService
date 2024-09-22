using AutoMapper;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAffiliatePublisherByReferIdQueryHandler : IRequestHandler<GetAffiliatePublisherByOrderIdQuery, long>
    {
        private readonly ILogger<GetAffiliatePublisherByReferIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;
        private readonly IAffiliatePartnerServices _affiliatePartnerSerivces;

        public GetAffiliatePublisherByReferIdQueryHandler(ILogger<GetAffiliatePublisherByReferIdQueryHandler> logger,
                                           IMapper mapper,
                                           IAffiliatePartnerServices affiliatePartnerSerivces,
                                           IAffiliateSubmissionServices affiliateSubmissionServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliatePartnerSerivces = affiliatePartnerSerivces;
            _affiliateSubmissionServices = affiliateSubmissionServices;
        }

        public async Task<long> Handle(GetAffiliatePublisherByOrderIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var submission = await _affiliateSubmissionServices.GetAffiliateSubmissionBySubmissionId(request.OrderId);
                if (submission == null)
                {
                    throw new Exception($"The OrderId {request.OrderId} does not exist");
                }
                var affiliatePartners = _affiliatePartnerSerivces.GetPartnerIdByTrackingIds(submission.TrackingIds);
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateStoreQueryHandler)}");
                if (request.IsLast)
                {
                    return affiliatePartners.LastOrDefault();
                }
                return affiliatePartners.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
