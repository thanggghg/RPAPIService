using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GoSell.Affiliate.Tracking.Commands.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Common.Utils;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Service;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCampaignHandler
{
    public class CreateOrUpdateAffiliateCampaignCommandHandler(IMapper mapper,
                                          IBaseService baseService,
                                          IAffiliateCampaignRepository affiliateCampaignRepository,
                                          AffiliateContext affiliateContext
                                      ) : IRequestHandler<CreateOrUpdateAffiliateCampaignCommand, BaseResponseCode>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBaseService _baseService = baseService;
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository = affiliateCampaignRepository;
        private readonly AffiliateContext _affiliateContext = affiliateContext;
        public async Task<BaseResponseCode> Handle(CreateOrUpdateAffiliateCampaignCommand request, CancellationToken cancellationToken)
        {
            var error = ValidateCampaignData(request);
            if (error != null)
                return error;

            if (request.Id.HasValue && request.Id.Value > 0)    // update campaign
            {
                return await UpdateCampaign(request);
            }
            else   // create campaign
            {
                return await CreateCampaign(request);
            }

        }

        public async Task<BaseResponseCode> CreateCampaign(CreateOrUpdateAffiliateCampaignCommand request)
        {
            var affiliateCampaign = _mapper.Map<AffiliateCampaign>(request);
            affiliateCampaign.Status = AffiliateCampaignStatus.DRAFT;

            var res = await _affiliateCampaignRepository.CreateCampaign(affiliateCampaign, request.Products, request.UserLogin);
            if(res > 0)
                return Response(CampaignResponseCodeEnum.SaveSuccessfully, res);

            return Response(CampaignResponseCodeEnum.SaveDataIntoDBError, res);
        }

        public async Task<BaseResponseCode> UpdateCampaign(CreateOrUpdateAffiliateCampaignCommand request)
        {
            var campaignUpdate = await _affiliateCampaignRepository.GetByIdAsync(request.Id.Value);
            if (campaignUpdate == null)
                return Response(CampaignResponseCodeEnum.CampaignNotExist);

            if(_baseService.isInvalidAffiliateStore(campaignUpdate.AffiliateStoreId, request.StoreId))
                return Response(CampaignResponseCodeEnum.CampaignNotExist);

            var listStatusChange = new List<int> { AffiliateCampaignStatus.DRAFT, AffiliateCampaignStatus.PUBLISHED };
            if (!listStatusChange.Contains(campaignUpdate.Status))
                return Response(CampaignResponseCodeEnum.StatusNotChange);
            if (request.currentStatus != null && request.currentStatus != campaignUpdate.Status)
            {
                return Response(CampaignResponseCodeEnum.OutdatedData);
            }
            // if status of campaign db is PUBLISHED then not update campaign info
            if (campaignUpdate.Status != AffiliateCampaignStatus.PUBLISHED)
            {
                campaignUpdate.Name = request.Name;
                campaignUpdate.AffiliateStoreId = request.AffiliateStoreId;
                campaignUpdate.StartDate = request.StartDate;
                campaignUpdate.EndDate = request.EndDate;
            }

            // if ispublish is true then change status is PUBLISHED
            if (request.IsPublish)
            {
                campaignUpdate.Status = AffiliateCampaignStatus.PUBLISHED;
                if (request.Products.Count > 0)
                {
                    var listProductIds = request.Products.Select(x => x.ProductId).ToList();
                    var productsInCampaign = await _affiliateContext.AffiliateProducts.Where(x => listProductIds.Contains(x.Id)).ToListAsync();
                    bool hasExistedInValidProductInCampaign = productsInCampaign.Any(x => x.IsDeleted == true || x.IsStopSelling == true);
                    if (hasExistedInValidProductInCampaign)
                    {
                        return Response(CampaignResponseCodeEnum.InValidProductInCampaign);

                    }
                } else
                {
                    return Response(CampaignResponseCodeEnum.AddProductToCampaign);
                }
            }


            var res = await _affiliateCampaignRepository.UpdateCampaign(campaignUpdate, request.Products, request.UserLogin);
            if (res > 0)
                return Response(CampaignResponseCodeEnum.SaveSuccessfully, res);

            return Response(CampaignResponseCodeEnum.SaveDataIntoDBError, res);
        }

        public BaseResponseCode ValidateCampaignData(CreateOrUpdateAffiliateCampaignCommand request)
        {
            var nowUtc = DateTime.UtcNow;
            var maxCommissionFix = 8999999999999999;
            var minCommissionFix = 0;
            var maxCommissionPercent = 100;
            var minCommissionPercent = 0;

            // check startdate and enddate
            if (request.StartDate > request.EndDate)
                return Response(CampaignResponseCodeEnum.AppliedTimeOfCampaignInValid);

            // check start time must be at least 5 minutes from the current time
            if (request.StartDate.AddMinutes(-5) <= nowUtc)
                return Response(CampaignResponseCodeEnum.StartDate5Minutes);

            // check end time must not exceed 30 days from Start time
            TimeSpan timeDifferenceOfCampaign = request.EndDate - request.StartDate;
            if (timeDifferenceOfCampaign.TotalDays > 30 || timeDifferenceOfCampaign.TotalHours < 1)
                return Response(CampaignResponseCodeEnum.StartDateEndDateLeast1Hour30Day);            

            // check list product
            if(request.Products.Any(a => a.CommissionPercent > maxCommissionPercent || a.CommissionPercent < minCommissionPercent || a.CommissionFix < minCommissionFix || a.CommissionFix > maxCommissionFix))
                return Response(CampaignResponseCodeEnum.ProductListError);

            // check name campaign
            if (string.IsNullOrEmpty(request.Name))
                return Response(CampaignResponseCodeEnum.CampaignNameIsRequired);

            if (_affiliateCampaignRepository.CheckIsExitCampaignName(request.Id, request.AffiliateStoreId, request.Name))
                return Response(CampaignResponseCodeEnum.ExitedCampaignName);

            // check affiliate store
            if (_baseService.isInvalidAffiliateStore(request.AffiliateStoreId, request.StoreId))
                return Response(CampaignResponseCodeEnum.NotFoundAffiliateStore);

            return null;
        }

        private BaseResponseCode Response(CampaignResponseCodeEnum statusCode, long res = 0)
        {
            return new BaseResponseCode((int)statusCode, statusCode.GetDescription(), res);
        }
    }
}
