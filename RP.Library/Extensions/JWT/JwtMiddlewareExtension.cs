
//namespace GoSell.Library.Extensions.JWT;

//using System.Threading.Tasks;
//using GoSell.Library.Utils;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;

//public class JwtMiddlewareExtension
//{
//    private readonly RequestDelegate _next;
//    private readonly string _secretKey;
//    private readonly string _validIssuer;
//    private readonly string _validAudience;

//    public JwtMiddlewareExtension(RequestDelegate next, JwtOptions jwtOptions)
//    {
//        _next = next;
//        _secretKey = jwtOptions.SigningKey;
//        _validIssuer = jwtOptions.Issuer;
//        _validAudience = jwtOptions.Audience;
//    }

//    public async Task InvokeAsync(HttpContext context)
//    {
//        var endpoint = context.GetEndpoint();
//        if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null)
//        {
//            await _next(context);
//        }

//        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
//        try
//        {
//            if (token != null)
//            {
//                if (VerifyJWTToken(context, token))
//                {
//                    await _next(context);
//                }
//                else
//                {
//                    // Handle case where token is missing
//                    context.Response.StatusCode = 401;
//                    await context.Response.WriteAsJsonAsync<ResultJWTVerify>(new ResultJWTVerify
//                    {
//                        Status = false,
//                        Message = "Invalid token. Unable to verify the JWT token."
//                    });
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//            // Handle case where token is missing
//            context.Response.StatusCode = 401;
//            await context.Response.WriteAsJsonAsync<ResultJWTVerify>(new ResultJWTVerify
//            {
//                Status = false,
//                Message = ex.Message
//            });
//        }

//    }
//    private bool VerifyJWTToken(HttpContext context, string token)
//    {
//        try
//        {
//            var jwtVerifier = new JwtVerifier(_secretKey);
//            var rolesRequirement = new List<JWTTokenRequirement>
//            {
//                new(AuthoritiesConstants.ADMIN),
//                new(AuthoritiesConstants.STORE),
//                new(AuthoritiesConstants.USER),
//                new(AuthoritiesConstants.DEFAULT)
//            };
//            return jwtVerifier.VerifyToken(token, context, rolesRequirement);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.ToString()); //Add log
//            throw new Exception(ex.Message);
//        }

//    }
//}

