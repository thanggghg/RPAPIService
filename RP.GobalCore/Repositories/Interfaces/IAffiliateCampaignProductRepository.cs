using System.Linq.Expressions;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Models.Requests;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Seedwork;

namespace RP.Affiliate.Tracking.Repositories.Interfaces
{
    public interface IAffiliateCampaignProductRepository : IRepository<AffiliateCampaignProduct>
    {
        IQueryable<AffiliateCampaignProduct> GetAsync(Expression<Func<AffiliateCampaignProduct, bool>> filter);
        Task<List<AffiliateCampaignProduct>> GetByQueryAsync(Expression<Func<AffiliateCampaignProduct, bool>> filter);
    }
}
