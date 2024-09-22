using System.Net;
using RP.Affiliate.Tracking.Commands.AffiliateCategory;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Library.Helpers;
using RP.Library.Helpers.Api;
using RP.Library.Helpers.Service;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class DeleteAffiliateCategoryCommandHandler(IAffiliateCategoryRepository AffiliateCategoryRepository,
                                              IBaseApi baseApi,
                                              IBaseService baseService) : IRequestHandler<DeleteAffiliateCategoryCommand, BaseResponse>
    {
        private readonly IAffiliateCategoryRepository _AffiliateCategoryRepository = AffiliateCategoryRepository;
        private readonly IBaseApi _baseApi = baseApi;
        private readonly IBaseService _baseService = baseService;

        public async  Task<BaseResponse> Handle(DeleteAffiliateCategoryCommand request, CancellationToken cancellationToken)
        {
            var deleteCategory = await _AffiliateCategoryRepository.GetByIdAsync(request.Id);
            if (deleteCategory == null || _baseService.isInvalidAffiliateStore(deleteCategory.AffiliateStoreId, _baseApi.User.StoreId))
            {
                throw new Exception("Category not exist");
            }

            deleteCategory.IsDeleted = true;
            deleteCategory.LastModifiedBy = _baseApi.User.Sub;

            await _AffiliateCategoryRepository.Update(deleteCategory);

            return new BaseResponse(HttpStatusCode.OK, "Deleted Affiliate Category successfully");
        }
    }
}
