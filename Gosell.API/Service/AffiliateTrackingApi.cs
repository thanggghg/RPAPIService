using System.Net;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Validations.AffiliateSubmission;
using GoSell.Affiliate.Tracking.Validations.AffiliateTheme;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.API.Requests;
using GoSell.Common.Constants;
using GoSell.Common.Enums;
using GoSell.Common.Models;
using GoSell.Common.Models.Requests;
using GoSell.Common.Models.Responses;
using GoSell.Common.Queries;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using Serilog;
using Sprache;
using static GoSell.Affiliate.Authentication.Domain.Constants.Consts;

namespace GoSell.API.Service
{
    public static class AffiliateTrackingApi
    {
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> AddClickTrackingAsync(
            [FromQuery] string clickId,
            [FromQuery] string groupId,
            [FromQuery] Guid trackingId,
            [FromQuery] string platform,
            [FromQuery] string device,
            IMediator mediator)
        {
            try
            {
                CreateClickTrackingCommand command = new CreateClickTrackingCommand(clickId,
                                                                                    trackingId,
                                                                                    groupId,
                                                                                    platform,
                                                                                    device);
                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(AddClickTrackingAsync)}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, "Request succeeded"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AddClickTrackingAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<List<string>>>, BadRequest<string>, UnauthorizedHttpResult>> AddAffiliateLinkAsync(
            [FromBody] CreateAffiliateLinkRequest request,
            IBaseApi baseApi,
            IMediator mediator)
        {
            try
            {
                var userInfos = await mediator.Send(new GetAffiliateUserStoreCommand(baseApi.User.StoreId, CommissionApprovalConstant.PUBLISHER_ID, baseApi.User.userAffiliateStoreId.ToString()));
                if (userInfos.AffiliateUserStoreModels.FirstOrDefault().Status != UserStoreStatusEnum.ACTIVATED)
                {
                    return TypedResults.Unauthorized();
                }
                var command = new CreateAffiliateLinkCommand()
                {
                    CampaignId = request.CampaignId,
                    OriginLinks = request.OriginLinks.Distinct().ToList(),
                    SubId1 = request.SubId1,
                    SubId2 = request.SubId2,
                    SubId3 = request.SubId3,
                    SubId4 = request.SubId4,
                    SubId5 = request.SubId5
                };

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(AddAffiliateLinkAsync)}");
                return TypedResults.Ok(new GenericResponse<List<string>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AddAffiliateLinkAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<string>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<long>>, BadRequest<string>>> AddAffiliateStoreAsync(
            [FromBody] AffiliateStoreRequest request,
            IMediator mediator,
            IBaseApi baseApi)
        {
            try
            {
                var command = new CreateAffiliateStoreCommand()
                {
                    GoSellStoreId = request.GoSellStoreId,
                    Logo = request.Logo,
                    AllowPublisherRegister = request.AllowPublisherRegister,
                    AutoApproved = request.AutoApproved,
                    CookieDurationDay = request.CookieDurationDay,
                    Name = request.Name,
                    ApiKey = request.ApiKey,
                    Website = request.Website,
                    BusinessId = request.BusinessId,
                    ColorId = request.ColorId,
                    CurrencyId = request.CurrencyId
                };

                var result = await mediator.Send(command);
                Log.Logger.Information($"DONE {nameof(AddAffiliateStoreAsync)}");
                return TypedResults.Ok(new GenericResponse<long>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                if (ex.Message == "OUT_OFLIMIT_PUBLISHER_PAGE")
                {
                    return TypedResults.Ok(new GenericResponse<long>(HttpStatusCode.NotAcceptable, "OUT_OFLIMIT_PUBLISHER_PAGE"));
                }
                Log.Logger.Error(ex, $"FAIL {nameof(AddAffiliateStoreAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<long>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdateAffiliateStoreAsync(
            AffiliateStoreRequest request,
            IMediator mediator
            )
        {
            try
            {
                var command = new UpdateAffiliateStoreCommand()
                {
                    Id = request.Id,
                    Logo = request.Logo,
                    AllowPublisherRegister = request.AllowPublisherRegister,
                    AutoApproved = request.AutoApproved,
                    CookieDurationDay = request.CookieDurationDay,
                    Name = request.Name,
                    ApiKey = request.ApiKey,
                    Website = request.Website,
                    AllowGetOrderTrackingCode = request.AllowGetOrderTrackingCode,
                    AllowGetOrderTrackingUrl = request.AllowGetOrderTrackingUrl,
                    KeyWordByCode = request.KeyWordByCode,
                    KeyWordByUrl = request.KeyWordByUrl,
                    CurrencyId = request.CurrencyId
                };

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(UpdateAffiliateStoreAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateAffiliateStoreAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdateWebsiteOrIsDeletedOfExternalStoreAsync(
           UpdateWebsiteOrIsDeletedOfExternalStoreCommand request,
           IMediator mediator
           )
        {
            try
            {
                var result = await mediator.Send(request);

                Log.Logger.Information($"DONE {nameof(UpdateWebsiteOrIsDeletedOfExternalStoreAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateWebsiteOrIsDeletedOfExternalStoreAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        public static async Task<Results<Ok<GenericResponse<List<AffiliateStoreViewModel>>>, BadRequest<string>>> GetAllAffiliateStoreAsync(IMediator mediator)
        {
            try
            {
                var command = new GetAllAffiliateStoreQuery();

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateStoreAsync)}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStoreViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStoreViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<List<AffiliateStoreViewModel>>>, BadRequest<string>>> GetAllAffiliateStoreByGsIdAsync(long goSellStoreId, IMediator mediator)
        {
            try
            {
                var command = new GetAllAffiliateStoreByGsIdQuery(goSellStoreId);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateStoreByGsIdAsync)}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStoreViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreByGsIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStoreViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<AffiliateStoreCurrencyViewModel>>>, BadRequest<string>>> GetAllAffiliateStoreCurrencyAsync(IMediator mediator)
        {
            try
            {
                var command = new GetAllAffiliateStoreCurrencyQuery();

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateStoreByGsIdAsync)}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStoreCurrencyViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreByGsIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStoreCurrencyViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        [AllowAnonymous]
        public static async Task<Results<Ok<GenericResponse<AffiliateStoreByDomainViewModel>>, BadRequest<string>>> GetAffiliateStoreByDomainAsync(
            [FromQuery] string domain,
            IMediator mediator)
        {
            try
            {
                var command = new GetSpecificAffiliateStoreByDomainQuery(domain);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAffiliateStoreByDomainAsync)}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreByDomainViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateStoreByDomainAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreByDomainViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<AffiliateStoreViewModel>>, BadRequest<string>>> GetSpecificAffiliateStoreByIdAsync(
            long id,
            IMediator mediator)
        {
            try
            {
                var command = new GetSpecificAffiliateStoreByIdQuery(id);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateStoreByIdAsync)}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateStoreByIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<AffiliateStoreViewModel>>, BadRequest<string>>> GetSpecificAffiliateStoreByGoSellStoreIdAsync(
            long goSellStoreId,
            IMediator mediator)
        {
            try
            {
                var command = new GetSpecificAffiliateStoreByGoSellStoreIdQuery(goSellStoreId);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateStoreByGoSellStoreIdAsync)}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateStoreByGoSellStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<AffiliateThemeViewModel>>, BadRequest<string>>> GetAffiliateThemePublishedByStoreIdAsync(
            long storeId,
            IMediator mediator)
        {
            try
            {
                var command = new GetAffiliateThemePublishedByStoreIdQuery(storeId);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAffiliateThemePublishedByStoreIdAsync)}");
                return TypedResults.Ok(new GenericResponse<AffiliateThemeViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateThemePublishedByStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateThemeViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<AffiliateThemeViewModel>>>, BadRequest<string>>> GetAllAffiliateThemeByStoreIdAsync(
            long storeId,
            IMediator mediator)
        {
            try
            {
                var command = new GetAllAffiliateThemeByStoreIdQuery(storeId);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateThemeByStoreIdAsync)}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateThemeViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateThemeByStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateThemeViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<string>>, BadRequest<string>>> CreateApiKey(
            long storeId,
            IMediator mediator)
        {
            try
            {
                var command = new CreateApiKeyCommand
                {
                    StoreId = storeId,
                };

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(CreateApiKey)}");
                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateApiKey)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AffiliateStoreViewModel>>, BadRequest<string>>> GetSpecificAffiliateStoreAsync(
            IMediator mediator,
            IBaseApi baseApi)
        {
            try
            {
                var command = new GetSpecificAffiliateStoreByGoSellStoreIdQuery(baseApi.User.StoreId);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateStoreByGoSellStoreIdAsync)}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateStoreByGoSellStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<AffiliateTransactionViewModel>, BadRequest<string>>> AddAffiliateSubmissionAsync(
            [FromHeader(Name = "API-Key")] string apiKey,
            [FromBody] CreateAffiliateSubmissionCommand request,
            IMediator mediator)
        {
            try
            {
                var validator = new CreateAffiliateSubmissionCommandValidator();
                var validationResult = validator.Validate(request);
                Dictionary<string, string> messageCommons = SubmissionMessengerDictionary.errorMessages;
                List<string> messageErrors = new List<string>();
                if (string.IsNullOrEmpty(apiKey))
                {
                    messageErrors.Add(messageCommons[nameof(SubmissionCodeEnum.INVALID_API_KEY)]);
                }

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors;
                    foreach (var error in errors)
                    {
                        messageErrors.Add(messageCommons[error.ErrorCode]);
                    }
                    if (messageErrors.Any())
                    {
                        return TypedResults.Ok(new AffiliateTransactionViewModel
                        {
                            ResultCode = (int)HttpStatusCode.BadRequest,
                            ResultMessages = messageErrors
                        });
                    }
                }
                request.ApiKey = apiKey;
                request.TrackingIds = request.TrackingIds.Distinct().ToList();
                var (statusCode, messageKey) = await mediator.Send(request);

                if (!string.IsNullOrEmpty(messageKey))
                    messageErrors.Add(messageCommons[messageKey]);

                Log.Logger.Information($"DONE {nameof(AddAffiliateSubmissionAsync)}");
                return TypedResults.Ok(new AffiliateTransactionViewModel
                {
                    ResultCode = statusCode,
                    ResultMessages = messageErrors.Distinct().ToList(),
                });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AddAffiliateSubmissionAsync)} : {ex.Message}");
                return TypedResults.Ok(new AffiliateTransactionViewModel
                {
                    ResultCode = (int)HttpStatusCode.InternalServerError,
                    ResultMessages = new List<string>() { SubmissionMessengerDictionary.errorMessages[nameof(SubmissionCodeEnum.HTTP_CLIENT_INTERNAL_SERVER_ERROR)] },
                });
            }
        }

        public static async Task<Results<Ok<AffiliateTransactionViewModel>, BadRequest<string>>> AddAffiliateSubmissionByScriptAsync(
            [FromHeader(Name = "API-Key")] string apiKey,
            [FromBody] CreateAffiliateSubmissionByScriptCommand request,
            IMediator mediator)
        {
            try
            {
                Dictionary<string, string> messageCommons = SubmissionMessengerDictionary.errorMessages;
                List<string> messageErrors = new List<string>();
                var validator = new CreateAffiliateSubmissionByScriptCommandValidator();
                var validationResult = validator.Validate(request);

                if (string.IsNullOrEmpty(apiKey))
                {
                    messageErrors.Add(messageCommons[nameof(SubmissionCodeEnum.INVALID_API_KEY)]);
                }

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors;
                    foreach (var error in errors)
                    {
                        messageErrors.Add(messageCommons[error.ErrorCode]);
                    }
                    if (messageErrors.Any())
                    {
                        return TypedResults.Ok(new AffiliateTransactionViewModel
                        {
                            ResultCode = (int)HttpStatusCode.BadRequest,
                            ResultMessages = messageErrors
                        });
                    }
                }

                request.ApiKey = apiKey;
                var (statusCode, messageKey) = await mediator.Send(request);

                if (!string.IsNullOrEmpty(messageKey))
                    messageErrors.Add(messageCommons[messageKey]);

                Log.Logger.Information($"DONE {nameof(AddAffiliateSubmissionAsync)}");
                return TypedResults.Ok(new AffiliateTransactionViewModel
                {
                    ResultCode = statusCode,
                    ResultMessages = messageErrors.Distinct().ToList(),
                });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AddAffiliateSubmissionAsync)} : {ex.Message}");
                return TypedResults.Ok(new AffiliateTransactionViewModel
                {
                    ResultCode = (int)HttpStatusCode.InternalServerError,
                    ResultMessages = new List<string>() { SubmissionMessengerDictionary.errorMessages[nameof(SubmissionCodeEnum.HTTP_CLIENT_INTERNAL_SERVER_ERROR)] },
                });
            }
        }

        public static async Task<Results<Ok<GenericResponse<long>>, BadRequest<string>>> GetAffiliatePublisherByOrderId(
            [FromQuery] long orderId,
            [FromQuery] bool isLast,
            IMediator mediator)
        {
            try
            {
                var command = new GetAffiliatePublisherByOrderIdQuery(orderId, isLast);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAffiliateStoreByDomainAsync)}");
                return TypedResults.Ok(new GenericResponse<long>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateStoreByDomainAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<long>(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<AffiliateKeyValueViewModel>>>, BadRequest<string>>> GetAllAffiliateBusinessAsync(
            IMediator mediator)
        {
            try
            {
                var command = new GetAllAffiliateBusinessQuery();

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateBusinessAsync)}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateKeyValueViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateBusinessAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateKeyValueViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<AffiliateKeyValueViewModel>>>, BadRequest<string>>> GetAllAffiliateColorDefaultAsync(
            [FromQuery] bool isBusinessColor,
            IMediator mediator)
        {
            try
            {
                var command = new GetAllAffiliateColorDefaultQuery(isBusinessColor);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateColorDefaultAsync)}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateKeyValueViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateColorDefaultAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateKeyValueViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<List<string>>>> CreateThemeAsync(
            [FromBody] CreateThemeRequest request,
            IMediator mediator)
        {
            try
            {
                var validator = new CreateThemeRequestValidator();
                var validationResult = validator.Validate(request);
                if (validationResult.Errors.Count > 0)
                {
                    return TypedResults.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
                }
                var command = new CreateThemeCommand()
                {
                    ColorId = request.ColorId,
                    CoverImage = request.CoverImage,
                    Logo = request.Logo,
                    StoreId = request.StoreId,
                    IsPublished = request.IsPublished,
                    BusinessId = request.BusinessId,
                };
                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(CreateThemeAsync)}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, "Request succeeded"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateThemeAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }


        public static async Task<Results<Ok<BaseResponse>, BadRequest<List<string>>>> UpdateThemeAsync(
            [FromBody] UpdateThemeRequest request,
            IMediator mediator)
        {
            try
            {
                var validator = new UpdateThemeRequestValidator();
                var validationResult = validator.Validate(request);
                if (validationResult.Errors.Count > 0)
                {
                    return TypedResults.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
                }
                var command = new UpdateThemeCommand()
                {
                    Id = request.Id,
                    ColorId = request.ColorId,
                    CoverImage = request.CoverImage,
                    Logo = request.Logo,
                    StoreId = request.StoreId,
                    IsPublished = request.IsPublished,
                };
                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(UpdateThemeAsync)}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, "Request succeeded"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateThemeAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AffiliateThemeViewModel>>, BadRequest<AffiliateThemeViewModel>>> GetThemeByIdAsync(
           long themeId,
           IMediator mediator)
        {
            try
            {
                var command = new GetThemeByIdCommand()
                {
                    Id = themeId

                };
                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetThemeByIdAsync)}");
                return TypedResults.Ok(new GenericResponse<AffiliateThemeViewModel>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetThemeByIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateThemeViewModel>(HttpStatusCode.BadRequest, "Request failed", new AffiliateThemeViewModel()));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AffiliateThemeViewModel>>, BadRequest<AffiliateThemeViewModel>>> GetAffiliateThemeByBusinessIdAsync(
           [FromQuery] long businessId,
           [FromQuery] long externalStoreId,
           IMediator mediator)
        {
            try
            {
                var command = new GetAffiliateThemeByBusinessIdQuery(businessId, externalStoreId);
                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetThemeByIdAsync)}");
                return TypedResults.Ok(new GenericResponse<AffiliateThemeViewModel>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetThemeByIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateThemeViewModel>(HttpStatusCode.BadRequest, "Request failed", new AffiliateThemeViewModel()));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<DefaultThemeViewModel>>>, BadRequest<DefaultThemeViewModel>>> GetThemesOfBusinessAsync(
           [FromQuery] long externalStoreId,
           IMediator mediator)
        {
            try
            {
                var command = new GetThemesOfBusinessQuery(externalStoreId);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetThemeByIdAsync)}");
                return TypedResults.Ok(new GenericResponse<List<DefaultThemeViewModel>>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetThemeByIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<DefaultThemeViewModel>>(HttpStatusCode.BadRequest, "Request failed", new List<DefaultThemeViewModel>()));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<List<string>>>> PublishThemeAsync(
            [FromBody] PublishThemeRequest request,
            IMediator mediator)
        {
            try
            {
                var command = new PublishThemeCommand()
                {
                    Id = request.Id,

                };
                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(UpdateThemeAsync)}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, "Request succeeded"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateThemeAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<List<string>>>> DeleteThemeAsync(
            [FromBody] DeleteThemeRequest request,
            IMediator mediator)
        {
            try
            {
                var command = new DeleteThemeCommand()
                {
                    Id = request.Id,

                };
                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(UpdateThemeAsync)}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, "Request succeeded"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateThemeAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<PaginatedList<AffiliateSubmissionViewModel>>>, BadRequest<string>>> GetAllAffiliateSubmissionByGsStoreIdAsync(
            long gsStoreId,
            IMediator mediator,
            [FromQuery] int typeId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchString = null,
            [FromQuery] int? searchType = null,
            [FromQuery] string approvalStatus = null,
            [FromQuery] Boolean? affiliateStoreStatus = null,
            [FromQuery] int? affiliateStoreId = null,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            try
            {
                var command = new GetAllAffiliateSubmissionByGsStoreIdQuery(gsStoreId, typeId, pageSize, pageNumber, searchString, searchType, string.IsNullOrEmpty(approvalStatus) ? null : Int32.Parse(approvalStatus), affiliateStoreId, fromDate, toDate, affiliateStoreStatus);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateSubmissionByGsStoreIdAsync)}");
                return TypedResults.Ok(new GenericResponse<PaginatedList<AffiliateSubmissionViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateSubmissionByGsStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PaginatedList<AffiliateSubmissionViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<OrderDetailsViewModel>>, BadRequest<string>>> GetSpecificAffiliateSubmissionByIdAsync(
           [FromQuery] long submissionId,
           IMediator mediator)
        {
            try
            {
                var command = new GetSpecificAffiliateSubmissionBySubmisstionIdQuery(submissionId);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateSubmissionByIdAsync)}");
                return TypedResults.Ok(new GenericResponse<OrderDetailsViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateSubmissionByIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<OrderDetailsViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<TrackingOrderOfPublishersViewModel>>>, BadRequest<string>>> GetPublishersByAffStoreIdAsync(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] long? publisherId,
            IMediator mediator,
            [FromQuery] TrackingPrioritizeEnum? trackingPrioritize,
            [FromQuery] long? externalStoreId = 0)
        {
            try
            {
                if (externalStoreId == 0 || externalStoreId == null)
                {
                    return TypedResults.Ok(new GenericResponse<List<TrackingOrderOfPublishersViewModel>>(HttpStatusCode.BadRequest, "externalStoreId is required"));
                }
                if (startDate == null)
                {
                    return TypedResults.Ok(new GenericResponse<List<TrackingOrderOfPublishersViewModel>>(HttpStatusCode.BadRequest, "startDate is required"));
                }
                if (endDate == null)
                {
                    return TypedResults.Ok(new GenericResponse<List<TrackingOrderOfPublishersViewModel>>(HttpStatusCode.BadRequest, "endDate is required"));
                }
                if (trackingPrioritize == null)
                {
                    return TypedResults.Ok(new GenericResponse<List<TrackingOrderOfPublishersViewModel>>(HttpStatusCode.BadRequest, "trackingPrioritize is required"));
                }
                var request = new GetPublishersByAffStoreIdQuery()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    ExternalStoreId = externalStoreId.Value,
                    PublisherId = publisherId,
                    TrackingPrioritize = trackingPrioritize
                };
                var result = await mediator.Send(request);

                Log.Logger.Information($"DONE {nameof(GetPublishersByAffStoreIdAsync)}");
                return TypedResults.Ok(new GenericResponse<List<TrackingOrderOfPublishersViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetPublishersByAffStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<TrackingOrderOfPublishersViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<TrackingOrderOfPublishersViewModel>>>, BadRequest<string>>> GetPublishersByAffStoreIdForCronJobAsync(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] long? publisherId,
            IMediator mediator,
            [FromQuery] TrackingPrioritizeEnum trackingPrioritize = 0,
            [FromQuery] long? externalStoreId = 0)
        {
            try
            {
                if (externalStoreId == 0 || externalStoreId == null)
                {
                    return TypedResults.Ok(new GenericResponse<List<TrackingOrderOfPublishersViewModel>>(HttpStatusCode.BadRequest, "externalStoreId is required"));
                }

                var request = new GetPublishersByAffStoreIdQuery()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    ExternalStoreId = externalStoreId.Value,
                    PublisherId = publisherId,
                    TrackingPrioritize = trackingPrioritize,
                    IsRunCronJob = true
                };
                var result = await mediator.Send(request);

                Log.Logger.Information($"DONE {nameof(GetPublishersByAffStoreIdForCronJobAsync)}");
                return TypedResults.Ok(new GenericResponse<List<TrackingOrderOfPublishersViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetPublishersByAffStoreIdForCronJobAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<TrackingOrderOfPublishersViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<FileContentHttpResult> ExportSubmissionAsync(
           IMediator mediator,
            [FromHeader] string langkey,
            [FromBody] ExportSubmissionCommand command)
        {
            try
            {
                command.Langkey = langkey ?? SystemBaseConstants.DEFAULT_LANG;
                var result = await mediator.Send(command);
                return TypedResults.File(result.File.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", result.FileName);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ExportSubmissionAsync)} : {ex.Message}");
                throw;
            }
        }

        public static async Task<Results<Ok<GenericResponse<ResultImportDataViewModel>>, BadRequest<string>>> ImportSubmissionByFileAsync(
           IMediator mediator,
           [FromForm] IFormFile file,
           [FromQuery] bool isFileTemplate,
           [FromQuery] long affiliateStoreId,
           [FromQuery] string clientTimeZone)
        {
            try
            {
                var command = new ImportSubmissionByFileCommand(file, isFileTemplate, affiliateStoreId, clientTimeZone);
                var result = await mediator.Send(command);

                return TypedResults.Ok(new GenericResponse<ResultImportDataViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ImportSubmissionByFileAsync)} : {ex.Message}");
                throw;
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> AddAffiliateMappingAsync(
            [FromBody] CreateAffiliateMappingCommand command,
            IMediator mediator,
            IBaseApi baseApi)
        {
            try
            {
                foreach (var item in command.ListAffiliateMapping)
                {
                    if (!MappingKeyEnum.TryParse(item.MappingKey, out MappingKeyEnum mappingKey))
                    {
                        return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, string.Format("Mapping Key {0} Incorrect", item.MappingKey)));
                    }
                }
                var result = await mediator.Send(command);
                Log.Logger.Information($"DONE {nameof(AddAffiliateMappingAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AddAffiliateMappingAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdateStatusSubmissionAsync(
            [FromBody] UpdateStatusSubmissionCommand request,
            IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);

                Log.Logger.Information($"DONE {nameof(UpdateStatusSubmissionAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, result.Item2, result.Item1));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateStatusSubmissionAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<long>>, BadRequest<string>>> UpdateStatusListSubmissionAsync(
            [FromBody] UpdateStatusListSubmissionCommand request,
            IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);

                Log.Logger.Information($"DONE {nameof(UpdateStatusListSubmissionAsync)}");
                return TypedResults.Ok(new GenericResponse<long>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateStatusListSubmissionAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<long>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdatePartnerSubmissionAsync(
            [FromBody] UpdatePartnerSubmissionCommand request,
            IMediator mediator,
            IBaseApi baseApi)
        {
            try
            {

                var result = await mediator.Send(request);

                Log.Logger.Information($"DONE {nameof(UpdatePartnerSubmissionAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, result.Item2, result.Item1));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdatePartnerSubmissionAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> DeleteAffiliateMappingAsync(
            [FromQuery] long affiliateStoreId,
            IMediator mediator,
            IBaseApi baseApi)
        {
            try
            {
                var command = new DeleteAffiliateMappingCommand(affiliateStoreId);
                var result = await mediator.Send(command);
                Log.Logger.Information($"DONE {nameof(DeleteAffiliateMappingAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(DeleteAffiliateMappingAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<AffiliateMappingViewModel>>>, BadRequest<string>>> GetAffiliateMappingByStoreId(
            [FromQuery] long affiliateStoreId,
            IMediator mediator,
            IBaseApi baseApi)
        {
            try
            {

                var command = new GetAffiliateMappingByIdQuery(affiliateStoreId);
                var result = await mediator.Send(command);
                Log.Logger.Information($"DONE {nameof(GetAffiliateMappingByStoreId)}");

                return TypedResults.Ok(new GenericResponse<List<AffiliateMappingViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateMappingByStoreId)} : {ex.Message}");
                throw;
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> AddOrderTrackingAsync(
            [FromQuery] string orderId,
            [FromQuery] string trackingIds,
            [FromQuery] string website,
            IMediator mediator)
        {
            try
            {
                CreateOrderTrackingCommand command = new CreateOrderTrackingCommand(orderId, trackingIds, website);
                var result = await mediator.Send(command);
                if (!result)
                {
                    return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "orderId and website already exist"));
                }
                Log.Logger.Information($"DONE {nameof(AddOrderTrackingAsync)}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, "Request succeeded"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AddOrderTrackingAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }


        public static async Task<Results<Ok<GenericResponse<List<AffiliateOrderTrackingViewModel>>>, BadRequest<string>>> GetOrderTrackingAsync(
            [FromQuery] long latestId,
            IMediator mediator)
        {
            try
            {
                GetOrderTrackingCommand command = new GetOrderTrackingCommand(latestId);
                var result = await mediator.Send(command);
                Log.Logger.Information($"DONE {nameof(GetOrderTrackingAsync)}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateOrderTrackingViewModel>>(HttpStatusCode.OK, "Request successfully", result)); ;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetOrderTrackingAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateOrderTrackingViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdatePlatformByTrackingId(
           UpdatePlatformByTrackingIdCommand request,
           IMediator mediator
           )
        {
            try
            {
                var result = await mediator.Send(request);

                Log.Logger.Information($"DONE {nameof(UpdatePlatformByTrackingId)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdatePlatformByTrackingId)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AffiliateStoreValidateViewModel>>, BadRequest<string>>> GetAffiliateStoreByIdAsync(
            long id,
            IMediator mediator)
        {
            try
            {
                var command = new GetAffiliateStoreByIdQuery(id);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAffiliateStoreByIdAsync)}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreValidateViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateStoreByIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreValidateViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<AffiliateStore>>>, BadRequest<string>>> GetAllAffiliateStoreByGoSellIdAsync(
            [FromBody] GetAllAffiliateStoreByGoSellIdQuery command,
            IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateStoreByGoSellIdAsync)}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStore>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreByGoSellIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStore>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<GenericResponse<bool>>>> UpdateAutoApproveStoresAsync(
            UpdateAutoApproveStoreCommand command,
            IMediator mediator
            )
        {
            try
            {
                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(UpdateAutoApproveStoresAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateAutoApproveStoresAsync)} : {ex.Message}");
                return TypedResults.BadRequest(new GenericResponse<bool>(HttpStatusCode.BadRequest, ex.Message, false));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AffiliateUrlReportViewModel>>, BadRequest<string>>> GetAffUrlReport(
            [FromBody] AffiliateUrlReportRequest request,
            [FromRoute] long affiliateStoreId,
            IMediator mediator)
        {
            try
            {
                if (request != null)
                {
                    var query = new GetAffiliateUrlReportQuery(affiliateStoreId, request);

                    var result = await mediator.Send(query);

                    Log.Logger.Information($"DONE {nameof(GetAffUrlReport)}");
                    return TypedResults.Ok(new GenericResponse<AffiliateUrlReportViewModel>(HttpStatusCode.OK, "Request successfully", result));
                }
                else
                {
                    Log.Logger.Warning("Invalid request - Request is null.");
                    throw new ArgumentException("Request Data is null.");
                }

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffUrlReport)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateUrlReportViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<FileContentHttpResult> ExportAffUrlReportAsync(
            [FromRoute] string type,
            [FromRoute] long affiliateStoreId,
            ILogger<GetAffiliateUrlReportQuery> _logger,
            IBaseApi baseApi,
            IMediator mediator,
            [FromBody] ExportCommonRequest exportRequest)
        {
            if (string.IsNullOrEmpty(type) || !Enum.TryParse(type, out ExportCommonServiceType exportServiceType))
            {
                Log.Logger.Warning("Invalid request - type is missing - {@IntegrationEvent}", type);
                throw new ArgumentException("Type is missing or invalid.");
            }

            if (exportRequest == null)
            {
                Log.Logger.Warning("Invalid request - exportRequest is null.");
                throw new ArgumentException("Export request is null.");
            }

            try
            {
                var conditions = JsonConvert.DeserializeObject<AffiliateUrlReportRequest>(exportRequest.Conditions);
                if (conditions != null)
                {
                    var exportData = await mediator.Send(new GetAffiliateUrlReportQuery(affiliateStoreId, conditions));

                    if (exportData != null && exportData.Data.Count > 0)
                    {
                        var exportAffUrlReportQuery = new ExportAffUrlReportQuery(exportData.Data, conditions.currencyCode);

                        var exportQuery = new ExportCommonQuery<ExportAffUrlReportQuery>(exportRequest, exportServiceType, affiliateStoreId, exportAffUrlReportQuery);

                        ExportCommonQueryResponse result = await mediator.Send(exportQuery);

                        if (result != null && result.File != null && result.File.Length > 0)
                        {
                            return TypedResults.File(result.File, result.TemplateType, result.TemplateName);
                        }
                    }

                }
                else
                {
                    throw new ArgumentException("Invalid JSON format in export conditions.");
                }
                Log.Logger.Warning("No valid export data found.");
                throw new InvalidOperationException("No valid export data found.");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Error exporting data.");
                throw;
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<AffiliateStoreCurrencyViewModel>>>, BadRequest<string>>> GetStoreCurrencyAsync(
            IMediator mediator)
        {
            try
            {
                var command = new GetAllAffiliateStoreCurrencyQuery();

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAffiliateStoreByIdAsync)}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStoreCurrencyViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateStoreByIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<AffiliateStoreCurrencyViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AffiliateStoreCurrencyViewModel>>, BadRequest<string>>> GetCurrencyUnit(long affiliateStoreId, IMediator mediator)
        {
            try
            {
                var command = new GetAffiliateCurrencyUnitByIdQuery(affiliateStoreId);

                var result = await mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetCurrencyUnit)}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreCurrencyViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCurrencyUnit)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreCurrencyViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AffiliateStoreSourceVNViewModel>>, BadRequest<string>>> GetAffiliateStoreByAPIdAsync(
            [FromHeader] string apiKey,
            IMediator mediator)
        {
            try
            {
                if (string.IsNullOrEmpty(apiKey))
                {
                    return TypedResults.Ok(new GenericResponse<AffiliateStoreSourceVNViewModel>(HttpStatusCode.BadRequest, "Request apiKey invalid"));
                }
                GetAffiliateStoreByAPIQuery request = new GetAffiliateStoreByAPIQuery()
                {
                    ApiKey = apiKey,
                };
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetAffiliateStoreByAPIdAsync)}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreSourceVNViewModel>(HttpStatusCode.OK, "Request successfully", result)); ;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateStoreByAPIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateStoreSourceVNViewModel>(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}
