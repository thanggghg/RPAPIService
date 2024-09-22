using GoSell.Library.Db;
using GoSell.Library.Extensions.MailClient;
using GoSell.Library.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoSell.Library.Extensions
{
    public static class MailClientExtension
    {
        public static IServiceCollection AddMailClientConfiguration(this IServiceCollection services, string sectionName = "EmailConfigurations", IConfiguration configuration = null)
        {
            configuration ??= services.BuildServiceProvider().GetService<IConfiguration>();

            var jiraSection = configuration.GetSectionWithEnvironment(sectionName) ?? throw new ArgumentNullException("Jira configuration should not be null.");
            var jiraConfiguration = jiraSection.Get<MailClientConfiguration>();

            services.AddSingleton(jiraConfiguration);
             
            return services;
        }
    }
}
