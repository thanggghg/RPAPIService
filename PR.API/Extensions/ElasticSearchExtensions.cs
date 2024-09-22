using Nest;

namespace GoSell.API.Extensions
{
    public class ElasticSearchSetting
    {
        public List<string> ExplorerIndexs { get; set; } = new List<string>();
        public string Endpoint { get; set; }
        public string GetEndpoint()
        {
            var result = Endpoint.Replace("{ELASTIC_HOST}", Environment.GetEnvironmentVariable("ELASTIC_HOST"))
                                 .Replace("{ELASTIC_PORT}", Environment.GetEnvironmentVariable("ELASTIC_PORT"));
            Console.WriteLine($"Connectionstring: ${result}");
            return result;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public static class ElasticSearchExtensions
    {
        public static void AddElasticClient(this IHostApplicationBuilder builder, string sectionName = null)
        {
            if (string.IsNullOrEmpty(sectionName))
            {
                sectionName = "ElasticSearch";
            }
            var config = builder.Configuration.GetSection(sectionName).Get<ElasticSearchSetting>();
            var setting = new ConnectionSettings(new Uri("http://localhost:9200"));
            if (!string.IsNullOrEmpty(config.Username) && !string.IsNullOrEmpty(config.Password))
            {
                setting.BasicAuthentication(config.Username, config.Password);
            }

            GoSell.API.Domains.Elastics.Mappings.BuildElasticMapping(setting);

            builder.Services.AddSingleton(setting);
            var client = new ElasticClient(setting);
            builder.Services.AddSingleton<IElasticClient>(client);

            //foreach (var item in config.ExplorerIndexs)
            //{
            //    setting.DefaultIndex(item);
            //    IElasticClient indexClient = new ElasticClient(setting);
            //    builder.Services.AddKeyedSingleton(item, indexClient);
            //}                
        }
    }
}
