using Microsoft.AspNetCore.Http.HttpResults;
using RP.Library.Helpers;
using Serilog;
using System.Net;

namespace RP.API.Service
{
    public class AuthenticateService
    {
        public static async Task<Results<Ok<GenericResponse<AffiliateThemeViewModel>>, BadRequest<AffiliateThemeViewModel>>> UpdateThemeAsync(
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
    }
}
