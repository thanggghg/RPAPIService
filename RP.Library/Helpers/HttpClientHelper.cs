using System.Net.Http.Headers;
using System.Text;
using RP.Library.Extensions.JWT;
using RP.Library.Utils;
using Newtonsoft.Json;
using Serilog;

namespace RP.Library.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private const string HttpHeaderAccept = "Accept";
        private const string HttpContentValue = "application/json";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JwtOptions _jwtOptions;

        // private string _accessToken;
        public HttpClientHelper(IHttpClientFactory httpClientFactory, JwtOptions jwtOptions)
        {
            _httpClientFactory = httpClientFactory;
            _jwtOptions = jwtOptions;
        }
        public Task<string> GetTokenAsync(string resourceId)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> SendPostAsync(string apiName, Uri uri, HttpContent content, bool isNeedAuthorize = false)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(apiName);

                var httpRequest = new HttpRequestMessage
                {
                    RequestUri = uri,
                    Method = HttpMethod.Post,
                };
                if (isNeedAuthorize)
                {
                    var accessToken = GetTokenAsync(AuthoritiesConstants.SYSTEM_USERNAME, AuthoritiesConstants.ADMIN);
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                }
                httpRequest.Content = content;

                return await httpClient.SendAsync(httpRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SendPost failed uri: {0} exception: {1}", uri, ex.Message));
            }
        }

        public async Task<HttpResponseMessage> SendGetAsync(string apiName, Uri uri, bool isNeedAuthorize = false)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(apiName);

                var httpRequest = new HttpRequestMessage
                {
                    RequestUri = uri,
                    Method = HttpMethod.Get,
                };
                if (isNeedAuthorize)
                {
                    var accessToken = GetTokenAsync(AuthoritiesConstants.SYSTEM_USERNAME, AuthoritiesConstants.ADMIN);
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                }

                return await httpClient.SendAsync(httpRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SendPost failed uri: {0} exception: {1}", uri, ex.Message));
            }
        }

        public async Task<T> SendServiceApiGetAsync<T>(string apiBaseUrl, string url, ApiNameConstants service, List<(string, string)> customHeaders = null)
        {
            try
            {
                if (string.IsNullOrEmpty(apiBaseUrl))
                {
                    throw new ArgumentNullException($"ApiBaseUrl is not specified in appsettings.json.");
                }

                var uri = new Uri($"{apiBaseUrl}{url}");

                var httpClient = _httpClientFactory.CreateClient(service.ToString());

                var httpRequest = new HttpRequestMessage
                {
                    RequestUri = uri,
                    Method = HttpMethod.Get,
                };

                var accessToken = GetTokenAsync(AuthoritiesConstants.SYSTEM_USERNAME, AuthoritiesConstants.ADMIN);
                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                if (customHeaders != null && customHeaders.Count > 0)
                {
                    customHeaders.ForEach(x =>
                    {
                        httpRequest.Headers.Add(x.Item1, x.Item2);
                    });
                }

                Console.WriteLine($"[CALLING API]: {apiBaseUrl}{url}");

                var response = await httpClient.SendAsync(httpRequest);

                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(body);
                }

                var data = JsonConvert.DeserializeObject<T>(body);

                return data;
            }
            catch (Exception ex)
            {
                Log.Error(apiBaseUrl + url + " [Error]: ", ex.Message);
                Console.WriteLine($"{apiBaseUrl}{url} - [Error]: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> SendServiceApiPostAsync<R>(string apiBaseUrl, string url, ApiNameConstants service, R input, string token = null)
        {
            try
            {
                if (string.IsNullOrEmpty(apiBaseUrl))
                {
                    throw new ArgumentNullException($"ApiBaseUrl is not specified in appsettings.json.");
                }

                var uri = new Uri($"{apiBaseUrl}{url}");

                var stringContent = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, HttpContentValue);

                var httpClient = _httpClientFactory.CreateClient(service.ToString());

                var httpRequest = new HttpRequestMessage
                {
                    RequestUri = uri,
                    Method = HttpMethod.Post,
                };

                var accessToken = !string.IsNullOrEmpty(token) ? token : GetTokenAsync(AuthoritiesConstants.SYSTEM_USERNAME, AuthoritiesConstants.ADMIN);
                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                httpRequest.Content = stringContent;

                var httpResponse = await httpClient.SendAsync(httpRequest);
                return httpResponse;
            }
            catch (Exception ex)
            {
                Log.Error(apiBaseUrl + url + " [Error]: ", ex.Message);
                throw;
            }
        }

        public async Task<T> SendServiceApiPostAsync<R, T>(string apiBaseUrl, string url, ApiNameConstants service, R input)
        {
            try
            {
                if (string.IsNullOrEmpty(apiBaseUrl))
                {
                    throw new ArgumentNullException($"ApiBaseUrl is not specified in appsettings.json.");
                }

                var uri = new Uri($"{apiBaseUrl}{url}");

                var stringContent = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, HttpContentValue);

                var httpClient = _httpClientFactory.CreateClient(service.ToString());

                var httpRequest = new HttpRequestMessage
                {
                    RequestUri = uri,
                    Method = HttpMethod.Post,
                };

                var accessToken = GetTokenAsync(AuthoritiesConstants.SYSTEM_USERNAME, AuthoritiesConstants.ADMIN);
                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                httpRequest.Content = stringContent;

                var response = await httpClient.SendAsync(httpRequest);

                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(body);
                }

                var data = JsonConvert.DeserializeObject<T>(body);
                return data;
            }
            catch (Exception ex)
            {
                Log.Error(apiBaseUrl + url + " [Error]: ", ex.Message);
                throw;
            }
        }

        private string GetTokenAsync(string userName, string role)
        {
            var jwtVerifier = new JwtVerifier(_jwtOptions);
            var token = jwtVerifier.BuildToken("system", AuthoritiesConstants.ADMIN);
            return token;
        }
    }
}
