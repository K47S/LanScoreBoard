using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanScoreBoard.Model
{
    public class EventBase
    {
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
