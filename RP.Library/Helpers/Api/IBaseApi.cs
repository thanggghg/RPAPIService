using RP.Library.Extensions.JWT;
using Microsoft.AspNetCore.Http;

namespace RP.Library.Helpers.Api
{
    public interface IBaseApi
    {
        IHttpContextAccessor HttpContextAccessor { get; }
        PayloadJWT User { get; }
    }
}
