using Newtonsoft.Json;

namespace LanScoreBoard.Model
{
    public class Cod2Event : EventBase
    {

        [JsonProperty("addedScore")]
        public int AddedScore { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("adress")]
        public string Adress { get; set; }
    }
}
