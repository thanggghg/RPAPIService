using System.Net.Http.Json;
using GoSell.Library.Extensions.Jira;

namespace GoSell.Library.Helpers.Jira
{
    public class JiraClientHelper(JiraConfiguration jiraConfiguration) : IJiraClientHelper
    {
        private readonly JiraConfiguration _jiraConfiguration = jiraConfiguration;

        public async Task<HttpResponseMessage> SendPostAsync(JiraUser jiraUser, string jiraUri, JsonContent jsonData)
        {
            using HttpClient client = new();
            client.BaseAddress = new(_jiraConfiguration.JiraUri.BaseAddress);
            client.DefaultRequestHeaders.Authorization = new("Basic", jiraUser.AuthData);
            return await client.PostAsync(jiraUri, jsonData);
        }

        public async Task<HttpResponseMessage> SendGetAsync(JiraUser jiraUser, string requestUri)
        {
            using HttpClient client = new();
            client.BaseAddress = new(_jiraConfiguration.JiraUri.BaseAddress);
            client.DefaultRequestHeaders.Authorization = new("Basic", jiraUser.AuthData);
            return await client.GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> AddAttachmentToIssue(JiraUser jiraUser, string jiraUri, MultipartFormDataContent formFile)
        {
            using HttpClient client = new();
            client.BaseAddress = new(_jiraConfiguration.JiraUri.BaseAddress);
            client.DefaultRequestHeaders.Authorization = new("Basic", jiraUser.AuthData);
            client.DefaultRequestHeaders.Add("X-Atlassian-Token", "nocheck");
            client.DefaultRequestHeaders.Accept.Add(new("application/json"));

            return await client.PostAsync(jiraUri, formFile);
        }

        public async Task<HttpResponseMessage> SendPutAsync(JiraUser jiraUser, string jiraUri, JsonContent jsonData)
        {
            using HttpClient client = new();
            client.BaseAddress = new(_jiraConfiguration.JiraUri.BaseAddress);
            client.DefaultRequestHeaders.Authorization = new("Basic", jiraUser.AuthData);
            return await client.PutAsync(jiraUri, jsonData);
        }
    }
}
