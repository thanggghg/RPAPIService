using AutoMapper;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetSpecificAffiliateSubmissionByIdQueryHandler : IRequestHandler<GetSpecificAffiliateSubmissionBySubmisstionIdQuery, OrderDetailsViewModel>
    {
        private readonly ILogger<GetSpecificAffiliateSubmissionByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;
        private readonly IAffiliateStoreServices _affiliateStoreServices;

        public GetSpecificAffiliateSubmissionByIdQueryHandler(ILogger<GetSpecificAffiliateSubmissionByIdQueryHandler> logger, IMapper mapper, IAffiliateSubmissionServices affiliateSubmissionServices, IAffiliateStoreServices affiliateStoreServices)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateSubmissionServices = affiliateSubmissionServices;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<OrderDetailsViewModel> Handle(GetSpecificAffiliateSubmissionBySubmisstionIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _affiliateSubmissionServices.GetAffiliateSubmissionBySubmissionId(request.SubmissionId);
                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateSubmissionByIdQueryHandler)}");
                var orderDetailsViewModel = _mapper.Map<OrderDetailsViewModel>(result);
                if (orderDetailsViewModel != null)
                {
                    var storeCurrency = await _affiliateStoreServices.GetBaseSpecificAffiliateByStoreId(orderDetailsViewModel.ExternalStoreId, cancellationToken);
                    if (storeCurrency != null && storeCurrency.AffiliateStoreCurrency != null)
                    {
                        orderDetailsViewModel.CurrencySymbol = storeCurrency.AffiliateStoreCurrency.Symbol;
                        orderDetailsViewModel.CurrencyCode = storeCurrency.AffiliateStoreCurrency.Code;
                    }
                }
                return orderDetailsViewModel;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateSubmissionByIdQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
