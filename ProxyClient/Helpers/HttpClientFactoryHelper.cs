using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace ProxyClient.Helpers
{
    public interface IHttpClientFactoryHelper
    {
        Task<HttpResponseMessage> SendPostAsync(string apiName, Uri uri, HttpContent content, List<KeyValuePair<string, string>> httpHeader);
        Task<HttpResponseMessage> SendPostAsync(string apiName, Uri uri, HttpContent content);
        Task<HttpResponseMessage> SendPutAsync<T>(string apiName, Uri uri, T data);
        Task<HttpResponseMessage> SendGetAsync(string apiName, Uri uri, List<KeyValuePair<string, string>> httpHeader = null);
        Task<T> SendGetAsync<T>(string apiName, Uri uri, string accessToken, List<KeyValuePair<string, string>> httpHeader = null, Dictionary<string, string> parameters = null) where T : class;
        Task<T> SendPostAsync<T>(string apiName, Uri uri, object payload = null, List<KeyValuePair<string, string>> httpHeader = null, string accessToken = null) where T : class;
        Task<T> SendGetAsync<T>(string apiName, Uri uri, List<KeyValuePair<string, string>> httpHeader = null, string accessToken = null) where T : class;
        Task<HttpResponseMessage> SendGetAsync(string apiName, Uri uri, string accessToken, List<KeyValuePair<string, string>> httpHeader = null, Dictionary<string, string> parameters = null);

        Task<T> PostAsync<T>(string apiName, string uri, FormUrlEncodedContent data, bool setAccessToken) where T : class;
        Task<T> DeleteAsync<T>(string apiName, string uri, bool setAccessToken) where T : class;
        Task<string> GetTokenAsync(string apiName);
        Task<T> PostRawAsync<T>(string apiName, string uri, string data, string accessToken) where T : class;
    }

    public class HttpClientFactoryHelper : IHttpClientFactoryHelper
    {
        private const string HttpHeaderAccept = "Accept";
        private const string HttpContentValue = "application/json";
        private string _accessToken;
        private IHttpClientFactory _httpClientFactory;
        public HttpClientFactoryHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetTokenAsync(string apiName)
        {
            //var scopes = _azureAppSetting.ApiResources.FirstOrDefault(x => x.Name == apiName).Scopes;
            //return await _tokenAzureManager.AcquireTokenAsync(scopes);

            await Task.CompletedTask;
            return null;
        }

        public async Task<HttpResponseMessage> SendPostAsync(string apiName, Uri uri, HttpContent content)
        {
            using (var httpClient = _httpClientFactory.CreateClient(apiName))
            {
                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = uri,
                    Method = HttpMethod.Post,
                };

                _accessToken = await GetTokenAsync(apiName);
                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
                httpRequest.Content = content;
                return await httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            }
        }

        public async Task<HttpResponseMessage> SendPostAsync(string apiName, Uri uri, HttpContent content, List<KeyValuePair<string, string>> httpHeader)
        {
            using (var httpClient = _httpClientFactory.CreateClient(apiName))
            {
                var httpRequest = new HttpRequestMessage
                {
                    RequestUri = uri,
                    Method = HttpMethod.Post,
                    Content = content,
                };

                if (httpHeader != null)
                {
                    foreach (var item in httpHeader)
                    {
                        httpRequest.Headers.Add(item.Key, item.Value);
                    }
                }
                _accessToken = await GetTokenAsync(apiName);
                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);

                return await httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            }
        }

        public async Task<HttpResponseMessage> SendPutAsync<T>(string apiName, Uri uri, T data)
        {
            using (var httpClient = _httpClientFactory.CreateClient(apiName))
            {
                var httpHeader = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(HttpHeaderAccept, HttpContentValue)
                };

                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = uri,
                    Method = HttpMethod.Put,
                };

                foreach (var item in httpHeader)
                {
                    httpRequest.Headers.Add(item.Key, item.Value);
                }

                var dataString = JsonConvert.SerializeObject(data, Formatting.Indented,
                                                             new JsonSerializerSettings
                                                             {
                                                                 NullValueHandling = NullValueHandling.Ignore,
                                                                 Converters = new List<JsonConverter> { new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() } },
                                                             });
                var content = new StringContent(dataString, Encoding.UTF8, HttpContentValue);

                httpRequest.Content = content;
                _accessToken = await GetTokenAsync(apiName);
                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);

                return await httpClient.SendAsync(httpRequest);
            }
        }

        public async Task<HttpResponseMessage> SendGetAsync(string apiName, Uri uri, List<KeyValuePair<string, string>> httpHeader = null)
        {
            using (var httpClient = _httpClientFactory.CreateClient(apiName))
            {
                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = uri,
                    Method = HttpMethod.Get
                };

                _accessToken = await GetTokenAsync(apiName);
                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);

                if (httpHeader == null) return await httpClient.SendAsync(httpRequest);
                foreach (var item in httpHeader)
                {
                    httpRequest.Headers.Add(item.Key, item.Value);
                }

                return await httpClient.SendAsync(httpRequest);
            }
        }

        public async Task<T> SendGetAsync<T>(string apiName, Uri uri, string accessToken, List<KeyValuePair<string, string>> httpHeader = null, Dictionary<string, string> parameters = null) where T : class
        {
            try
            {
                Console.WriteLine($"PostAsync - apiName: {apiName} - apiUrl: {uri}");
                using (var httpClient = _httpClientFactory.CreateClient(apiName))
                {
                    var httpRequest = new HttpRequestMessage()
                    {
                        RequestUri = uri,
                        Method = HttpMethod.Get,
                    };

                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    if (httpHeader != null)
                    {
                        foreach (var item in httpHeader)
                        {
                            httpRequest.Headers.Add(item.Key, item.Value);
                        }
                    }

                    if (parameters != null)
                        httpRequest.Content = new FormUrlEncodedContent(parameters);

                    var response = await httpClient.SendAsync(httpRequest);
                    var jsonString = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        Log.Logger.Error($"PostAsync - apiName: {apiName} - apiUrl: {uri} - statusCode: {response.StatusCode} - message: {jsonString}");
                        return null;
                    }

                    var result = JsonConvert.DeserializeObject<T>(jsonString);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"SendGetAsync - apiName: {apiName} - apiUrl: {uri} - Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<HttpResponseMessage> SendGetAsync(string apiName, Uri uri, string accessToken, List<KeyValuePair<string, string>> httpHeader = null, Dictionary<string, string> parameters = null)
        {
            try
            {
                Console.WriteLine($"PostAsync - apiName: {apiName} - apiUrl: {uri}");
                using (var httpClient = _httpClientFactory.CreateClient(apiName))
                {
                    var httpRequest = new HttpRequestMessage()
                    {
                        RequestUri = uri,
                        Method = HttpMethod.Get,
                    };

                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    if (httpHeader != null)
                    {
                        foreach (var item in httpHeader)
                        {
                            httpRequest.Headers.Add(item.Key, item.Value);
                        }
                    }

                    if (parameters != null)
                        httpRequest.Content = new FormUrlEncodedContent(parameters);

                    var response = await httpClient.SendAsync(httpRequest);
                    return response;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"SendGetAsync - apiName: {apiName} - apiUrl: {uri} - Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<T> SendPostAsync<T>(string apiName, Uri uri, object payload = null, List<KeyValuePair<string, string>> httpHeader = null, string accessToken = null) where T : class
        {
            try
            {
                Console.WriteLine($"SendPostAsync - apiName: {apiName} - apiUrl: {uri}");
                using (var httpClient = _httpClientFactory.CreateClient(apiName))
                {
                    var httpRequest = new HttpRequestMessage()
                    {
                        RequestUri = uri,
                        Method = HttpMethod.Post,
                    };

                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    if (httpHeader != null)
                    {
                        foreach (var item in httpHeader)
                        {
                            httpRequest.Headers.Add(item.Key, item.Value);
                        }
                    }

                    if (payload != null)
                        httpRequest.Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, HttpContentValue);

                    var response = await httpClient.SendAsync(httpRequest);
                    var jsonString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        Log.Logger.Warning($"SendPostAsync - apiName: {apiName} - apiUrl: {uri} - statusCode: {response.StatusCode} - message: {jsonString}");
                        return null;
                    }

                    var result = JsonConvert.DeserializeObject<T>(jsonString);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"SendPostAsync - apiName: {apiName} - apiUrl: {uri} - Exception: {ex.Message}");
                return null;
            }
        }
        public async Task<T> SendGetAsync<T>(string apiName, Uri uri, List<KeyValuePair<string, string>> httpHeader = null, string accessToken = null) where T : class
        {
            try
            {
                Console.WriteLine($"SendGetAsync - apiName: {apiName} - apiUrl: {uri}");
                using (var httpClient = _httpClientFactory.CreateClient(apiName))
                {
                    var httpRequest = new HttpRequestMessage()
                    {
                        RequestUri = uri,
                        Method = HttpMethod.Get,
                    };

                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    if (httpHeader != null)
                    {
                        foreach (var item in httpHeader)
                        {
                            httpRequest.Headers.Add(item.Key, item.Value);
                        }
                    }

                    var response = await httpClient.SendAsync(httpRequest);
                    var jsonString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        Log.Logger.Warning($"SendGetAsync - apiName: {apiName} - apiUrl: {uri} - statusCode: {response.StatusCode} - message: {jsonString}");
                        return null;
                    }

                    var result = JsonConvert.DeserializeObject<T>(jsonString);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"SendGetAsync - apiName: {apiName} - apiUrl: {uri} - Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<T> PostAsync<T>(string apiName, string uri, FormUrlEncodedContent data, bool setAccessToken = true) where T : class
        {
            using (var httpClient = _httpClientFactory.CreateClient(apiName))
            {
                if (setAccessToken)
                {
                    _accessToken = await GetTokenAsync(apiName);
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
                }
                var response = await httpClient.PostAsync(uri, data);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                {
                    Log.Logger.Error($"PostAsync - apiName: {apiName} - apiUrl: {uri} - statusCode: {response.StatusCode} - message: {jsonString}");
                    return null;
                }
                var result = JsonConvert.DeserializeObject<T>(jsonString);
                return result;
            }
        }

        public async Task<T> DeleteAsync<T>(string apiName, string uri, bool setAccessToken = true) where T : class
        {
            using (var httpClient = _httpClientFactory.CreateClient(apiName))
            {
                if (setAccessToken)
                {
                    _accessToken = await GetTokenAsync(apiName);
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
                }
                var response = await httpClient.DeleteAsync(uri);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                {
                    Log.Logger.Error($"DeleteAsync - apiName: {apiName} - apiUrl: {uri} - statusCode: {response.StatusCode} - message: {jsonString}");
                    return null;
                }
                var result = JsonConvert.DeserializeObject<T>(jsonString);
                return result;
            }
        }

        public async Task<T> PostRawAsync<T>(string apiName, string uri, string data, string accessToken) where T : class
        {
            using (var httpClient = _httpClientFactory.CreateClient(apiName))
            {
                if (!string.IsNullOrEmpty(accessToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                }
                var response = await httpClient.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created) return null;
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(jsonString);
                return result;
            }
        }
    }
}
