using System.Linq.Expressions;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Seedwork;
using Microsoft.EntityFrameworkCore;

namespace GoSell.Affiliate.Tracking.Repositories
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
