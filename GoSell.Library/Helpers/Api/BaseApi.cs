using GoSell.Library.Extensions.JWT;
using Microsoft.AspNetCore.Http;

namespace GoSell.Library.Helpers.Api
{
    public class BaseApi : IBaseApi
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly PayloadJWT user;

        public BaseApi(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            try
            {
                // get user from Items["Users"] - view at class JwtOptions
                user = _httpContextAccessor?.HttpContext?.Items["Users"] as PayloadJWT ?? new PayloadJWT();
                user.TimeZone = _httpContextAccessor?.HttpContext?.Request?.Headers["time-zone"];
                user.LangKey = _httpContextAccessor?.HttpContext?.Request?.Headers["langKey"];
            }
            catch
            {
                user = new PayloadJWT();
            }
        }

        public IHttpContextAccessor HttpContextAccessor => _httpContextAccessor;

        public PayloadJWT User => user;
    }
}
