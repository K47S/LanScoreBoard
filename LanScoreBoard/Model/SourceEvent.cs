using Newtonsoft.Json;

namespace LanScoreBoard.Model
{
    public class SourceEvent : EventBase
    {       
       

        [JsonProperty("steamId")]
        public int SteamId { get; set; }

        
    }
}
