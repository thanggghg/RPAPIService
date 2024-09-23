using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using RP.Common.Models;
using RP.Library.Exceptions;
using RP.Library.Extensions.JWT;
using RP.Library.Helpers;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static RP.API.Service.JwtTokenService;

namespace RP.API.Service
{

        public interface IJwtTokenService
        {
            string CreateToken(UserDto userDto);
        }

        public class JwtTokenService : IJwtTokenService
        {
            private readonly JwtOptions _jwtOptions;
            private readonly IDistributedCache _cache;

            public JwtTokenService(JwtOptions jwtOptions,
                IDistributedCache cache)
            {
                _jwtOptions = jwtOptions;
                _cache = cache;
            }

            //public string GenerateJwtRefreshToken(UserDto userInf, string clientId) //for qc testing
            //{
            //    try
            //    {
            //        var secrect = GetSecret(clientId).Result;
            //        var iat = DateTime.UtcNow;
            //        //var tokenExpiration = DateTime.UtcNow.Add(TimeSpan.FromSeconds(_jwtOptions.RefreshTokenExpirationSeconds));
            //        var tokenExpiration = DateTime.UtcNow.Add(TimeSpan.FromSeconds(3600)); // for qc testing

            //        string combinedString = $"{clientId}:{secrect}";
            //        var clientSign = JwtTokenUtil.ComputeSha256Hash(combinedString);

            //        var jsonObject = new Dictionary<string, object>
            //{
            //    { "sub", userInf.Id },
            //    { "userAffiliateStoreId", userInf.Id },
            //    { "iat", iat.ToUnixTimestamp() },
            //    { "clientId", clientId },
            //    { "clientSign", clientSign},
            //    { "exp", tokenExpiration.ToUnixTimestamp() }
            //};

            //        var base64UrlEncodedHeader = JwtTokenUtil.CreateBase64UrlEncoderJwtHeader(_jwtOptions.SigningKey);
            //        var base64UrlEncodedPayload = JwtTokenUtil.CreateBase64UrlEncoderJwtPayLoad(jsonObject);
            //        var jwtSign = JwtTokenUtil.SignJwt(base64UrlEncodedHeader + "." + base64UrlEncodedPayload, _jwtOptions.SigningKey);

            //        if (string.IsNullOrEmpty(jwtSign))
            //        {
            //            throw new JWTException($"Cannot generate refresh token");
            //        }

            //        return jwtSign;
            //    }
            //    catch (Exception ex)
            //    {
            //        Log.Logger.Error(ex, $"FAIL {nameof(SigninCommand)} : {ex.Message}");
            //        throw new Exception($"JWT options hello: {JsonConvert.SerializeObject(_jwtOptions)}");
            //    }
            //}

            //private async Task<string> GetSecret(string clientId)
            //{
            //    var secret = await _cache.GetAsync(clientId);
            //    if (secret == null)
            //    {
            //        var oauth = await _gatewayService.GetOauthClientDetailByClientIdAsync(clientId);
            //        if (oauth != null && !string.IsNullOrWhiteSpace(oauth.clientSecret))
            //        {
            //            secret = Convert.FromBase64String(oauth.clientSecret);
            //            await _cache.SetAsync(clientId, secret);
            //        }
            //    }
            //    return secret != null ? Convert.ToBase64String(secret) : throw new Exception($"Cannot get client secret");
            //}

        public string CreateToken(UserDto userDto)
        {
            try
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _jwtOptions.Issuer),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                    new Claim("UserName", userDto.UserName),
                    new Claim("TokenSession", userDto.Token),
                    new Claim("Email", userDto.Email),
                    new Claim("SupervisorName", userDto.SupervisorName)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SigningKey));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(12), 
                    signingCredentials: signIn);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Error occurred while creating JWT token");
                throw new Exception("Token creation failed.");
            }
        }


        //public long? ValidateRefreshToken(string token)
        //    {
        //        var jwtData = string.IsNullOrEmpty(token) ? new List<string>() : token.Split(".").ToList();
        //        if (jwtData.Count != 3)
        //        {
        //            string msg = $"JWT strings must contain exactly 2 period characters. Found: {jwtData.Count}";
        //            throw new Exception(msg);
        //        }

        //        string base64UrlEncodedHeader = jwtData[0];
        //        string base64UrlEncodedPayload = jwtData[1];

        //        if (String.IsNullOrEmpty(base64UrlEncodedHeader) || String.IsNullOrEmpty(base64UrlEncodedPayload))
        //        {
        //            throw new Exception($"JWT string '{token}' is missing a header, body/payload.");
        //        }

        //        var jwtSign = JwtTokenUtil.SignJwt(base64UrlEncodedHeader + "." + base64UrlEncodedPayload, _jwtOptions.SigningKey);
        //        if (token != jwtSign)
        //        {
        //            throw new Exception($"Invalid token. Unable to verify the JWT token.");
        //        }

        //        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        //        if (handler.CanReadToken(token))
        //        {
        //            JwtSecurityToken jwtSecurityToken = handler.ReadToken(token) as JwtSecurityToken;

        //            // Access the payload
        //            var userAffiliateStoreId = long.Parse(jwtSecurityToken.Claims.First(x => x.Type == "userAffiliateStoreId").Value);
        //            var exp = int.Parse(jwtSecurityToken.Claims.First(x => x.Type == "exp").Value);

        //            //Verify Exp
        //            if (!VerifyExpireDate(exp))
        //            {
        //                throw new Exception($"Token has expired. Unable to verify the JWT token.");
        //            }

        //            return userAffiliateStoreId;
        //        }

        //        return null;
        //    }

            private bool VerifyExpireDate(long exp)
            {
                DateTime currentTimeUtc = DateTime.UtcNow;
                DateTime expireDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(exp);
                int comparisonResult = DateTime.Compare(currentTimeUtc, expireDate);
                return comparisonResult <= 0;
            }
        }
    }
