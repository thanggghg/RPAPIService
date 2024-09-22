using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Common.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAffiliateUrlReportQueryHandler : IRequestHandler<GetAffiliateUrlReportQuery, AffiliateUrlReportViewModel>
    {
        private readonly ILogger<GetAffiliateUrlReportQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateTrackingServices _affiliateTrackingServices;

        public GetAffiliateUrlReportQueryHandler(ILogger<GetAffiliateUrlReportQueryHandler> logger,
                                           IMapper mapper,
                                           IAffiliateTrackingServices affiliateTrackingServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateTrackingServices = affiliateTrackingServices;
        }

        public async Task<AffiliateUrlReportViewModel> Handle(GetAffiliateUrlReportQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            try
            {
                if (request.Request?.PublisherId > 0)
                {
                    var result = await _affiliateTrackingServices.GetAffiliateUrlReport(request, cancellationToken);

                    if (result.Data?.Count == 0)
                        return new AffiliateUrlReportViewModel(new List<AffiliateUrlModel>(), 0, 0, 0);
                    else
                        Log.Logger.Information($"DONE {nameof(GetAffiliateUrlReportQueryHandler)}");
                        return result;
                }
                else
                {
                    Log.Logger.Error($"FAIL {nameof(GetAffiliateUrlReportQueryHandler)}");
                    throw new Exception("Publisher Id is not valid");
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateUrlReportQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
