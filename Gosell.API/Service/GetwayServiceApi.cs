using System.Net;
using GoSell.Library.Helpers;
using GoSell.SocialAuthentication.Application.Commands;
using GoSell.SocialAuthentication.Application.Contracts;
using GoSell.SocialAuthentication.Application.Queries.User;
using GoSell.SocialAuthentication.Models.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public class GetwayServiceApi
    {
        public static async Task<Results<Ok<GenericResponse<UserContract>>, BadRequest<object>>> CreateUserByPhoneNumberAsync(
           [FromBody] CreateUserByPhoneNumberCommand request,
           IMediator mediator
           )
        {
            Log.Logger.Information
            (
                "Sending CreateUserByPhoneNumberAsync: {Domain} - {CountryCode} - {PhoneNumber}: {LocationCode}",
                "",
                request.Domain,
                request.CountryCode,
                request.PhoneNumber,
                request.LocationCode
            );

            try
            {
                var result = await mediator.Send(request);

                return TypedResults.Ok(new GenericResponse<UserContract>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "CreateUserByPhoneNumberAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<OauthClientDetailContract>>, BadRequest<object>>> GetOauthClientDetailByClientIdAsync(
            [FromRoute] string clientId,
            IMediator mediator
            )
        {
            Log.Logger.Information($"Sending GetOauthClientDetailByClientIdAsync: {clientId}");

            try
            {
                var result = await mediator.Send(new GetOauthClientDetailByClientIdQuery
                {
                    ClientId = clientId
                });

                return TypedResults.Ok(new GenericResponse<OauthClientDetailContract>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "GetOauthClientDetailByClientIdAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<UserContract>>, BadRequest<object>>> GetUserByIdAsync(
            [FromRoute] long id,
            IMediator mediator
            )
        {
            Log.Logger.Information($"Sending GetUserByIdAsync: {id}");

            try
            {
                var result = await mediator.Send(new GetUserByIdQuery
                {
                    Id = id
                });

                return TypedResults.Ok(new GenericResponse<UserContract>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "GetUserByIdAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<UserContract>>, BadRequest<object>>> GetUserByLoginAsync(
            [FromRoute] string login,
            IMediator mediator
            )
        {
            Log.Logger.Information($"Sending GetUserByLoginAsync: {login}");

            try
            {
                var result = await mediator.Send(new GetUserByLoginQuery
                {
                    IdentityId = login
                });

                return TypedResults.Ok(new GenericResponse<UserContract>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "GetUserByLoginAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<UserContract>>, BadRequest<object>>> GetUserByPhoneNumberAsync(
            [FromBody] GetUserByPhoneNumberQuery query,
            IMediator mediator
        )
        {
            Log.Logger.Information($"Sending GetUserByPhoneNumberAsync: {query.CountryCode}:{query.PhoneNumber}");
            if (string.IsNullOrEmpty(query.CountryCode) || string.IsNullOrEmpty(query.PhoneNumber))
            {
                throw new Exception("CountryCode - PhoneNumber is required.");
            }

            try
            {
                var result = await mediator.Send(query);

                return TypedResults.Ok(new GenericResponse<UserContract>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "GetUserByPhoneNumberAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<UserContract>>>, BadRequest<object>>> GetUsersByLoginsAsync(
            [FromBody] GetUsersByLoginsQuery command,
            IMediator mediator
        )
        {
            Log.Logger.Information($"Sending GetUsersByLoginsAsync: {command}");

            try
            {
                var result = await mediator.Send(new GetUsersByLoginsQuery
                {
                    Logins = command.Logins
                });

                return TypedResults.Ok(new GenericResponse<List<UserContract>>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "GetUsersByLoginsAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<UserResponse>>, BadRequest<object>>> GetUsersAsync(
            [FromBody] GetUsersQuery request,
            IMediator mediator
            )
        {
            Log.Logger.Information($"Sending GetUsersAsync: {request}");

            try
            {
                var result = await mediator.Send(new GetUsersQuery
                {
                    FromCreatedDate = request.FromCreatedDate,
                    ToCreatedDate = request.ToCreatedDate,
                    Keyword = request.Keyword,
                    PageOffset = request.PageOffset,
                    PageSize = request.PageSize,
                    Status = request.Status
                });

                return TypedResults.Ok(new GenericResponse<UserResponse>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "GetUsersAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }
    }
}
