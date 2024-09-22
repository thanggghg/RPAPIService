using System.Net;
using AutoMapper;
using RP.Affiliate.Tracking.Commands.AffiliateCategory;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.Database.Entities;
using RP.Library.Helpers;
using RP.Library.Helpers.Api;
using RP.Library.Seedwork;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class CreateAffiliateCategoryCommandHandler : IRequestHandler<CreateAffiliateCategoryCommand, BaseResponse>
    {
        private readonly IAffiliateCategoryRepository _AffiliateCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        private readonly AffiliateContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CreateAffiliateCategoryCommandHandler(IAffiliateCategoryRepository AffiliateCategoryRepository,
                                                  IMapper mapper,
                                                  IBaseApi baseApi,
                                                  AffiliateContext affiliateContext)
        {
            _AffiliateCategoryRepository = AffiliateCategoryRepository;
            _mapper = mapper;
            _baseApi = baseApi;
            _context = affiliateContext;
        }

        public async Task<BaseResponse> Handle(CreateAffiliateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await _AffiliateCategoryRepository.GetByRefIdAsync(request.RefCategoryId, request.AffiliateStoreId, true);
            if (existCategory != null)
            {
                existCategory.Name = request.Name;
                existCategory.IsDeleted = false;
                existCategory.Status = true;
                existCategory.LastModifiedBy = _baseApi.User.Sub;
                existCategory.AffiliateStoreId = request.AffiliateStoreId;
                await _AffiliateCategoryRepository.Update(existCategory);
            }
            else
            {
                var affiliateCategory = _mapper.Map<AffiliateCategory>(request);
                affiliateCategory.AffiliateStoreId = request.AffiliateStoreId;
                affiliateCategory.Status = true;
                affiliateCategory.CreatedBy = _baseApi.User.Sub;
                affiliateCategory.LastModifiedBy = _baseApi.User.Sub;
                await _AffiliateCategoryRepository.Add(affiliateCategory);
            }
            return new BaseResponse(HttpStatusCode.OK, "Added Affiliate Category successfully");
        }
    }
}
