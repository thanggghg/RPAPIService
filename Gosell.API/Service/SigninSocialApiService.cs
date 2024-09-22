using GoSell.Library.Enums.SocialAuthen;
using GoSell.Library.Exceptions;
using GoSell.SocialAuthentication.Model.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;
using static GoSell.SocialAuthentication.Application.Queries.SignInQueries;

namespace GoSell.API.Service
{
    public class SigninSocialApiService
    {
        public static async Task<Results<Ok<SignInQueryResult>, BadRequest<object>>> SignInSocialAsync(
            [FromRoute] string type,
            [FromRoute] string providerId,
            [FromQuery] string domain,
            [FromBody] SocialSignInRequest request,
            [FromHeader] string Platform,
            IMediator mediator
            )
        {
            Log.Logger.Information
            (
                "Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "",
                nameof(request.Authorization),
                request.Authorization,
                request
            );

            if (request is null || request.Authorization is null)
            {
                Log.Logger.Warning("Invalid IntegrationEvent - Authorization is missing - {@IntegrationEvent}", request);
                return TypedResults.BadRequest<object>("Authorization is missing.");
            }

            var variables = new[] { type, domain };
            if (variables.Any(String.IsNullOrEmpty))
            {
                Log.Logger.Warning("Null Data");
                return TypedResults.BadRequest<object>("Null Data.");
            }

            if (!Enum.TryParse(providerId, true, out AccountType parsedProviderId))
            {
                Log.Logger.Warning("Invalid Provider Id -  {@providerId}", providerId);
                return TypedResults.BadRequest<object>($"Invalid Provider Id - {providerId}");
            }

            if (string.IsNullOrEmpty(Platform))
            {
                Platform = DomainType.GOSELL.ToString();
            }

            try
            {
                SignInQuery signInSocialQuery = new(type, parsedProviderId, domain, request.LangKey, request, Platform);
                SignInQueryResult signInQueryResult = await mediator.Send(signInSocialQuery);

                if (signInQueryResult is not null)
                    Log.Logger.Information("Result signInSocialQuery succeeded");
                else
                    Log.Logger.Warning("Result signInSocialQuery failed");

                return TypedResults.Ok(signInQueryResult);
            }
            catch (StoreDomainException ex)
            {
                var responseException = new
                {
                    DomainSuggestion = ex.DomainSuggestion,
                    Valid = ex.Valid,
                    LocalizedMessage = ex.LocalizedMessage,
                    Message = ex.Message
                };
                Log.Logger.Warning($"SignInSocialAsync - StoreDomainExceptionfailed: {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "SignInSocialAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }

    }
}
