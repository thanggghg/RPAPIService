using System.Net;
using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commands.AffiliateCategory;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Service;
using GoSell.Library.Seedwork;
using LinqKit;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class UpdateAffiliateCategoryCommandHandler : IRequestHandler<UpdateAffiliateCategoryCommand, BaseResponse>
    {
        private readonly IAffiliateCategoryRepository _AffiliateCategoryRepository;
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        private readonly AffiliateContext _context;
        private readonly IBaseService _baseService;
        public IUnitOfWork UnitOfWork => _context;

        public UpdateAffiliateCategoryCommandHandler(IAffiliateCategoryRepository AffiliateCategoryRepository,
                                                  IMapper mapper,
                                                  IBaseApi baseApi,
                                                  AffiliateContext affiliateContext,
                                                  IBaseService baseService,
                                                  IAffiliateProductRepository affiliateProductRepository)
        {
            _AffiliateCategoryRepository = AffiliateCategoryRepository;
            _mapper = mapper;
            _baseApi = baseApi;
            _context = affiliateContext;
            _baseService = baseService;
            _affiliateProductRepository = affiliateProductRepository;
        }

        public async Task<BaseResponse> Handle(UpdateAffiliateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updateCategory = await _AffiliateCategoryRepository.GetByIdAsync(request.Id);
            if (updateCategory == null || _baseService.isInvalidAffiliateStore(updateCategory.AffiliateStoreId, _baseApi.User.StoreId))
            {
                throw new Exception("Category not exist");
            }

            if(updateCategory.AffiliateStoreId != request.AffiliateStoreId)
            {
                updateCategory.AffiliateStoreId = request.AffiliateStoreId;
                
                await HandleUpdateProduct(updateCategory.Id, updateCategory.AffiliateStoreId);
            }

            updateCategory.RefCategoryId = request.RefCategoryId;
            updateCategory.Name = request.Name;            
            updateCategory.LastModifiedBy = _baseApi.User.Sub;

            await _AffiliateCategoryRepository.Update(updateCategory);
            return new BaseResponse(HttpStatusCode.OK, "Updated Affiliate Category successfully");
        }

        private async Task<int> HandleUpdateProduct(long categoryId, long affiliateStoreId)
        {
            var products = _affiliateProductRepository.GetByCategoryAsync(categoryId);

            var refIds = products.Select(x => x.RefProductId).ToList();

            var exitedRefIdProducts = _affiliateProductRepository.GetByRefIdsWithAffiliateStoreIdAsync(refIds, affiliateStoreId);

            var exitedRefId = exitedRefIdProducts.Select(x => x.RefProductId).ToList();

            var updateProducts = products.Where(x => !exitedRefId.Contains(x.RefProductId));

            updateProducts.ForEach(product =>
            {
                product.AffiliateStoreId = affiliateStoreId;
            });

            return await _affiliateProductRepository.UpdateMultipleAffiliateProduct(updateProducts);
        }
    }
}
