using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RP.Library.Extensions.Localization
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly IDistributedCache _cache;
        private readonly JsonSerializer _serializer = new();
        public JsonStringLocalizer(IDistributedCache cache)
        {
            _cache = cache;
        }
        public LocalizedString this[string name]
        {
            get
            {
                string value = GetString(name);
                return new LocalizedString(name, value ?? name, value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var actualValue = this[name];
                return !actualValue.ResourceNotFound
                    ? new LocalizedString(name, string.Format(actualValue.Value, arguments), false)
                    : actualValue;
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            string filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            using var str = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var sReader = new StreamReader(str);
            using var reader = new JsonTextReader(sReader);
            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName)
                    continue;
                string key = (string)reader.Value;
                reader.Read();
                string value = _serializer.Deserialize<string>(reader);
                yield return new LocalizedString(key, value, false);
            }
        }

        private string GetString(string key)
        {
            string relativeFilePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            string fullFilePath = Path.GetFullPath(relativeFilePath);
            if (File.Exists(fullFilePath))
            {
                return GetValueFromNestedJSON(key, Path.GetFullPath(relativeFilePath));
            }
            return default;
        }

        private static string GetValueFromNestedJSON(string propertyName, string filePath)
        {
            if (propertyName == null || filePath == null)
                return null;

            try
            {
                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(jsonContent);
                JToken token = jsonObject.SelectToken(propertyName);
                if (token != null)
                {
                    return token.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return null;
            }
        }
    }
}
