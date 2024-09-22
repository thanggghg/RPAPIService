using System.IdentityModel.Tokens.Jwt;
using RP.Library.Constants;
using RP.Library.Enums;
using RP.Library.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RP.Library.Extensions.Permission
{
    public class StaffPermissionRequirementHandle : AuthorizationHandler<StaffPermissionRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StaffPermissionRequirementHandle(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, StaffPermissionRequirement requirement)
        {
            try
            {
                var token = _httpContextAccessor.HttpContext.Request.Headers["Staffpermissions-Token"].FirstOrDefault()?.Split(" ").Last();

                if (!string.IsNullOrWhiteSpace(token))
                {
                    if (VerifyStaffPermissionsToken(token, _httpContextAccessor.HttpContext, requirement))
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
                context.Succeed(requirement);


            }
            catch (Exception ex)
            {
                _httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
                await _httpContextAccessor.HttpContext.Response.WriteAsJsonAsync(new { StatusCode = StatusCodes.Status401Unauthorized, Message = ex is JWTException ? ex.Message : "Invalid token." });
                await _httpContextAccessor.HttpContext.Response.CompleteAsync();
                context.Fail();
            }
        }

        private bool VerifyStaffPermissionsToken(string token, HttpContext context, StaffPermissionRequirement staffPermissionRequirement)
        {
            var jwtData = string.IsNullOrEmpty(token) ? new List<string>() : token.Split(".").ToList();
            if (jwtData.Count != 3)
            {
                string msg = $"JWT strings must contain exactly 2 period characters. Found: {jwtData.Count}";
                throw new JWTException(msg);
            }
            else
            {
                string base64UrlEncodedHeader = jwtData[0];
                string base64UrlEncodedPayload = jwtData[1];

                if (System.String.IsNullOrEmpty(base64UrlEncodedHeader) || System.String.IsNullOrEmpty(base64UrlEncodedPayload))
                {
                    throw new JWTException($"JWT string '{token}' is missing a header, body/payload.");
                }
                else
                {
                    var tokenData = DecodeJwtPayload(token);
                    var payloadJson = tokenData.Item2 as string;
                    var staffPermissionsModel = JsonConvert.DeserializeObject<StaffPermissionsModel>(payloadJson);

                    StaffPermissionEnum? permission = null;
                    if (context.Request.Path.Value.Contains("publisher/update-status"))
                    {
                        permission = staffPermissionRequirement.StaffPermissions.FirstOrDefault(s => context.Request.RouteValues.Any(a => a.Key == "type" && (StaffPermissionEnum)Enum.Parse(typeof(StaffPermissionEnum), a.Value.ToString()) == s));
                    }
                    else
                        permission = staffPermissionRequirement.StaffPermissions.FirstOrDefault();

                    if (!permission.HasValue) { throw new Exception("GoSell staff permission not grant"); }

                    var staffPermission = StaffPermissionConstanst.StaffPermissionList.FirstOrDefault(s => s.ThirdLevel == permission);
                    if (staffPermission == null) { throw new Exception("GoSell staff permission not grant"); }
                    var permissionData = staffPermissionsModel.StaffPermissions.FirstOrDefault(s => s.Key == staffPermission.CombinedKey);
                    if (permissionData.Key == null || permissionData.Value == 0) { throw new Exception("GoSell staff permission not grant"); }


                    bool isMatchPermission = validatePermissions(staffPermission.BitIndex, permissionData.Value, staffPermission.Code);
                    if (!isMatchPermission) { throw new Exception("GoSell staff permission not grant"); }

                }
            }
            return true;

        }
        private static (string, string) DecodeJwtPayload(string jwtToken)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // Read the JWT token
            if (handler.CanReadToken(jwtToken))
            {
                JwtSecurityToken jwtSecurityToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

                // Access the payload
                string header = jwtSecurityToken?.Header.SerializeToJson();
                string payload = jwtSecurityToken?.Payload.SerializeToJson();
                return (header, payload);
            }

            return (null, null);
        }

        private bool validatePermissions(int index, int binary1, int binary2)
        {
            return ((binary1 >> index) & 1) == ((binary2 >> index) & 1);
        }
    }
}
