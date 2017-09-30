using Newtonsoft.Json;

namespace LanScoreBoard.Model
{
    public class CsgoScoreBoardEntry
    {

        [JsonProperty("Names")]
        public string Names { get; set; }

        [JsonProperty("Kills")]
        public int Kills { get; set; }

        [JsonProperty("Kills_Players")]
        public int PlayerKills { get; set; }

        [JsonProperty("Kills_Bots")]
        public int BotKills { get; set; }

        [JsonProperty("Teamkills")]
        public int Teamkills { get; set; }

        [JsonProperty("Deaths")]
        public int Deaths { get; set; }

        [JsonProperty("Bombs_Planted")]
        public int PlantedBombs { get; set; }

        [JsonProperty("Bombs_Exploded")]
        public int ExplodedBombs { get; set; }

        [JsonProperty("Bombs_Defused")]
        public int DefusedBombs { get; set; }

        [JsonProperty("MVPs")]
        public string MVPs { get; set; }
    }
}
