using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace RP.Library.Db
{
    public static class LibExtensions
    {
        public static string GetConnectionStringEnvironment(this IConfigurationManager configuration, string name)
        {
            var connectionString = configuration.GetConnectionString(name) ?? string.Empty;
            return connectionString.ReplaceStringWithEnvironment();
        }
        public static string ReplaceStringWithEnvironment(this string value)
        {
            Regex regex = new Regex(@"{([^{}]+)}");
            string replacedString = regex.Replace(value, match =>
            {
                string key = match.Groups[1].Value;
                return ReplacementValue(key);
            });
            return replacedString;
        }
        public static void ReplaceAllSectionChild(this IConfigurationSection sections)
        {
            foreach (var item in sections.GetChildren())
            {
                if (item.Key != null && item.Value != null)
                {
                    Regex regex = new Regex(@"{([^{}]+)}");
                    var value = item.Value;
                    item.Value = regex.Replace(value, match =>
                    {
                        string key = match.Groups[1].Value;
                        return ReplacementValue(key);
                    });
                }
                if (item.GetChildren().Count() <= 0)
                {
                    continue;
                }
                item.ReplaceAllSectionChild();
            }
        }
        public static IConfigurationSection GetSectionWithEnvironment(this IConfiguration configuration, string key)
        {
            var sections = configuration.GetSection(key);
            sections.ReplaceAllSectionChild();
            return sections;
        }
        public static string GetSectionValueWithEnvironment(this IConfiguration configuration, string key)
        {
            Regex regex = new Regex(@"{([^{}]+)}");
            var value = configuration[key];
            string replacedString = regex.Replace(value, match =>
            {
                string key = match.Groups[1].Value;
                return ReplacementValue(key);
            });
            return replacedString;
        }
        private static string ReplacementValue(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
