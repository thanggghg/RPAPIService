using System.Net.Http.Headers;
using GoSell.Library.Utils;

namespace GoSell.Library.Helpers
{
    public interface IHttpClientHelper
    {
        Task<HttpResponseMessage> SendPostAsync(string apiName, Uri uri, HttpContent content, bool isNeedAuthorize = false);
        Task<HttpResponseMessage> SendGetAsync(string apiName, Uri uri, bool isNeedAuthorize = false);
        Task<string> GetTokenAsync(string resourceId);
        Task<T> SendServiceApiGetAsync<T>(string apiBaseUrl, string url, ApiNameConstants service, List<(string, string)> customHeaders = null);
        Task<HttpResponseMessage> SendServiceApiPostAsync<R>(string apiBaseUrl, string url, ApiNameConstants service, R input, string token = null);
        Task<T> SendServiceApiPostAsync<R, T>(string apiBaseUrl, string url, ApiNameConstants service, R input);
    }
}
