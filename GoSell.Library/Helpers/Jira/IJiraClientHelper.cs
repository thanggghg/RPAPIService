using System.Net.Http.Json;
using GoSell.Library.Extensions.Jira;

namespace GoSell.Library.Helpers.Jira
{
    public interface IJiraClientHelper
    {
        Task<HttpResponseMessage> SendPostAsync(JiraUser jiraUser, string jiraUri, JsonContent jsonData);
        Task<HttpResponseMessage> SendGetAsync(JiraUser jiraUser, string requestUri);
        Task<HttpResponseMessage> AddAttachmentToIssue(JiraUser jiraUser, string jiraUri, MultipartFormDataContent formFile);
        Task<HttpResponseMessage> SendPutAsync(JiraUser jiraUser, string jiraUri, JsonContent jsonData);
    }
}
