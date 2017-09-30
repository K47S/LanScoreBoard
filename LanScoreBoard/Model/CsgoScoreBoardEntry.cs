using Newtonsoft.Json;

namespace LanScoreBoard.Model
{
    public class CsgoScoreBoardEntry
    {

        [JsonProperty("names")]
        public string Names { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("playerKills")]
        public int PlayerKills { get; set; }

        [JsonProperty("botKills")]
        public int BotKills { get; set; }

        [JsonProperty("teamkills")]
        public int Teamkills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("plantedBombs")]
        public int PlantedBombs { get; set; }

        [JsonProperty("explodedBombs")]
        public int ExplodedBombs { get; set; }

        [JsonProperty("defusedBombs")]
        public int DefusedBombs { get; set; }

        [JsonProperty("mvpCount")]
        public int MVPs { get; set; }
    }
}
