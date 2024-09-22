using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetThemesOfBusinessQuery : IRequest<List<DefaultThemeViewModel>>
    {
        public long ExternalStoreId { get; set; }
        public GetThemesOfBusinessQuery(long externalStoreId)
        {
            ExternalStoreId = externalStoreId;
        }
    }
}
