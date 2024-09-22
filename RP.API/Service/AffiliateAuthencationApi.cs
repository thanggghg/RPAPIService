using System.Net;
using RP.Affiliate.Authentication.Application.Commands;
using RP.Affiliate.Authentication.Application.Contracts;
using RP.Affiliate.Authentication.Application.Handler;
using RP.Affiliate.Authentication.Application.Queries;
using RP.Affiliate.Authentication.Models;
using RP.Affiliate.PublisherManagement.Commands;
using RP.Affiliate.PublisherManagement.Queries;
using RP.Common.Enums;
using RP.Common.Models;
using RP.Common.Utils;
using RP.Library.Enums.SocialAuthen;
using RP.Library.Helpers;
using RP.Library.Helpers.Api;
using RP.SocialAuthentication.Services.Implementation;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace RP.API.Service
{
    public static class AffiliateAuthenticationApi
    {
        private static readonly string redirectScript = $"<script>window.location.href='@redirectUrl';</script>";

        public static async Task<Results<Ok<GenericResponse<AuthResultDto>>, BadRequest<BaseResponse>>> AffiliateSigninAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            [FromBody] SigninCommand command,
            ILogger<SigninCommand> _logger)
        {
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(AffiliateSigninAsync)}");
            return TypedResults.Ok(result);

        }

        public static async Task<Results<Ok<GenericResponse<AuthResultDto>>, BadRequest<BaseResponse>>> AffiliateSignupAsync(
            IMediator mediator,
            ILogger<SignupCommand> _logger,
            [FromHeader] string langKey,
            [FromBody] SignupCommand command)
        {
            var result = await mediator.Send(command);

            try
            {
                Log.Logger.Information($"CHECK AUTO APPROVED");

                if (result.Code == HttpStatusCode.OK)
                {
                    /* Affiliate auto approved */
                    await AutoApproveProcessAsync(mediator, result.Data.Id, result.Data.Status, command.StoreId, command.GoSellStoreId,
                        result.Data.AccessToken);
                }

                Log.Logger.Information($"DONE CHECK AUTO APPROVED");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"CHECK AUTO APPROVED faild: {ex.Message}");
            }

            Log.Logger.Information($"DONE {nameof(AffiliateSignupAsync)}");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<GenericResponse<SendSMSOTPResult>>, BadRequest<BaseResponse>>> AffiliateSendSMSOTPAsync(
            IMediator mediator,
            ILogger<SendSMSOTPAffiliateCommand> _logger,
            [FromHeader] string langKey,
            long storeId,
            [FromBody] SendSMSOTPAffiliateCommand command)
        {

            command.StoreId = storeId;
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(AffiliateSendSMSOTPAsync)}");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<BaseResponse>>> VerifyOtpAsync(
            IMediator mediator,
            ILogger<VerifyOtpCommandHandler> _logger,
            [FromHeader] string langKey,
            [FromBody] VerifyOtpCommand command)
        {
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(VerifyOtpAsync)}");
            return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, "Request succeeded"));
        }

        public static async Task<Results<Ok<GenericResponse<AuthResultDto>>, BadRequest<BaseResponse>>> AffiliateForgotPassword(
            IMediator mediator,
            ILogger<ResetPasswordCommand> _logger,
            [FromHeader] string langKey,
            [FromBody] ResetPasswordCommand command)
        {
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(AffiliateForgotPassword)}");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<GenericResponse<UseProfileDto>>, BadRequest<BaseResponse>>> GetUserProfileByIdAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            ILogger<GetProfileQuery> _logger,
            IBaseApi baseApi)
        {
            var command = new GetProfileQuery
            {
                Id = baseApi.User.userAffiliateStoreId
            };
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(GetUserProfileByIdAsync)}");
            return TypedResults.Ok(new GenericResponse<UseProfileDto>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<BaseResponse>>> UpdateUserProfileAsync(
            IMediator mediator,
            ILogger<UserProfileCommand> _logger,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] UserProfileCommand command)
        {
            command.Id = baseApi.User.userAffiliateStoreId;
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(UpdateUserProfileAsync)}");
            return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, "Request succeeded"));
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<BaseResponse>>> ChangePasswordAsync(
            IMediator mediator,
            ILogger<ChangePasswordCommand> _logger,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] ChangePasswordCommand command)
        {
            command.Id = baseApi.User.userAffiliateStoreId;
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(ChangePasswordAsync)}");
            return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, "Request succeeded"));
        }

        public static async Task<Results<Ok<GenericResponse<UseProfileDto>>, BadRequest<BaseResponse>>> UploadAvatarAsync(
            IMediator mediator,
            ILogger<UploadAvatarCommand> _logger,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] UploadAvatarCommand command)
        {
            command.Id = baseApi.User.userAffiliateStoreId;
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(ChangePasswordAsync)}");
            return TypedResults.Ok(new GenericResponse<UseProfileDto>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<AuthResultDto>>, BadRequest<BaseResponse>>> RefreshTokenAsync(
           IMediator mediator,
           ILogger<GetAccessTokenQuery> _logger,
           [FromBody] GetAccessTokenQuery command)
        {
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(RefreshTokenAsync)}");
            return TypedResults.Ok(new GenericResponse<AuthResultDto>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<AuthResultDto>>, BadRequest<BaseResponse>>> SocialAuthenAsync(
            [FromRoute] string type,
            [FromRoute] string providerId,
            [FromQuery] string domain,
            [FromBody] SocialAuthRequest request,
            [FromHeader] string Platform,
            IMediator mediator,
            ILogger<SocialSigninServices> _logger)
        {
            var variables = new[] { type, domain };
            if (variables.Any(String.IsNullOrEmpty))
            {
                Log.Logger.Warning("Null Data");
                return TypedResults.BadRequest(new BaseResponse(HttpStatusCode.OK, "Null Data."));
            }

            if (!Enum.TryParse(providerId, true, out AccountType parsedProviderId))
            {
                Log.Logger.Warning("Invalid Provider Id -  {@providerId}", providerId);
                return TypedResults.BadRequest(new BaseResponse(HttpStatusCode.OK, $"Invalid Provider Id - {providerId}"));
            }

            if (string.IsNullOrEmpty(Platform))
            {
                Platform = DomainType.GOSELL.ToString();
            }

            try
            {
                SocialSigninCommand command = new(type, parsedProviderId, domain, request.LangKey, request, Platform);
                var result = await mediator.Send(command);

                if (result is not null)
                    Log.Logger.Information($"DONE {nameof(SocialAuthenAsync)}");
                else
                    Log.Logger.Warning($"FAIL {nameof(SocialAuthenAsync)}");

                return TypedResults.Ok(new GenericResponse<AuthResultDto>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new BaseResponse(HttpStatusCode.OK, ex.Message));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AuthResultDto>>, BadRequest<BaseResponse>>> SocialVerifyOtpSignupAsync(
            [FromBody] SocialSignupCommand command,
            [FromHeader] string Platform,
            IMediator mediator,
            ILogger<SocialSigninServices> _logger)
        {
            if (string.IsNullOrEmpty(Platform))
            {
                Platform = DomainType.GOSELL.ToString();
            }

            try
            {
                var result = await mediator.Send(command);
                if (result is not null)
                {
                    /* Affiliate auto approved */
                    if (result.IsSocialVerifyOtpSuccess) await AutoApproveProcessAsync(mediator, result.Id, result.Status, command.StoreId, command.GoSellStoreId, result.AccessToken);

                    Log.Logger.Information($"DONE {nameof(SocialAuthenAsync)}");
                }
                else
                    Log.Logger.Warning($"FAIL {nameof(SocialAuthenAsync)}");

                return TypedResults.Ok(new GenericResponse<AuthResultDto>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new BaseResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        public static async Task<Results<Ok<GenericResponse<string>>, BadRequest<BaseResponse>>> GetSocialRedirectUrlAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            [FromRoute] string provider,
            [FromQuery] string domain,
            ILogger<GetSocialRedirectUrlQuery> _logger,
            IBaseApi baseApi)
        {
            var query = new GetSocialRedirectUrlQuery
            {
                Provider = provider,
                Domain = domain
            };
            var redirectUrl = await mediator.Send(query);
            Log.Logger.Information($"DONE {nameof(GetSocialRedirectUrlAsync)}");
            return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.OK, "Request succeeded", redirectUrl));
        }

        public static async Task<Results<ContentHttpResult, BadRequest<BaseResponse>>> GoogleAuthenCallbackAsync(
            IMediator mediator,
            [AsParameters] GoogleAuthenCallbackQuery query,
            ILogger<SocialAuthenCallbackQuery> _logger,
            IBaseApi baseApi)
        {
            var redirectUrl = await mediator.Send(query);
            Log.Logger.Information($"DONE {nameof(GoogleAuthenCallbackAsync)}");
            return TypedResults.Content(redirectScript.Replace("@redirectUrl", redirectUrl), "text/html");
        }

        public static async Task<Results<ContentHttpResult, BadRequest<BaseResponse>>> AppleAuthenCallbackAsync(
           IMediator mediator,
           [AsParameters] AppleAuthenCallbackQuery query,
           ILogger<SocialAuthenCallbackQuery> _logger,
           IBaseApi baseApi)
        {
            var redirectUrl = await mediator.Send(query);
            Log.Logger.Information($"DONE {nameof(AppleAuthenCallbackAsync)}");
            return TypedResults.Content(redirectScript.Replace("@redirectUrl", redirectUrl), "text/html");
        }

        public static async Task<Results<ContentHttpResult, BadRequest<BaseResponse>>> FacebookAuthenCallbackAsync(
            IMediator mediator,
            [AsParameters] FacebookAuthenCallbackQuery query,
            ILogger<SocialAuthenCallbackQuery> _logger,
            IBaseApi baseApi)
        {
            var redirectUrl = await mediator.Send(query);
            Log.Logger.Information($"DONE {nameof(FacebookAuthenCallbackAsync)}");
            return TypedResults.Content(redirectScript.Replace("@redirectUrl", redirectUrl), "text/html");
        }

        private static async Task AutoApproveProcessAsync(
            IMediator mediator,
            long affiliateUserstoreId,
            UserStoreStatusEnum userStoreStatus,
            long affiliateStoreId,
            long gosellStoreId,
            string accessToken
        )
        {
            Log.Logger.Information($"CHECK AUTO APPROVED");

            if (userStoreStatus != UserStoreStatusEnum.ACTIVATED)
            {
                var infoStore = await mediator.Send(new GetStoreByIdQuery(affiliateStoreId));
                if (infoStore != null && infoStore.AutoApproved)
                {
                    await mediator.Send(new UpdatePublisherStoreStatusCommand
                    {
                        Id = affiliateUserstoreId,
                        StoreId = gosellStoreId,
                        Status = UserStoreStatusEnum.ACTIVATED.GetDescription(),
                        JavaAccessToken = accessToken
                    });
                }
            }

            Log.Logger.Information($"DONE CHECK AUTO APPROVED");
        }

        /// <summary>
        /// Get list user by list info user name
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="command"></param>
        /// <param name="_logger"></param>
        /// <returns></returns>
        public static async Task<Results<Ok<GenericResponse<UserInfoDto>>, BadRequest<BaseResponse>>> GetUserByListUserNamesAsync(
            IMediator mediator,
            [FromBody] GetUserByListUserNamesCommand command,
            ILogger<GetUserByListUserNamesCommand> _logger)
        {
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(GetUserByListUserNamesAsync)}");
            return TypedResults.Ok(result);
        }
    }
}
