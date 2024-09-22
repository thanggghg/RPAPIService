using System.Text.Json.Serialization;

namespace RP.Library.Extensions.Jira
{
    public class JiraSearchData
    {
        public class JiraSearchResponseData
        {
            public string expand { get; set; }
            public int startAt { get; set; }
            public int maxResults { get; set; }
            public int total { get; set; }
            public List<Issue> issues { get; set; }
        }
        public class Item
        {
            public string field { get; set; }
            public string fieldtype { get; set; }
            public string from { get; set; }
            public string fromString { get; set; }
            public string to { get; set; }
            public string toString { get; set; }
        }
        public class History
        {
            public string id { get; set; }
            public List<Item> items { get; set; }
        }
        public class Changelog
        {
            public List<History> histories { get; set; }
        }
        public class Issue
        {
            public string expand { get; set; }
            public Fields fields { get; set; }
            public string id { get; set; }
            public string key { get; set; }
            public string self { get; set; }
            public Changelog changelog { get; set; }
        }

        public class Fields
        {
            public IssueType issuetype { get; set; }
            public Parent parent { get; set; }
            public Status status { get; set; }
            public Creator creator { get; set; }
            public Reporter reporter { get; set; }
            public string created { get; set; }
            public string updated { get; set; }
            public string summary { get; set; }

            [JsonPropertyName("customfield_10809")]
            public string email { get; set; }
            public List<IssueLink> issuelinks { get; set; }

            [JsonPropertyName("customfield_10812")]
            public Description lastUpdater { get; set; }
        }
        public class IssueType
        {
            public string self { get; set; }
            public string id { get; set; }
            public string description { get; set; }
            public string iconUrl { get; set; }
            public string name { get; set; }
            public bool subtask { get; set; }
            public int avatarId { get; set; }
            public int hierarchyLevel { get; set; }
        }
        public class Parent
        {
            public string id { get; set; }
            public string key { get; set; }
            public string self { get; set; }
            public JiraParent fields { get; set; }
        }
        public class JiraParent
        {
            public string summary { get; set; }
             
        }
        public class Description
        {
            public List<Content> content { get; set; }
            public string type { get; set; }
            public int version { get; set; }
        }
        public class Content
        {
            public List<Content> content { get; set; }
            public string type { get; set; }
            public string text { get; set; }
        }
        public class Creator
        {
            public string self { get; set; }
            public string accountId { get; set; }
            public string emailAddress { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            public string timeZone { get; set; }
            public string accountType { get; set; }
        }
        public class Reporter
        {
            public string self { get; set; }
            public string accountId { get; set; }
            public string emailAddress { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            public string timeZone { get; set; }
            public string accountType { get; set; }
        }
        public class Status
        {
            public string self { get; set; }
            public string description { get; set; }
            public string iconUrl { get; set; }
            public string name { get; set; }
            public string id { get; set; }
            public StatusCategory statusCategory { get; set; }
        }
        public class StatusCategory
        {
            public string self { get; set; }
            public int id { get; set; }
            public string key { get; set; }
            public string colorName { get; set; }
            public string name { get; set; }
        }

        public class IssueLink
        {
            public int id { get; set; }
            public Issue inwardIssue { get; set; }
        }
    }
}
