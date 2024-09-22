using GoSell.Common.Enums;
using Newtonsoft.Json;

namespace GoSell.Common.Models
{
    public record HistoryMessageTemplate
    {
        [JsonProperty("message_template")]
        public string MessageTemplate { get; set; }
        [JsonProperty("params")]
        public string[] Params { get; set; } = [];

    }
}
