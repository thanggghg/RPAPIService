using Microsoft.AspNetCore.Http.HttpResults;
using RP.GobalCore.Application.Queries.Authenticate;
using RP.GobalCore.ViewModels.Queries;
using RP.Library.Helpers;
using Serilog;
using System.Net;

namespace RP.API.Service
{
    public class AuthenticateService
    {
        public static async Task<Results<Ok<GenericResponse<AuthenticateLoginResponse>>, BadRequest<AuthenticateLoginResponse>>> AccountLoginAsync(
        [FromBody] AuthenticateLoginQueries request,
        IMediator mediator)
            {
                try
                {
                    var result = await mediator.Send(request);

                    Log.Logger.Information($"DONE {nameof(AuthenticateService)}");
                    return TypedResults.Ok(new GenericResponse<AuthenticateLoginResponse>(HttpStatusCode.OK, "Request succeeded",null));
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex, $"FAIL {nameof(AuthenticateService)} : {ex.Message}");
                    return TypedResults.Ok(new GenericResponse<AuthenticateLoginResponse>(HttpStatusCode.BadRequest, "Request failed", null));
                }
            }
    }
}
