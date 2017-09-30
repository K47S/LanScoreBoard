using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LanScoreBoard.Model;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanScoreBoard.Controllers
{
    [Route("api/[controller]")]
    public class CsgoScoreboardController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<CsgoScoreBoardEntry> Get()
        {
            var csgoScoreBoard = new List<CsgoScoreBoardEntry>();

            var litedb = Database.Instance.LiteDatabase;

            var col = litedb.GetCollection<CsgoEvent>("CsgoEvents");

            var entries = col.FindAll();

            var killsperSteamId = entries.Where(a => a.Event.Equals("player_death") && !a.IsTeamkill).GroupBy(a => a.SteamId).Select(group => new
            {
                SteamId = group.Key,
               KillCount = group.Count()
            });

            var botkillsperSteamId = entries.Where(b => b.Event.Equals("player_death") && !b.IsTeamkill && b.VictimSteamId != 0).GroupBy(b => b.SteamId).Select(group => new
            {
                SteamId = group.Key,
                KillCount = group.Count()
            });

            var teamkillsperSteamId = entries.Where(c => c.Event.Equals("player_death") && c.IsTeamkill).GroupBy(c => c.SteamId).Select(group => new
            {
                SteamId = group.Key,
                KillCount = group.Count()
            });


            var names  = entries.Select(a=> new { a.Name, a.SteamId }).Distinct().GroupBy(a => a.SteamId).Select(group => new
            {
                SteamId = group.Key,
                Names = string.Join(",", group.Select(a=> a.Name))
            });


            return csgoScoreBoard;


        }

        // POST api/values
        [HttpPost]
        public void PostCsgo([FromBody] CsgoEvent csgoEvent)
        {
            var litedb = Database.Instance.LiteDatabase;

            var col = litedb.GetCollection<CsgoEvent>("CsgoEvents");

            // Insert new customer document (Id will be auto-incremented)
            col.Insert(csgoEvent);

        }
    }
}
