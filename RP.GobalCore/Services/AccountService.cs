using System.Linq.Expressions;
using System.Web;
using RP.Affiliate.Tracking.Services.Interfaces;
using RP.Affiliate.Tracking.Utils;
using RP.Affiliate.Tracking.ViewModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace RP.Affiliate.Tracking.Services
{
    public class AccountService : IAccountService
    {
        private ILogger<AccountService> Logger;

        private readonly AffiliateContext _affiliateDbContext;
        public AccountService(
            ILogger<AccountService> logger,
            AffiliateContext affiliateDbContext
           )
        {
            Logger = logger;
            _affiliateDbContext = affiliateDbContext;
        }

        public async Task<bool> CreateAffiliateClickTracking(AffiliateClickTracking clickTracking, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateLink = await _affiliateLinkRepository.Filter(x => x.TrackingId == clickTracking.TrackingId).FirstOrDefaultAsync();
                if (affiliateLink == null)
                {
                    return false;
                }
                var newAffiliateClickTracking = await _affiliateClickTrackingRepository.AddAsync(clickTracking);

                var result = await _affiliateClickTrackingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                if (result)
                {
                    await CalculateAffiliateManagementAsync(newAffiliateClickTracking, affiliateLink);
                    result = await _affiliateClickTrackingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }
                Log.Logger.Information($"DONE {nameof(CreateClickTrackingCommandHandler)}");
                return result;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateClickTrackingCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

    }
}


