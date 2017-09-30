using Newtonsoft.Json;

namespace LanScoreBoard.Model
{
    public class CsgoEvent : SourceEvent
    {

        [JsonProperty("isHeadshot")]
        public bool IsHeadshot { get; set; }

        [JsonProperty("isPenetrated")]
        public bool IsPenetrated { get; set; }

        [JsonProperty("isTeamkill")]
        public bool IsTeamkill { get; set; }

        [JsonProperty("assister")]
        public string Assister { get; set; }

        [JsonProperty("assisterSteamId")]
        public int AssisterSteamId { get; set; }

        [JsonProperty("victim")]
        public string Victim { get; set; }

        [JsonProperty("victimSteamId")]
        public int VictimSteamId { get; set; }

        [JsonProperty("weapon")]
        public string Weapon { get; set; }
    }
}
