using GoSell.Library.Extensions.JWT;
using Microsoft.AspNetCore.Http;

namespace GoSell.Library.Helpers.Api
{
    public interface IBaseApi
    {
        IHttpContextAccessor HttpContextAccessor { get; }
        PayloadJWT User { get; }
    }
}
