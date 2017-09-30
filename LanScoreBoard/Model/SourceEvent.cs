using Newtonsoft.Json;

namespace LanScoreBoard.Model
{
    public class SourceEvent
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string SteamId { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
