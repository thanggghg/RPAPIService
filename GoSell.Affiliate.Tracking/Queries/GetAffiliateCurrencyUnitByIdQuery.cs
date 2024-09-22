using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries;

public class GetAffiliateCurrencyUnitByIdQuery : IRequest<AffiliateStoreCurrencyViewModel>
{
    public long Id { get; }
    public GetAffiliateCurrencyUnitByIdQuery(long id = default)
    {
        Id = id;
    }
}
