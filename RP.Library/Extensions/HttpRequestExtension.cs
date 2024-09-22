using Microsoft.AspNetCore.Http;

namespace GoSell.Library.Extensions
{
    public static class HttpRequestExtension
    {
        public static string GetHeader(this HttpRequest request, string key)
        {
            return request.Headers.FirstOrDefault(x => x.Key.ToLower() == key.ToLower()).Value.FirstOrDefault();
        }
    }
}
