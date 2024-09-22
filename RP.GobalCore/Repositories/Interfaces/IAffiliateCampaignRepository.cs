using System.Linq.Expressions;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.Queries.AffiliateCampaign;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Repositories.Interfaces
{
    public interface IAffiliateCampaignRepository : IRepository<AffiliateCampaign>
    {
        Task<long> CreateCampaign(AffiliateCampaign affiliateCampaign, List<CampaignProductRequest> products, string userLogin);

        Task<long> UpdateCampaign(AffiliateCampaign affiliateCampaign, List<CampaignProductRequest> campaignProducts, string userLogin);

        bool CheckIsExitCampaignName(long? campaignId, long affiliateStoreId, string name);

        Task Delete(AffiliateCampaign affiliateCampaign);
        Task<AffiliateCampaign> GetByIdAsync(long id);

        Task<AffiliateCampaign> GetByIdAsync(long id, long affiliateStoreId);

        Task<AffiliateCampaignDetailViewModel> GetDetailViewModelByIdAsync(long id);

        IQueryable<AffiliateCampaign> GetByStoreIdAsync(Expression<Func<AffiliateCampaign, bool>> filter);
        IQueryable<AffiliateCampaign> GetAsync(Expression<Func<AffiliateCampaign, bool>> filter);
        Task<List<AffiliateCampaign>> GetByQueryAsync(Expression<Func<AffiliateCampaign, bool>> filter);
        Task UpdateRangeAsync(List<AffiliateCampaign> affiliateCampaigns);
        Task<List<CampaignToCalculateCommissionModel>> GetCampaignsToCommissionCalculateAsync(long affiliateStoreId, DateTime fromDate, DateTime toDate);
        Task<List<CampaignsHappeningForPublisherIncludeProductModel>> GetCampaignsHappeningForPublisherIncludeProductAsync(GetCampaignsHappeningForPublisherIncludeProductQuery request);
        Task<List<CampaignsHappeningForPublisherModel>> GetCampaignsHappeningForPublisherAsync(long affiliateStoreId, int size, long? campaignId = null);

        Task<List<long>> GetProductIdsInCampaignAsync(long campaignId);
        Task<int> CronJobUpdateAllExpriredCampaignAsync(long affiliateStoreId = 0);
    }
}
