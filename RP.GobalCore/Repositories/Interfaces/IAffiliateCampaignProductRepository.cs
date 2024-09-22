using System.Linq.Expressions;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Repositories.Interfaces
{
    public interface IAffiliateCampaignProductRepository : IRepository<AffiliateCampaignProduct>
    {
        IQueryable<AffiliateCampaignProduct> GetAsync(Expression<Func<AffiliateCampaignProduct, bool>> filter);
        Task<List<AffiliateCampaignProduct>> GetByQueryAsync(Expression<Func<AffiliateCampaignProduct, bool>> filter);
    }
}
