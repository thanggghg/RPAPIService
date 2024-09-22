using System.Text.Json;
using GoSell.Library.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Interfaces;

namespace GoSell.Library.Extensions.JWT
{
    public class JWTTokenRequirementHandle : AuthorizationHandler<JWTTokenRequirement>
    {
        private readonly JwtOptions _jwtOptions;
        public JWTTokenRequirementHandle(IHttpContextAccessor httpContextAccessor, JwtOptions jwtOptions)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtOptions = jwtOptions;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, JWTTokenRequirement requirement)
        {
            try
            {
                var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var jwtVerifier = new JwtVerifier(_jwtOptions);
                var rolesRequirement = new List<JWTTokenRequirement>
                {
                    new(requirement.Role)
                };
                if (jwtVerifier.VerifyToken(token, _httpContextAccessor.HttpContext, rolesRequirement))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    _httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
                    await _httpContextAccessor.HttpContext.Response.WriteAsJsonAsync(new { StatusCode = StatusCodes.Status401Unauthorized, Message = "Unauthorized!" });
                    await _httpContextAccessor.HttpContext.Response.CompleteAsync();
                    context.Fail();
                }

            }
            catch (Exception ex)
            {
                _httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
                await _httpContextAccessor.HttpContext.Response.WriteAsJsonAsync(new { StatusCode = StatusCodes.Status401Unauthorized, Message = "Invalid token. " + ex.Message });
                await _httpContextAccessor.HttpContext.Response.CompleteAsync();
                context.Fail();
            }
        }
        private readonly IHttpContextAccessor _httpContextAccessor;
    }
}
