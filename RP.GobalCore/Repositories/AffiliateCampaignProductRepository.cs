using System.Linq.Expressions;
using RP.Affiliate.Tracking.Commons.Constants;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Models.Requests;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Seedwork;
using Microsoft.EntityFrameworkCore;

namespace RP.Affiliate.Tracking.Repositories
{
    public class AffiliateCampaignProductRepository(AffiliateContext context) : IAffiliateCampaignProductRepository
    {
        private readonly AffiliateContext _context = context;
        public IUnitOfWork UnitOfWork => _context;

        public IQueryable<AffiliateCampaignProduct> GetAsync(Expression<Func<AffiliateCampaignProduct, bool>> filter)
        {
            var query = _context.AffiliateCampaignProducts.AsNoTracking();
            return filter != null ? query.Where(filter).AsQueryable() : query.AsQueryable();
        }
        
        public async Task<List<AffiliateCampaignProduct>> GetByQueryAsync(Expression<Func<AffiliateCampaignProduct, bool>> filter)
        {
            var query = _context.AffiliateCampaignProducts.AsNoTracking();
            return filter != null ? await query.Where(filter).ToListAsync() : await query.ToListAsync();
        }
    }
}
