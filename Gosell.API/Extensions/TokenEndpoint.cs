using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using GoSell.Library.Extensions.JWT;
using Microsoft.IdentityModel.Tokens;

namespace GoSell.Ordering.API.Extensions
{
    public static class TokenEndpoint
    {
        //handles requests from /connect/token
        public static async Task<IResult> Connect(
            HttpContext ctx,
            JwtOptions jwtOptions)
        {
            // validates the content type of the request
            if (ctx.Request.ContentType != "application/x-www-form-urlencoded")
                return Results.BadRequest(new { Error = "Invalid Request" });

            var formCollection = await ctx.Request.ReadFormAsync();
            // pulls information from the form
            if (formCollection.TryGetValue("grant_type", out var grantType) == false)
                return Results.BadRequest(new { Error = "Invalid grantType" });

            if (formCollection.TryGetValue("client_id", out var client_id) == false)
                return Results.BadRequest(new { Error = "Invalid client_id" });

            if (formCollection.TryGetValue("client_secret", out var client_secret) == false)
                return Results.BadRequest(new { Error = "Invalid client_secret" });

            //Check username + password

            //creates the access token (jwt token)
            var tokenExpiration = TimeSpan.FromSeconds(jwtOptions.ExpirationSeconds);
            var accessToken = TokenEndpoint.CreateAccessToken(
                jwtOptions,
                client_id,
                TimeSpan.FromMinutes(60),
                new[] { "read_todo", "create_todo" });

            //returns a json response with the access token
            return Results.Ok(new
            {
                access_token = accessToken,
                expiration = (int)tokenExpiration.TotalSeconds,
                type = "bearer"
            });
        }

        static string CreateAccessToken(
            JwtOptions jwtOptions, string username, TimeSpan expiration, string[] permissions)
        {
            var symmetricKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtOptions.SigningKey));

            var signingCredentials = new SigningCredentials(
                symmetricKey,
                // 👇 one of the most popular. 
                SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>()
            {
                new Claim("sub", username),
                new Claim("name", username),
                new Claim("aud", jwtOptions.Audience)
            };

            var roleClaims = permissions.Select(x => new Claim("role", x));
            claims.AddRange(roleClaims);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.Add(expiration),
                signingCredentials: signingCredentials);

            var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
            return rawToken;
        }
    }
}
