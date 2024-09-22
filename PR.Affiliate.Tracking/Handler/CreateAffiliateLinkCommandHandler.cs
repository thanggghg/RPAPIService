using System.Web;
using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class CreateAffiliateLinkCommandHandler : IRequestHandler<CreateAffiliateLinkCommand, List<string>>
    {
        private readonly ILogger<CreateAffiliateLinkCommandHandler> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateTrackingServices _affiliateTrackingServices;
        public CreateAffiliateLinkCommandHandler(ILogger<CreateAffiliateLinkCommandHandler> logger,
                                                 IBaseApi baseApi,
                                                 IMapper mapper,
                                                 IAffiliateTrackingServices affiliateTrackingServices)
        {
            _logger = logger;
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateTrackingServices = affiliateTrackingServices;
        }
        public async Task<List<string>> Handle(CreateAffiliateLinkCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<AffiliateLink> affiliateLinks = _mapper.Map<List<AffiliateLink>>(request);
                affiliateLinks.ForEach(x => { x.UpdateCreatedBy(_baseApi.User.Sub); x.PartnerId = _baseApi.User.UserId; });
                var reponses = await _affiliateTrackingServices.CreateAffiliateLinkTracking(affiliateLinks, cancellationToken);
                Log.Logger.Information($"DONE {nameof(CreateAffiliateLinkCommandHandler)}");
                return await Task.FromResult(reponses);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateLinkCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
