using System.Net;
using DocumentFormat.OpenXml.Spreadsheet;
using RP.Affiliate.Tracking.Commands.AffiliateCampaign;
using RP.Affiliate.Tracking.Commons.Constants;
using RP.Affiliate.Tracking.Commons.Enums;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.Queries.AffiliateCampaign;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Common.Models;
using RP.CommonHistory.Commons.Enums;
using RP.Library.Db;
using RP.Library.Helpers;
using RP.Library.Helpers.Api;
using RP.Library.Helpers.Service;
using RP.Library.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;

namespace RP.Affiliate.Tracking.Functions.Implementation
{
    public class AffiliateCampaignFunctions(IAffiliateCampaignRepository affiliateCampaignRepository, IBaseApi baseApi, IBaseService baseService, AffiliateContext affiliateContext, IHttpContextAccessor httpContextAccessor, IHttpClientHelper httpClientHelper, IConfiguration configuration) : IAffiliateCampaignFunctions
    {
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository = affiliateCampaignRepository;
        private readonly IBaseApi _baseApi = baseApi;
        private readonly IBaseService _baseService = baseService;
        private readonly AffiliateContext _affiliateContext = affiliateContext;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IHttpClientHelper _httpClientHelper = httpClientHelper;
        private readonly IConfiguration _configuration = configuration;

        public async Task<BaseResponse> DeleteAffiliateCampaign(DeleteAffiliateCampaignCommand request)
        {
            var deleteCampaign = await _affiliateCampaignRepository.GetByIdAsync(request.Id);
            if (deleteCampaign == null || _baseService.isInvalidAffiliateStore(deleteCampaign.AffiliateStoreId, request.StoreId))
            {
                throw new Exception("Affiliate not exist");
            }            

            await _affiliateCampaignRepository.Delete(deleteCampaign);

            return new BaseResponse(HttpStatusCode.OK, "Deleted Affiliate Campaign successfully");
        }

        public async Task<GenericResponse<int>> TerminateAffiliateCampaignAsync(TerminateAffiliateCampaignCommand terminateAffiliateCampaignCommand)
        {
            try
            {
                var affiliateCampaign = await _affiliateCampaignRepository.GetByIdAsync(terminateAffiliateCampaignCommand.Id);
                if (affiliateCampaign == null || _baseService.isInvalidAffiliateStore(affiliateCampaign.AffiliateStoreId, _baseApi.User.StoreId))
                {
                    return new GenericResponse<int>(HttpStatusCode.OK, "Campaign is not exist", (int)CampaignResponseCodeEnum.CampaignNotExist);
                }
                else
                {
                    if (affiliateCampaign.EndDate <= DateTime.UtcNow)
                    {
                        return new GenericResponse<int>(HttpStatusCode.OK, "Cannot terminate! This campaign is ended. Please reload this page!", (int)CampaignResponseCodeEnum.EndedCampaign);
                    }
                    else
                    {
                        affiliateCampaign.Status = AffiliateCampaignStatus.TERMINATED;
                        affiliateCampaign.LastModifiedBy = _baseApi.User.Sub;
                        affiliateCampaign.LastModifiedDate = DateTime.UtcNow;
                        affiliateCampaign.TerminatedBy = _baseApi.User.Sub;
                        affiliateCampaign.TerminatedDate = DateTime.UtcNow;
                        affiliateCampaign.Note = "be terminated by " + _baseApi.User.Sub;
                        _affiliateContext.Update(affiliateCampaign);
                        await _affiliateContext.SaveChangesAsync();
                    }
                    CreateCampaigncHistory(affiliateCampaign.Id, new HistoryMessageTemplate()
                    {
                        MessageTemplate = "page.affiliate.campaign.form.terminate",
                        Params = []
                    }, "");
                }

                return new GenericResponse<int>(HttpStatusCode.OK, "Teminated campaign successfully", (int)CampaignResponseCodeEnum.SaveSuccessfully);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new GenericResponse<int>(HttpStatusCode.InternalServerError, ex.Message);
            }            
        }

        public async Task<GenericResponse<int>> PublishAffiliateCampaignAsync(PublishAffiliateCampaignCommand affiliateCampaignCommand)
        {
            try
            {
                var validateAffiliateCampaignQuery = new ValidateAffiliateCampaignQuery(affiliateCampaignCommand);
                int validateCode = await ValidateCampaignData(validateAffiliateCampaignQuery);
                if (validateCode == (int)CampaignResponseCodeEnum.SaveSuccessfully)
                {
                    if (affiliateCampaignCommand.Id.HasValue && affiliateCampaignCommand.Id.Value > 0)
                    {
                        var updatedAffiliateCampaign = await _affiliateCampaignRepository.GetByIdAsync(affiliateCampaignCommand.Id.Value);
                        updatedAffiliateCampaign.AffiliateStoreId = affiliateCampaignCommand.AffiliateStoreId;
                        updatedAffiliateCampaign.Name = affiliateCampaignCommand.Name;
                        updatedAffiliateCampaign.StartDate = affiliateCampaignCommand.StartDate;
                        updatedAffiliateCampaign.EndDate = affiliateCampaignCommand.EndDate;
                        updatedAffiliateCampaign.Status = AffiliateCampaignStatus.PUBLISHED;
                        var res = await _affiliateCampaignRepository.UpdateCampaign(updatedAffiliateCampaign, affiliateCampaignCommand.Products, _baseApi.User.Sub);
                        CreateCampaigncHistory(updatedAffiliateCampaign.Id, new HistoryMessageTemplate()
                        {
                            MessageTemplate = "page.affiliate.campaign.form.publish",
                            Params = []
                        }, "");
                        if (res > 0)
                            return new GenericResponse<int>(HttpStatusCode.OK, "Publish Affiliate Campaign Successfully", (int)res);
                    }
                    else
                    {
                        var affiliateCampaign = new AffiliateCampaign();
                        affiliateCampaign.Name = affiliateCampaignCommand.Name;
                        affiliateCampaign.StartDate = affiliateCampaignCommand.StartDate;
                        affiliateCampaign.EndDate = affiliateCampaignCommand.EndDate;
                        affiliateCampaign.Status = AffiliateCampaignStatus.PUBLISHED;
                        affiliateCampaign.AffiliateStoreId = affiliateCampaignCommand.AffiliateStoreId;

                        var res = await _affiliateCampaignRepository.CreateCampaign(affiliateCampaign, affiliateCampaignCommand.Products, _baseApi.User.Sub);
                        if (res > 0)
                            return new GenericResponse<int>(HttpStatusCode.OK, "Publish Affiliate Campaign Successfully", (int)res);
                    }

                    return new GenericResponse<int>(HttpStatusCode.BadRequest, "Publish Affiliate Campaign Failed");
                }
                else
                {
                    return new GenericResponse<int>(HttpStatusCode.BadRequest, "Publish Affiliate Campaign Failed");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new GenericResponse<int>(HttpStatusCode.InternalServerError, ex.Message);
            }            
        }

        public async Task<GenericResponse<int>> ValidateAffiliateCampaignAsync(ValidateAffiliateCampaignQuery affiliateCampaignRequest)
        {
            try
            {
                int validateCode = await ValidateCampaignData(affiliateCampaignRequest);

                if (validateCode != (int)CampaignResponseCodeEnum.SaveSuccessfully)
                {
                    return new GenericResponse<int>(HttpStatusCode.OK, "Validate Affiliate Campaign Failed", validateCode);
                }

                return new GenericResponse<int>(HttpStatusCode.OK, "Validate Affiliate Campaign Successfully", validateCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new GenericResponse<int>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<int> ValidateCampaignData(ValidateAffiliateCampaignQuery affiliateCampaignRequest)
        {
            if (affiliateCampaignRequest.Id.HasValue && affiliateCampaignRequest.Id.Value > 0)
            {
                var affiliateCampaign = await _affiliateCampaignRepository.GetByIdAsync(affiliateCampaignRequest.Id.Value);
                if (affiliateCampaign != null)
                {
                    if (_affiliateCampaignRepository.CheckIsExitCampaignName(affiliateCampaignRequest.Id.Value, affiliateCampaignRequest.AffiliateStoreId, affiliateCampaignRequest.Name))
                    {
                        return (int)CampaignResponseCodeEnum.ExitedCampaignName;
                    }
                }
                else
                {
                    return (int)CampaignResponseCodeEnum.CampaignNotExist;
                }
            }

            if (_affiliateCampaignRepository.CheckIsExitCampaignName(affiliateCampaignRequest.Id.Value, affiliateCampaignRequest.AffiliateStoreId, affiliateCampaignRequest.Name))
            {
                return (int)CampaignResponseCodeEnum.ExitedCampaignName;
            }
            if (string.IsNullOrEmpty(affiliateCampaignRequest.Name))
            {
                return (int)CampaignResponseCodeEnum.CampaignNameIsRequired;
            }

            if (affiliateCampaignRequest.StartDate > affiliateCampaignRequest.EndDate)
            {
                return (int)CampaignResponseCodeEnum.AppliedTimeOfCampaignInValid;
            }

            if (affiliateCampaignRequest.StartDate.AddMinutes(-5) <= DateTime.UtcNow)
            {
                return (int)CampaignResponseCodeEnum.StartDate5Minutes;
            }

            TimeSpan timeDifference = affiliateCampaignRequest.EndDate - affiliateCampaignRequest.StartDate;

            if (timeDifference.TotalDays > 30 || timeDifference.TotalHours < 1)
            {
                return (int)CampaignResponseCodeEnum.StartDateEndDateLeast1Hour30Day;
            }

            if (affiliateCampaignRequest.Products.Count > 0)
            {
                var listProductIds = affiliateCampaignRequest.Products.Select(x => x.ProductId).ToList();
                var productsInCampaign = await _affiliateContext.AffiliateProducts.Where(x => listProductIds.Contains(x.Id)).ToListAsync();
                bool hasExistedInValidProductInCampaign = productsInCampaign.Any(x => x.IsDeleted == true || x.IsStopSelling == true);
                if (hasExistedInValidProductInCampaign)
                {
                    return (int)CampaignResponseCodeEnum.InValidProductInCampaign;
                }
            }
            else
            {
                return (int)CampaignResponseCodeEnum.AddProductToCampaign;
            }

            var campaignsInAffStore = await _affiliateContext.AffiliateCampaigns
                .Where(x => x.AffiliateStoreId == affiliateCampaignRequest.AffiliateStoreId && x.Status == AffiliateCampaignStatus.PUBLISHED)
                .ToListAsync();

            foreach (var campaign in campaignsInAffStore)
            {
                if (affiliateCampaignRequest.StartDate < campaign.EndDate && affiliateCampaignRequest.EndDate > campaign.StartDate)
                {
                    return (int)CampaignResponseCodeEnum.OverlapOtherCampaign;
                }
            }

            return (int)CampaignResponseCodeEnum.SaveSuccessfully;
        }
        private async void CreateCampaigncHistory(long campaignId, HistoryMessageTemplate jsonActionHistory = null, string description = "")
        {
            try
            {
                var url = $"/netservice/api/v1/common-history/history-node-create";
                var token = string.Empty;
                var authorToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                if (authorToken != null)
                {
                    token = authorToken?.Split(" ").Last();
                }

                var body = new
                {
                    Type = CommonHistoryType.CAMPAIGN,
                    ObjectId = campaignId,
                    JsonActionHistory = JsonConvert.SerializeObject(jsonActionHistory != null ? jsonActionHistory : string.Empty),
                    Description = description
                };

                await _httpClientHelper.SendServiceApiPostAsync<Object>(
                              _configuration.GetSectionValueWithEnvironment("ApiBaseUrl"),
                              url, ApiNameConstants.HISTORY_SERVICE, body, token);

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(CreateCampaigncHistory)} : {ex.Message}");
            }
        }

    }
}
