namespace RP.Library.Extensions.Jira
{
    public record class JiraConfiguration
    {
        public string SupportTicketProjId { get; set; } 
        public JiraUser CSUser { get; set; }
        public JiraUser Seller { get; set; }
        public JiraUri JiraUri { get; set; }
        public JiraStatus JiraStatus { get; set; }
        public SendConfirmationEmail SendConfirmationEmail { get; set; }
        public string RedisCacheConfirmationEmailKey { get => "JIRA-SENT-CONFIRMATION-EMAIL"; }
    }

    public record class JiraUri
    {
        public string BaseAddress { get; set; }
        public string CreateIssue { get; } = "/rest/api/3/issue";
        public string LinkIssue { get; } = "/rest/api/3/issueLink";
        public string AddAttachmentsToIssue { get; } = "/rest/api/3/issue/:issueIdOrKey/attachments";
        public string SearchIssue { get; } = "/rest/api/3/search";
        public string GetIssue { get; } = "/rest/api/3/search?jql=";
        public string GetIssueConfirmationEmailRequireFields { get; } = "/rest/api/3/issue/:issueIdOrKey?fields=created,issuetype,summary,customfield_10809,issuelinks,status,parent";
        public string GetIssueType { get; } = "/rest/api/3/issuetype";
        public string GetIssueDetail { get; } = "/rest/api/3/issue/:issueIdOrKey?expand=renderedFields&fields=summary,status,created,updated,issuetype,attachment,description,customfield_10812";
        public string GetProject { get; } = "/rest/api/3/project/";
        public string GetTransitions { get; } = "/rest/api/3/issue/:issueIdOrKey/transitions";
        public string UpdateStatusIssue { get; } = "/rest/api/3/issue/:issueIdOrKey/transitions?expand=transitions.field";
        public string AddIssueComment { get; } = "/rest/api/3/issue/:issueIdOrKey/comment";
        public string GoSellStaff { get; set; } = "page.myTicket.title.GSStaff";
        public string GetHtmlComments { get; set; } = "/rest/api/3/issue/:issueIdOrKey/comment?expand=renderedBody";
        public string UpdateLastUpdater { get; } = "/rest/api/3/issue/:issueIdOrKey";
        public string DownloadAttachmentContent { get; } = "/rest/api/3/attachment/content/";
        public string GetcredentialsDetail { get; } = "/rest/api/3/attachment/read/issue/:issueIdOrKey/credentials";
    }

    public record class JiraUser
    {
        public string Email { get; set; }
        public string APIToken { get; set; }
        public string AuthData
        {
            get
            {
                var authData = System.Text.Encoding.UTF8.GetBytes($"{Email}:{APIToken}");
                var basicAuthentication = Convert.ToBase64String(authData);
                return basicAuthentication;
            }
        }
        public string Avatar { get; set; }
        public string AccountId { get; set; }
    }

    public record class JiraStatus
    {
        public int New { get; set; }
        public int Reopened { get; set; }
        public int StaffAnswered { get; set; }
        public int CustomerAnswered { get; set; }
        public int Closed { get; set; }
    }

    public record SendConfirmationEmail(
        string DashboardDomainVN,
        string DashboardDomainBiz,
        string DisplayName,
        string FromVN,
        string FromBiz
    );
}
