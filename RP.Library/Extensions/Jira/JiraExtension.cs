using RP.Library.Db;
using RP.Library.Extensions.Jira;
using RP.Library.Helpers.Jira;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RP.Library.Extensions
{
    public static class JiraExtension
    {
        public static IServiceCollection AddJiraConfiguration(this IServiceCollection services, string sectionName = "Jira", IConfiguration configuration = null)
        {
            configuration ??= services.BuildServiceProvider().GetService<IConfiguration>();

            var jiraSection = configuration.GetSectionWithEnvironment(sectionName) ?? throw new ArgumentNullException("Jira configuration should not be null.");
            var jiraConfiguration = jiraSection.Get<JiraConfiguration>();

            services.AddSingleton(jiraConfiguration);
            services.AddTransient<IJiraClientHelper, JiraClientHelper>();

            return services;
        }
    }
}
