using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler;

public class GetAffiliateCurrencyUnitByIdQueryHandle : IRequestHandler<GetAffiliateCurrencyUnitByIdQuery, AffiliateStoreCurrencyViewModel>
{
    private readonly IAffiliateStoreServices _affiliateStoreServices;
    public GetAffiliateCurrencyUnitByIdQueryHandle(IAffiliateStoreServices affiliateStoreServices)
    {
        _affiliateStoreServices = affiliateStoreServices;
    }

    public async Task<AffiliateStoreCurrencyViewModel> Handle(GetAffiliateCurrencyUnitByIdQuery request, CancellationToken cancellationToken)
    {
        return await _affiliateStoreServices.GetCurrencyUnitAsync(request.Id);
    }
}
