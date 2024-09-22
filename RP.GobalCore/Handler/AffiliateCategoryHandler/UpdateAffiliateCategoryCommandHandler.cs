using System.Net;
using AutoMapper;
using RP.Affiliate.Tracking.Commands;
using RP.Affiliate.Tracking.Commands.AffiliateCategory;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Library.Helpers;
using RP.Library.Helpers.Api;
using RP.Library.Helpers.Service;
using RP.Library.Seedwork;
using LinqKit;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateCategoryHandler
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
