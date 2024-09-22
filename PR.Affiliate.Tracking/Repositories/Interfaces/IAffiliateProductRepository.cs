using System.Linq.Expressions;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Queries.AffiliateProduct;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Repositories.Interfaces
{
    public interface IAffiliateProductRepository : IRepository<AffiliateProduct>
    {
        Task Add(AffiliateProduct affiliateProduct);

        Task Update(AffiliateProduct affiliateProduct);

        Task<AffiliateProduct> GetByIdAsync(long id, long storeId);

        Task<bool> InsertOrUpdateByBulkAsync(List<AffiliateProduct> affiliateProducts, long storeId);

        IQueryable<AffiliateProduct> GetByStoreIdAsync(Expression<Func<AffiliateProduct, bool>> filter);

        IQueryable<AffiliateProduct> GetAsync(Expression<Func<AffiliateProduct, bool>> filter);
        IQueryable<AffiliateProduct> GetProductAPIAsync(Expression<Func<AffiliateProduct, bool>> filter);
        Task<List<AffiliateProduct>> GetByQueryAsync(Expression<Func<AffiliateProduct, bool>> filter);

        Task<PagingItems<AffiliateProduct>> GetProducNotCampaignQuery(GetAffiliateProductViewPublisherQuery request);
        Task<PagingItems<AffiliateProductViewModel>> GetProductWithCampaignQuery(GetAffiliateProductViewPublisherQuery request);

        IQueryable<AffiliateProduct> GetProductByIds(List<long> productIds);
        Task<int> UpdateMultipleAffiliateProduct(long storeId, List<long> productIds, string actionType, string userLogin);
        Task<int> UpdateMultipleAffiliateProduct(IQueryable<AffiliateProduct> affiliateProducts);

        Task<AffiliateProduct> GetByRefIdAsync(string id);

        Task<AffiliateProduct> GetByIdAsync(long id);

        Task<AffiliateProduct> GetByRefIdWithAffiliateStoreIdAsync(string refProductId, long storeId);

        Task<AffiliateProduct> GetDeletedAffProductByRefIdAsync(string refProductId, long storeId);

        Task<AffiliateProduct> GetAffProductByRefIdAsync(string refProductId, long storeId);

        Task<PagingItems<AffiliateProductAddCampaignViewModel>> GetProductsAddCampaignAsync(GetProductsAddCampaignQuery request);

        IQueryable<AffiliateProduct> GetByCategoryAsync(long categoryId);

        IQueryable<AffiliateProduct> GetByRefIdsWithAffiliateStoreIdAsync(List<string> refProductIds, long affiliateStoreId);
        IQueryable<AffiliateProduct> GetAll(Expression<Func<AffiliateProduct, bool>> predicate = null);
    }
}
