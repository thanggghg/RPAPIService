using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using RP.Library.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Security.Claims;

namespace RP.Library.Extensions.JWT
{
    public record class JwtOptions(
     string Issuer,
     string Audience,
     string SigningKey,
     int ExpirationSeconds,
     int RefreshTokenExpirationSeconds
    );


    public class JwtVerifier
    {
        private readonly JwtOptions _jwtOptions;
        private const int JWT_EXPIRED_TIME = 3; // expiry can be a maximum of 6 months - generate one per request or re-use until expiration
        public JwtVerifier() { }
        public JwtVerifier(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public bool VerifyToken(string token, HttpContext context, List<JWTTokenRequirement> requirements)
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

                if (String.IsNullOrEmpty(base64UrlEncodedHeader) || String.IsNullOrEmpty(base64UrlEncodedPayload))
                {
                    throw new JWTException($"JWT string '{token}' is missing a header, body/payload.");
                }
                else
                {
                    var tokenData = DecodeJwtPayload(token);
                    var headerJson = tokenData.Item1 as string;//
                    var payloadJson = tokenData.Item2 as string;
                    var header = JsonConvert.DeserializeObject<HeaderJWT>(headerJson);
                    var payload = JsonConvert.DeserializeObject<PayloadJWT>(payloadJson);
                    //Verify Exp
                    if (!payload.VerifyExpireDate())
                    {
                        throw new JWTException($"Token has expired. Unable to verify the JWT token.");
                    }
                    //Verify ROLE
                    if (!requirements.Any(a => payload.CheckPermission(a.Role)))
                    {
                        throw new JWTException($"User does not have permission!");
                    }

                    context.Items["HeaderJWT"] = header;
                    context.Items["Users"] = payload;
                    var jwtSign = SignJwt(base64UrlEncodedHeader + "." + base64UrlEncodedPayload, _jwtOptions.SigningKey);

                    if (!string.Equals(token, jwtSign, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new JWTException($"Invalid token. Unable to verify the JWT token. ");
                    }

                }
            }
            return true;
        }

       


        public string BuildToken(string username, string role)
        {
            try
            {
                var tokenExpiration = DateTime.UtcNow.Add(TimeSpan.FromSeconds(_jwtOptions.ExpirationSeconds));
                var jsonObject = new Dictionary<string, object>
                {
                    { "sub", username},
                    { "auth", role},
                    { "exp", ToUnixTimestamp(tokenExpiration) }
                };

                var base64UrlEncodedHeader = CreateBase64UrlEncoderJwtHeader();
                var base64UrlEncodedPayload = CreateBase64UrlEncoderJwtPayLoad(jsonObject);
                var jwtSign = SignJwt(base64UrlEncodedHeader + "." + base64UrlEncodedPayload, _jwtOptions.SigningKey);
                if (string.IsNullOrEmpty(jwtSign))
                {
                    throw new JWTException($"Cannot generate access token");
                }
                return jwtSign;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public PayloadJWT VerifyTokenAPI(string token)
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

                if (String.IsNullOrEmpty(base64UrlEncodedHeader) || String.IsNullOrEmpty(base64UrlEncodedPayload))
                {
                    throw new JWTException($"JWT string '{token}' is missing a header, body/payload.");
                }
                else
                {
                    var tokenData = DecodeJwtPayload(token);
                    var headerJson = tokenData.Item1 as string;//
                    var payloadJson = tokenData.Item2 as string;
                    var header = JsonConvert.DeserializeObject<HeaderJWT>(headerJson);
                    var payload = JsonConvert.DeserializeObject<PayloadJWT>(payloadJson);
                    //Verify Exp
                    if (!payload.VerifyExpireDate())
                    {
                        throw new JWTException($"Token has expired. Unable to verify the JWT token.");
                    }
                    //Verify ROLE
                   

                    var jwtSign = SignJwt(base64UrlEncodedHeader + "." + base64UrlEncodedPayload, _jwtOptions.SigningKey);

                    if (!string.Equals(token, jwtSign, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new JWTException($"Invalid token. Unable to verify the JWT token. ");
                    }
                    return payload;
                }
            }
        }

        public string BuildTokenAPI(string username, string role,long affiliateStoreId, string APIkey)
        {
            try
            {
                var tokenExpiration = DateTime.UtcNow.Add(TimeSpan.FromSeconds(_jwtOptions.ExpirationSeconds));
                var jsonObject = new Dictionary<string, object>
                {
                    { "sub", username},
                    { "auth", role},
                    { "APIKey", APIkey},
                    { "AffiliateStoreId", affiliateStoreId},
                    { "exp", ToUnixTimestamp(tokenExpiration) }
                };

                var base64UrlEncodedHeader = CreateBase64UrlEncoderJwtHeader();
                var base64UrlEncodedPayload = CreateBase64UrlEncoderJwtPayLoad(jsonObject);
                var jwtSign = SignJwt(base64UrlEncodedHeader + "." + base64UrlEncodedPayload, _jwtOptions.SigningKey);
                if (string.IsNullOrEmpty(jwtSign))
                {
                    throw new JWTException($"Cannot generate access token");
                }
                return jwtSign;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string DecodeToString(string encoded, string encodingName)
        {
            byte[] bytes = Decode(encoded);
            Encoding encoding = Encoding.GetEncoding(encodingName);
            return encoding.GetString(bytes);
        }

        private byte[] Decode(string encoded)
        {
            while (encoded.Length % 4 != 0)
            {
                encoded = encoded.Remove(encoded.Length - 1);
            }

            return Convert.FromBase64String(encoded);
        }
        private byte[] Encode(string key)
        {
            while (key.Length % 4 != 0)
            {
                key = key.Remove(key.Length - 1);
            }

            return Convert.FromBase64String(key);
        }
        public static (string, string) DecodeJwtPayload(string jwtToken)
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

        //private string CreateToken(string payload, string secretKey)
        //{
           
        //        var claims = new[] {
        //                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //                new Claim(GeneralCode.CLAIMS_USER_NAME_KEY, AESEncryption.Encrypt(account.UserName)),
        //                new Claim(GeneralCode.CLAIMS_DATABASE_KEY, AESEncryption.Encrypt(JsonConvert.SerializeObject(database))),
        //                new Claim("UserName", account.UserName),
        //                new Claim("TokenType",tokenType),
        //                new Claim("TokenSession",account.Token),
        //                new Claim("Email", account.Email),
        //                new Claim("SupervisorName", account.SupervisorName)
        //            };
        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //        var token = new JwtSecurityToken(
        //            _configuration["Jwt:Issuer"],
        //            _configuration["Jwt:Audience"],
        //            claims,
        //            expires: DateTime.UtcNow.AddHours(12),
        //            signingCredentials: signIn);
        //        return new JwtSecurityTokenHandler().WriteToken(token);
        //    return string.Empty;
        //}


        private string SignJwt(string payload, string secretKey)
        {
            // Convert the payload to bytes
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

            // Convert the secret key to bytes
            byte[] keyBytes = Decode(secretKey);

            // Create an instance of HMACSHA512 with the secret key
            using (HMACSHA512 hmac = new HMACSHA512(keyBytes))
            {
                // Compute the hash of the payload
                byte[] hashBytes = hmac.ComputeHash(payloadBytes);

                // Convert the hash to a Base64-encoded string
                string signature = Convert.ToBase64String(hashBytes).Replace('+', '-').Replace('/', '_').TrimEnd('='); ;

                // Combine the payload and signature to form the JWT
                return $"{payload}.{signature}";
            }
        }

        private string CreateBase64UrlEncoderJwtHeader()
        {
            var securityKey = new SymmetricSecurityKey(Encode(_jwtOptions.SigningKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var header = new JwtHeader(signingCredentials);
            var encodedHeader = Base64UrlEncoder.Encode(header.SerializeToJson());
            return encodedHeader;
        }
        private string CreateBase64UrlEncoderJwtPayLoad(object payload)
        {
            var jsonPayload = JsonConvert.SerializeObject(payload);
            return Base64UrlEncoder.Encode(jsonPayload);
        }

        public long ToUnixTimestamp(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var time = date.ToUniversalTime().Subtract(epoch);
            return time.Ticks / TimeSpan.TicksPerSecond;
        }
    }
}
