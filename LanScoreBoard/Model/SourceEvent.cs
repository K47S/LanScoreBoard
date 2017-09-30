﻿using Newtonsoft.Json;

namespace LanScoreBoard.Model
{
    public class SourceEvent : EventBase
    {       
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("steamId")]
        public int SteamId { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
