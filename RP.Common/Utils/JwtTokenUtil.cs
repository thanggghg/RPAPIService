using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace RP.Common.Utils
{
    public class JwtTokenUtil
    {
        public static byte[] Encode(string key)
        {
            //This token must be encoded using Base64 and be at least 256 bits long (you can type `openssl rand -base64 64` on your command line to generate a 512 bits one)
            while (key.Length % 4 != 0)
            {
                key = key.Remove(key.Length - 1);
            }

            return Convert.FromBase64String(key);
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            byte[] bytes;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            }

            return Encoding.UTF8.GetString(bytes);
        }

        public static string CreateBase64UrlEncoderJwtPayLoad(object payload)
        {
            var jsonPayload = JsonSerializer.Serialize(payload);
            return Base64UrlEncoder.Encode(jsonPayload);
        }

        public static string SignJwt(string payload, string secretKey)
        {
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);
            byte[] keyBytes = Encode(secretKey);

            using (HMACSHA512 hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(payloadBytes);

                string signature = Convert.ToBase64String(hashBytes).Replace('+', '-').Replace('/', '_').TrimEnd('='); ;

                return $"{payload}.{signature}";
            }
        }

        public static string CreateBase64UrlEncoderJwtHeader(string secretKey)
        {
            var securityKey = new SymmetricSecurityKey(Encode(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var header = new JwtHeader(signingCredentials);
            var encodedHeader = Base64UrlEncoder.Encode(header.SerializeToJson());

            return encodedHeader;
        }
    }
}
