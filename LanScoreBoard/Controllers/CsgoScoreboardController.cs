using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LanScoreBoard.Model;
using System.Linq;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanScoreBoard.Controllers
{
    [Route("api/[controller]")]
    public class CsgoScoreboardController : Controller
    {
        private const string _CollectionName = "CsgoEvents";

        // GET: api/values
        [HttpGet]
        public IEnumerable<CsgoScoreBoardEntry> Get()
        {           
            var litedb = LiteDb.Instance;

            var col = litedb.GetCollection<CsgoEvent>(_CollectionName);

            var entries = col.FindAll().Where(a=> a.Game.Equals("csgo", StringComparison.OrdinalIgnoreCase));

            var scoreBoard = entries.GroupBy(a => a.SteamId).Select(group => new
            {
                SteamId = group.Key,
                KillCount = group.Where(a => a.Event.Equals("player_death", StringComparison.OrdinalIgnoreCase) && !a.IsTeamkill).Count(),
                BotKillCount = group.Where(b => b.Event.Equals("player_death", StringComparison.OrdinalIgnoreCase) && !b.IsTeamkill && b.VictimSteamId == 0).Count(),
                PlayerKillCount = group.Where(b => b.Event.Equals("player_death", StringComparison.OrdinalIgnoreCase) && !b.IsTeamkill && b.VictimSteamId != 0).Count(),
                TeamKillCount = group.Where(b => b.Event.Equals("player_death", StringComparison.OrdinalIgnoreCase) && b.IsTeamkill).Count(),
                Deaths = group.Where(b => b.Event.Equals("player_death", StringComparison.OrdinalIgnoreCase) && b.VictimSteamId == group.Key).Count(),
                Names = string.Join(",", group.OrderByDescending(a=> a.Timestamp).Select(a => a.Name).Distinct()),
                Mvp = group.Where(b => b.Event.Equals("round_mvp", StringComparison.OrdinalIgnoreCase)).Count(),
                BombsPlanted = group.Where(b => b.Event.Equals("bomb_planted", StringComparison.OrdinalIgnoreCase)).Count(),
                BombsExploded = group.Where(b => b.Event.Equals("bomb_exploded", StringComparison.OrdinalIgnoreCase)).Count(),
                BombsDefused = group.Where(b => b.Event.Equals("bomb_defused", StringComparison.OrdinalIgnoreCase)).Count(),
            }).Select(a => new CsgoScoreBoardEntry()
            {
                Names = a.Names,
                Kills = a.KillCount,
                PlayerKills = a.PlayerKillCount,
                Teamkills = a.TeamKillCount,
                BotKills = a.BotKillCount,
                Deaths = a.Deaths,
                DefusedBombs = a.BombsDefused,
                ExplodedBombs = a.BombsExploded,
                PlantedBombs = a.BombsPlanted,
                MVPs = a.Mvp,
            }).OrderByDescending(a=> a.PlayerKills);

            return scoreBoard;
        }

        // POST api/values
        [HttpPost]
        public void PostCsgo([FromBody] CsgoEvent csgoEvent)
        {
            var litedb = LiteDb.Instance;
            var col = litedb.GetCollection<CsgoEvent>(_CollectionName);            
            col.Insert(csgoEvent);
        }
    }
}
