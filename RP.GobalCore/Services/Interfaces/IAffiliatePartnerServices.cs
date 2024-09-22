using System.Linq.Expressions;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Handler;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Library.Seedwork;
using Microsoft.EntityFrameworkCore.Query;
using Serilog;

namespace GoSell.Affiliate.Tracking.Services.Interfaces
{
    public interface IAffiliatePartnerServices
    {
        IQueryable<long> GetPartnerIdByTrackingIds(string trackingIds);
        Dictionary<Guid, long> GetPartnerByTrackingIds(string trackingIds);
    }
}
